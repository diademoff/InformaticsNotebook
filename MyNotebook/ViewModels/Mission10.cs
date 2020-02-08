using MyNotebook.Models;
using System;

namespace MyNotebook.ViewModels
{
    [Serializable]
    public class Mission10 : MissionGenerator
    {
        public override MissionBase Generate()
        {
            TextMission result;
        regenerate:
            if (rnd.RandomBool())
            {
                result = Task1();
            }
            else
            {
                result = Task2();
            }
            if (double.Parse(result.Answer) != (int)double.Parse(result.Answer))
            {
                goto regenerate;
            }
            result.TypeOfMission = MissionType.Practice;
            return result;
        }

        private TextMission Task2()
        {

        genAgain:
            int b = rnd.Next(6, 9);  // bytes on one symbol

            int p = rnd.Next(5, 9);
            int l = rnd.Next(25, 41);
            int s = rnd.Next(40, 86);
            string q = $"Для записи текста использовался {Math.Pow(2, b)}-символьный алфавит.\n" +
                       $"Каждая страница содержит {l} строк по {s} символов в строке.\n" +
                       $"Какой объем информации содержат {p} страниц текста (в байтах)?";

            double a = (double)(p * l * s * b) / 8.0;

            if (a != (int)a)
            {
                goto genAgain;
            }

            TextMission result = new TextMission(10, "Посчитать информационный вес текста", q, ((int)a).ToString())
            {
                Tooltip = "Подсчет веса текста"
            };
            return result;
        }

        private TextMission Task1()
        {
            int p = rnd.Next(5, 9);
            int l = rnd.Next(25, 41);
            int s = rnd.Next(40, 86);
            string q = $"Созданный на компьютере текст занимает {p} полных страниц.\n" +
                       $"На каждой странице размещается {l} строк по {s} символов в строке.\n" +
                       $"Какой объем оперативной памяти (в байтах) займет этот текст?";
            string a = $"{p * l * s}";
            TextMission result = new TextMission(10, "Посчитать информационный вес текста", q, a)
            {
                Tooltip = "Подсчет веса текста"
            };
            return result;
        }
    }
}
