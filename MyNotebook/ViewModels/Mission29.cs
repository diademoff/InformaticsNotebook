using MyNotebook.Models;
using System;

namespace MyNotebook.ViewModels
{
    [Serializable]
    public class Mission29 : MissionGenerator
    {
        public override string MissionName => "Количество ячеек в диапазоне";

        public override int NumOfMission => 29;

        public override int TimeToSolveMission => 45;

        public override int MaxNumInTest => 10;

        public override MissionType TypeOfMission => MissionType.Theory;

        string alph = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public override MissionBase Generate()
        {
            // Сколько ячеек электронной таблицы содержит диапазон B4:F12?

            int x1 = rnd.Next(1, 10);
            int y1 = rnd.Next(1, 10);

            int x2 = x1 + rnd.Next(1, 7);
            int y2 = y1 + rnd.Next(1, 7);

            string point1 = $"{alph[x1 - 1]}{y1}";
            string point2 = $"{alph[x2 - 1]}{y2}";

            int width = x2 - x1 + 1;
            int height = y2 - y1 + 1;

            int answer = width * height;
            string q = $"Сколько ячеек электронной таблицы содержит диапазон {point1}:{point2}?";

            return new TextMission(NumOfMission, MissionName, q, answer.ToString());
        }
    }
}
