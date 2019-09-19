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
        public bool IsCalcBlockEnabled;
        public List<MissionBase> AllMissons = new List<MissionBase>();
        public List<MissionBase> MissionsPassed = new List<MissionBase>();

        public void FinishTest()
        {
            Finished = true;
            TimeFinish = DateTime.Now;
            for (int i = 0; i < AllMissons.Count; i++)
            {
                if (!AllMissons[i].IsSolved)
                {
                    MissionsPassed.Add(AllMissons[i]);
                }
            }
        }
        public Test(int[] numOfMissions, bool isCalcBlockEnabled)
        {
            this.IsCalcBlockEnabled = isCalcBlockEnabled;

            for (int i = 0; i < numOfMissions.Length; i++)
            {
                AllMissons.Add(MissionGeneratorCollection.Missions[numOfMissions[i]].Generate());
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
