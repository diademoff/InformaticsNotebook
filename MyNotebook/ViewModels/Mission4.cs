using MyNotebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyNotebook.ViewModels
{
    /// <summary>
    /// Определения компьютерных комплектующих
    /// </summary>
    [Serializable]
    public class Mission4 : MissionGenerator
    {
        string title = "Определения компьютерных комплектующих";
        public override MissionBase Generate()
        {
            List<MatchElement> matchElements = new List<MatchElement>();

            foreach (var item in DataCollection.GetAllElementsWhere(false, true))
            {
                matchElements.Add(new MatchElement(item.Term, item.Defenitions));
            }

            var generated = new MatchMission(4, title, matchElements.ToArray());
            generated.Tooltip = $"Термины: {string.Join(", ", matchElements)}";
            generated.TimeNeedToSolveMissionSeconds = 120;
            generated.TypeOfMission = MissionType.Theory;
            return generated;
        }
    }
}
