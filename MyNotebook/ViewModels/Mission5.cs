using MyNotebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyNotebook.ViewModels
{
    [Serializable]
    public class Mission5 : MissionGenerator
    {
        public override MissionBase Generate()
        {
            List<MatchElement> matchElements = new List<MatchElement>();
            matchElements.Add(new MatchElement("CPU", new[] { "Процессор" }));
            matchElements.Add(new MatchElement("RAM", new[] { "Оперативная память" }));
            matchElements.Add(new MatchElement("ROM", new[] { "Постоянная память" }));
            matchElements.Add(new MatchElement("HDD", new[] { "Жесткий диск" }));
            matchElements.Add(new MatchElement("SOUND CARD", new[] { "Звуковая карта" }));
            matchElements.Add(new MatchElement("VIDEO CARD", new[] { "Видеокарта" }));

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
            var generated = new MatchMission(5, "Компьютерные комплектующие на английском", terms, defs, answer);
            generated.Tooltip = $"Термины: {string.Join(", ", matchElements)}";
            generated.TimeNeedToSolveMissionSeconds = 60;
            return generated;
        }
    }
}
