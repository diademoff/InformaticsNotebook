using MyNotebook.Models;
using MyNotebook.StaticCollections;
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
            switch (rnd.Next(1, 4))
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
                case 3:
                    while (true)
                    {
                        double x = Math.Pow(2, rnd.Next(5, 11));
                        double y = rnd.RandomBool() ? Math.Pow(2, rnd.Next(5, 7)) : rnd.Next(4, 11);

                        int unitIndex = rnd.Next(0, 3);
                        int unitMultiplier;
                        switch (unitIndex)
                        {
                            case 0:
                                unitMultiplier = 1;
                                break;
                            case 1:
                                unitMultiplier = 8;
                                break;
                            case 2:
                                unitMultiplier = 1024 * 8;
                                break;
                            default:
                                throw new Exception("Mission 21A exeption (3)");
                        }
                        string unit = DataCollection.InformationUnits[unitIndex];

                        q = $"Для хранения растрового изображения размером {x}х{x} пикселей отвели {y} {unit}\n" +
                            $"памяти. Каково максимально возможное число цветов в палитре изображения?";

                        double answer = (y * unitMultiplier) / (x * x);

                        if (answer == Convert.ToDouble((int)answer))
                        {
                            return new TextMission(NumOfMission, MissionName, q, answer.ToString());
                        }
                    }
                default:
                    throw new Exception("ex mission 21");
            }
        }
    }
}
