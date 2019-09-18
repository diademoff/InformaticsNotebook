using System;

namespace MyNotebook.Models
{
    public enum MissionType
    {
        Text,
        Match // сопоставить
    }
    [Serializable]
    public class MissionBase //task
    {
        protected Random rnd = new Random();

        public MissionType MissionType;
        public int NumOfMission { get; private set; }

        public DateTime TimeMissionSolved { get; set; }


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

        /// <summary>
        /// Constructor for Text mission
        /// </summary>
        /// <param name="numOfMission"> number of mission in order </param>
        /// <param name="question"> formulated question </param>
        /// <param name="answer"> expected answer </param>
        public MissionBase(int numOfMission, string question, string answer)
        {
            this.MissionType = MissionType.Text;

            NumOfMission = numOfMission;
            Question = question;
            TextAnswer = answer;
        }
        

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

        /// <summary>
        /// Constructor for match mission
        /// </summary>
        /// <param name="numOfMission"> number of mission in order </param>
        /// <param name="terms"> terms in this mission </param>
        /// <param name="defenitions"> defenition for each term </param>
        /// <param name="answer"></param>
        public MissionBase(int numOfMission, string[] terms, string[] defenitions, int[] answer)
        {
            if (defenitions.Length != terms.Length)
            {
                throw new ArgumentException($"{nameof(terms)} length != {nameof(defenitions)} length");
            }

            this.MissionType = MissionType.Match;

            NumOfMission = numOfMission;
            Terms = terms;
            Definitions = defenitions;
            MatchAnswer = answer;
        }

        public override string ToString()
        {
            return $"{NumOfMission}";
        }
    }
}
