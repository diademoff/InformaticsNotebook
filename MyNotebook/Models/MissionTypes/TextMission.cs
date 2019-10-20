using System;

namespace MyNotebook.Models
{
    [Serializable]
    public class TextMission : MissionBase
    {
        public string Question { get; private set; }
        public string Answer { get; private set; }
        public override string String_AnswerGiven => AnswerGiven;

        public string AnswerGiven;
        public override bool IsSolvedRight() => AnswerGiven == Answer;

        public void FinishMission(string answer)
        {
            AnswerGiven = answer;
            TimeMissionSolved = DateTime.Now;
        }

        public override bool IsAnswerGiven()
        {
            return !string.IsNullOrEmpty(AnswerGiven);
        }

        /// <summary>
        /// Constructor for Text mission
        /// </summary>
        /// <param name="numOfMission"> number of mission in order </param>
        /// <param name="question"> formulated question </param>
        /// <param name="answer"> expected answer </param>
        public TextMission(int numOfMission, string title, string question, string answer)
        {
            this.Title = title;
            NumOfMission = numOfMission;
            Question = question;
            Answer = answer;
        }
    }
}
