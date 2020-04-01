using MyNotebook.Models;
using System;
using System.Linq;

namespace MyNotebook.ViewModels
{
    [Serializable]
    public class Mission23 : MissionGenerator
    {
        public override int NumOfMission => 23;
        public override string MissionName => "Запросы в поисковой системе";
        public override int TimeToSolveMission => 365;
        public override int MaxNumInTest => 10;
        public override MissionType TypeOfMission => MissionType.Theory;

        public override MissionBase Generate()
        {
            WordPair[] wordPairs = new WordPair[]
            {
                new WordPair("Розы", "Лилии"),
                new WordPair("Деревня", "Город"),
                new WordPair("Мальчики", "Девочки"),
                new WordPair("Фиалки", "Пионы"),
                new WordPair("Рубль", "Доллар"),
                new WordPair("Медведь", "Заяц"),
                new WordPair("Математика", "Алгебра"),
                new WordPair("Математика", "Геометрия"),
                new WordPair("Конфеты", "Печенье"),
                new WordPair("Молоко", "Чай"),
                new WordPair("Пицца", "Макароны"),
                new WordPair("Майонез", "Кетчуп")
            };

            var pair = wordPairs[rnd.Next(0, wordPairs.Length)];
            string q = $"Ниже приведены запросы и количество страниц, которые нашел поисковый\n" +
                       $"сервер по этим запросам в некотором сегменте Интернета:\n";

            int n1;
            int n3;
            int n2;

            do
            {
                n1 = rnd.Next(4000, 10000);
                n3 = rnd.Next(5000, 10000);
                n2 = rnd.Next(1000, 1000 + Math.Abs(n1 - n3));
            } while (n2 < n1 && n2 < n3);

            switch (rnd.Next(1, 2))
            {
                case 1:
                    q += $"{pair.Word1} and {pair.Word2}\t{n2}\n" +
                         $"{pair.Word1}\t{n1 + n2}\n" +
                         $"{pair.Word2}\t{n3 + n2}\n" +
                         $"Сколько страниц будет найдено по запросу\n" +
                         $"{pair.Word1} or {pair.Word2}";
                    FormatQ(ref q);
                    return new TextMission(23, "Запросы в поисковой системе", q, $"{n1 + n2 + n3}");
                case 2:
                    q += $"{pair.Word1} and {pair.Word2}\t{n2}\n" +
                         $"{pair.Word1}\t{n1 + n2}\n" +
                         $"{pair.Word2}\t{n3 + n2}\n" +
                         $"Сколько страниц будет найдено по запросу\n" +
                         $"{pair.Word1} and {pair.Word2}";
                    FormatQ(ref q);
                    return new TextMission(23, "Запросы в поисковой системе", q, $"{n2}");
                case 3:
                    q += $"{pair.Word1} and {pair.Word2}\t{n2}\n" +
                         $"{pair.Word1} or {pair.Word2}\t{n1 + n2 + n3}\n" +
                         $"{pair.Word1}\t{n1 + n2}\n" +
                         $"Сколько страниц будет найдено по запросу\n" +
                         $"{pair.Word2}";
                    FormatQ(ref q);
                    return new TextMission(23, "Запросы в поисковой системе", q, $"{n3 + n2}");
                default:
                    throw new Exception("mission 23 ex");
            }
        }

        void FormatQ(ref string q)
        {
            string[] lines = q.Split('\n').ToArray();
            int len = 35;
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i].Length > len)
                {
                    len = lines[i].Length;
                }
            }
            len += 4;

            for (int i = 0; i < lines.Length; i++)
            {
                if (!lines[i].Contains('\t'))
                {
                    continue;
                }
                int thisLen = lines[i].Split('\t')[0].Length;
                string newLine = lines[i].Replace("\t", new string(' ', len - thisLen));
                lines[i] = newLine;
            }
            q = string.Join("\n", lines);
        }
        [Serializable]
        struct WordPair
        {
            public string Word1 { get; set; }
            public string Word2 { get; set; }

            public WordPair(string word1, string word2)
            {
                Word1 = word1 ?? throw new ArgumentNullException(nameof(word1));
                Word2 = word2 ?? throw new ArgumentNullException(nameof(word2));
            }
        }
    }
}
