using System;
namespace MyNotebook.Models
{
    [Serializable]
    public class MatchMission : MissionBase
    {
        public string[] Terms { get; private set; }
        public string[] Definitions { get; private set; }

        public int[] Answer { get; private set; }
        public override string String_AnswerGiven
        {
            get
            {
                if (AnswerGiven == null)
                {
                    return "";
                }
                return string.Join("", AnswerGiven);
            }
        }

        public int[] AnswerGiven;

        public void FinishMission(int[] answer)
        {
            AnswerGiven = answer;
            TimeMissionSolved = DateTime.Now;
        }

        public override bool IsSolvedRight()
        {
            if (AnswerGiven == null)
            {
                return false;
            }
            if (AnswerGiven.Length != Answer.Length)
            {
                return false;
            }
            for (int i = 0; i < Answer.Length; i++)
            {
                if (Answer[i] != AnswerGiven[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override bool IsAnswerGiven()
        {
            return TimeMissionSolved >= DateTime.Now;
        }

        /// <summary>
        /// Constructor for match mission
        /// </summary>
        /// <param name="numOfMission"> number of mission in order </param>
        /// <param name="terms"> terms in this mission </param>
        /// <param name="defenitions"> defenition for each term </param>
        /// <param name="answer"></param>
        public MatchMission(int numOfMission, string title, string[] terms, string[] defenitions, int[] answer)
        {
            if (defenitions.Length != terms.Length)
            {
                throw new ArgumentException($"{nameof(terms)} length != {nameof(defenitions)} length");
            }

            this.Title = title;
            NumOfMission = numOfMission;
            Terms = terms;
            Definitions = defenitions;
            Answer = answer;
        }
    }
}
