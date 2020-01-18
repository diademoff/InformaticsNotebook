using MyNotebook;
using MyNotebook.Models;
using MyNotebook.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Statistics
{
    class Program
    {
        struct MissionStat
        {
            public int NumOfMission { get; set; }
            public int NumOfWrongAnswers { get; set; }
            public int NumOfRightAnswers { get; set; }
            public double SuccessPercent { get; set; }
            public TimeSpan TimeSpanMission { get; set; }
            public int TotalAnswers
            {
                get
                {
                    return NumOfWrongAnswers + NumOfRightAnswers;
                }
            }
            public MissionBase mission { get; set; }

            public MissionStat(int numOfMission, MissionBase mission, MissionBase[] missions)
            {
                this.mission = mission;
                NumOfMission = numOfMission;
                NumOfWrongAnswers = 0;
                NumOfRightAnswers = 0;
                TimeSpanMission = new TimeSpan(0);
                SuccessPercent = 0;

                foreach (var m in missions)
                {
                    if (m.NumOfMission != numOfMission)
                    {
                        continue;
                    }
                    TimeSpanMission = TimeSpanMission.Add(m.TimeSpanOnMission);
                    if (m.IsSolvedRight())
                    {
                        NumOfRightAnswers++;
                    }
                    else
                    {
                        NumOfWrongAnswers++;
                    }
                }
                try
                {
                    SuccessPercent = Convert.ToDouble(NumOfRightAnswers) / NumOfWrongAnswers;
                }
                catch { }
            }
        }
        static string fileName = "result.txt";
        static void Main(string[] args)
        {
            Console.WriteLine($"Сохранение статистики в файл {fileName}");
            Console.Write("Введите путь к папке с *.bin файлами: ");
            string pathToFolder = Console.ReadLine();

            Console.WriteLine("Десериализация папки");
            var allUsers = UserCollection.Instance.DeserializeFolder(pathToFolder);
            List<Test> allTests = GetAllTests(allUsers);

            try
            {
                File.Delete("result.txt");
            }
            catch { }

            Console.WriteLine("Начало сбора статистики");
            StreamWriter sw = new StreamWriter("result.txt", false);

            sw.WriteLine($"Ученики ({allUsers.Count}), по которым собиралась статистика:");
            GetUserNames(allUsers).ToList().ForEach(x => sw.WriteLine("• " + x));
            Console.WriteLine("Ученики, по которым собиралась статистика записаны");

            sw.WriteLine($"Средняя оценка по всем ученикам: {AverageMark(allTests).ToString("0.00")}");
            sw.WriteLine($"Всего заданий решено: {TotalMissionsCount(allTests)}");

            Console.WriteLine("Запись заданий с наибольшим количеством ошибок");
            List<MissionStat> missionStats = GetMissionStats(allUsers);
            sw.WriteLine("Больше всего ошибок допущено в этих заданиях");
            foreach (var stat in missionStats)
            {
                sw.WriteLine($"\"{stat.NumOfMission}. {stat.mission.Title}\" - ошибок {stat.NumOfWrongAnswers}, верных ответов {stat.NumOfRightAnswers}, процент успеха {stat.SuccessPercent.ToString("0.00 %")}.");
            }
            sw.Flush();
            sw.Close();
            Console.WriteLine($"Вся информация записана в файл {fileName}");
            Console.ReadLine();
        }

        private static List<MissionStat> GetMissionStats(List<User> allUsers)
        {
            List<MissionStat> missionStats = new List<MissionStat>();
            int[] mostMistaked = NumOfMissionsMostMistakes(allUsers);
            int[] mistaked = mostMistaked.Distinct().ToArray();
            for (int i = 0; i < mistaked.Length; i++)
            {
                missionStats.Add(new MissionStat(mistaked[i], MissionGeneratorCollection.GetMissionByNum(mistaked[i]).Generate(), GetAllMissions(allUsers)));
            }

            for (int i = 0; i < missionStats.Count; i++)
            {
                for (int j = i; j < missionStats.Count; j++)
                {
                    if (missionStats[i].SuccessPercent < missionStats[j].SuccessPercent)
                    {
                        var temp = missionStats[i];
                        missionStats[i] = missionStats[j];
                        missionStats[j] = temp;
                    }
                }
            }

            return missionStats;
        }

        private static MissionBase[] GetAllMissions(List<User> allUsers)
        {
            List<MissionBase> res = new List<MissionBase>();
            foreach (var user in allUsers)
            {
                foreach (var test in user.UserTests)
                {
                    res.AddRange(test.AllMissions);
                }
            }
            return res.ToArray();
        }

        static int TotalMissionsCount(List<Test> allTests)
        {
            int res = 0;
            foreach (var test in allTests)
            {
                res += test.AllMissions.Count;
            }
            return res;
        }

        static int[] NumOfMissionsMostMistakes(List<User> users)
        {
            List<int> result = new List<int>();
            foreach (var user in users)
            {
                foreach (var test in user.UserTests)
                {
                    foreach (var mission in test.AllMissions)
                    {
                        if (!mission.IsSolvedRight())
                        {
                            result.Add(mission.NumOfMission);
                        }
                    }
                }
            }
            result.Sort();
            return result.ToArray();
        }
        static double AverageMark(List<Test> allTests)
        {
            double result = 0;
            foreach (var test in allTests)
            {
                result += test.Mark;
            }
            return result / allTests.Count;
        }
        static List<Test> GetAllTests(List<User> users)
        {
            List<Test> tests = new List<Test>();
            foreach (var user in users)
            {
                tests.AddRange(user.UserTests);
            }
        removing:
            for (int i = 0; i < tests.Count; i++)
            {
                if (tests[i].PercentSolved < 25)
                {
                    tests.Remove(tests[i]);
                    goto removing;
                }
            }
            tests = tests.Distinct().ToList();
            return tests;
        }
        static string[] GetUserNames(List<User> users)
        {
            List<string> names = users.Select(x => x.Name).ToList();
            for (int i = 0; i < names.Count; i++)
            {
                string[] splitted = names[i].Split(' ');
                names[i] = $"{FirstUpper(splitted[0].ToLower())} {FirstUpper(splitted[1].ToLower())} - {users[i].Class[0]} класс";
            }
            names = names.Distinct().ToList();
            names.Sort();
            return names.ToArray();

            string FirstUpper(string str)
            {
                string[] s = str.Split(' ');

                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i].Length > 1)
                        s[i] = s[i].Substring(0, 1).ToUpper() + s[i].Substring(1, s[i].Length - 1).ToLower();
                    else s[i] = s[i].ToUpper();
                }
                return string.Join(" ", s);
            }
        }
    }
}
