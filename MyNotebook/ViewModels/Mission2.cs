using MyNotebook.Models;
using System;

namespace MyNotebook.ViewModels
{
    /// <summary>
    /// Единицы измерения информации. Бит Байт Килобайт Мегабайт Гигабайт
    /// </summary>
    [Serializable]
    public class Mission2 : MissionGenerator
    {
        public override int NumOfMission => 2;
        public override string MissionName => "Единицы измерения информации";
        public override int TimeToSolveMission => 120;
        public override int MaxNumInTest => 10;
        public override MissionType TypeOfMission => MissionType.Practice;

        string[] units = new string[]
        {
            "Бит",
            "Байт",
            "Килобайт",
            "Мегабайт",
            "Гигабайт"
        };

        public override MissionBase Generate()
        {
            var temp = GetRandomTwoUnits();
            string unit1 = temp[0];
            string unit2 = temp[1];
            //unit1 > unit2

            int num = rnd.Next(5, 20);

            int result = ConvertFromTo(num, unit1, unit2);

            MissionBase generated;
            if (rnd.Next(0, 2) == 0)
            {
                var Question = $"Перевидите {num} из {unit1} в {unit2}";
                var Answer = result.ToString();

                generated = new TextMission(2, "Единицы измерения информации", Question, Answer);
            }
            else
            {
                var Question = $"Перевидите {result} из {unit2} в {unit1}";
                var Answer = num.ToString();

                generated = new TextMission(2, "Единицы измерения информации", Question, Answer);
            }
            return generated;
        }

        private int ConvertFromTo(int num, string unit1, string unit2)
        {
            int numOfUnit1 = GetNumOfUnitInArray(unit1);
            int numOfUnit2 = GetNumOfUnitInArray(unit2);

            if (!(numOfUnit1 > numOfUnit2))
            {
                throw new ArgumentException();
            }
            // Бит Байт Килобайт Мегабайт Гигабайт
            if (numOfUnit2 == 0 && numOfUnit1 == 1)
            {
                //Байт -> бит
                return num * 8;
            }
            else if (numOfUnit2 == 1 && numOfUnit1 == 2)
            {
                //Килобайт -> байт
                return num * 1024;
            }
            else if (numOfUnit2 == 2 && numOfUnit1 == 3)
            {
                //Мегабайт -> Килобайт
                return num * 1024;
            }
            else if (numOfUnit2 == 3 && numOfUnit1 == 4)
            {
                //Гигабайт -> Мегабайт
                return num * 1024;
            }

            throw new Exception("Unknown exeption");
        }

        int GetNumOfUnitInArray(string unit)
        {
            for (int i = 0; i < units.Length; i++)
            {
                if (unit == units[i])
                {
                    return i;
                }
            }

            throw new ArgumentException($"No unit {unit} in array");
        }

        /// <summary>
        /// unit[0] > unit[1]
        /// </summary>
        /// <returns></returns>
        string[] GetRandomTwoUnits()
        {
            while (true)
            {
                int n1 = rnd.Next(0, 5);
                int n2 = rnd.Next(0, 5);

                if (n1 == n2)
                {
                    continue;
                }

                if (n1 < n2)
                {
                    (n1, n2) = (n2, n1);
                }

                if (n1 - n2 != 1)
                {
                    continue;
                }

                return new string[]
                {
                    units[n1],
                    units[n2]
                };
            }
        }
    }
}
