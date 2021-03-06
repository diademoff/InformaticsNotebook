﻿using MyNotebook;
using MyNotebook.Models;
using MyNotebook.MissionsModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;
using System.Windows.Forms;

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
            public int TimeSpanMissionSeconds { get; set; }
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
                TimeSpanMissionSeconds = 0;
                SuccessPercent = 0;

                foreach (var m in missions)
                {
                    if (m.NumOfMission != numOfMission)
                    {
                        continue;
                    }
                    TimeSpanMissionSeconds += m.TimeSpanOnMissionSeconds;
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
        static string fileName = "result.xlsx";
        static string fileNameStudents = "students.txt";
        [STAThread]
        static void Main(string[] args)
        {
            Console.OutputEncoding = Console.InputEncoding = Encoding.UTF8;

            Console.WriteLine($"Сохранение статистики в файл {fileName}");

            Console.Write("Выберете путь к папке с *.bin файлами: ");
            string pathToFolder = "";
            using (FolderBrowserDialog fbd = new FolderBrowserDialog())
            {
                if (fbd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                else
                {
                    pathToFolder = fbd.SelectedPath;
                }
            }
            Console.WriteLine(pathToFolder);

            Console.WriteLine("Десериализация папки");
            List<User> allUsers = UserCollection.Instance.DeserializeFolder(pathToFolder);

            Console.WriteLine("Выборка учеников");
            FormSelectUsers selectUsers = new FormSelectUsers(allUsers);
            selectUsers.ShowDialog();
            allUsers = selectUsers.ResultUsers;

            List<Test> allTests = GetAllTests(allUsers);
            FormSelectTests selectTests = new FormSelectTests(allTests);
            if(selectTests.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            allTests = selectTests.ResultTests;

            Console.WriteLine("Начало сбора статистики");
            Console.WriteLine($"Отобрано учеников - {allUsers.Count}");
            Console.WriteLine($"Отобрано тестов: {allTests.Count}");

            string[] StudentsNames = GetUserNames(allUsers);
            File.WriteAllLines(fileNameStudents, StudentsNames, Encoding.UTF8);
            Console.WriteLine($"Ученики, по которым собиралась статистика записаны в файл {fileNameStudents}");

            Console.WriteLine($"Средняя оценка по всем ученикам: {AverageMark(allTests).ToString("0.00")}");

            Console.WriteLine("Формирование информации о заданиях");
            List<MissionStat> missionStats = GetMissionStats(allUsers);
            WriteToExel(missionStats);
            Console.WriteLine($"Информация записана в файл {fileName}");
            Console.ReadLine();
        }

        private static void WriteToExel(List<MissionStat> missionStats)
        {
            if (File.Exists(fileName))
            {
                File.Delete(fileName);
            }
            using (var p = new ExcelPackage())
            {
                var ws = p.Workbook.Worksheets.Add("Статистика");

                ws.Cells[1, 1].Value = "Название задания";
                ws.Cells[1, 2].Value = "Допущено ошибок";
                ws.Cells[1, 3].Value = "Правильных ответов";
                ws.Cells[1, 4].Value = "Процент успеха";
                ws.Cells[1, 5].Value = "Времяни затрачено (сек)";

                for (int i = 0; i < missionStats.Count; i++)
                {
                    string name = $"{missionStats[i].NumOfMission}. {missionStats[i].mission.Title}";
                    int mistakes = missionStats[i].NumOfWrongAnswers;
                    int right = missionStats[i].NumOfRightAnswers;
                    double success = missionStats[i].SuccessPercent;
                    double time = Convert.ToDouble(missionStats[i].TimeSpanMissionSeconds) / (missionStats[i].NumOfRightAnswers + missionStats[i].NumOfWrongAnswers); 
                    int row = i + 2;

                    ws.Cells[row, 1].Value = name;
                    ws.Cells[row, 2].Value = mistakes;
                    ws.Cells[row, 3].Value = right;
                    ws.Cells[row, 4].Style.Numberformat.Format = "0.00%";
                    ws.Cells[row, 4].Value = success;
                    ws.Cells[row, 5].Value = Convert.ToInt32(time);
                }
                for (int i = 1; i <= 5; i++)
                {
                    ws.Column(i).AutoFit();
                }


                p.SaveAs(new FileInfo(fileName));
            }
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
            tests = tests.Distinct().ToList();
            return tests;
        }
        static string[] GetUserNames(List<User> users)
        {
            List<string> names = users.Select(x => x.Name).ToList();
            for (int i = 0; i < names.Count; i++)
            {
                try
                { 
                    string[] splitted = names[i].Split(' ');
                    names[i] = $"{FirstUpper(splitted[0].ToLower())} {FirstUpper(splitted[1].ToLower())} - {users[i].Class[0]} класс";
                }
                catch { }
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
