using MyNotebook.ViewModels;
using System;
using System.Collections.Generic;

namespace MyNotebook.Models
{
    [Serializable]
    public class Test
    {
        public DateTime TimeStart;
        public DateTime TimeFinish;
        public bool Finished = false;
        public List<MissionBase> AllMissons = new List<MissionBase>();
        public List<MissionBase> MissionsPassed = new List<MissionBase>();

        public void FinishTest()
        {
            Finished = true;
            TimeFinish = DateTime.Now;

        }
        public Test(int[] numOfMissions)
        {
            for (int i = 0; i < numOfMissions.Length; i++)
            {
                if (numOfMissions[i] == 1)
                {
                    AllMissons.Add(new Mission1().Generate());
                }
                if (numOfMissions[i] == 2)
                {
                    AllMissons.Add(new Mission2().Generate());
                }
                if (numOfMissions[i] == 3)
                {
                    AllMissons.Add(new Mission3().Generate());
                }
                if (numOfMissions[i] == 4)
                {
                    AllMissons.Add(new Mission4().Generate());
                }
            }

            TimeStart = DateTime.Now;
        }
        public int GetMissionsSolvedRight()
        {
            int result = 0;
            for (int i = 0; i < MissionsPassed.Count; i++)
            {
                if (MissionsPassed[i].TextIsSolvedRight)
                {
                    result += 1;
                }
            }
            return result;
        }
    }
}
