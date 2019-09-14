using MyNotebook.Models;
using MyNotebook.ViewModels;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyNotebook.Forms
{
    public partial class MissionSolveForm : Form
    {
        public User CurrentUser { get; set; }

        public MissionSolveForm(User user, int[] numOfMissions)
        {
            InitializeComponent();
            CurrentUser = user;
            this.Shown += (s, e) => UpdateUI();
            AddTabsWithMissions(numOfMissions);
        }

        private void AddTabsWithMissions(int[] numOfMissions)
        {
            for (int i = 0; i < numOfMissions.Length; i++)
            {
                if (numOfMissions[i] == 1)
                {
                    AddTabWithMission(new Mission1().Generate());
                }
                if (numOfMissions[i] == 2)
                {
                    AddTabWithMission(new Mission2().Generate());
                }
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

                CurrentUser.MissionsDone.Add(mission);
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
