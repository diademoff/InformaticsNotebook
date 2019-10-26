﻿using MyNotebook.ViewModels;
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
        public bool ShowAnswerAtOnce = false;
        public int Mark;
        private List<MissionGenerator> AllMissonsGenerator = new List<MissionGenerator>();
        public List<MissionBase> AllMissions = new List<MissionBase>();

        public void RegenerateMissions()
        {
            for (int i = 0; i < AllMissonsGenerator.Count; i++)
            {
                AllMissonsGenerator[i].rnd = new Random();
            }
            AllMissions.Clear();
            for (int i = 0; i < AllMissonsGenerator.Count; i++)
            {
                AllMissions.Add(AllMissonsGenerator[i].Generate());
            }
        }

        public int NumOfSolved
        {
            get
            {
                int count = 0;
                for (int i = 0; i < AllMissions.Count; i++)
                {
                    if (AllMissions[i].IsAnswerGiven())
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
                AllMissonsGenerator.Add(MissionGeneratorCollection.Missions[numOfMissions[i]]);
            }
        }
        public int GetMissionsSolvedRight()
        {
            int result = 0;
            for (int i = 0; i < AllMissions.Count; i++)
            {
                if (AllMissions[i].IsSolvedRight())
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
