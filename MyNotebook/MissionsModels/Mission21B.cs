using MyNotebook.Models;
using System;

namespace MyNotebook.MissionsModels
{
    [Serializable]
    class Mission21B : MissionGenerator
    {
        public override int NumOfMission => 21;
        public override string MissionName => "Задачи на кодирование изображений средней сложности";
        public override int TimeToSolveMission => 2 * 60 + 30;
        public override int MaxNumInTest => 10;
        public override MissionType TypeOfMission => MissionType.Practice;
        public override MissionBase Generate()
        {
            string q = "";
            int i = 0;
            i = rnd.Next(3, 10);
            switch (rnd.Next(3, 5))
            {
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
                            return new TextMission(NumOfMission, MissionName, q, res.ToString());
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
                        double res = Convert.ToDouble(Math.Pow(2, i)) * Convert.ToDouble(Math.Pow(2, j)) / 8.0;
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
