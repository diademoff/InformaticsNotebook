using MyNotebook.Models;
using System;
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
            AddTabsWithMissions(test);

            System.Windows.Forms.Timer uiUpdater = new System.Windows.Forms.Timer()
            {
                Interval = 100,
                Enabled = true
            };
            uiUpdater.Tick += (s, e) => UpdateUI();
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

        private void AddTabsWithMissions(Test test)
        {
            for (int i = 0; i < test.AllMissions.Count; i++)
            {
                AddTabWithMission(test.AllMissions[i]);
            }
        }

        void AddTabWithMission(MissionBase mission)
        {
            tabControl.TabPages.Add(mission.GetTabPage(showAnswerAtOnce:Test.ShowAnswerAtOnce));
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
