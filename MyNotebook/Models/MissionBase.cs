using System;

namespace MyNotebook.Models
{
    public enum MissionType
    {
        Text,
        Match, // сопоставить
        Select
    }
    [Serializable]
    public class MissionBase //task
    {
        #region general
        protected Random rnd = new Random();

        public MissionType MissionType;
        public string Title { get; set; }
        public int NumOfMission { get; private set; }
        public bool IsSolved
        {
            get
            {
                switch (MissionType)
                {
                    case MissionType.Text:
                        return TextIsSolvedRight;
                    case MissionType.Match:
                        return MatchIsSolvedRight;
                }
                return false;
            }

        }
        public string Note { get; set; }
        public DateTime TimeMissionSolved { get; set; }

        public override string ToString()
        {
            return $"{NumOfMission}. {Title}";
        }
        #endregion

        #region text mission
        private string question;
        public string Question
        {
            get
            {
                CheckTextMission();
                return question;
            }
            private set
            {
                CheckTextMission();
                question = value;
            }
        }

        private string textAnswer;
        public string TextAnswer
        {
            get
            {
                CheckTextMission();
                return textAnswer;
            }
            private set
            {
                CheckTextMission();
                textAnswer = value;
            }
        }

        public string TextAnswerGiven;
        public bool TextIsSolvedRight => (TextAnswerGiven == TextAnswer);

        private void CheckTextMission()
        {
            if (MissionType != MissionType.Text)
            {
                throw new Exception("this mission is not text");
            }
        }

        public void FinishTextMission(string answer)
        {
            TextAnswerGiven = answer;
            TimeMissionSolved = DateTime.Now;
        }

        /// <summary>
        /// Constructor for Text mission
        /// </summary>
        /// <param name="numOfMission"> number of mission in order </param>
        /// <param name="question"> formulated question </param>
        /// <param name="answer"> expected answer </param>
        public MissionBase(int numOfMission, string title, string question, string answer)
        {
            this.MissionType = MissionType.Text;

            this.Title = title;
            NumOfMission = numOfMission;
            Question = question;
            TextAnswer = answer;
        }

        #endregion

        #region match mission
        private string[] terms;
        public string[] Terms
        {
            get
            {
                CheckMatchMission();
                return terms;
            }
            private set
            {
                CheckMatchMission();
                terms = value;
            }
        }

        private string[] definitions;
        public string[] Definitions
        {
            get
            {
                CheckMatchMission();
                return definitions;
            }
            private set
            {
                CheckMatchMission();
                definitions = value;
            }
        }

        private int[] mathAnswer;
        public int[] MatchAnswer
        {
            get
            {
                CheckMatchMission();
                return mathAnswer;
            }
            private set
            {
                CheckMatchMission();
                mathAnswer = value;
            }
        }

        public int[] MatchAnswerGiven;
        public bool MatchIsSolvedRight
        {
            get
            {
                if (MatchAnswerGiven == null)
                {
                    return false;
                }
                if (MatchAnswerGiven.Length != MatchAnswer.Length)
                {
                    return false;
                }
                for (int i = 0; i < MatchAnswer.Length; i++)
                {
                    if (MatchAnswer[i] != MatchAnswerGiven[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        private void CheckMatchMission()
        {
            if (MissionType != MissionType.Match)
            {
                throw new Exception("this mission is not match");
            }
        }

        public void FinishMatchMission(int[] answer)
        {
            MatchAnswerGiven = answer;
            TimeMissionSolved = DateTime.Now;
        }

        /// <summary>
        /// Constructor for match mission
        /// </summary>
        /// <param name="numOfMission"> number of mission in order </param>
        /// <param name="terms"> terms in this mission </param>
        /// <param name="defenitions"> defenition for each term </param>
        /// <param name="answer"></param>
        public MissionBase(int numOfMission, string title, string[] terms, string[] defenitions, int[] answer)
        {
            if (defenitions.Length != terms.Length)
            {
                throw new ArgumentException($"{nameof(terms)} length != {nameof(defenitions)} length");
            }

            this.MissionType = MissionType.Match;

            this.Title = title;
            NumOfMission = numOfMission;
            Terms = terms;
            Definitions = defenitions;
            MatchAnswer = answer;
        }
        #endregion

        #region select mission
        private string select_tasktext;
        public string Select_Tasktext
        {
            get
            {
                CheckSelectMission();
                return select_tasktext;
            }
            private set
            {
                CheckSelectMission();
                select_tasktext = value;
            }
        }

        private string[] select_answers;
        public string[] Select_Answers
        {
            get
            {
                CheckSelectMission();
                return select_answers;
            }
            private set
            {
                CheckSelectMission();
                select_answers = value;
            }
        }

        private int[] select_Answer;
        public int[] Select_Answer
        {
            get
            {
                CheckSelectMission();
                return select_Answer;
            }
            private set
            {
                CheckSelectMission();
                select_Answer = value;
            }
        }

        public int[] SelectAnswerGiven;
        public bool SelectIsSolvedRight
        {
            get
            {
                if (SelectAnswerGiven == null)
                {
                    return false;
                }
                if (SelectAnswerGiven.Length != Select_Answer.Length)
                {
                    return false;
                }
                for (int i = 0; i < Select_Answer.Length; i++)
                {
                    if (Select_Answer[i] != SelectAnswerGiven[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        private void CheckSelectMission()
        {
            if (MissionType != MissionType.Select)
            {
                throw new Exception("this mission is not select");
            }
        }

        public void FinishSelectMission(int[] answer)
        {
            SelectAnswerGiven = answer;
            TimeMissionSolved = DateTime.Now;
        }

        /// <summary>
        /// Select mission
        /// </summary>
        /// <param name="numOfMission"></param>
        /// <param name="tasktext"></param>
        /// <param name="answers"></param>
        /// <param name="answerExpected"></param>
        public MissionBase(int numOfMission, string tasktext, string[] answers, int[] answerExpected)
        {
            MissionType = MissionType.Select;
            NumOfMission = numOfMission;
            Select_Tasktext = tasktext;
            Select_Answers = answers;
            Select_Answer = answerExpected;
        }
        #endregion
    }
}
