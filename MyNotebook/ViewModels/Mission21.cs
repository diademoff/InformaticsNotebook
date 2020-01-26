using MyNotebook.Models;
using System;

namespace MyNotebook.ViewModels
{
    [Serializable]
    public class Mission21 : MissionGenerator
    {
        public override MissionBase Generate()
        {
            string title = "Кодирование изображений";
            string q = "";
            int i = 0;
            i = rnd.Next(3, 10);
            switch (rnd.Next(1, 7))
            {
                case 1:
                    #region
                    q = $"Определите глубину цвета растрового\n" +
                        $"графического изображения с политрой \n" +
                        $"из {Math.Pow(2, i)} цветов.";
                    return new TextMission(21, title, q, i.ToString());
                    #endregion
                case 2:
                    #region
                    q = $"Глубина цвета растрового графического\n" +
                        $"изображения составляет {i} Бит. Определите\n" +
                        $"максимально возможное количество цветов в палитре.";
                    return new TextMission(21, title, q, Math.Pow(2, i).ToString());
                    #endregion
                case 3:
                    #region
                    while (true)
                    {
                        double x = rnd.Next(600, 2140);
                        double y = rnd.Next(600, 2140);
                        q = $"Определите сколько памяти (в мегабайтах) \n" +
                            $"будет занимать растровое графическое изображение\n" +
                            $"с разрешением {x}x{y} и глубиной цвета {Math.Pow(2, i)},\n" +
                            $"если сжатие не использовалось.";
                        double res = (x * y * Convert.ToDouble(Math.Pow(2, i))) / (1024.0 * 1024.0 * 8.0);
                        if (res == Convert.ToDouble((int)res))
                        {
                            return new TextMission(21, title, q, res.ToString());
                        }
                    }
                    #endregion
                case 4:
                    #region
                    while (true)
                    {
                        i = rnd.Next(2, 9);
                        int j = rnd.Next(2, 9);

                        q = $"Черно-белое (без градаций серого) растровое графическое\n" +
                            $"изображение имеет размер {Math.Pow(2, i)} на {Math.Pow(2, j)} пикселей.\n" +
                            $"Какой объём памяти в байтах займёт это изображение?";
                        double res = Convert.ToDouble(Math.Pow(2, i)) * Convert.ToDouble(Math.Pow(2, j)) * 2.0 / 8.0;
                        if (res == Convert.ToDouble((int)res))
                        {
                            return new TextMission(21, title, q, res.ToString());
                        }
                    }
                    #endregion
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
                            return new TextMission(21, title, q, res.ToString());
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
                            return new TextMission(21, title, q, res.ToString());
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

                        double res = Math.Pow(2, (Convert.ToDouble(x) * 8.0) / Convert.ToDouble(i) * Convert.ToDouble(j));
                        if (res == Convert.ToDouble((int)res))
                        {
                            return new TextMission(21, title, q, res.ToString());
                        }
                    }
                    #endregion
                default:
                    throw new Exception("ex mission 21");
            }
        }
    }
}
