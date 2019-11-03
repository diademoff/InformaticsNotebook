using MyNotebook.Models;
using MyNotebook.Models.MissionTypes;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace MyNotebook.ViewModels
{
    [Serializable]
    public class Component
    {
        public string ClassName { get; set; }
        public Bitmap[] Images { get; set; }

        public Component(string className, Bitmap[] images)
        {
            ClassName = className ?? throw new ArgumentNullException(nameof(className));
            Images = images ?? throw new ArgumentNullException(nameof(images));
        }
    }

    [Serializable]
    public class Mission13 : MissionGenerator
    {
        public override MissionBase Generate()
        {
            List<Component> list = new List<Component>();
            list.Add(new Component("Просессор", new Bitmap[]
            {
                Properties.Resources.cpu1,
                Properties.Resources.cpu2,
                Properties.Resources.cpu3
            }));
            list.Add(new Component("Жесткий диск", new Bitmap[]
            {
                Properties.Resources.hdd1,
                Properties.Resources.hdd2,
                Properties.Resources.hdd3
            }));
            list.Add(new Component("Материнская плата", new Bitmap[]
            {
                Properties.Resources.motherboard1,
                Properties.Resources.motherboard2,
                Properties.Resources.motherboard3,
                Properties.Resources.motherboard4
            }));
            list.Add(new Component("Сетевая карта", new Bitmap[]
            {
                Properties.Resources.networkcard1,
                Properties.Resources.networkcard2,
                Properties.Resources.networkcard3
            }));
            list.Add(new Component("Оперативная память", new Bitmap[]
            {
                Properties.Resources.ram1,
                Properties.Resources.ram2,
                Properties.Resources.ram3
            }));
            list.Add(new Component("Звуковая карта", new Bitmap[]
            {
                Properties.Resources.soundcard1,
                Properties.Resources.soundcard2,
                Properties.Resources.soundcard3
            }));
            list.Add(new Component("Видеокарта", new Bitmap[]
            {
                Properties.Resources.videocard1,
                Properties.Resources.videocard2
            }));

            Bitmap[] pictures = new Bitmap[4];
            int rightIndex = rnd.Next(0, 4);
            var rightel = list[rnd.Next(0, list.Count)];
            string question = "";

            for (int i = 0; i < 4; i++)
            {
                if (i == rightIndex)
                {
                    question = $"Выберите картинку \"{rightel.ClassName}\"";
                    pictures[i] = rightel.Images[rnd.Next(0, rightel.Images.Length)];
                    continue;
                }
            genAgain:
                var el = list[rnd.Next(0, list.Count)];
                if (el.ClassName == rightel.ClassName)
                {
                    goto genAgain;
                }
                pictures[i] = el.Images[rnd.Next(0, el.Images.Length)];
            }

            ChoosePictureMission mission = new ChoosePictureMission(13, "Выбрать изображение комплектующего", question, pictures, rightIndex);
            mission.Tooltip = "Определить изображение по названию";
            return mission;
        }
    }
}
