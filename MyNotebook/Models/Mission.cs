using System;

namespace MyNotebook.Models
{
    [Serializable]
    public abstract class Mission //task
    {
        protected Random rnd = new Random();

        public int NumOfMission { get; protected set; }
        public string Question { get; protected set; }
        public string Answer { get; protected set; }
        public DateTime Solved { get; set; }
        public string AnswerGiven { get; set; }

        public bool IsSolvedRight => Answer == AnswerGiven;

        public abstract Mission Generate();
    }
}
