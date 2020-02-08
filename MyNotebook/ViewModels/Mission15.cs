using MyNotebook.Models;
using System;

namespace MyNotebook.ViewModels
{
    [Serializable]
    public class Mission15 : MissionGenerator
    {
        public override MissionBase Generate()
        {
            int num = rnd.Next(50, 200);
            int n1 = int.Parse("2,3,4,5,6,7,8,9,11,12,13,14,15,16".Split(',').RandomElement());
            int n2 = int.Parse("2,3,4,5,6,7,8,9,11,12,13,14,15,16".Split(',').RandomElement());
            var q = $"Переведите число {FromDec(num, n1)} из {n1}-ой в {n2}-ую.";

            var answer = FromDec(num, n2);
            //TimeNeedToSolveMissionSeconds
            var mission = new TextMission(15, "Перевод между любыми системами счисления", q, answer);
            mission.TimeNeedToSolveMissionSeconds = 426;
            mission.TypeOfMission = MissionType.Theory;
            return mission;
        }

        string FromDec(long n, int p)
        {
            var result = "";
            for (; n > 0; n /= p)
            {
                var x = n % p;
                result = (char)(x < 0 || x > 9 ? x + 'A' - 10 : x + '0') + result;
            }
            return result;
        }
    }
}
