﻿using MyNotebook.Models;
using System;

namespace MyNotebook.MissionsModels
{
    [Serializable]
    class Mission26 : MissionGenerator
    {
        public override string MissionName => "Цикл на Pascal";

        public override int NumOfMission => 26;

        public override int TimeToSolveMission => 180;

        public override int MaxNumInTest => 10;

        public override MissionType TypeOfMission => MissionType.Practice;

        public override MissionBase Generate()
        {
            int input = rnd.Next(5, 11);
            bool plus = rnd.RandomBool(); // if true -> "+". if false -> "-"
            string s_plus = plus ? "+" : "-";
            int firstValue = rnd.Next(5, 15);

            int answer = GetAnswer(input, plus, firstValue);

            switch (rnd.Next(1, 3))
            {
                case 1:
                    string q = $"Какой результат выдаст программа при входном значении {input}?\n" +
                               $"var N, S : integer;\n" +
                               $"begin\n" +
                               $"readln(N);\n" +
                               $"S:={firstValue};\n" +
                               $"while N > 0 do\n" +
                               $"begin\n" +
                               $"    S := S {s_plus} (N mod 10);\n" +
                               $"    N := N div 10;\n" +
                               $"end;\n" +
                               $"WriteLn(S);\n" +
                               $"end.";

                    return new TextMission(26, MissionName, q, answer.ToString());
                case 2:
                    string qu = $"При каком входном значении программа выдаст результат {answer}?\n" +
                                $"var N, S : integer;\n" +
                                $"begin\n" +
                                $"readln(N);\n" +
                                $"S:={firstValue};\n" +
                                $"while N > 0 do\n" +
                                $"begin\n" +
                                $"    S := S {s_plus} (N mod 10);\n" +
                                $"    N := N div 10;\n" +
                                $"end;\n" +
                                $"WriteLn(S);\n" +
                                $"end.";

                    return new TextMission(26, MissionName, qu, input.ToString());
                default:
                    throw new Exception("miss 26 ex");
            }
        }

        private int GetAnswer(int input, bool plus, int firstValue)
        {
            int s = firstValue;
            while (input > 0)
            {
                if (plus)
                {
                    s = s + (input % 10);
                }
                else
                {
                    s = s - (input % 10);
                }
                input = input / 10;
            }
            return s;
        }
    }
}
