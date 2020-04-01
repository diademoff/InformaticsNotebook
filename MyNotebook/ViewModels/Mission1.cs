using MyNotebook.Models;
using System;

namespace MyNotebook.ViewModels
{
    /// <summary>
    /// Перевод между 10-ой и 2-ой сс
    /// </summary>
    [Serializable]
    public class Mission1 : MissionGenerator
    {
        public override int NumOfMission => 1;
        public override string MissionName => "Перевод между 10-ой и 2-ой сс";
        public override int TimeToSolveMission => 130;
        public override int MaxNumInTest => 10;
        public override MissionType TypeOfMission => MissionType.Theory;
        public override string Tooltip => "Интервал чисел: от 50 до 200";

        public override MissionBase Generate()
        {
            MissionBase result;
            if (rnd.Next(0, 2) == 0)
            {
                result = Generate2to10();
            }
            else
            {
                result = Generate10to2();
            }
            return result;
        }

        /// <summary>
        /// Генерация задачи перевода из 10-ой в 2-ую
        /// </summary>
        MissionBase Generate10to2()
        {
            int num = rnd.Next(50, 200);
            var Question = $"Переведите число {num} из 10-ой с.с в 2-ую";
            var Answer = Convert.ToString(num, 2);

            return new TextMission(NumOfMission, MissionName, Question, Answer);
        }

        /// <summary>
        /// Генерация задачи перевода из 2-й в 10-ую
        /// </summary>
        MissionBase Generate2to10()
        {
            int num = rnd.Next(50, 200);
            var Question = $"Переведите число {Convert.ToString(num, 2)} из 2-ой с.с в 10-ую";
            var Answer = num.ToString();

            return new TextMission(NumOfMission, MissionName, Question, Answer);
        }
    }
}
