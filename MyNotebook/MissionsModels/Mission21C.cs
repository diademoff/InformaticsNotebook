﻿using MyNotebook.Models;
using MyNotebook.StaticCollections;
using System;

namespace MyNotebook.MissionsModels
{
    [Serializable]
    class Mission21C : MissionGenerator
    {
        public override int NumOfMission => 21;
        public override string MissionName => "Cложные задачи на кодирование изображений";
        public override int TimeToSolveMission => 330;
        public override int MaxNumInTest => 10;
        public override MissionType TypeOfMission => MissionType.Practice;
        public override MissionBase Generate()
        {
            string q = "";
            int i;
            switch (rnd.Next(5, 9))
            {
                case 5:
                    #region
                    while (true)
                    {
                        int x = rnd.Next(2, 6);
                        i = rnd.Next(1, 6);
                        int j = (int)Math.Pow(2, rnd.Next(2, 9));

                        q = $"Какой объём видеопамяти в килобайтах необходим для\n" +
                            $"хранения {x} страниц изображения, если глубина цвета\n" +
                            $"равна {Math.Pow(2, i)} бит, а разрешающая способность\n" +
                            $"дисплея - {j} на {j} пикселей?";
                        double res = (Convert.ToDouble(x) * Convert.ToDouble(j * j) * Math.Pow(2, i)) / (8.0 * 1024.0);
                        if (res == Convert.ToDouble((int)res))
                        {
                            return new TextMission(NumOfMission, MissionName, q, res.ToString());
                        }
                    }
                #endregion
                case 6:
                    #region
                    while (true)
                    {
                        int x = rnd.Next(10000, 20000);
                        i = rnd.Next(125, 1025);
                        int j = rnd.Next(125, 1025);
                        int m = rnd.Next(2, 6);

                        q = $"Сколько секунд потребуется модему,\n" +
                            $"передающему сообщения со скоростью {x} бит/c,\n" +
                            $"чтобы передать цветовое растровое изображение размером\n" +
                            $"{i} на {j} пикселей, при условии, что цвет каждого пикселя\n" +
                            $"кодируется {m} байтами?";
                        double res = (Convert.ToDouble(i) * Convert.ToDouble(j) * m * 8.0) / x;
                        if (res == Convert.ToDouble((int)res))
                        {
                            return new TextMission(NumOfMission, MissionName, q, res.ToString());
                        }
                    }
                #endregion
                case 7:
                    #region
                    while (true)
                    {
                        int x = rnd.Next(10000, 80000);
                        i = rnd.Next(125, 1025);
                        int j = rnd.Next(125, 1025);

                        q = $"Страница видеопамяти составляет {x} байтов. Дисплей\n" +
                            $"работает в режиме {i} на {j} пикселей. Сколько цветов\n" +
                            $"в палитре?";

                        double res = Math.Pow(2, (Convert.ToDouble(x) * 8.0) / (Convert.ToDouble(i) * Convert.ToDouble(j)));
                        if (res == Convert.ToDouble((int)res))
                        {
                            return new TextMission(NumOfMission, MissionName, q, res.ToString());
                        }
                    }
                #endregion
                case 8:
                    #region
                    while (true)
                    {
                        double a = rnd.Next(3, 6);
                        double y = rnd.Next(3, 7);
                        double x = y * a;
                        double m = rnd.Next(10, 35);

                        string unit = DataCollection.InformationUnits[rnd.Next(1, 4)];

                        q = $"Автоматическая фотокамера делает фотографии высокого разрешения\n" +
                            $"с палитрой, содержащей {Math.Pow(2, x)} (2^{x}) цветов. Средний размер фотографии\n" +
                            $"составляет {m} {unit}. Для хранения в базе данных фотографии преобразуютn\n" +
                            $"в чёрно-белый формат с палитрой, содержащей {Math.Pow(2, y)} цветов. Другие\n" +
                            $"преобразования и дополнительные методы сжатия не используются. Сколько\n" +
                            $"{unit} составляет средний размер преобразованной фотографии?";

                        double res = m / a;

                        if (res == Convert.ToDouble((int)res))
                        {
                            return new TextMission(NumOfMission, MissionName, q, res.ToString());
                        }
                    }
                #endregion
                default:
                    throw new Exception("ex mission 21");
            }
        }
    }
}
