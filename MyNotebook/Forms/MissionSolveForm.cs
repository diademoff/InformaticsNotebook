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
        public User CurrentUser { get; set; }
        public Test Test;

        public MissionSolveForm(User user, Test test)
        {
            InitializeComponent();
            
            CurrentUser = user;
            this.Test = test;
            this.Shown += (s, e) =>
            {
                new Task(() => StartTimer()).Start();
                UpdateUI();
            };
            AddTabsWithMissions(test);
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
            for (int i = 0; i < test.AllMissons.Count; i++)
            {
                if (test.AllMissons[i].MissionType == MissionType.Text)
                {
                    AddTabWithTextMission(test.AllMissons[i]);
                }
                else if (test.AllMissons[i].MissionType == MissionType.Match)
                {
                    AddTabWithMatchMission(test.AllMissons[i]);
                }
            }
        }

        private void AddTabWithMatchMission(MissionBase mission)
        {
            TabPage tp = new TabPage(mission.ToString());
            tabControl.TabPages.Add(tp);

            List<Label> terms = new List<Label>();
            List<Label> answers = new List<Label>();
            List<TextBox> inputAnswer = new List<TextBox>();
            int numOfNewLinePrevious = 0;
            for (int i = 0; i < mission.Terms.Length; i++)
            {
                #region term labels
                int index = i;
                string term = mission.Terms[i];

                var lastYLocation = 10;
                if (terms.Count >= 1)
                {
                    lastYLocation = terms.Last().Location.Y;
                }
                

                terms.Add(new Label()
                {
                    Text = $"{index + 1}. {term}",
                    AutoSize = true,
                    Font = new Font("Arial", 10),
                    Location = new Point(20, lastYLocation + 20 + (numOfNewLinePrevious * 35))
                });
                #endregion

                #region answer labels
                answers.Add(new Label()
                {
                    AutoSize = true,
                    Font = new Font("Arial", 10),
                    Location = new Point(350, lastYLocation + 20 + (numOfNewLinePrevious * 35))
                });

                string def = mission.Definitions[i];
                numOfNewLinePrevious = 0;
                if (def.Length > 70)
                {
                    for (int j = 70; j < def.Length; j += 70)
                    {
                        def = def.Insert(j, "\n");
                        numOfNewLinePrevious++;
                    }
                }

                answers.Last().Text = def;
                #endregion

                #region input textbox
                inputAnswer.Add(new TextBox()
                {
                    AutoSize = true,
                    Font = new Font("Arial", 10),
                    Location = new Point(220, terms.Last().Location.Y)
                });
                #endregion
            }

            #region create answer button

            Button btn_answer = new Button()
            {
                Size = new Size(91, 28),
                Location = new Point(691, 359),
                Dock = DockStyle.Bottom,
                UseVisualStyleBackColor = true,
                FlatStyle = FlatStyle.Flat,
                Text = "Готово"
            };
            btn_answer.Click += (s, e) =>
            {
                bool isAllInput = true;
                for (int j = 0; j < inputAnswer.Count; j++)
                {
                    if (string.IsNullOrWhiteSpace(inputAnswer[j].Text))
                    {
                        inputAnswer[j].ErrorTextBox();
                        isAllInput = false;
                    }
                }
                if (!isAllInput)
                {
                    return;
                }

                #region disable elements
                for (int j = 0; j < inputAnswer.Count; j++)
                {
                    inputAnswer[j].Enabled = false;
                }
                btn_answer.Enabled = false;
                #endregion
                List<int> answerGiven = new List<int>();
                #region get answer given
                for (int i = 0; i < inputAnswer.Count; i++)
                {
                    answerGiven.Add(int.Parse(inputAnswer[i].Text));
                }
                #endregion

                mission.TimeMissionSolved = DateTime.Now;
                mission.MatchAnswerGiven = answerGiven.ToArray();

                btn_answer.Text = mission.MatchIsSolvedRight ? "Верно" : "Ошибка";
                btn_answer.BackColor = mission.MatchIsSolvedRight ? Color.Green : Color.Red;

                CurrentUser.UserTests.Last().MissionsPassed.Add(mission);
            };

            #endregion

            tp.Controls.AddRange(terms.ToArray());
            tp.Controls.AddRange(answers.ToArray());
            tp.Controls.AddRange(inputAnswer.ToArray());
            tp.Controls.Add(btn_answer);
        }

        void AddTabWithTextMission(MissionBase mission)
        {
            TabPage tp = new TabPage(mission.ToString());
            tabControl.TabPages.Add(tp);

            #region create question label
            Label lbl_question = new Label()
            {
                Dock = DockStyle.Top,
                Text = mission.Question,
                AutoSize = true,
                Font = new Font("Arial", 13)
            };
            #endregion

            #region create answer textbox
            TextBox txtbx_answer = new TextBox()
            {
                Text = "Введите ответ",
                Dock = DockStyle.Bottom,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F),
                Location = new System.Drawing.Point(9, 359)
            };
            txtbx_answer.UpperTextBox();
            txtbx_answer.Click += Txtbx_answer_Click;
            void Txtbx_answer_Click(object sender, EventArgs e)
            {
                txtbx_answer.Text = "";
                txtbx_answer.Click -= Txtbx_answer_Click;
            }
            #endregion

            #region create button answer

            Button btn_answer = new Button()
            {
                Size = new Size(91, 28),
                Location = new Point(691, 359),
                Dock = DockStyle.Bottom,
                UseVisualStyleBackColor = true,
                FlatStyle = FlatStyle.Flat,
                Text = "Готово"
            };
            btn_answer.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtbx_answer.Text))
                {
                    return;
                }

                mission.TimeMissionSolved = DateTime.Now;
                mission.TextAnswerGiven = txtbx_answer.Text;

                btn_answer.Enabled = false;
                txtbx_answer.Enabled = false;

                btn_answer.Text = mission.TextIsSolvedRight ? "Верно" : "Ошибка";
                btn_answer.BackColor = mission.TextIsSolvedRight ? Color.Green : Color.Red;

                CurrentUser.UserTests.Last().MissionsPassed.Add(mission);
            };

            #endregion

            tp.Controls.Add(lbl_question);
            tp.Controls.Add(txtbx_answer);
            tp.Controls.Add(btn_answer);
        }

        void UpdateUI()
        {
            lbl_user.Text = CurrentUser.ToString();

            lbl_isCalcBlockEnabled.ForeColor = Test.IsCalcBlockEnabled ? Color.Green : Color.Red;
            lbl_isCalcBlockEnabled.Text = Test.IsCalcBlockEnabled ? "Блокировка калькулятора включена" : "Блокировка калькулятора выключена";
        }

        private void Btn_finishTest_Click(object sender, EventArgs e)
        {
            Test.FinishTest();
            this.FullHideForm();
            TestResultForm trf = new TestResultForm(Test);
            trf.ShowDialog();
            this.Close();
        }
    }
}
