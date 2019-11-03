using MyNotebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyNotebook.ViewModels
{
    [Serializable]
    public class Mission8 : MissionGenerator
    {
        public override MissionBase Generate()
        {
            List<MatchElement> matchElements = new List<MatchElement>
            {
                new MatchElement("exe", new[] { "Программы" }),
                new MatchElement("doc", new[] { "Документы" }),
                new MatchElement("xls", new[] { "Таблицы" }),
                new MatchElement("txt", new[] { "Текстовые документы" }),
                new MatchElement("ppt", new[] { "Презентации" }),
                new MatchElement("html", new[] { "Страницы из Интернета" }),
                new MatchElement("jpg", new[] { "Рисунок, фотография" }),
                new MatchElement("mp3", new[] { "Музыка" }),
                new MatchElement("avi", new[] { "Видео" }),
                new MatchElement("rar", new[] { "Архив" })
            };

            List<MatchElement> matchElementsInResult = new List<MatchElement>();
            for (int i = 0; i < matchElements.Count;)
            {
                MatchElement elToAdd = matchElements[rnd.Next(0, matchElements.Count)];
                if (!matchElementsInResult.Contains(elToAdd))
                {
                    matchElementsInResult.Add(elToAdd);
                    i++;
                }
            }
            matchElementsInResult = matchElementsInResult.OrderBy(x => rnd.Next()).ToList(); //shuffle array
            string[] terms = new string[6];
            string[] defs = new string[6];
            int[] answer = new int[6];
            for (int i = 0; i < terms.Length; i++)
            {
                MatchElement currentElement = matchElementsInResult[i];

                terms[i] = currentElement.Term;
                defs[i] = currentElement.Definitions.ToList().OrderBy(x => rnd.Next()).ToArray()[0]; //random element
                int currAnswer = i;
                currAnswer++;
                answer[i] = currAnswer;
            }
            //shuffle defs and answer
            for (int i = 0; i < defs.Length; i++)
            {
                int index1 = rnd.Next(0, defs.Length), index2 = rnd.Next(0, defs.Length);

                (defs[index1], defs[index2]) = (defs[index2], defs[index1]);
                (answer[index1], answer[index2]) = (answer[index2], answer[index1]);
            }
            MissionBase generated = new MatchMission(8, "Типы (расширения) файлов", terms, defs, answer)
            {
                Tooltip = $"Расширения: {string.Join(", ", matchElements)}"
            };
            return generated;
        }
    }
}
