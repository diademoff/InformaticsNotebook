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
        public List<Mission> AllMissons = new List<Mission>();
        public List<Mission> MissionsPassed = new List<Mission>();

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
            }

            TimeStart = DateTime.Now;
        }
        public int GetMissionsSolvedRight()
        {
            int result = 0;
            for (int i = 0; i < MissionsPassed.Count; i++)
            {
                if (MissionsPassed[i].IsSolvedRight)
                {
                    result += 1;
                }
            }
            return result;
        }
    }
}
