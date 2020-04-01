using MyNotebook.Models;
using System;


namespace MyNotebook.ViewModels
{
    [Serializable]
    public class Mission7 : MissionGenerator
    {
        public override int NumOfMission => 7;
        public override string MissionName => "Степени двойки";
        public override int TimeToSolveMission => 35;
        public override int MaxNumInTest => 9;
        public override MissionType TypeOfMission => MissionType.Theory;
        public override string Tooltip => "Степень от 3 до 12";

        public override MissionBase Generate()
        {
            string question, answer;
            int pow = rnd.Next(3, 13);
            question = $"Напишите {pow}-ую степень двойки";
            answer = Math.Pow(2, pow).ToString();

            MissionBase mb = new TextMission(NumOfMission, MissionName, question, answer);
            return mb;
        }
    }
}
