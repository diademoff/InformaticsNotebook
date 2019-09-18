using System;

namespace MyNotebook.Models
{
    public abstract class MissionGenerator
    {
        protected Random rnd = new Random();
        public abstract MissionBase Generate();
    }
}
