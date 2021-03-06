﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyNotebook.Models
{
    [Serializable]
    public class TextMission : MissionBase
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public override string String_AnswerExpecting { get; set; }
        public override string String_AnswerGiven 
        {
            get
            {
                return AnswerGiven;
            }
            set
            {
                AnswerGiven = value;
            }
        }

        public string AnswerGiven;
        public override bool IsSolvedRight()
        {
            if (isSolvedRight != null)
            {
                return isSolvedRight.Invoke(AnswerGiven);
            }
            else
            {
                return AnswerGiven == Answer;
            }
        }

        public void FinishMission(string answer)
        {
            AnswerGiven = answer;
            TimeMissionSolved = DateTime.Now;
        }

        public override bool IsSolved()
        {
            return !string.IsNullOrEmpty(AnswerGiven);
        }

        public override TabPage GetTabPage(bool showAnswerAtOnce)
        {
            string beginText = "Введите ответ";
            TabPage tp = new TabPage(ToString());

            StartMonitorTabPageActiveCountTime(tp);

            #region create question label
            Label lbl_question = new Label()
            {
                Text = NumOfMission + ". " + Question,
                AutoSize = true,
                Font = new Font("Arial", 13),
                Location = new Point(15, 15)
            };
            #endregion

            #region create answer textbox
            TextBox txtbx_answer = new TextBox()
            {
                Text = beginText,
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
                if (string.IsNullOrWhiteSpace(txtbx_answer.Text) || txtbx_answer.Text == beginText)
                {
                    return;
                }


                FinishMission(answer: txtbx_answer.Text);

                btn_answer.Enabled = false;
                txtbx_answer.Enabled = false;

                if (!showAnswerAtOnce)
                {
                    btn_answer.Text = "Ответ принят";
                    btn_answer.BackColor = Color.Gray;
                    tp.Text = "*";
                }
                else
                {
                    btn_answer.Text = IsSolvedRight() ? "Верно" : $"Ошибка ({this.Answer})";
                    btn_answer.BackColor = IsSolvedRight() ? Color.Green : Color.Red;
                    tp.Text = IsSolvedRight() ? "✓" : "✖";
                }
            };

            txtbx_answer.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btn_answer.PerformClick();
                }
            };

            #endregion

            tp.Controls.Add(lbl_question);
            tp.Controls.Add(txtbx_answer);
            tp.Controls.Add(btn_answer);

            return tp;
        }

        public override TabPage GetSolvedTabPage()
        {
            string beginText = "Введите ответ";
            TabPage tp = new TabPage(ToString());

            #region create question label
            Label lbl_question = new Label()
            {
                Text = NumOfMission + ". " + Question,
                AutoSize = true,
                Font = new Font("Arial", 13),
                Location = new Point(15, 15)
            };
            #endregion

            #region create answer textbox
            TextBox txtbx_answer = new TextBox()
            {
                Text = beginText,
                Dock = DockStyle.Bottom,
                Font = new System.Drawing.Font("Microsoft Sans Serif", 13.25F),
                Location = new System.Drawing.Point(9, 359)
            };
            txtbx_answer.Text = AnswerGiven;
            txtbx_answer.Enabled = false;
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

            tp.Text = IsSolvedRight() ? "✓" : "✖";

            #endregion

            tp.Controls.Add(lbl_question);
            tp.Controls.Add(txtbx_answer);
            tp.Controls.Add(btn_answer);

            return tp;
        }

        public override string GetHTMLResult()
        {
            string html = "";
            html += $"<h2>{Question}</h2>";
            html += $"<p>Время затрачено на решение: {TimeSpanOnMissionSeconds} секунд</p>";
            html += $"<p>Ответ ожидался: {String_AnswerExpecting}</p>";
            html += $"<p>Ответ дан: {String_AnswerGiven}</p>";
            return html;
        }

        public override string AppendHTMLMission(string pathToFolder)
        {
            string html = "";
            html += $"<div>" +
                    $"  {string.Join("<br>", Question.Split('\n'))}" +
                    $"<br>" +
                    $"  Ответ: ____________________" +
                    $"</div>";
            return html;
        }

        /// <summary>
        /// Constructor for Text mission
        /// </summary>
        /// <param name="numOfMission"> number of mission in order </param>
        /// <param name="question"> formulated question </param>
        /// <param name="answer"> expected answer </param>
        public TextMission(int numOfMission, string title, string question, string answer)
        {
            this.Title = title;
            NumOfMission = numOfMission;
            Question = question;
            Answer = answer;
            String_AnswerExpecting = answer;
        }
        public delegate bool IsSolvedRightOver(string answerGiven);
        IsSolvedRightOver isSolvedRight;
        public TextMission(int numOfMission, string title, string question, string answer, IsSolvedRightOver solvedRight)
        {
            this.Title = title;
            NumOfMission = numOfMission;
            Question = question;
            Answer = answer;
            String_AnswerExpecting = answer;
            isSolvedRight = solvedRight;
        }

        public TextMission()
        {

        }
    }
}
