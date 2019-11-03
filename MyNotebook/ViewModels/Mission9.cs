using MyNotebook.Models;
using System;
using System.Collections.Generic;

namespace MyNotebook.ViewModels
{
    [Serializable]
    public class Mission9 : MissionGenerator
    {
        enum tasktype
        {
            input = 1,
            output = 2
        }

        public override MissionBase Generate()
        {
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
            var task = new List<string>();
            var answer = new List<int>();

            while (true)
            {
                bool isOneNeedAdded = false;
                for (int i = 0; i < numOfAnswers; i++)
                {
                    if (rnd.RandomBool())
                    {
                        for (int j = 0; j < 20; j++)
                        {
                            var toAdd = input.RandomElement();
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
                            var toAdd = output.RandomElement();
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

            MissionBase mb = new SelectMission(9, title, "Выберите устройства ввода/вывода", task.ToArray(), answer.ToArray());
            mb.Tooltip = "Выбрать устройства ввода или вывода";
            return mb;
        }
    }
}
