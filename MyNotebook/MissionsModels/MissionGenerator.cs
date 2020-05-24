using System;

namespace MyNotebook.Models
{
    [Serializable]
    public abstract class MissionGenerator
    {
        public Random rnd = new Random();
        public abstract string MissionName { get; }
        public abstract int NumOfMission { get; }
        public abstract int TimeToSolveMission { get; }
        public abstract int MaxNumInTest { get; }
        public abstract MissionType TypeOfMission { get; }
        public virtual string Tooltip { get; }
        public abstract MissionBase Generate();
    }
}
