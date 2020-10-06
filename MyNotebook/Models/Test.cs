using MyNotebook.Forms;
using MyNotebook.MissionsModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace MyNotebook.Models
{
    public enum TestShowType
    {
        OneByOneBlocks,
        OneByOneMissions,
        OnOneForm
    }
    [Serializable]
    public class Test
    {
        public DateTime TimeStart;
        public DateTime TimeFinish;
        public bool Finished = false;
        public bool IsCalcBlockEnabled;
        public bool IsTopMost = false;
        public TestShowType ShowType;
        public bool ShowAnswerAtOnce = false;
        public bool RandomOrder = false;
        public bool EnableMistakesCorrection = false;
        public double PercentSolvedRight
        {
            get
            {
                double solvedright = 0;

                foreach (MissionBase item in AllMissions)
                {
                    if (item.IsSolvedRight())
                    {
                        solvedright += 1;
                    }
                }

                return (Convert.ToDouble(solvedright) / Convert.ToDouble(AllMissions.Count)) * 100.0;
            }
        }
        public int Mark
        {
            get
            {
                if (PercentSolvedRight < 50.0)
                {
                    return 2;
                }
                else if ((50.0 <= PercentSolvedRight) && (PercentSolvedRight <= 74.0))
                {
                    return 3;
                }
                else if ((75.0 <= PercentSolvedRight) && (PercentSolvedRight <= 89.0))
                {
                    return 4;
                }
                else if ((90.0 <= PercentSolvedRight) && (PercentSolvedRight <= 100.0))
                {
                    return 5;
                }
                return 0;
            }
        }
        private List<MissionGenerator> AllMissonsGenerator = new List<MissionGenerator>();
        public List<MissionBase> AllMissions = new List<MissionBase>();

        public Test()
        {

        }
        public Test(int[] numOfMissions, int[] numOfMissionsForEach, bool isCalcBlockEnabled)
        {
            this.IsCalcBlockEnabled = isCalcBlockEnabled;

            for (int i = 0; i < numOfMissions.Length; i++)
            {
                for (int j = 0; j < numOfMissionsForEach[i]; j++)
                {
                    int numOfMissionToAdd = numOfMissions[i];

                    AllMissonsGenerator.Add(MissionGeneratorCollection.GetMissionByNum(numOfMissionToAdd));
                }
            }
        }

        public string GetHTMLPage(User user)
        {
            string html = "";
            //html += "<!DOCTYPE html> <html> <body>";
            html += $"<h1>Отчет о тесте</h1>";
            html += $"<h2>Тест решал(а): {user.Name} - {user.Class}</h2>";
            html += $"<h2>Решено {Math.Round(PercentSolvedRight, 2)}%. Оценка: {Mark}</h2>";
            html += $"<h2>Время начала: {TimeStart}</h2>";
            for (int i = 0; i < AllMissions.Count; i++)
            {
                html += AllMissions[i].GetHTMLResult();
            }
            //html += "</body> </html>";
            return html;
        }
        public void OpenHTMLPage(User user)
        {
            for (int i = 0; ; i++)
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.InternetCache) + $"\\{i}.html";
                if (!File.Exists(path))
                {
                    File.WriteAllText(path, GetHTMLPage(user));
                    Process.Start(path);
                    return;
                }
            }
        }

        public void OpenHTMLMissionSolve(string pathToFolder, int numOfVariants, bool breakPageAfterVariants)
        {
            string fileName = "index.html";


            string html = "<!DOCTYPE html>" +
                           "<html>" +
                           "<head>" +
                           "	<title>Задания</title>" +
                           "	<style>" +
                           "		.brd {" +
                           "			border: 1px solid black;" +
                           "            padding: 5px;" +
                           "		}" +
                           "		.wrapper {" +
                           "			display: grid;" +
                           "			grid-template-columns: 50% 50%;";
            html += breakPageAfterVariants ? "page-break-after:always;" : "";
            html += "		}" +
                          "	</style>" +
                          "</head>" +
                          "<body>";
            string htmlAnswer = "<!DOCTYPE html>" +
                                "<html>" +
                                "<head>" +
                                "	<title>Ответы</title>" +
                                "	<style>" +
                                "		.brd {" +
                                "			border: 1px solid black;" +
                                "			padding: 5px;" +
                                "			width: auto;" +
                                "			height: auto;" +
                                "			float: left;" +
                                "		}" +
                                "		.wrapper {" +
                                "			display: grid;" +
                                "			grid-template-columns: 50% 50%;" +
                                "		}" +
                                "	</style>" +
                                "</head>" +
                                "<body>";

            for (int i = 1; i <= numOfVariants; i++)
            {
                html += $"<h1>Вариант {i}</h1>" +
                        $"<br>";
                html += "<div class=\"wrapper\">";

                htmlAnswer += $"<h1>Ответы к варианту {i}</h1>";
                for (int j = 0; j < AllMissions.Count; j++)
                {
                    html += "<div class=\"brd\">";
                    html += $"<p> Задание №{j + 1} ({AllMissions[j].NumOfMission}) </p>";
                    html += AllMissions[j].AppendHTMLMission(pathToFolder);
                    html += "</div>";

                    htmlAnswer += $"{j + 1}. " + AllMissions[j].String_AnswerExpecting + "\n<br>\n";
                }
                html += "</div>";
                RegenerateMissions();
            }

            html += "</body>" +
                    "</html>";

            htmlAnswer += "</body>" +
                          "</html>";

            File.WriteAllText(Path.Combine(pathToFolder, fileName), html, Encoding.UTF8);
            Process.Start(Path.Combine(pathToFolder, fileName));

            File.WriteAllText(Path.Combine(pathToFolder, "Answer.html"), htmlAnswer, Encoding.UTF8);
            Process.Start(Path.Combine(pathToFolder, "Answer.html"));
        }

        /// <summary>
        /// Перезаполняет List<MissionBase> AllMissions с помощью AllMissonsGenerator
        /// </summary>
        public void RegenerateMissions()
        {
            AllMissions.Clear();
            for (int i = 0; i < AllMissonsGenerator.Count; i++)
            {
            regenerate:
                MissionBase generated = AllMissonsGenerator[i].Generate();
                if (AllMissions.Contains(generated))
                {
                    goto regenerate;
                }
                AllMissions.Add(generated);
            }
        }

        public int NumOfSolved
        {
            get
            {
                int count = 0;
                for (int i = 0; i < AllMissions.Count; i++)
                {
                    if (AllMissions[i].IsSolved())
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

        public static Test Deserialize(byte[] data)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (MemoryStream fs = new MemoryStream(data))
            {
                Test result = bf.Deserialize(fs) as Test;
                return result;
            }
        }

        /// <summary>
        /// Создать тест для проработки ошибок
        /// </summary>
        public Test CreateCorrectMistakesTest(Test testToCorrect)
        {
            Test result = testToCorrect.MemberwiseClone() as Test;

            result.AllMissions = new List<MissionBase>();
            for (int i = 0; i < result.AllMissonsGenerator.Count; i++)
            {
                result.AllMissonsGenerator[i].rnd = new Random();
            }

            for (int i = 0; i < testToCorrect.AllMissions.Count; i++)
            {
                if (!testToCorrect.AllMissions[i].IsSolvedRight())
                {
                    result.AllMissions.Add(MissionGeneratorCollection.GetMissionByNum(AllMissions[i].NumOfMission).Generate());
                }
            }

            return result;
        }
    }
}
