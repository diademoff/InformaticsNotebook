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
                        return Text_IsSolvedRight;
                    case MissionType.Match:
                        return Match_IsSolvedRight;
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
        private string text_question;
        public string Text_Question
        {
            get
            {
                Text_CheckMission();
                return text_question;
            }
            private set
            {
                Text_CheckMission();
                text_question = value;
            }
        }

        private string text_Answer;
        public string Text_Answer
        {
            get
            {
                Text_CheckMission();
                return text_Answer;
            }
            private set
            {
                Text_CheckMission();
                text_Answer = value;
            }
        }

        public string Text_AnswerGiven;
        public bool Text_IsSolvedRight => (Text_AnswerGiven == Text_Answer);

        private void Text_CheckMission()
        {
            if (MissionType != MissionType.Text)
            {
                throw new Exception("this mission is not text");
            }
        }

        public void Text_FinishMission(string answer)
        {
            Text_AnswerGiven = answer;
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
            Text_Question = question;
            Text_Answer = answer;
        }

        #endregion

        #region match mission
        private string[] match_terms;
        public string[] Match_Terms
        {
            get
            {
                Match_CheckMission();
                return match_terms;
            }
            private set
            {
                Match_CheckMission();
                match_terms = value;
            }
        }

        private string[] match_definitions;
        public string[] Match_Definitions
        {
            get
            {
                Match_CheckMission();
                return match_definitions;
            }
            private set
            {
                Match_CheckMission();
                match_definitions = value;
            }
        }

        private int[] math_Answer;
        public int[] Match_Answer
        {
            get
            {
                Match_CheckMission();
                return math_Answer;
            }
            private set
            {
                Match_CheckMission();
                math_Answer = value;
            }
        }

        public int[] Match_AnswerGiven;
        public bool Match_IsSolvedRight
        {
            get
            {
                if (Match_AnswerGiven == null)
                {
                    return false;
                }
                if (Match_AnswerGiven.Length != Match_Answer.Length)
                {
                    return false;
                }
                for (int i = 0; i < Match_Answer.Length; i++)
                {
                    if (Match_Answer[i] != Match_AnswerGiven[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        private void Match_CheckMission()
        {
            if (MissionType != MissionType.Match)
            {
                throw new Exception("this mission is not match");
            }
        }

        public void Match_FinishMission(int[] answer)
        {
            Match_AnswerGiven = answer;
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
            Match_Terms = terms;
            Match_Definitions = defenitions;
            Match_Answer = answer;
        }
        #endregion

        #region select mission
        private string select_tasktext;
        public string Select_Tasktext
        {
            get
            {
                Select_CheckMission();
                return select_tasktext;
            }
            private set
            {
                Select_CheckMission();
                select_tasktext = value;
            }
        }

        private string[] select_answers;
        public string[] Select_Answers
        {
            get
            {
                Select_CheckMission();
                return select_answers;
            }
            private set
            {
                Select_CheckMission();
                select_answers = value;
            }
        }

        private int[] select_Answer;
        public int[] Select_Answer
        {
            get
            {
                Select_CheckMission();
                return select_Answer;
            }
            private set
            {
                Select_CheckMission();
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
        private void Select_CheckMission()
        {
            if (MissionType != MissionType.Select)
            {
                throw new Exception("this mission is not select");
            }
        }

        public void Select_FinishMission(int[] answer)
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
