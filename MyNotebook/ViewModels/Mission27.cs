using MyNotebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotebook.ViewModels
{
    [Serializable]
    class Mission27 : MissionGenerator
    {
        public override string MissionName => "Поиск адреса сети по маске";

        public override int NumOfMission => 27;

        public override int TimeToSolveMission => 240;

        public override int MaxNumInTest => 10;

        public override MissionType TypeOfMission => MissionType.Theory;

        public override MissionBase Generate()
        {
            // IP & Маска = Адрес
            int[] ip = new int[4];
            int[] mask = new int[4];
            for (int i = 0; i < ip.Length; i++)
            {
                ip[i] = rnd.Next(0, 256);
                mask[i] = rnd.RandomBool() ? 255 - rnd.Next(8) : rnd.Next(8);
            }

            int[] answer = new int[4];

            for (int i = 0; i < 4; i++)
            {
                answer[i] = ip[i] & mask[i];
            }

            string a = string.Join(".", answer);

            string q = $"По заданным IP-адресу узла сети и маске определите адрес сети:\n" +
                       $"IP-адрес: {string.Join(".", ip)}\n" +
                       $"Маска:    {string.Join(".", mask)}\n";

            return new TextMission(NumOfMission, MissionName, q, a);
        }
    }
}
