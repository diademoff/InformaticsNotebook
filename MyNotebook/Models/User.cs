using MyNotebook.Models;
using System;
using System.Collections.Generic;

namespace MyNotebook
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }
        public string Class { get; set; }
        public List<Test> UserTests { get; set; } = new List<Test>();

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
