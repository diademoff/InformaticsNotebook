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
        public bool IsMistakesCorrection;
        public FormMissionSolve(User user, Test test, bool isMistakesCorrection)
        {
            InitializeComponent();
            StyleApply.ForForm(this);
            IsMistakesCorrection = isMistakesCorrection;
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
            var showType = test.ShowType;
            if (isMistakesCorrection)
            {
                showType = TestShowType.OnOneForm;
            }
            this.Shown += (s, e) =>
            {
                UpdateUI();

                switch (showType)
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
            };

            System.Windows.Forms.Timer uiUpdater = new System.Windows.Forms.Timer()
            {
                Interval = 100,
                Enabled = true
            };
            uiUpdater.Tick += (s, e) => UpdateUI();            
        }

        void ShowMissionsOneByOne(Test test)
        {
            if (test.RandomOrder)
            {
                test.AllMissions = test.AllMissions.OrderBy(x => rnd.Next()).ToList(); //shuffle list
            }

            new Thread(() =>
            {
                int num = 1;
                for (int i = 0; i < test.AllMissions.Count; i++)
                {
                    object indexOfCurrMission = i; // номер миссии

                    TabPage tab = test.AllMissions[i].GetTabPage(showAnswerAtOnce: Test.ShowAnswerAtOnce); // создем tab миссии
                    tab.Text = num.ToString();
                    tab.AutoScroll = true;
                    num++;
                    this.Invoke(new MethodInvoker(() =>
                    {
                        tabControl.TabPages.Add(tab);
                    }));
                    while (!test.AllMissions[(int)indexOfCurrMission].IsSolved())
                    {
                        if (Test.Finished)
                        {
                            return;
                        }
                        Thread.Sleep(200);
                    }
                    Thread.Sleep(800);
                    this.Invoke(new MethodInvoker(() =>
                    {
                        tabControl.TabPages.Remove(tab);
                    }));
                }
                ShowResult();
            }).Start();
        }

        void ShowResult()
        {
            if (IsMistakesCorrection)
            {
                this.Close();
                return;
            }
            this.FullHideForm();
            Test.FinishTest();

            FormTestResult trf = new FormTestResult(Test, CurrentUser);
            trf.ShowDialog();
        }

        Random rnd = new Random();
        void ShowMissionsBlocksOneByOne(Test test)
        {
            if (test.RandomOrder)
            {
                test.AllMissions = test.AllMissions.OrderBy(x => rnd.Next()).ToList(); //shuffle list
            }

            new Thread(() =>
            {
                int num = 1;
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

                   
                    List<MissionBase> missionsOnCurrentForm = new List<MissionBase>();
                    List<TabPage> tabs = new List<TabPage>();
                    List<int> indexesOfMissions = new List<int>();
                    // заполняем subtab
                    for (int j = i; j < test.AllMissions.Count; j++)
                    {
                        if (test.AllMissions[j].NumOfMission == currNumOfMission) // выбираем только миссии с текущим номером
                        {
                            TabPage tab = test.AllMissions[j].GetTabPage(showAnswerAtOnce: Test.ShowAnswerAtOnce); // создем tab миссии
                            tab.Text = num.ToString();
                            num++;
                            missionsOnCurrentForm.Add(test.AllMissions[j]);
                            indexesOfMissions.Add(j);
                            tabs.Add(tab); // добавляем tab
                        }
                    }

                    this.Invoke(new MethodInvoker(() =>
                    {
                        tabControl.TabPages.AddRange(tabs.ToArray());
                    }));
                    while (true)
                    {
                        bool allSolved = true;
                        for (int j = 0; j < indexesOfMissions.Count; j++)
                        {
                            if (!test.AllMissions[indexesOfMissions[j]].IsSolved())
                            {
                                allSolved = false;
                                break;
                            }
                        }
                        if (allSolved)
                        {
                            break;
                        }
                        if (Test.Finished)
                        {
                            return;
                        }
                        Thread.Sleep(200);
                    }
                    Thread.Sleep(800);
                    this.Invoke(new MethodInvoker(() =>
                    {
                        tabs.ForEach(x => tabControl.TabPages.Remove(x));
                    }));
                }

                ShowResult();
            }).Start();
        }

        void AddTabsWithMissions(Test test)
        {
            List<int> numOfMissionsAdded = new List<int>(); // уже  добавленные миссии
            int indexOfTab = 0; // текущий индекс "maintab"
            int num = 1;
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
                        tab.Text = num.ToString();
                        num++;
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

            ShowResult();
        }
    }
}