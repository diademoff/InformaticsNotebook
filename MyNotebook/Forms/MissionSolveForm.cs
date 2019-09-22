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
            tp.AutoScroll = true;
            tabControl.TabPages.Add(tp);

            Label lbl_title = new Label()
            {
                Text = "Соотнесите определения и термины",
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopCenter,
                AutoSize = false,
                Font = new Font("Arial", 20)
            };

            List<Label> lbl_definitions = new List<Label>();
            List<ComboBox> cb_terms = new List<ComboBox>();
            int shiftY = 40;
            for (int i = 0; i < mission.Definitions.Length; i++)
            {
                #region create combobox
                var cb = new ComboBox()
                {
                    Location = new Point(20, (i * 40) + shiftY),
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Width = 170
                };
                for (int j = 0; j < mission.Terms.Length; j++)
                {
                    cb.Items.Add($"{j + 1}. {mission.Terms[j]}"); //{numOfAnswer}{separator} {term}
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
                for (int j = 85; j < mission.Definitions[i].Length; j += 85)
                {
                    mission.Definitions[i] = mission.Definitions[i].Insert(j, "\n");
                    shiftY += 20;
                }
                #endregion
                lbl.Text = mission.Definitions[i];
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


                mission.FinishMatchMission(answerGiven);

                btn_answer.Enabled = false;
                cb_terms.ForEach(x => x.Enabled = false);

                btn_answer.Text = mission.MatchIsSolvedRight ? "Верно" : "Ошибка";
                btn_answer.BackColor = mission.MatchIsSolvedRight ? Color.Green : Color.Red;

            };
            #endregion

            tp.Controls.Add(btn_answer);
            tp.Controls.AddRange(lbl_definitions.ToArray());
            tp.Controls.AddRange(cb_terms.ToArray());
            tp.Controls.Add(lbl_title);
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

                mission.FinishTextMission(answer:txtbx_answer.Text);

                btn_answer.Enabled = false;
                txtbx_answer.Enabled = false;

                btn_answer.Text = mission.TextIsSolvedRight ? "Верно" : "Ошибка";
                btn_answer.BackColor = mission.TextIsSolvedRight ? Color.Green : Color.Red;

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
