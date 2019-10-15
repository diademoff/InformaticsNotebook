using MyNotebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNotebook.ViewModels
{
    class Mission6 : MissionGenerator
    {
        public override MissionBase Generate()
        {
            int numOfAnswers = 7;
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
                        while (true)// not to repeat
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
                        while (true)// not to repeat
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
            MissionBase mb = new MissionBase(6, "Выберите устройства, находящьеся в системном блоке", answers.ToArray(), answerExpected.ToArray());
            mb.Title = "Выбрать устройства находящиеся в системном блоке";
            mb.Note = $"{numOfAnswers} вариантов ответов";
            return mb;
        }
    }
}
