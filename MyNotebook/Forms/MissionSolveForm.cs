using MyNotebook.Models;
using MyNotebook.ViewModels;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MyNotebook.Forms
{
    public partial class MissionSolveForm : Form
    {
        public User CurrentUser { get; set; }

        public MissionSolveForm(User user, Test test)
        {
            InitializeComponent();
            CurrentUser = user;
            this.Shown += (s, e) => UpdateUI();
            AddTabsWithMissions(test);
        }

        private void AddTabsWithMissions(Test test)
        {
            for (int i = 0; i < test.AllMissons.Count; i++)
            {
                AddTabWithMission(test.AllMissons[i]);
            }
        }

        void AddTabWithMission(Mission mission)
        {
            TabPage tp = new TabPage(mission.NumOfMission.ToString());
            tabControl.TabPages.Add(tp);

            #region create question label
            Label lbl_question = new Label()
            {
                Dock = DockStyle.Top,
                Text = mission.Question,
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

                mission.Solved = DateTime.Now;
                mission.AnswerGiven = txtbx_answer.Text;

                btn_answer.Enabled = false;
                txtbx_answer.Enabled = false;

                btn_answer.Text = mission.IsSolvedRight ? "Верно" : "Ошибка";
                btn_answer.BackColor = mission.IsSolvedRight ? Color.Green : Color.Red;

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
        }
    }
}
