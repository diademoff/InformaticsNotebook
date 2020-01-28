using MyNotebook.Models;
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
