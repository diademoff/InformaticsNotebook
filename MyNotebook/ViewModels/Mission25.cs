using MyNotebook.Models;
using System;

namespace MyNotebook.ViewModels
{
    [Serializable]
    class Mission25 : MissionGenerator
    {
        public override int NumOfMission => 25;
        public override string MissionName => "Поиск суммы/разницы";
        public override int TimeToSolveMission => 220;
        public override int MaxNumInTest => 10;
        public override MissionType TypeOfMission => MissionType.Theory;

        public override MissionBase Generate()
        {
            switch (rnd.Next(1, 3))
            {
                case 1:
                    // Берём степень двойки люубую (от 5 до 12)
                    var pwr = rnd.Next(5, 13);

                    // Переводим 2^pwr в двоичную систему
                    var bin = Convert.ToString((int)Math.Pow(2, pwr), 2);

                    var num = rnd.Next((int)Math.Pow(2, pwr - 1), (int)Math.Pow(2, pwr)); // это ответ

                    var decNum = (int)Math.Pow(2, pwr) - num;

                    string q = ($"Найдите такое минимальное целое положительное число N,\n" +
                                $"что если прибавить его к {decNum} и перевести результат суммирования\n" +
                                $"в двоичную систему счисления, то получившаяся запись числа будет\n" +
                                $"содержать {string.Join("", bin.Split('0')).Length} единиц(ы) и некоторое количество нулей.\n" +
                                $"В ответе укажите число N, записанное в десятичной системе счисления.");
                    string answ = num.ToString();

                    return new TextMission(NumOfMission, MissionName, q, answ);
                case 2:
                    int powr = rnd.Next(7, 12);
                    int res = (int)Math.Pow(2, powr) - 1;
                    int x = (int)Math.Pow(2, powr - rnd.Next(2, 6)) - 1;

                    int n = res - x;

                    string que =     ($"Найдите такое минимальное целое положительное число N,\n" +
                                      $"что если прибавить его к {Convert.ToString(x, 2)} (двоичная с.с.) и перевести результат\n" +
                                      $"суммирования в двоичную систему счисления, то получившаяся\n" +
                                      $"запись числа будет содержать только единицы. В ответе укажите\n" +
                                      $"число N, записанное в десятичной системе счисления.");
                    string ans = n.ToString();
                    return new TextMission(25, MissionName, que, ans);
                default:
                    throw new Exception("mission 25 exeption");
            }
        }
    }
}
