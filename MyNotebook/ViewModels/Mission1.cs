using MyNotebook.Models;
using System;

namespace MyNotebook.ViewModels
{
    /// <summary>
    /// Перевод между 10-ой и 2-ой сс
    /// </summary>
    [Serializable]
    public class Mission1 : Mission
    {
        public override Mission Generate()
        {
            this.NumOfMission = 1;

            if (rnd.Next(0, 2) == 0)
            {
                Generate2to10();
            }
            else
            {
                Generate10to2();
            }

            return this;
        }

        /// <summary>
        /// Генерация задачи перевода из 10-ой в 2-ую
        /// </summary>
        void Generate10to2()
        {
            int num = rnd.Next(50, 200);
            Question = $"Переведите число {num} из 10-ой с.с в 2-ую";
            Answer = Convert.ToString(num, 2);
        }

        /// <summary>
        /// Генерация задачи перевода из 2-й в 10-ую
        /// </summary>
        void Generate2to10()
        {
            int num = rnd.Next(50, 200);
            Question = $"Переведите число {Convert.ToString(num, 2)} из 2-ой с.с в 10-ую";
            Answer = num.ToString();
        }
    }
}
