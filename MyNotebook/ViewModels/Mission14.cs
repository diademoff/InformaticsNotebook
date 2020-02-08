using MyNotebook.Models;
using System;

namespace MyNotebook.ViewModels
{
    [Serializable]
    public class Mission14 : MissionGenerator
    {
        public override MissionBase Generate()
        {
            new TextMission(numOfMission: 14, title: "", question: "", answer: "");
            var t = rnd.RandomBool() ? "наименьшее" : "наибольшее";
            var q = "Среди приведённых ниже трёх чисел, записанных в шестнадцатеричной, восьмеричной, двоичной\n" +
                   $"системах счисления, найдите {t} и запишите его в ответе в десятичной\n" +
                    "системе счисления. В ответе запишите только число, основание системы\n" +
                    "счисления указывать не нужно.\n";

            int a = rnd.Next(50, 200);
            int b = a + rnd.Next(-5, 6);
            int c = a + rnd.Next(-5, 6);

            q += $"{Convert.ToString(a, 16)}, {Convert.ToString(b, 8)}, {Convert.ToString(c, 2)}";

            string answ;
            if (t == "наибольшее")
            {
                answ = Convert.ToString(Math.Max(Math.Max(a, b), c));
            }
            else
            {
                answ = Convert.ToString(Math.Min(Math.Min(a, b), c));
            }

            return new TextMission(14, "Среди трёх чисел найти наименьшее/наибольшее", q, answ)
            {
                TimeNeedToSolveMissionSeconds = 60,
                TypeOfMission = MissionType.Theory
            };
        }
    }
}
