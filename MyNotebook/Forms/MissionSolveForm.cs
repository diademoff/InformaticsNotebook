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
                else if(test.AllMissons[i].MissionType == MissionType.Select)
                {
                    AddTabWithSelectMission(test.AllMissons[i]);
                }
            }
        }


        void AddTabWithTextMission(MissionBase mission)
        {
            TabPage tp = new TabPage(mission.ToString());
            tabControl.TabPages.Add(tp);

            #region create question label
            Label lbl_question = new Label()
            {
                Dock = DockStyle.Top,
                Text = mission.Text_Question,
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

                mission.Text_FinishMission(answer: txtbx_answer.Text);

                btn_answer.Enabled = false;
                txtbx_answer.Enabled = false;

                btn_answer.Text = mission.Text_IsSolvedRight ? "Верно" : "Ошибка";
                btn_answer.BackColor = mission.Text_IsSolvedRight ? Color.Green : Color.Red;

            };

            #endregion

            tp.Controls.Add(lbl_question);
            tp.Controls.Add(txtbx_answer);
            tp.Controls.Add(btn_answer);
        }
        void AddTabWithMatchMission(MissionBase mission)
        {
            TabPage tp = new TabPage(mission.ToString());
            tp.AutoScroll = true;
            tabControl.TabPages.Add(tp);

            Label lbl_title = new Label()
            {
                Text = "", 
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopCenter,
                AutoSize = false,
                Font = new Font("Arial", 20)
            };

            List<Label> lbl_definitions = new List<Label>();
            List<ComboBox> cb_terms = new List<ComboBox>();
            int shiftY = 40;
            for (int i = 0; i < mission.Match_Definitions.Length; i++)
            {
                #region create combobox
                var cb = new ComboBox()
                {
                    Location = new Point(20, (i * 40) + shiftY),
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Width = 170
                };
                for (int j = 0; j < mission.Match_Terms.Length; j++)
                {
                    cb.Items.Add($"{j + 1}. {mission.Match_Terms[j]}"); //{numOfAnswer}{separator} {term}
                }
                cb_terms.Add(cb);
                #endregion

                #region create lbl definishion
                Label lbl = new Label()
                {
                    Location = new Point(200, (i * 40) + shiftY),
                    AutoSize = true,
                    Font = new Font("Arial", 10)
                };
                #region new line in Definition
                for (int j = 85; j < mission.Match_Definitions[i].Length; j += 85)
                {
                    mission.Match_Definitions[i] = mission.Match_Definitions[i].Insert(j, "\n");
                    shiftY += 20;
                }
                #endregion
                lbl.Text = mission.Match_Definitions[i];
                lbl_definitions.Add(lbl);
                #endregion
            }

            #region create answer btn
            Button btn_answer = new Button()
            {
                Dock = DockStyle.Bottom,
                UseVisualStyleBackColor = true,
                FlatStyle = FlatStyle.Flat,
                Text = "Готово"
            };
            btn_answer.Click += (s, e) =>
            {
                int[] answerGiven = new int[cb_terms.Count];
                bool allInput = true;
                for (int i = 0; i < cb_terms.Count; i++)
                {
                    try
                    {
                        answerGiven[i] = Convert.ToInt32(cb_terms[i].Text.Split('.')[0]);
                    }
                    catch
                    {
                        allInput = false;
                        break;
                    }
                }
                if (!allInput)
                {
                    MessageBox.Show("Вы выбрали не все значения", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                mission.Match_FinishMission(answerGiven);

                btn_answer.Enabled = false;
                cb_terms.ForEach(x => x.Enabled = false);

                btn_answer.Text = mission.Match_IsSolvedRight ? "Верно" : "Ошибка";
                btn_answer.BackColor = mission.Match_IsSolvedRight ? Color.Green : Color.Red;

            };
            #endregion

            tp.Controls.Add(btn_answer);
            tp.Controls.AddRange(lbl_definitions.ToArray());
            tp.Controls.AddRange(cb_terms.ToArray());
            tp.Controls.Add(lbl_title);
        }
        void AddTabWithSelectMission(MissionBase mission)
        {
            TabPage tp = new TabPage(mission.ToString());
            tp.AutoScroll = true;

            Label lbl_title = new Label()
            {
                Text = mission.Select_Tasktext,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopCenter,
                AutoSize = false,
                Font = new Font("Arial", 13)
            };

            List<CheckBox> checkboxes = new List<CheckBox>();
            for (int i = 0; i < mission.Select_Answers.Length; i++)
            {
                CheckBox checkBox = new CheckBox()
                {
                    Location = new Point(20, (i * 40) + 40),
                    Text = $"{i + 1}. {mission.Select_Answers[i]}",
                    Checked = false,
                    Font = new Font("Arial", 10),
                    AutoSize = true
                };

                checkboxes.Add(checkBox);
            }

            #region create answer btn
            Button btn_answer = new Button()
            {
                Dock = DockStyle.Bottom,
                UseVisualStyleBackColor = true,
                FlatStyle = FlatStyle.Flat,
                Text = "Готово"
            };
            btn_answer.Click += (s, e) =>
            {
                List<int> answerGiven = new List<int>();
                for (int i = 0; i < checkboxes.Count; i++)
                {
                    if (checkboxes[i].Checked)
                    {
                        answerGiven.Add(i);
                    }
                }

                answerGiven.Sort();

                mission.Select_FinishMission(answerGiven.ToArray());

                btn_answer.Enabled = false;
                checkboxes.ForEach(x => x.Enabled = false);

                btn_answer.Text = mission.Select_IsSolvedRight ? "Верно" : "Ошибка";
                btn_answer.BackColor = mission.Select_IsSolvedRight ? Color.Green : Color.Red;

            };
            #endregion

            tp.Controls.AddRange(checkboxes.ToArray());
            checkboxes.ForEach(x => x.BringToFront());
            tp.Controls.Add(lbl_title); 
            tp.Controls.Add(btn_answer);
            tabControl.TabPages.Add(tp);
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
