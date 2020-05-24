using MyNotebook.Models;
using System;

namespace MyNotebook.MissionsModels
{
    /// <summary>
    /// Линейный алгоритм, записанный на алгоритмическом языке
    /// </summary>
    [Serializable]
    public class Mission3 : MissionGenerator
    {
        public override int NumOfMission => 3;
        public override string MissionName => "Линейный алгоритм";
        public override int TimeToSolveMission => 120;
        public override int MaxNumInTest => 10;
        public override MissionType TypeOfMission => MissionType.Practice;
        public override MissionBase Generate()
        {
            var Question = "В программе «:=» обозначает оператор присваивания, знаки «+», «-», «*» и «/» —\n\r" +
                       "соответственно операции сложения, вычитания, умножения и деления.\n\r" +
                       "Правила выполнения операций и порядок действий соответствуют правилам арифметики.\n\r";

            int x = rnd.Next(0, 17);
            int y = rnd.Next(2, 30);

            //line 1 - 2
            string task = $"a := {x}\n\r" +
                          $"b := {y}\n\r";

            //line 3
            int x1;
            if (x % 2 == 0)
            {
                if (rnd.RandomBool())
                {
                    task += $"a := a/2*b\n\r";
                    x1 = x / 2 * y;
                }
                else
                {
                    task += $"a := b+a/2\n\r";
                    x1 = y + x / 2;
                }
            }
            else
            {
                if (rnd.RandomBool())
                {
                    task += $"a := a*2+b\n\r";
                    x1 = x * 2 + y;
                }
                else
                {
                    task += $"a := a*2+3*b\n\r";
                    x1 = x * 2 + 3 * y;
                }
            }

            //line 4
            int y1;
            if (x1 % 3 == 0)
            {
                if (rnd.RandomBool())
                {
                    task += $"b := a/3-b\n\r";
                    y1 = x1 / 3 - y;
                }
                else
                {
                    task += $"b := a/3+b\n\r";
                    y1 = x1 / 3 + y;
                }
            }
            else
            {
                if (rnd.RandomBool())
                {
                    int randomNum = rnd.Next(30, 100);
                    task += $"b := {randomNum}-a\n\r";
                    y1 = randomNum - x1;
                }
                else
                {
                    if (rnd.RandomBool())
                    {
                        int randomNum = rnd.Next(30, 100);
                        task += $"b := {randomNum}-a-b\n\r";
                        y1 = randomNum - x1 - y;
                    }
                    else
                    {
                        int randomNum = rnd.Next(30, 100);
                        task += $"b := {randomNum}-a+b\n\r";
                        y1 = randomNum - x1 + y;
                    }
                }
            }

            //add all generated lines
            Question += task;

            MissionBase generated;
            //create answer
            if (rnd.RandomBool())
            {
                Question += "В ответе укажите одно целое число — значение переменной a.";
                var Answer = x1.ToString();

                generated = new TextMission(NumOfMission, MissionName, Question, Answer);
            }
            else
            {
                Question += "В ответе укажите одно целое число — значение переменной b.";
                var Answer = y1.ToString();

                generated = new TextMission(NumOfMission, MissionName, Question, Answer);
            }
            return generated;
        }
    }
}
