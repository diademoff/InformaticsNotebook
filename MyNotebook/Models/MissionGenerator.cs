using System;

namespace MyNotebook.Models
{
    [Serializable]
    public abstract class MissionGenerator
    {
        public Random rnd = new Random();
        public abstract MissionBase Generate();
    }
}
