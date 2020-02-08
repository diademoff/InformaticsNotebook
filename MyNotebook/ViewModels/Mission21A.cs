using MyNotebook.Models;
using System;

namespace MyNotebook.ViewModels
{
    [Serializable]
    public class Mission21A : MissionGenerator
    {
        public override MissionBase Generate()
        {
            string title = "Задачи на кодирование изображений";
            string q = "";
            int i = 0;
            i = rnd.Next(3, 10);
            switch (rnd.Next(1, 3))
            {
                case 1:
                    #region
                    q = $"Определите глубину цвета растрового\n" +
                        $"графического изображения с политрой \n" +
                        $"из {Math.Pow(2, i)} цветов.";
                    return new TextMission(21, title, q, i.ToString())
                    {
                        TypeOfMission = MissionType.Solve
                    };
                #endregion
                case 2:
                    #region
                    q = $"Глубина цвета растрового графического\n" +
                        $"изображения составляет {i} Бит. Определите\n" +
                        $"максимально возможное количество цветов в палитре.";
                    return new TextMission(21, title, q, Math.Pow(2, i).ToString())
                    {
                        TypeOfMission = MissionType.Solve
                    };
                #endregion
                default:
                    throw new Exception("ex mission 21");
            }
        }
    }
}
