﻿using MyNotebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotebook.ViewModels
{
    [Serializable]
    public class Mission20 : MissionGenerator
    {
        public override MissionBase Generate()
        {
            while (true)
            {
                if (rnd.RandomBool())
                {
                    int fs = rnd.Next(5, 2000);
                    int t = rnd.Next(5, 61);
                    int tAsk = rnd.Next(5, 61);
                    if (t == tAsk)
                    {
                        continue;
                    }

                    string q = $"Файл размером {fs} Кбайт передаётся через некоторое соединение \n" +
                               $"в течение {t} секунд. Определите размер файла (в Кбайт), который \n" +
                               $"можно передать через это соединение за {tAsk} секунд.";

                    double a = Convert.ToDouble(fs) * Convert.ToDouble(tAsk) / Convert.ToDouble(t);
                    if (Convert.ToDouble((int)a) != a)
                    {
                        continue;
                    }

                    return new TextMission(20, "Скорость передачи данных", q, a.ToString())
                    {
                        TimeNeedToSolveMissionSeconds = 450
                    };
                }
                else
                {
                    int fs = rnd.Next(5, 2000);
                    int t = rnd.Next(5, 61);
                    int fsAsk = rnd.Next(5, 61);
                    if (fs == fsAsk)
                    {
                        continue;
                    }

                    string q = $"Файл размером {fs} Кбайт передаётся через некоторое соединение\n" +
                               $"в течение {t} секунд. Определите время, за которое\n" +
                               $"можно передать файл весом {fsAsk} Кбайт.";

                    double a = Convert.ToDouble(t) * Convert.ToDouble(fsAsk) / Convert.ToDouble(fs);
                    if (Convert.ToDouble((int)a) != a)
                    {
                        continue;
                    }
                    var mission = new TextMission(20, "Скорость передачи данных", q, a.ToString());
                    mission.TimeNeedToSolveMissionSeconds = 600;
                    mission.TypeOfMission = MissionType.Practice;
                    return mission;
                }
            }
        }
    }
}
