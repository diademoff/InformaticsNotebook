using MyNotebook.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace MyNotebook.Models
{
    [Serializable]
    public class Test
    {
        public DateTime TimeStart;
        public DateTime TimeFinish;
        public bool Finished = false;
        public bool IsCalcBlockEnabled;
        public bool IsTopMost = false;
        public int Mark;
        public List<MissionBase> AllMissons = new List<MissionBase>();

        public int NumOfSolved
        {
            get
            {
                int count = 0;
                for (int i = 0; i < AllMissons.Count; i++)
                {
                    if (AllMissons[i].IsAnswerGiven)
                    {
                        count++;
                    }
                }
                return count;
            }
        }

        public void InitTest()
        {
            TimeStart = DateTime.Now;
        }

        public void FinishTest()
        {
            Finished = true;
            TimeFinish = DateTime.Now;
        }

        public Test(int[] numOfMissions, bool isCalcBlockEnabled)
        {
            this.IsCalcBlockEnabled = isCalcBlockEnabled;

            for (int i = 0; i < numOfMissions.Length; i++)
            {
                AllMissons.Add(MissionGeneratorCollection.Missions[numOfMissions[i]].Generate());
            }
        }
        public int GetMissionsSolvedRight()
        {
            int result = 0;
            for (int i = 0; i < AllMissons.Count; i++)
            {
                if (AllMissons[i].Text_IsSolvedRight)
                {
                    result += 1;
                }
            }
            return result;
        }

        public void Serialize(string filePath)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                bf.Serialize(fs, this);
            }
        }

        public static Test Deserialize(string filePath)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate))
            {
                Test result = bf.Deserialize(fs) as Test;
                return result;
            }
        }
    }
}
