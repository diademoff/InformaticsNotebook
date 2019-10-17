using MyNotebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotebook.ViewModels
{
    public class Mission8 : MissionGenerator
    {
        public override MissionBase Generate()
        {
            List<MatchElement> matchElements = new List<MatchElement>();
            matchElements.Add(new MatchElement("exe", new[] { "Программы" }));
            matchElements.Add(new MatchElement("doc", new[] { "Документы" }));
            matchElements.Add(new MatchElement("xls", new[] { "Таблицы" }));
            matchElements.Add(new MatchElement("txt", new[] { "Текстовые документы" }));
            matchElements.Add(new MatchElement("ppt", new[] { "Презентации" }));
            matchElements.Add(new MatchElement("html", new[] { "Страницы из Интернета" }));
            matchElements.Add(new MatchElement("jpg", new[] { "Рисунок, фотография" }));
            matchElements.Add(new MatchElement("mp3", new[] { "Музыка" }));
            matchElements.Add(new MatchElement("avi", new[] { "Видео" }));
            matchElements.Add(new MatchElement("rar", new[] { "Архив" }));

            List<MatchElement> matchElementsInResult = new List<MatchElement>();
            for (int i = 0; i < matchElements.Count;)
            {
                var elToAdd = matchElements[rnd.Next(0, matchElements.Count)];
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
                var currentElement = matchElementsInResult[i];

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
            var generated = new MissionBase(5, "Типы (расширения) файлов", terms, defs, answer);
            generated.Note = $"Расширения: {string.Join(", ", matchElements)}";
            return generated;
        }
    }
}
