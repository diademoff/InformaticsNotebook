using MyNotebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotebook.ViewModels
{
    [Serializable]
    public class Mission12 : MissionGenerator
    {
        public override MissionBase Generate()
        {
            List<MatchElement> matchElements = new List<MatchElement>();
            matchElements.Add(new MatchElement("Оперативная память", new[] { "ddr2", "ddr3" }));
            matchElements.Add(new MatchElement("Архиватор", new[] { "zip", "7z" }));
            matchElements.Add(new MatchElement("Антивирусная программа", new[] { "DrWeb", "Antivirus Kasperski", "Avast" }));
            matchElements.Add(new MatchElement("Коммуникационная программа", new[] { "Skype", "Discord" }));
            matchElements.Add(new MatchElement("Интегрированная среда разработки", new[] { "Visual Studio", "IntelliJ IDEA", "PyCharm" }));
            matchElements.Add(new MatchElement("Текстовый редактор", new[] { "WordPad", " MS Word" }));
            matchElements.Add(new MatchElement("Графический редактор", new[] { "Paint", "Photoshop" }));
            matchElements.Add(new MatchElement("Электронные таблицы", new[] { "MS Excel" }));
            matchElements.Add(new MatchElement("Электронное учебное издание", new[] { "Wikipedia" }));

            var res = new MatchMission(12, "Программное обеспечение", matchElements.ToArray());
            res.Tooltip = $"Пример: {string.Join(", ", res.Terms)}";

            return res;
        }
    }
}
