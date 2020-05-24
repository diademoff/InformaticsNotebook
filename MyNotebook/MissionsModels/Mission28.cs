using MyNotebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotebook.MissionsModels
{
    [Serializable]
    class Mission28 : MissionGenerator
    {
        public override string MissionName => "Двоичная запись чисел в отрезке";

        public override int NumOfMission => 28;

        public override int TimeToSolveMission => 240;

        public override int MaxNumInTest => 10;

        public override MissionType TypeOfMission => MissionType.Theory;

        public override MissionBase Generate()
        {
            /*
             * Сколько чисел из отрезка [n1, n2], содержат в своей двоичной записи менее
             * x значащих нулей.
             */
            int n1 = rnd.Next(10, 40);
            int n2 = n1 + rnd.Next(30, 60);
            int x = rnd.Next(2, 4);
            bool more = rnd.RandomBool();
            bool zeros = rnd.RandomBool();
            int[] nums = Enumerable.Range(n1, n2).ToArray();
            
            string q = $"Сколько чисел из отрезка [{n1}, {n2}], содержат в своей двоичной записи {(more ? "более" : "менее")}\n" +
                       $"{x} значащих {(zeros ? "нулей" : "единиц")}.";

            int answer = 0;

            foreach (var num in nums)
            {
                if (IsNumOk(num, x, more, zeros))
                {
                    answer++;
                }
            }

            return new TextMission(NumOfMission, MissionName, q, answer.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"> from task </param>
        /// <param name="zero"> true is zero. false is one </param>
        /// <returns></returns>
        bool IsNumOk(int num, int x, bool more, bool zero)
        {
            string bin_num = Convert.ToString(num, 2);

            char chr;
            if (zero)
            { // нулей
                chr = '0';
            }
            else
            { // единиц
                chr = '1';
            }

            int numOf = 0;
            foreach (var i in bin_num)
            {
                if (i == chr)
                {
                    numOf++;
                }
            }


            if (more)
            { // более
                return numOf > x;
            }
            else
            { // менее
                return numOf < x;
            }
        }
    }
}
