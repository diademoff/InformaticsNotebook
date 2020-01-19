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
    public partial class FormMissionSolve : Form
    {
        int MissionsLeft => Test.AllMissions.Count - Test.NumOfSolved;
        public User CurrentUser { get; set; }
        public Test Test;

        public FormMissionSolve(User user, Test test)
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

            switch (test.ShowType)
            {
                case TestShowType.OneByOneBlocks:
                    ShowMissionsBlocksOneByOne(test);
                    break;
                case TestShowType.OneByOneMissions:
                    ShowMissionsOneByOne(test);
                    break;
                case TestShowType.OnOneForm:
                    AddTabsWithMissions(test);
                    break;
                default:
                    throw new Exception("Unknown show type for test");
            }
        }

        private void ShowMissionsOneByOne(Test test)
        {
            this.FullHideForm();
            if (test.RandomOrder)
            {
                test.AllMissions = test.AllMissions.OrderBy(x => rnd.Next()).ToList(); //shuffle list
            }

            for (int i = 0; i < test.AllMissions.Count; i++)
            {
                object indexOfCurrMission = i; // номер миссии

                // создаём форму для показа блока миссий
                Form previewForm = new Form()
                {
                    Width = 800,
                    Height = 500,
                    Icon = Properties.Resources.icon,
                    StartPosition = FormStartPosition.CenterScreen,
                    Text = $"Задание {i + 1} из {test.AllMissions.Count}. \"{test.AllMissions[i].ToString()}\""
                };
                previewForm.Controls.Add(new Panel()
                {
                    Name = "pnl_status",
                    Dock = DockStyle.Top,
                    Height = 20
                });
                previewForm.Controls["pnl_status"].Controls.Add(new ProgressBar()
                {
                    Value = i + 1,
                    Maximum = test.AllMissions.Count,
                    Dock = DockStyle.Top,
                    Height = 3
                });

                previewForm.Controls["pnl_status"].Controls.Add(new Label()
                {
                    Location = new Point(3, 0),
                    Text = CurrentUser.Name
                });

                if (test.IsTopMost)
                {
                    previewForm.WindowState = FormWindowState.Maximized;
                    previewForm.FormBorderStyle = FormBorderStyle.None;
                    previewForm.TopMost = true;
                }


                TabControl MainTab = new TabControl()
                {
                    Dock = DockStyle.Fill
                };
                TabPage tab = test.AllMissions[i].GetTabPage(showAnswerAtOnce: Test.ShowAnswerAtOnce); // создем tab миссии
                tab.Text = test.AllMissions[(int)indexOfCurrMission].NumOfMission.ToString();
                tab.AutoScroll = true;

                MainTab.TabPages.Add(tab); // добавляем tab


                // добавляем созданный ранее таб
                previewForm.Controls.Add(MainTab);
                MainTab.BringToFront();
                MainTab.BringToFront();
                MainTab.BringToFront();

                // показываем форму
                new Task(() =>
                {
                    while (true)
                    {
                        if (test.AllMissions[(int)indexOfCurrMission].IsSolved())
                        {
                            previewForm.Invoke(new MethodInvoker(() =>
                            {
                                previewForm.Close();
                            }));
                            break;
                        }
                        Thread.Sleep(350);
                    }
                }).Start();
                previewForm.ShowDialog();
            }

            this.FullHideForm();
            Test.FinishTest();
            FormTestResult trf = new FormTestResult(Test, CurrentUser);
            trf.ShowDialog();
            this.Close();
        }

        Random rnd = new Random();
        void ShowMissionsBlocksOneByOne(Test test)
        {
            this.FullHideForm();
            if (test.RandomOrder)
            {
                test.AllMissions = test.AllMissions.OrderBy(x => rnd.Next()).ToList(); //shuffle list
            }

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

                TabControl subTab = new TabControl()
                {
                    Width = 880,
                    Height = 430,
                    Location = new Point(5, 5),
                    Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                    Dock = DockStyle.Fill
                };

                List<MissionBase> missionsOnCurrentForm = new List<MissionBase>();

                // создаём форму для показа блока миссий
                Form previewForm = new Form()
                {
                    Width = 800,
                    Height = 500,
                    Icon = Properties.Resources.icon,
                    StartPosition = FormStartPosition.CenterScreen,
                    Text = $"Задание {i + 1} из {test.AllMissions.Count}. \"{test.AllMissions[i].ToString()}\""
                };


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
                        TabPage tab = test.AllMissions[j].GetTabPage(showAnswerAtOnce: Test.ShowAnswerAtOnce); // создем tab миссии
                        tab.Text = currNumOfMission.ToString();
                        missionsOnCurrentForm.Add(test.AllMissions[j]);
                        subTab.TabPages.Add(tab); // добавляем tab
                    }
                }


                // добавляем созданный ранее таб
                previewForm.Controls.Add(subTab);

                // создаём кнопку для завершения блока
                Button btn = new Button()
                {
                    Text = "Завершить блок",
                    Dock = DockStyle.Bottom
                };
                btn.Click += (s, e) =>
                {
                    bool areAllSolved = true;
                    foreach (MissionBase m in missionsOnCurrentForm)
                    {
                        if (!m.IsSolved())
                        {
                            areAllSolved = false;
                            break;
                        }
                    }
                    if (!areAllSolved)
                    {
                        bool agree = MessageBox.Show("Вы решили не все задания в этом блоке. Хотите продолжить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes;
                        if (agree)
                        {
                            btn.Enabled = false;
                            previewForm.Close();
                        }
                    }
                    else
                    {
                        btn.Enabled = false;
                        previewForm.Close();
                    }
                };
                previewForm.Controls.Add(btn);

                // показываем форму
                previewForm.ShowDialog();

                //resultTabControl.TabPages.Add(subTab.TabPages[0]);
            }

            this.FullHideForm();
            Test.FinishTest();
            FormTestResult trf = new FormTestResult(Test, CurrentUser);
            trf.ShowDialog();
            this.Close();
        }

        void AddTabsWithMissions(Test test)
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
                TabControl subTab = new TabControl()
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
                        TabPage tab = test.AllMissions[j].GetTabPage(showAnswerAtOnce: Test.ShowAnswerAtOnce); // создем tab миссии
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
                                if (!test.AllMissions[j].IsSolved())
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
        void Btn_finishTest_Click(object sender, EventArgs e)
        {
            if (MissionsLeft > 0)
            {
                DialogResult ans = MessageBox.Show("Вы решили не все задания. Хотите продолжить?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (ans == DialogResult.No)
                {
                    return;
                }
            }

            Test.FinishTest();
            this.FullHideForm();
            FormTestResult trf = new FormTestResult(Test, CurrentUser);
            trf.ShowDialog();
            this.Close();
        }
    }
}
