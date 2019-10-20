﻿using MyNotebook.Models;
using System;

namespace MyNotebook.ViewModels
{
    /// <summary>
    /// Перевод между 10-ой и 2-ой сс
    /// </summary>
    [Serializable]
    public class Mission1 : MissionGenerator
    {
        string title = "Перевод между 10-ой и 2-ой сс";
        public override MissionBase Generate()
        {
            MissionBase result;
            if (rnd.Next(0, 2) == 0)
            {
                result = Generate2to10();
            }
            else
            {
                result = Generate10to2();
            }
            result.Note = "Интервал чисел: от 50 до 200";
            return result;
        }

        /// <summary>
        /// Генерация задачи перевода из 10-ой в 2-ую
        /// </summary>
        MissionBase Generate10to2()
        {
            int num = rnd.Next(50, 200);
            var Question = $"Переведите число {num} из 10-ой с.с в 2-ую";
            var Answer = Convert.ToString(num, 2);

            return new TextMission(1, title, Question, Answer);
        }

        /// <summary>
        /// Генерация задачи перевода из 2-й в 10-ую
        /// </summary>
        MissionBase Generate2to10()
        {
            int num = rnd.Next(50, 200);
            var Question = $"Переведите число {Convert.ToString(num, 2)} из 2-ой с.с в 10-ую";
            var Answer = num.ToString();

            return new TextMission(1, title, Question, Answer);
        }
    }
}
