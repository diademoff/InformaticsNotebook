using MyNotebook.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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
        Random rnd = new Random();
        private void ShowMissionsOneByOne(Test test)
        {
            this.FullHideForm();
            if (test.RandomOrder)
            {
                test.AllMissions = test.AllMissions.OrderBy(x => rnd.Next()).ToList(); //shuffle list
            }
            List<int> numOfMissionsAdded = new List<int>(); // уже  добавленные миссии
            TabControl resultTabControl = new TabControl();
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
                    Text = $"Задание {i + 1} из {test.AllMissions.Count}. \"{test.AllMissions[i].ToString()}\""
                };
                previewForm.Controls.Add(new ProgressBar()
                {
                    Value = i + 1,
                    Maximum = test.AllMissions.Count,
                    Dock = DockStyle.Top,
                    Height = 3
                });

                if (test.IsTopMost)
                {
                    previewForm.WindowState = FormWindowState.Maximized;
                    previewForm.FormBorderStyle = FormBorderStyle.None;
                    previewForm.TopMost = true;
                }

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

                resultTabControl.TabPages.Add(subTab.TabPages[0]);
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

                object currIndex = indexOfTab;
                new Task(() => // изменить Text mainTab, когда все subTab решены
                {
                    while (true)
                    {
                        bool allAnswersGiven = true;
                        for (int j = 0; j < test.AllMissions.Count; j++)
                        {
                            if (test.AllMissions[j].NumOfMission == currNumOfMission) // выбираем только миссии с текущим номером
                            {
                                if (!test.AllMissions[j].IsAnswerGiven())
                                {
                                    allAnswersGiven = false;
                                }
                            }
                        }
                        if (allAnswersGiven)
                        {
                            tabControl.Invoke(new MethodInvoker(() =>
                            {
                                tabControl.TabPages[(int)currIndex].Text = "*";
                            }));
                            break;
                        }
                        Thread.Sleep(250);
                    }
                }).Start();

                indexOfTab++; // увелициваем текущий индекс
            }
        }


        void UpdateUI()
        {
            lbl_user.Text = CurrentUser.ToString();
            lbl_missionLeft.Text = $"Осталось решить: {MissionsLeft}";
            lbl_isCalcBlockEnabled.ForeColor = Test.IsCalcBlockEnabled ? Color.Green : Color.Red;
            lbl_isCalcBlockEnabled.Text = Test.IsCalcBlockEnabled ? "Блокировка калькулятора включена" : "Блокировка калькулятора выключена";
            progressBar.Maximum = Test.AllMissions.Count;
            progressBar.Value = Test.NumOfSolved;
            lbl_timer.Text = $"{(DateTime.Now - Test.TimeStart).TotalMinutes.ToString("00")}:{(DateTime.Now - Test.TimeStart).Seconds.ToString("00")}";
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
