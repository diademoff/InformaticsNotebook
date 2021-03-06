﻿using MyNotebook.Models;
using System;
using System.Linq;

namespace MyNotebook.MissionsModels
{
    [Serializable]
    public class Mission11 : MissionGenerator
    {
        public override int NumOfMission => 11;
        public override string MissionName => "Исполнитель Квадратор";
        public override int TimeToSolveMission => 330;
        public override int MaxNumInTest => 10;
        public override MissionType TypeOfMission => MissionType.Practice;
        public override string Tooltip => "Указать последовательность комманд для исполнителя Квадратор";

        public override MissionBase Generate()
        {
            while (true)
            {
                string question = "У исполнителя Квадратор две команды, которым присвоены номера:\n";

                int command1 = rnd.Next(-2, 5);
                if (command1 == 0)
                {
                    continue;
                }

                question += command1 > 0 ? $"1. Прибавь {command1}\n" : $"1. Отними {Math.Abs(command1)}\n";

                double command2 = rnd.Next(2, 5);
                if (rnd.RandomBool())
                {
                    question += $"2. Раздели на {command2}\n";
                    command2 = 1 / command2;
                }
                else
                {
                    question += $"2. Умножить на {command2}\n";
                }

                for (int i = 0; i < 100; i++)
                {
                    int beginNum = rnd.Next(2, 120);
                    double result = beginNum;
                    string answer = "";
                    for (int j = 0; j < 5; j++)
                    {
                        if (rnd.RandomBool())
                        {
                            result += command1;
                            answer += "1";
                        }
                        else
                        {
                            result *= command2;
                            answer += "2";
                        }
                    }
                    if (result != (int)result || result == beginNum || answer.Distinct().Count() == 1  // целое число. искл ответ вида: 22222
                        || result > 500)
                    {
                        continue;
                    }

                    BeginNum = beginNum;
                    Result = (int)result;
                    c1 = command1;
                    c2 = command2;

                    question += $"Запишите порядок команд в программе,\n" +
                                $"которая преобразует число {beginNum} в число {result}.\n" +
                                $"Указывайте лишь номера пяти команд.";
                    var mission = new TextMission(NumOfMission, MissionName, question, answer, IsSolvedRight);
                    return mission;
                }
            }
        }
        double c1, c2;
        int BeginNum;
        int Result;
        bool IsSolvedRight(string answerGiven)
        {

            if (answerGiven == null)
            {
                return false;
            }

            answerGiven = answerGiven.Trim();

            double n = BeginNum;
            foreach (var num in answerGiven)
            {
                try
                {
                    int temp = Convert.ToInt32(num.ToString());
                    switch (Convert.ToInt32(num.ToString()))
                    {
                        case 1:
                            n += c1;
                            break;
                        case 2:
                            n *= c2;
                            break;
                        default:
                            throw new Exception("Unknown command. Mission 11");
                    }
                }
                catch { return false; }
            }
            return (int)n == Result;
        }
    }
}
