﻿using MyNotebook.Models;
using MyNotebook.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNotebook.Forms
{
    public partial class FormStatistics : Form
    {
        public FormStatistics()
        {
            InitializeComponent();
            RefreshUI();
        }

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

        void RefreshUI()
        {
            int numOfTests = 0;
            int[] numOfMark = new int[4];
            User bestUser = new User("", "");
            double maxAverageMark = 0;
            double averageTimeSpanOnSolveMission = 0; //seconds
            double numOfMissions = 0; 

            /*
             * numOfMark[0] - Количество пятёрок
             * numOfMark[1] - Количество четвёрок
             * numOfMark[2] - Количество троек
             * numOfMark[3] - Количество двоек
             */

            List<int> NumOfUnsolvedMissions = new List<int>();
            for (int i = 0; i < UserCollection.Instance.GetUsers.Length; i++)
            {
                numOfTests += UserCollection.Instance.GetUsers[i].UserTests.Count;
                double averageMark = 0;
                for (int j = 0; j < UserCollection.Instance.GetUsers[i].UserTests.Count; j++)
                {
                    numOfMissions += UserCollection.Instance.GetUsers[i].UserTests[j].AllMissions.Count;
                    for (int k = 0; k < UserCollection.Instance.GetUsers[i].UserTests[j].AllMissions.Count; k++)
                    {
                        averageTimeSpanOnSolveMission += UserCollection.Instance.GetUsers[i].UserTests[j].AllMissions[k].TimeSpanOnMissionSeconds;
                        if (UserCollection.Instance.GetUsers[i].UserTests[j].AllMissions[k].IsSolvedRight())
                        {
                            continue;
                        }
                        NumOfUnsolvedMissions.Add(UserCollection.Instance.GetUsers[i].UserTests[j].AllMissions[k].NumOfMission);
                    }
                    int mark = UserCollection.Instance.GetUsers[i].UserTests[j].Mark;
                    averageMark += mark;
                    switch (mark)
                    {
                        case 5:
                            numOfMark[0]++;
                            break;
                        case 4:
                            numOfMark[1]++;
                            break;
                        case 3:
                            numOfMark[2]++;
                            break;
                        case 2:
                            numOfMark[3]++;
                            break;
                    }
                }
                averageMark /= UserCollection.Instance.GetUsers[i].UserTests.Count;
                if (averageMark > maxAverageMark)
                {
                    maxAverageMark = averageMark;
                    bestUser = UserCollection.Instance.GetUsers[i];
                }
            }
            averageTimeSpanOnSolveMission /= numOfMissions;
            MissionBase hardestMission = MissionGeneratorCollection.GetMissionByNum(GetHardestMission(NumOfUnsolvedMissions)).Generate();

            lbl_numOfUsers.Text = $"Количество пользователей: {UserCollection.Instance.GetUsers.Length}";
            lbl_numOfTests.Text = $"Количество пройденых тестов: {numOfTests}";
            lbl_numOfMissions.Text = $"Количество заданий: {numOfMissions}";
            lbl_averageTimeSpanOnMission.Text = $"Затраченное время на задание в среднем: {averageTimeSpanOnSolveMission.ToString("0.00")} сек";

            num_ofMark5.Text = $"Количество пятёрок: {numOfMark[0]}";
            num_ofMark4.Text = $"Количество четвёрок: {numOfMark[1]}";
            num_ofMark3.Text = $"Количество троек: {numOfMark[2]}";
            num_ofMark2.Text = $"Количество двоек: {numOfMark[3]}";

            lbl_bestUser.Text = $"Лучший ученик: {bestUser.Name} (средний балл - {maxAverageMark})";
            lbl_hardestMission.Text = $"Самое сложное задание: {hardestMission.Title} (№{hardestMission.NumOfMission})";

            List<MissionStat> missionStats = GetMissionStats(UserCollection.Instance.Users);

            dg_missions.Rows.Add(missionStats.Count);
            for (int i = 0; i < missionStats.Count; i++)
            {
                string name = $"{missionStats[i].NumOfMission}. {missionStats[i].mission.Title}";
                int mistakes = missionStats[i].NumOfWrongAnswers;
                int right = missionStats[i].NumOfRightAnswers;
                double success = missionStats[i].SuccessPercent;
                double time = Convert.ToDouble(missionStats[i].TimeSpanMissionSeconds) / (missionStats[i].NumOfRightAnswers + missionStats[i].NumOfWrongAnswers);
                int row = i + 1;

                dg_missions.Rows[row].Cells[0].Value = name;
                dg_missions.Rows[row].Cells[1].Value = mistakes;
                dg_missions.Rows[row].Cells[2].Value = right;
                dg_missions.Rows[row].Cells[3].Value = success.ToString("P");
                dg_missions.Rows[row].Cells[4].Value = Convert.ToInt32(time);
            }
            dg_missions.Rows.RemoveAt(0);
        }

        List<MissionStat> GetMissionStats(List<User> allUsers)
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

        MissionBase[] GetAllMissions(List<User> allUsers)
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

        int[] NumOfMissionsMostMistakes(List<User> users)
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

        int GetHardestMission(List<int> arr)
        {
            var count = 0;
            var index = -1;
            for (var i = 0; i < arr.Count; ++i)
            {
                var k = 1;
                for (var j = i + 1; j < arr.Count; ++j)
                    if (arr[i] == arr[j]) k++;
                if (k <= count) continue;
                count = k;
                index = i;
            }

            return arr[index];
        }

        void btn_export_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog()
            {
                Filter = "Bin файл | *.bin"
            })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.Copy(UserCollection.dataPath, sfd.FileName);
                    MessageBox.Show("Статистика сохранена");
                }
            }
        }
    }
}
