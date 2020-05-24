using MyNotebook.Models;
using System;

namespace MyNotebook.MissionsModels
{
    [Serializable]
    public class Mission21A : MissionGenerator
    {
        public override int NumOfMission => 21;
        public override string MissionName => "Задачи на кодирование изображений";
        public override int TimeToSolveMission => 400;
        public override int MaxNumInTest => 10;
        public override MissionType TypeOfMission => MissionType.Practice;

        public override MissionBase Generate()
        {
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
                    return new TextMission(NumOfMission, MissionName, q, i.ToString());
                #endregion
                case 2:
                    #region
                    q = $"Глубина цвета растрового графического\n" +
                        $"изображения составляет {i} Бит. Определите\n" +
                        $"максимально возможное количество цветов в палитре.";
                    return new TextMission(NumOfMission, MissionName, q, Math.Pow(2, i).ToString());
                #endregion
                default:
                    throw new Exception("ex mission 21");
            }
        }
    }
}
