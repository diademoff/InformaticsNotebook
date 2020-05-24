using MyNotebook.Models;
using MyNotebook.StaticCollections;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyNotebook.MissionsModels
{
    /// <summary>
    /// Определения компьютерных комплектующих
    /// </summary>
    [Serializable]
    public class Mission4 : MissionGenerator
    {
        public override int NumOfMission => 4;
        public override string MissionName => "Определения компьютерных комплектующих";
        public override int TimeToSolveMission => 120;
        public override int MaxNumInTest => 10;
        public override MissionType TypeOfMission => MissionType.Theory;
        public override MissionBase Generate()
        {
            List<MatchElement> matchElements = new List<MatchElement>();

            foreach (var item in DataCollection.GetAllElementsWhere(false, true))
            {
                matchElements.Add(new MatchElement(item.Term, item.Defenitions));
            }

            var generated = new MatchMission(NumOfMission, MissionName, matchElements.ToArray());
            return generated;
        }
    }
}
