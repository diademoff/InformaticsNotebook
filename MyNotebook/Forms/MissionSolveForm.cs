using MyNotebook.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNotebook.Forms
{
    public partial class MissionSolveForm : Form
    {
        int MissionsLeft => Test.AllMissions.Count - Test.NumOfSolved;
        public User CurrentUser { get; set; }
        public Test Test;

        public MissionSolveForm(User user, Test test)
        {
            InitializeComponent();

            lbl_isTopMost.ForeColor = Color.Red;
            lbl_isTopMost.Text = "Монопольный режим выключен";
            if (test.IsTopMost)
            {
                this.WindowState = FormWindowState.Maximized;
                this.TopMost = true;
                this.MaximizeBox = false;
                this.MinimizeBox = false;
                this.FormBorderStyle = FormBorderStyle.None;
                lbl_isTopMost.ForeColor = Color.Green;
                lbl_isTopMost.Text = "Монопольный режим включен";
            }

            test.TimeStart = DateTime.Now;
            CurrentUser = user;
            this.Test = test;
            this.Shown += (s, e) =>
            {
                new Task(() => StartTimer()).Start();
                UpdateUI();
            };

            System.Windows.Forms.Timer uiUpdater = new System.Windows.Forms.Timer()
            {
                Interval = 100,
                Enabled = true
            };
            uiUpdater.Tick += (s, e) => UpdateUI();
            if (test.OneByOne)
            {
                ShowMissionsOneByOne(test);
            }
            else
            {
                AddTabsWithMissions(test);
            }
        }
        private void StartTimer()
        {
            while (true)
            {
                try
                {
                    lbl_timer.Invoke(new MethodInvoker(() =>
                    {
                        lbl_timer.Text = $"{(DateTime.Now - Test.TimeStart).TotalMinutes.ToString("00")}:{(DateTime.Now - Test.TimeStart).Seconds.ToString("00")}";
                    }));
                }
                catch { /*if window is closed*/ }
                Thread.Sleep(200);
            }
        }

        private void ShowMissionsOneByOne(Test test)
        {
            this.FullHideForm();
            List<int> numOfMissionsAdded = new List<int>(); // уже  добавленные миссии
            for (int i = 0; i < test.AllMissions.Count; i++)
            {
                if (numOfMissionsAdded.Contains(test.AllMissions[i].NumOfMission))
                {
                    continue; // если миссия уже добавлена
                }
                int currNumOfMission = test.AllMissions[i].NumOfMission; // номер миссии
                numOfMissionsAdded.Add(currNumOfMission); // добавить номер миссии в список
                // создаем subTab чтобы потом довить в maintab
                var subTab = new TabControl()
                {
                    Width = 880,
                    Height = 430,
                    Location = new Point(5, 5),
                    Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                    Dock = DockStyle.Fill
                };

                List<MissionBase> missions = new List<MissionBase>();

                // создаём форму для показа блока миссий
                Form previewForm = new Form()
                {
                    Width = 800,
                    Height = 500,
                    Icon = Properties.Resources.icon,
                    StartPosition = FormStartPosition.CenterScreen,
                    Text = $"Предпросмотр задания {i + 1} \"{test.AllMissions[i].ToString()}\""
                };

                // заполняем subtab
                for (int j = i; j < test.AllMissions.Count; j++)
                {
                    if (test.AllMissions[j].NumOfMission == currNumOfMission) // выбираем только миссии с текущим номером
                    {
                        var tab = test.AllMissions[j].GetTabPage(showAnswerAtOnce: Test.ShowAnswerAtOnce); // создем tab миссии
                        tab.Text = currNumOfMission.ToString();
                        missions.Add(test.AllMissions[j]);
                        subTab.TabPages.Add(tab); // добавляем tab
                    }
                }


                // добавляем созданный ранее таб
                previewForm.Controls.Add(subTab);

                // создаём кнопку для завершения блока
                var btn = new Button()
                {
                    Text = "Завершить блок",
                    Dock = DockStyle.Bottom
                };
                btn.Click += (s, e) =>
                {
                    btn.Enabled = false;
                    previewForm.Close();
                };
                previewForm.Controls.Add(btn);

                // показываем форму
                previewForm.ShowDialog();
            }

            this.FullHideForm();
            Test.FinishTest();
            TestResultForm trf = new TestResultForm(Test);
            trf.ShowDialog();
            this.Close();
        }


        private void AddTabsWithMissions(Test test)
        {
            List<int> numOfMissionsAdded = new List<int>(); // уже  добавленные миссии
            int indexOfTab = 0; // текущий индекс "maintab"
            for (int i = 0; i < test.AllMissions.Count; i++)
            {
                if (numOfMissionsAdded.Contains(test.AllMissions[i].NumOfMission))
                {
                    continue; // если миссия уже добавлена
                }
                int currNumOfMission = test.AllMissions[i].NumOfMission; // номер миссии
                numOfMissionsAdded.Add(currNumOfMission); // добавить номер миссии в список
                // создаем subTab чтобы потом довить в maintab
                var subTab = new TabControl()
                {
                    Width = 880,
                    Height = 430,
                    Location = new Point(5, 5),
                    Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                    Dock = DockStyle.Fill
                };
                
                // заполняем subtab
                for (int j = i; j < test.AllMissions.Count; j++)
                {
                    if (test.AllMissions[j].NumOfMission == currNumOfMission) // выбираем только миссии с текущим номером
                    {
                        var tab = test.AllMissions[j].GetTabPage(showAnswerAtOnce: Test.ShowAnswerAtOnce); // создем tab миссии
                        tab.Text = currNumOfMission.ToString();
                        subTab.TabPages.Add(tab); // добавляем tab
                    }
                }
                tabControl.TabPages.Add(new TabPage()
                {
                    Text = test.AllMissions[i].ToString()
                }); // добавляем tab в maintab чтобы в него добавить subtab
                tabControl.TabPages[indexOfTab].Controls.Add(subTab); // добавляем subtab в tabpage под индексом indexOfTab
                indexOfTab++; // увелициваем текущий индекс
            }
        }


        void UpdateUI()
        {
            lbl_user.Text = CurrentUser.ToString();
            lbl_missionLeft.Text = $"Осталось решить: {MissionsLeft}";
            lbl_isCalcBlockEnabled.ForeColor = Test.IsCalcBlockEnabled ? Color.Green : Color.Red;
            lbl_isCalcBlockEnabled.Text = Test.IsCalcBlockEnabled ? "Блокировка калькулятора включена" : "Блокировка калькулятора выключена";
        }
        private void Btn_finishTest_Click(object sender, EventArgs e)
        {
            if (MissionsLeft > 0)
            {
                var ans = MessageBox.Show("Вы решили не все задания. Хотите продолжить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ans == DialogResult.No)
                {
                    return;
                }
            }

            Test.FinishTest();
            this.FullHideForm();
            TestResultForm trf = new TestResultForm(Test);
            trf.ShowDialog();
            this.Close();
        }
    }
}
