using MyNotebook.MissionsModels;
using MyNotebook.Models;
using System;
using System.Linq;

namespace MyNotebook.MissionsModels
{
    [Serializable]
    public class Mission18 : MissionGenerator
    {
        public override int NumOfMission => 18;
        public override string MissionName => "Составление адреса URL из частей";
        public override int TimeToSolveMission => 60;
        public override int MaxNumInTest => 10;
        public override MissionType TypeOfMission => MissionType.Practice;

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
            string[] part1 = MissionsModels.Extentions.URLGenerator.part1;
            string[] part2 = MissionsModels.Extentions.URLGenerator.part2;
            string[] part3 = MissionsModels.Extentions.URLGenerator.part3;
            string[] part4 = MissionsModels.Extentions.URLGenerator.part4;
            string[] part5 = MissionsModels.Extentions.URLGenerator.part5;
            string[] part6 = MissionsModels.Extentions.URLGenerator.part6;
            string[] part7 = MissionsModels.Extentions.URLGenerator.part7;

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
            return new TextMission(NumOfMission, MissionName, q, string.Join("", answer));
        }
    }
}
