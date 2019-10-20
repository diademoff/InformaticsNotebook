using System;

namespace MyNotebook.Models
{
    [Serializable]
    public class SelectMission : MissionBase
    {
        public string Tasktext { get; private set; }
        public string[] Variants { get; private set; }
        public int[] AnswerExpected { get; private set; }

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
            if (AnswerGiven.Length != AnswerExpected.Length)
            {
                return false;
            }
            for (int i = 0; i < AnswerExpected.Length; i++)
            {
                if (AnswerExpected[i] != AnswerGiven[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override bool IsAnswerGiven()
        {
            return AnswerGiven?.Length > 0;
        }

        /// <summary>
        /// Select mission
        /// </summary>
        /// <param name="numOfMission"></param>
        /// <param name="tasktext"></param>
        /// <param name="answers"></param>
        /// <param name="answerExpected"></param>
        public SelectMission(int numOfMission, string tasktext, string[] answers, int[] answerExpected)
        {
            NumOfMission = numOfMission;
            Tasktext = tasktext;
            Title = Tasktext;
            Variants = answers;
            AnswerExpected = answerExpected;
        }
    }
}
