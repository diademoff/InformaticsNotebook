using MyNotebook.Models;
using System;
using System.Collections.Generic;

namespace MyNotebook.ViewModels
{
    [Serializable]
    public class Mission9 : MissionGenerator
    {
        public override int NumOfMission => 9;
        public override string MissionName => "Выберите устройства ввода/вывода";
        public override int TimeToSolveMission => 60;
        public override int MaxNumInTest => 3;
        public override MissionType TypeOfMission => MissionType.Theory;
        public override string Tooltip => "Выбрать устройства ввода или вывода";
        enum tasktype
        {
            input = 1,
            output = 2
        }

        public override MissionBase Generate()
        {
        generate:
            int numOfAnswers = 6;
            string[] input =
            {
                "Сканер",
                "Микрофон",
                "Диктофон",
                "Компьютерная мышь",
                "Графический планшет",
                "Джойстик",
                "Геймпад",
                "Трекбол"
            };

            string[] output =
            {
                "Монитор (дисплей)",
                "Принтер",
                "Плоттер",
                "Проектор",
                "Встроенный динамик",
                "Колонки",
                "Наушники"
            };

            tasktype tasktype = (tasktype)rnd.Next(1, 3);
            List<string> task = new List<string>();
            List<int> answer = new List<int>();

            while (true)
            {
                bool isOneNeedAdded = false;
                for (int i = 0; i < numOfAnswers; i++)
                {
                    if (rnd.RandomBool())
                    {
                        for (int j = 0; j < 20; j++)
                        {
                            string toAdd = input.RandomElement();
                            if (!task.Contains(toAdd))
                            {
                                task.Add(toAdd);
                                if (tasktype == tasktype.input)
                                {
                                    answer.Add(i);
                                    isOneNeedAdded = true;
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < 20; j++)
                        {
                            string toAdd = output.RandomElement();
                            if (!task.Contains(toAdd))
                            {
                                task.Add(toAdd);
                                if (tasktype == tasktype.output)
                                {
                                    answer.Add(i);
                                    isOneNeedAdded = true;
                                }
                                break;
                            }
                        }
                    }
                }
                if (isOneNeedAdded)
                {
                    break;
                }
            }

            string title = "";
            switch (tasktype)
            {
                case tasktype.input:
                    title = "Выберите устройства ввода";
                    break;
                case tasktype.output:
                    title = "Выберите устройства вывода";
                    break;
                default:
                    break;
            }

            if (task.Count != numOfAnswers)
            {
                goto generate;
            }

            MissionBase mb = new SelectMission(9, title, "Выберите устройства ввода/вывода", task.ToArray(), answer.ToArray());
            return mb;
        }
    }
}
