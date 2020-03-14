using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyNotebook.ViewModels;
using System.Windows.Forms;

namespace MyNotebook.Models.Test_
{
    [TestClass()]
    public class Test_
    {
        class MissionGenerateExample : MissionGenerator
        {
            public override MissionBase Generate()
            {
                // int randomNum = rnd.Next(); 
                TextMission randomMission = new TextMission(1, "Заголовок", "Попрос", "Ответ");
                randomMission.MaxNumInTest = 5;
                randomMission.TypeOfMission = MissionType.Theory;
                randomMission.TimeNeedToSolveMissionSeconds = 250;
                randomMission.Tooltip = "Подсказка (пояснение)";
                return randomMission;
            }
        }
        [TestMethod()]
        public void MissionGenerator()
        {
            MissionGenerateExample generator = new MissionGenerateExample();
            MissionGeneratorCategory missionGeneratorCatagory = new MissionGeneratorCategory("Название категории заданий", new MissionGenerator[]
            {
                generator
            });
            MissionBase generatedMission = missionGeneratorCatagory.Missions[0].Generate();
            #region check generated mission
            Assert.AreEqual(1, generatedMission.NumOfMission);
            Assert.AreEqual("Подсказка (пояснение)", generatedMission.Tooltip);
            Assert.AreEqual(250, generatedMission.TimeNeedToSolveMissionSeconds);
            Assert.AreEqual(MissionType.Theory, generatedMission.TypeOfMission);
            Assert.AreEqual(5, generatedMission.MaxNumInTest);
            #endregion     
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