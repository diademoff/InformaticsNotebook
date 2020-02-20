using MyNotebook.Models;
using System;

namespace MyNotebook.ViewModels
{
    class Mission21C : MissionGenerator
    {
        public override MissionBase Generate()
        {
            string title = "Cложные задачи на кодирование изображений";
            string q = "";
            int i = 0;
            i = rnd.Next(3, 10);
            switch (rnd.Next(5, 8))
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
                            return new TextMission(21, title, q, res.ToString())
                            {
                                TypeOfMission = MissionType.Practice
                            };
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
                            return new TextMission(21, title, q, res.ToString())
                            {
                                TypeOfMission = MissionType.Practice
                            };
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
                            return new TextMission(21, title, q, res.ToString())
                            {
                                TypeOfMission = MissionType.Practice
                            };
                        }
                    }
                #endregion
                default:
                    throw new Exception("ex mission 21");
            }
        }
    }
}
