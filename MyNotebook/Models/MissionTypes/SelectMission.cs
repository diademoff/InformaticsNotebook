using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MyNotebook.Models
{
    [Serializable]
    public class SelectMission : MissionBase
    {
        public string Tasktext { get; set; }
        public string[] Variants { get; set; }
        public int[] AnswerExpected { get; set; }

        public override string String_AnswerExpecting { get; set; }
        public override string String_AnswerGiven
        {
            get
            {
                if (AnswerGiven == null)
                {
                    return "";
                }
                return string.Join("", AnswerGiven);
            }
            set
            {
                AnswerGiven = new int[value.Length];
                for (int i = 0; i < value.Length; i++)
                {
                    AnswerGiven[i] = Convert.ToInt32(value[i]);
                }
            }
        }

        public int[] AnswerGiven;

        public void FinishMission(int[] answer)
        {
            AnswerGiven = answer;
            TimeMissionSolved = DateTime.Now;
        }

        public override bool IsSolvedRight()
        {
            if (AnswerGiven == null)
            {
                return false;
            }
            if (AnswerGiven.Length != AnswerExpected.Length)
            {
                return false;
            }
            for (int i = 0; i < AnswerExpected.Length; i++)
            {
                if (AnswerExpected[i] != AnswerGiven[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override bool IsSolved()
        {
            return AnswerGiven?.Length > 0;
        }

        public override TabPage GetTabPage(bool showAnswerAtOnce)
        {
            TabPage tp = new TabPage(ToString());
            tp.AutoScroll = true;

            StartMonitorTabPageActiveCountTime(tp);

            Label lbl_title = new Label()
            {
                Text = NumOfMission + ". " + Tasktext,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopCenter,
                AutoSize = false,
                Font = new Font("Arial", 13)
            };

            List<CheckBox> checkboxes = new List<CheckBox>();
            for (int i = 0; i < Variants.Length; i++)
            {
                CheckBox checkBox = new CheckBox()
                {
                    Location = new Point(20, (i * 40) + 40),
                    Text = $"{i + 1}. {Variants[i]}",
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

                if (answerGiven.Count == 0)
                {
                    MessageBox.Show("Вы ничего не выбрали", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                FinishMission(answerGiven.ToArray());

                btn_answer.Enabled = false;
                checkboxes.ForEach(x => x.Enabled = false);

                if (!showAnswerAtOnce)
                {
                    btn_answer.Text = "Ответ принят";
                    btn_answer.BackColor = Color.Gray;
                    tp.Text = "*";
                }
                else
                {
                    btn_answer.Text = IsSolvedRight() ? "Верно" : "Ошибка";
                    btn_answer.BackColor = IsSolvedRight() ? Color.Green : Color.Red;
                    tp.Text = IsSolvedRight() ? "✓" : "✖";
                }
            };
            #endregion

            tp.Controls.AddRange(checkboxes.ToArray());
            checkboxes.ForEach(x => x.BringToFront());
            tp.Controls.Add(lbl_title);
            tp.Controls.Add(btn_answer);

            return tp;
        }

        public override TabPage GetSolvedTabPage()
        {
            TabPage tp = new TabPage(ToString());
            tp.AutoScroll = true;

            Label lbl_title = new Label()
            {
                Text = NumOfMission + ". " + Tasktext,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopCenter,
                AutoSize = false,
                Font = new Font("Arial", 13)
            };

            List<CheckBox> checkboxes = new List<CheckBox>();
            for (int i = 0; i < Variants.Length; i++)
            {
                CheckBox checkBox = new CheckBox()
                {
                    Location = new Point(20, (i * 40) + 40),
                    Text = $"{i + 1}. {Variants[i]}",
                    Checked = false,
                    Font = new Font("Arial", 10),
                    AutoSize = true,
                    Enabled = false
                };

                if (AnswerGiven != null)
                {
                    if (AnswerGiven.Contains(i))
                    {
                        checkBox.Checked = true;
                    }
                }

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
            #endregion

            tp.Text = IsSolvedRight() ? "✓" : "✖";

            tp.Controls.AddRange(checkboxes.ToArray());
            checkboxes.ForEach(x => x.BringToFront());
            tp.Controls.Add(lbl_title);
            tp.Controls.Add(btn_answer);

            return tp;
        }

        public override string GetHTMLResult()
        {
            string html = "";
            html += $"<h1>{Tasktext}</h1>";
            html += $"<p>Время затрачено: {TimeSpanOnMissionSeconds} секунд</p>";
            html += $"<p>Варианты: {string.Join(", " ,Variants)}</p>";
            html += $"<p>Ответ дан: {String_AnswerGiven}, ответ ожидался: {String_AnswerExpecting}</p>";
            return html;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="numOfMission"></param>
        /// <param name="tasktext">in label on solve mission form</param>
        /// <param name="title">on select mission form</param>
        /// <param name="answers"></param>
        /// <param name="answerExpected"></param>
        public SelectMission(int numOfMission, string tasktext, string title, string[] answers, int[] answerExpected)
        {
            NumOfMission = numOfMission;
            Tasktext = tasktext;
            Title = title;
            Variants = answers;
            AnswerExpected = answerExpected;
            String_AnswerExpecting = string.Join("", answerExpected);
        }

        public SelectMission()
        {

        }
    }
}
