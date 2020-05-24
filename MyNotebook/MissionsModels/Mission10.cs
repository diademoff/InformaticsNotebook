using MyNotebook.Models;
using System;

namespace MyNotebook.MissionsModels
{
    [Serializable]
    public class Mission10 : MissionGenerator
    {
        public override int NumOfMission => 10;
        public override string MissionName => "Посчитать информационный вес текста";
        public override int TimeToSolveMission => 150;
        public override int MaxNumInTest => 10;
        public override MissionType TypeOfMission => MissionType.Practice;
        public override string Tooltip => "Подсчет веса текста";

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

            TextMission result = new TextMission(NumOfMission, MissionName, q, ((int)a).ToString());
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
            TextMission result = new TextMission(NumOfMission, MissionName, q, a);
            return result;
        }
    }
}
