using MyNotebook.Models;
using System;
using System.Collections.Generic;

namespace MyNotebook.ViewModels
{
    [Serializable]
    class Mission6 : MissionGenerator
    {
        public override int NumOfMission => 6;
        public override string MissionName => "Выбрать устройства, находящиеся в системном блоке";
        public override int TimeToSolveMission => 80;
        public override int MaxNumInTest => 10;
        public override MissionType TypeOfMission => MissionType.Theory;

        public override MissionBase Generate()
        {
            int numOfAnswers = 6;
            List<string> rightAnswers = new List<string>();
            rightAnswers.AddRange(new string[]
            {
                "Процессор",
                "Сетевая карта",
                "Оперативная память",
                "Материнская плата",
                "Видеокарта",
                "Блок питания",
                "Накопитель (дисковод)",
                "ПЗУ"
            });
            List<string> wrongAnswers = new List<string>();
            wrongAnswers.AddRange(new string[]
            {
                "Flash-память",
                "Плоттер",
                "Сканер",
                "Трекбол",
                "Источник бесперебойного питания",
                "Web-камера"
            });

            List<string> answers = new List<string>();
            List<int> answerExpected = new List<int>();
            while (true)
            {
                bool isOneRightAnswer = false;
                for (int i = 0; i < numOfAnswers; i++)
                {
                    if (rnd.RandomBool())
                    {
                        isOneRightAnswer = true;
                        for (int j = 0; j < 20; j++)// not to repeat
                        {
                            var toAdd = rightAnswers[rnd.Next(0, rightAnswers.Count)];
                            if (!answers.Contains(toAdd))
                            {
                                answers.Add(toAdd);
                                answerExpected.Add(i);
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int j = 0; j < 20; j++)
                        {
                            var toAdd = wrongAnswers[rnd.Next(0, wrongAnswers.Count)];
                            if (!answers.Contains(toAdd))
                            {
                                answers.Add(toAdd);
                                break;
                            }
                        }
                    }
                }
                if (isOneRightAnswer)
                {
                    break;
                }
            }
            MissionBase mb = new SelectMission (NumOfMission, MissionName, "Выберать устройства, находящьеся в системном блоке", answers.ToArray(), answerExpected.ToArray());
            return mb;
        }
    }
}
