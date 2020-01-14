using MyNotebook.Models;
using System;

namespace MyNotebook.ViewModels
{
    public class MissionGeneratorCategory
    {
        public MissionGenerator[] Missions { get; set; }
        public string CategoryName { get; set; }

        public MissionGeneratorCategory(string categoryName, MissionGenerator[] missions)
        {
            Missions = missions;
            CategoryName = categoryName;
        }
    }
    public static class MissionGeneratorCollection
    {
        public static MissionGeneratorCategory[] Categories = new MissionGeneratorCategory[]
        {
            new MissionGeneratorCategory("Математические основы информатики",
                new MissionGenerator[]
                {
                    new Mission1(),
                    new Mission14(),
                    new Mission15(),
                    new Mission16()
                }),
            new MissionGeneratorCategory("Информация и её свойства",
                new MissionGenerator[]
                {
                    new Mission2(),
                    new Mission18(),
                    new Mission20()
                }),
            new MissionGeneratorCategory("Компьютер как универсальное устройство для работы с информацией",
                new MissionGenerator[]
                {
                    new Mission4(),
                    new Mission5(),
                    new Mission6(),
                    new Mission8(),
                    new Mission9(),
                    new Mission12(),
                    new Mission13(),
                    new Mission19()
                }),
            new MissionGeneratorCategory("Алгоритмнмзяцня и программирование",
                new MissionGenerator[]
                {
                    new Mission3(),
                    new Mission11(),
                }),
            new MissionGeneratorCategory("Кодирование графической информации",
                new MissionGenerator[]
                {
                    new Mission21()
                }),
            new MissionGeneratorCategory("Кодирование текстовой информации",
                new MissionGenerator[]
                {
                    new Mission10(),
                    new Mission17()
                }),
            new MissionGeneratorCategory("Дополнительные темы",
                new MissionGenerator[]
                {
                    new Mission7()
                })
        };

        public static MissionGenerator GetMissionByNum(int numOfMissionToAdd)
        {
            foreach (var catagory in Categories)
            {
                foreach (var mission in catagory.Missions)
                {
                    var currentNum = mission.Generate().NumOfMission;
                    if (currentNum == numOfMissionToAdd)
                    {
                        return mission;
                    }
                }
            }
            throw new Exception("no mission with number " + numOfMissionToAdd);
        }
    }
}
