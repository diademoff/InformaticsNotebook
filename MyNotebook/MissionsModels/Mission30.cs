using MyNotebook.Models;
using System;

namespace MyNotebook.MissionsModels
{
    [Serializable]
    public class Mission30 : MissionGenerator
    {
        public override string MissionName => "Домен n-ого уровня";

        public override int NumOfMission => 30;

        public override int TimeToSolveMission => 30;

        public override int MaxNumInTest => 10;

        public override MissionType TypeOfMission => MissionType.Theory;

        public override MissionBase Generate()
        {
            // Запишите в ответ доменное имя второго уровня портала: [url]
            string url = Extentions.URLGenerator.GenerateURL(); // https://exams.org/data.xls

            string answer = "";

            int lvl = rnd.Next(1, 3);
            if (lvl == 1)
            {
                answer = url.Split('/', '.')[1];
            }
            else if (lvl == 2)
            {
                answer = url.Split('/', '.')[2];
            }
            else
            {
                throw new Exception("Unknown lvl mission 30");
            }

            string q = $"Запишите в ответ доменное имя {(lvl == 1 ? "первого" : "второго")} уровня портала:\n" +
                       $"{url}";

            return new TextMission(NumOfMission, MissionName, q, answer,
                (answerGiven) => { return answerGiven.ToLower() == answer.ToLower(); });
        }
    }
}
