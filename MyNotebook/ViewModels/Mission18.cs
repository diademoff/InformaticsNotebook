using MyNotebook.Models;
using System;
using System.Linq;

namespace MyNotebook.ViewModels
{
    [Serializable]
    public class Mission18 : MissionGenerator
    {
        struct Gen
        {
            public int NumOfPart { get; set; }
            public string PartItem { get; set; }

            public Gen(int numOfPart, string[] partItems)
            {
                NumOfPart = numOfPart;
                PartItem = partItems.RandomElement() ?? throw new ArgumentNullException(nameof(partItems));
            }
        }
        public override MissionBase Generate()
        {
            string[] part1 = new[]
            {
                "https",
                "http",
                "ftp"
            };
            string[] part2 = new[]
            {
                "://"
            };
            string[] part3 = new[]
            {
                "exams",
                "page",
                "home"
            };
            string[] part4 = new[]
            {
                ".ru",
                ".org",
                ".info"
            };
            string[] part5 = new[]
            {
                "/"
            };
            string[] part6 = new[]
            {
                "student",
                "data",
                "table",
                "biology",
                "biology",
                "literature"
            };
            string[] part7 = new[]
            {
                ".rar",
                ".html",
                ".htm",
                ".xls",
                ".jpg"
            };

            string[][] parts = new[]
            {
                part1,
                part2,
                part3,
                part4,
                part5,
                part6,
                part7
            };

            Gen[] gens = new Gen[7];
            for (int i = 1; i <= 7; i++)
            {
                gens[i - 1] = new Gen(i, parts[i - 1]);
            }
            string fileName = gens[5].PartItem + gens[6].PartItem;
            gens = gens.OrderBy(x => rnd.Next()).ToArray();

            int[] answer = new int[7];
            string q = "";
            for (int i = 0; i < gens.Length; i++)
            {
                answer[gens[i].NumOfPart - 1] = i + 1;
                q += $"{i + 1}. {gens[i].PartItem}\n";
            }
            q = $"В таблице фрагменты адреса файла закодированы числами от 1 до 7. \n" +
                $"Запишите последовательность чисел\n" +
                $"кодирующую адрес файла \"{fileName}\" в сети Интернет.\n" + q;
            return new TextMission(18, "Составление адреса URL из частей", q, string.Join("", answer))
            {
                TimeNeedToSolveMissionSeconds = 60,
                TypeOfMission = MissionType.Practice
            };
        }
    }
}
