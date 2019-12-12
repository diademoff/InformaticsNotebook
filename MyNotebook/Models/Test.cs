using MyNotebook.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

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
        public double PercentSolved
        {
            get
            {
                double solvedright = 0;

                foreach (var item in AllMissions)
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
                if (PercentSolved < 50.0)
                {
                    return 2;
                }
                else if ((50.0 <= PercentSolved) && (PercentSolved <= 74.0))
                {
                    return 3;
                }
                else if ((75.0 <= PercentSolved) && (PercentSolved <= 89.0))
                {
                    return 4;
                }
                else if ((90.0 <= PercentSolved) && (PercentSolved <= 100.0))
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

        public string GetHTMLPage(User user)
        {
            string html = "";
            //html += "<!DOCTYPE html> <html> <body>";
            html += $"<h1>Отчет о тесте</h1>";
            html += $"<h2>Тест решал(а): {user.Name} - {user.Class}</h2>";
            html += $"<h2>Решено {Math.Round(PercentSolved, 2)}%. Оценка: {Mark}</h2>";
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

        public void RegenerateMissions()
        {
            for (int i = 0; i < AllMissonsGenerator.Count; i++)
            {
                AllMissonsGenerator[i].rnd = new Random();
            }

            AllMissions.Clear();
            for (int i = 0; i < AllMissonsGenerator.Count; i++)
            {
            regenerate:
                var generated = AllMissonsGenerator[i].Generate();
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

        public Test(int[] numOfMissions, int[] numOfMissionsForEach, bool isCalcBlockEnabled)
        {
            this.IsCalcBlockEnabled = isCalcBlockEnabled;

            for (int i = 0; i < numOfMissions.Length; i++)
            {
                for (int j = 0; j < numOfMissionsForEach[i]; j++)
                {
                    AllMissonsGenerator.Add(MissionGeneratorCollection.Missions[numOfMissions[i]]);
                }
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
