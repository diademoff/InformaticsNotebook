using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyNotebook.Models
{
    [Serializable]
    public class MatchMission : MissionBase
    {
        public string[] Terms { get; private set; }
        public string[] Definitions { get; private set; }

        public int[] Answer { get; private set; }
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
            if (AnswerGiven.Length != Answer.Length)
            {
                return false;
            }
            for (int i = 0; i < Answer.Length; i++)
            {
                if (Answer[i] != AnswerGiven[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override bool IsAnswerGiven()
        {
            if (AnswerGiven == null)
            {
                return false;
            }
            return AnswerGiven.Length > 0;
        }

        public override TabPage GetTabPage(bool showAnswerAtOnce)
        {
            TabPage tp = new TabPage(this.ToString());
            tp.AutoScroll = true;
            

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
            for (int i = 0; i < Definitions.Length; i++)
            {
                #region create combobox
                var cb = new ComboBox()
                {
                    Location = new Point(20, (i * 40) + shiftY),
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Width = 170
                };
                for (int j = 0; j < Terms.Length; j++)
                {
                    cb.Items.Add($"{j + 1}. {Terms[j]}"); //{numOfAnswer}{separator} {term}
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
                for (int j = 85; j < Definitions[i].Length; j += 85)
                {
                    Definitions[i] = Definitions[i].Insert(j, "\n");
                    shiftY += 20;
                }
                #endregion
                lbl.Text = Definitions[i];
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


                FinishMission(answerGiven);

                btn_answer.Enabled = false;
                cb_terms.ForEach(x => x.Enabled = false);

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

            tp.Controls.Add(btn_answer);
            tp.Controls.AddRange(lbl_definitions.ToArray());
            tp.Controls.AddRange(cb_terms.ToArray());
            tp.Controls.Add(lbl_title);

            return tp;
        }

        /// <summary>
        /// Constructor for match mission
        /// </summary>
        /// <param name="numOfMission"> number of mission in order </param>
        /// <param name="terms"> terms in this mission </param>
        /// <param name="defenitions"> defenition for each term </param>
        /// <param name="answer"></param>
        public MatchMission(int numOfMission, string title, string[] terms, string[] defenitions, int[] answer)
        {
            if (defenitions.Length != terms.Length)
            {
                throw new ArgumentException($"{nameof(terms)} length != {nameof(defenitions)} length");
            }

            this.Title = title;
            NumOfMission = numOfMission;
            Terms = terms;
            Definitions = defenitions;
            Answer = answer;
        }
    }
}
