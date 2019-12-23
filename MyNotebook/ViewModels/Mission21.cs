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
            i = rnd.Next(4, 12);
            switch (rnd.Next(1, 4))
            {
                case 1:
                    q = $"Определите глубину цвета растрового\n" +
                        $"графического изображения с политрой \n" +
                        $"из {Math.Pow(2, i)} цветов.";
                    return new TextMission(21, title, q, i.ToString());
                case 2:
                    q = $"Глубина цвета растрового графического\n" +
                        $"изображения составляет {i} Бит. Определите\n" +
                        $"максимально возможное количество цветов в палитре.";
                    return new TextMission(21, title, q, Math.Pow(2, i).ToString());
                case 3:
                    while (true)
                    {
                        double x = rnd.Next(600, 2140);
                        double y = rnd.Next(600, 2140);
                        q = $"Определите сколько памяти (в мегабайтах) \n" +
                            $"будет занимать растровое графическое изображение\n" +
                            $"с разрешением {x}x{y} и глубиной цвета {Math.Pow(2, i)},\n" +
                            $"если сжатие не использовалось";
                        double res = (x * y * Convert.ToDouble(Math.Pow(2, i))) / (1024.0 * 1024.0 * 8.0);
                        if (res == Convert.ToDouble((int)res))
                        {
                            return new TextMission(21, title, q, res.ToString());
                        }
                    }
                default:
                    throw new Exception("ex mission 21");
            }
        }
    }
}
