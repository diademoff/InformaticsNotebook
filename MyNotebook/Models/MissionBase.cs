using System;

namespace MyNotebook.Models
{
    [Serializable]
    public abstract class MissionBase //task
    {
        protected Random rnd = new Random();
        public string Title { get; set; }
        public string Note { get; set; }
        public int NumOfMission { get; set; }
        public DateTime TimeMissionSolved { get; set; }
        public abstract string String_AnswerGiven { get; }

        public abstract bool IsSolvedRight();
        public abstract bool IsAnswerGiven();

        public override string ToString()
        {
            return $"{NumOfMission}. {Title}";
        }
    }
}
