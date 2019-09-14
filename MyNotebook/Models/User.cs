using MyNotebook.Models;
using System;
using System.Collections.Generic;

namespace MyNotebook
{
    public class User
    {
        public string Name { get; private set; }
        public string Class { get; private set; }
        public List<Mission> MissionsDone { get; set; } = new List<Mission>();

        public User()
        {
        }

        public User(string name, string @class)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Class = @class ?? throw new ArgumentNullException(nameof(@class));
        }

        public override string ToString()
        {
            return $"{Name} - {Class}";
        }
    }
}
