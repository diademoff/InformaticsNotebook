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
        public override int NumOfMission => 13;
        public override string MissionName => "Выбрать изображение комплектующего";
        public override int TimeToSolveMission => 60;
        public override int MaxNumInTest => 3;
        public override MissionType TypeOfMission => MissionType.Theory;
        public override string Tooltip => "Определить изображение по названию";

        public override MissionBase Generate()
        {
            List<Component> list = new List<Component>();

            foreach (var item in DataCollection.GetAllElementsWhere(true, false))
            {
                list.Add(new Component(item.Term, item.Images));
            }

            Bitmap[] pictures = new Bitmap[4];
            int rightIndex = rnd.Next(0, 4);
            var rightel = list[rnd.Next(0, list.Count)];
            string question = "";

            List<int> alreadyAdded = new List<int>();

            for (int i = 0; i < 4; i++)
            {
                if (i == rightIndex)
                {
                    question = $"Выберите картинку \"{rightel.ClassName}\"";
                    int index_ = rnd.Next(0, rightel.Images.Length);
                    pictures[i] = rightel.Images[index_];
                    alreadyAdded.Add(index_);
                    continue;
                }
            genAgain:
                int index = rnd.Next(0, list.Count);
                var el = list[index];
                if (el.ClassName == rightel.ClassName)
                {
                    goto genAgain;
                }
                if (alreadyAdded.Contains(index))
                {
                    goto genAgain;
                }
                pictures[i] = el.Images[rnd.Next(0, el.Images.Length)];
                alreadyAdded.Add(index);
            }

            ChoosePictureMission mission = new ChoosePictureMission(NumOfMission, MissionName, question, pictures, rightIndex);
            return mission;
        }
    }
}
