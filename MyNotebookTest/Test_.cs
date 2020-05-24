using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyNotebook.MissionsModels;
using System.Windows.Forms;

namespace MyNotebook.Models.Test_
{
    [TestClass()]
    public class Test_
    {
        class MissionGenerateExample : MissionGenerator
        {
            public override string MissionName => "test";

            public override int NumOfMission => 0;

            public override int TimeToSolveMission => 120;

            public override int MaxNumInTest => 5;

            public override MissionType TypeOfMission => MissionType.Theory;

            public override MissionBase Generate()
            {
                // int randomNum = rnd.Next(); 
                TextMission randomMission = new TextMission(NumOfMission, MissionName, "Вопрос", "Ответ");
                return randomMission;
            }
        }
        [TestMethod()]
        public void MissionGenerator()
        {
            MissionGenerateExample generator = new MissionGenerateExample();
            #region check mission
            Assert.AreEqual(0, generator.NumOfMission);
            Assert.AreEqual(120, generator.TimeToSolveMission);
            Assert.AreEqual(MissionType.Theory, generator.TypeOfMission);
            Assert.AreEqual(5, generator.MaxNumInTest);
            #endregion     
            MissionGeneratorCategory missionGeneratorCatagory = new MissionGeneratorCategory("Название категории заданий", new MissionGenerator[]
            {
                generator
            });
            TextMission generatedMission = missionGeneratorCatagory.Missions[0].Generate() as TextMission;

            Assert.AreEqual("Вопрос", generatedMission.Question);
            Assert.AreEqual("Ответ", generatedMission.Answer);
        }

        [TestMethod()]
        public void AutoGenerateMission()
        {
            int x = 2; // количество первых заданий
            int y = 1; //            вторых заданий
            Test testForUser = new Test(new int[]
            {
                1, // задача №1
                2 // задача №2
            }, new int[] 
            {
                x, // два первых задания
                y // одно первое задание
            }, true);                      // можно задать номера заданий 
                                           // и количество каждого из заданий 
                                           // из коллекции MissionGeneratorCollection
            Assert.AreEqual(true, testForUser.IsCalcBlockEnabled);
            Assert.AreEqual(0, testForUser.AllMissions.Count); // задания еще не сгенерированы
            testForUser.RegenerateMissions();
            Assert.AreEqual(x + y, testForUser.AllMissions.Count);
            testForUser.InitTest();

            double numOfSolved = 0;
            foreach (var mission in testForUser.AllMissions)
            {
                Assert.AreEqual(numOfSolved / (x + y) * 100.0, testForUser.PercentSolvedRight);
                Assert.AreEqual(false, testForUser.Finished);
                TabPage tab = mission.GetTabPage(showAnswerAtOnce:true);
                mission.SolveRight(); // пользователь решает задание через TabPage
                numOfSolved++;
            }

            testForUser.FinishTest();
            Assert.AreEqual(true, testForUser.Finished);
        }
    }
}