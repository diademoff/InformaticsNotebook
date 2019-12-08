using MyNotebook.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

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

        public string GetHTMLPage()
        {
            string html = "";
            html += $"<h1>Отчет ученика: {ToString()}</h1>";
            foreach (var test in UserTests)
            {
                html += test.GetHTMLPage(this);
            }
            return html;
        }

        public void OpenHTMLPage()
        {
            for (int i = 0; ; i++)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) + $"\\{i}.html";
                if (!File.Exists(path))
                {
                    File.WriteAllText(path, GetHTMLPage());
                    Process.Start(path);
                    return;
                }
            }
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
