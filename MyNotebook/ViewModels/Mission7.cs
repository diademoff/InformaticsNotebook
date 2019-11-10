using MyNotebook.Models;
using System;


namespace MyNotebook.ViewModels
{
    [Serializable]
    public class Mission7 : MissionGenerator
    {
        public override MissionBase Generate()
        {
            string question, answer;
            int pow = rnd.Next(3, 13);
            question = $"Напишите {pow}-ую степень двойки";
            answer = Math.Pow(2, pow).ToString();

            MissionBase mb = new TextMission(7, "Степени двойки", question, answer);
            mb.Tooltip = "Степень от 3 до 12";
            mb.MaxNumInTest = 9;
            return mb;
        }
    }
}
