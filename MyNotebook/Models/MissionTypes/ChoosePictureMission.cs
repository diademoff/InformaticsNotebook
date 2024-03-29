﻿using MyNotebook.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace MyNotebook.Models.MissionTypes
{
    [Serializable]
    public class ChoosePictureMission : MissionBase
    {
        public string Question;
        public bool AnswerGiven = false;
        Bitmap[] Pictures;
        public int IndexOfRightAnswer;
        public int IndexOfAnswerGiven;

        public override string String_AnswerExpecting { get => IndexOfRightAnswer.ToString(); set => IndexOfRightAnswer = int.Parse(value); }
        public override string String_AnswerGiven 
        {
            get
            {
                return IndexOfAnswerGiven.ToString();
            }
            set
            {
                IndexOfAnswerGiven = Convert.ToInt32(value);
            } 
        }


        public ChoosePictureMission()
        {

        }

        public ChoosePictureMission(int numOfMission, string title, string question, Bitmap[] pictures, int indexOfRightAnswer)
        {
            if (pictures.Length != 4)
            {
                throw new ArgumentException($"{nameof(pictures)} length must be 4");
            }
            if (string.IsNullOrWhiteSpace(question))
            {
                throw new Exception($"{nameof(question)} is null or empty");
            }

            NumOfMission = numOfMission;
            Title = title;
            Question = question;
            Pictures = pictures;
            String_AnswerExpecting = indexOfRightAnswer.ToString();
            IndexOfRightAnswer = indexOfRightAnswer;
        }

        public override TabPage GetTabPage(bool showAnswerAtOnce)
        {
            AnswerGiven = false;
            TabPage tp = new TabPage(ToString())
            {
                AutoScroll = true
            };

            StartMonitorTabPageActiveCountTime(tp);

            Label lbl_title = new Label()
            {
                Text = NumOfMission + ". " + Question,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopCenter,
                AutoSize = false,
                Font = new Font("Arial", 20)
            };
            Button give_answer = new Button()
            {
                Dock = DockStyle.Bottom,
                Text = "Выбрать"
            };

            PictureBox selector = new PictureBox()
            {
                Width = 150,
                Height = 10,
                BackColor = Color.Green,
                Location = new Point(-100, -100)
            };
            int pictureSelected = -1;
            List<PictureBox> pictures = new List<PictureBox>();
            bool isAnyPictureOpend = false;
            for (int i = 0; i < Pictures.Length; i++)
            {
                object currIndex = i;
                Bitmap currPicture = Pictures[i].Clone() as Bitmap;
                PictureBox picture = new PictureBox()
                {
                    Location = new Point((i * 125) + 50 * i + 50, 200),
                    Width = 150,
                    Height = 150,
                    BackgroundImage = new Bitmap(currPicture, new Size(150, 150))
                };
                picture.Click += (s, e) =>
                {
                    if (AnswerGiven)
                    {
                        return;
                    }

                    pictureSelected = (int)currIndex;
                    var thisPictute = (PictureBox)s;
                    selector.Location = new Point(thisPictute.Location.X, thisPictute.Location.Y + thisPictute.Width + 10);
                };

                picture.DoubleClick += (s, e) =>
                {
                    if (!isAnyPictureOpend && !AnswerGiven)
                    {
                        Bitmap clone = currPicture.Clone() as Bitmap;
                        isAnyPictureOpend = true;
                        var win = new FormBitmapViewer(clone)
                        {
                            TopMost = true
                        };
                        win.LostFocus += (se, ev) => win.Close();
                        win.ShowDialog();
                        isAnyPictureOpend = false;
                    }
                };

                bool isBigger = false;
                int animationStrength = 10;
                picture.MouseEnter += (s, e) =>
                {
                    if (isBigger)
                    {
                        return;
                    }
                    if (IsSolved())
                    {
                        return;
                    }
                    isBigger = true;
                    picture.Width -= animationStrength;
                    picture.Height -= animationStrength;
                };
                picture.MouseLeave += (s, e) =>
                {
                    if (!isBigger)
                    {
                        return;
                    }
                    isBigger = false;
                    picture.Width += animationStrength;
                    picture.Height += animationStrength;
                };

                pictures.Add(picture);
            }

            give_answer.Click += (s, e) =>
            {
                if (pictureSelected == -1)
                {
                    MessageBox.Show("Кликните на картинку чтобы выбрать ответ и приблизить её", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                give_answer.Enabled = false;
                AnswerGiven = true;
                IndexOfAnswerGiven = pictureSelected;
                TimeMissionSolved = DateTime.Now;

                if (!showAnswerAtOnce)
                {
                    tp.Text = "*";
                }
                else
                {
                    tp.Text = IsSolvedRight() ? "✓" : "✖";
                    give_answer.Text = IsSolvedRight() ? "Верно" : $"Ошибка ({IndexOfRightAnswer + 1})";
                }
            };

            tp.Controls.Add(selector);
            tp.Controls.Add(give_answer);
            tp.Controls.AddRange(pictures.ToArray());
            tp.Controls.Add(lbl_title);

            return tp;
        }
        public override TabPage GetSolvedTabPage()
        {
            TabPage tp = new TabPage(ToString())
            {
                AutoScroll = true
            };


            Label lbl_title = new Label()
            {
                Text = NumOfMission + ". " + Question,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.TopCenter,
                AutoSize = false,
                Font = new Font("Arial", 20)
            };
            Button give_answer = new Button()
            {
                Dock = DockStyle.Bottom,
                Text = "Выбрать"
            };

            PictureBox selector = new PictureBox()
            {
                Width = 150,
                Height = 10,
                BackColor = Color.Green,
                Location = new Point(-100, -100)
            };
            int pictureSelected = IndexOfAnswerGiven;
            List<PictureBox> pictures = new List<PictureBox>();
            try
            {

            for (int i = 0; i < Pictures.Length; i++)
            {
                object currIndex = i;
                Bitmap currPicture = Pictures[i].Clone() as Bitmap;
                PictureBox picture = new PictureBox()
                {
                    Location = new Point((i * 125) + 50 * i + 50, 200),
                    Width = 150,
                    Height = 150,
                    BackgroundImage = new Bitmap(currPicture, new Size(150, 150))
                };


                if (pictureSelected == i)
                {
                    pictureSelected = (int)currIndex;
                    selector.Location = new Point(picture.Location.X, picture.Location.Y + picture.Width + 10);
                }

                pictures.Add(picture);
            }

            }
            catch { }
            tp.Text = IsSolvedRight() ? "✓" : "✖";

            tp.Controls.Add(selector);
            tp.Controls.Add(give_answer);
            tp.Controls.AddRange(pictures.ToArray());
            tp.Controls.Add(lbl_title);

            return tp;
        }

        public override bool IsSolved()
        {
            return AnswerGiven;
        }

        public override bool IsSolvedRight()
        {
            if (!IsSolved())
            {
                return false;
            }
            return IndexOfAnswerGiven == IndexOfRightAnswer;
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
                    $"<h3>{Question}</h3>";
            for (int i = 0; i < Pictures.Length; i++)
            {
                html += $"<img src=\"{SavePictute(Pictures[i])}\" width=\"220\" height=\"200\">";
            }

            html += "</div>";

            return html;

            string SavePictute(Bitmap bitmap)
            {
                while (true)
                {
                    string fileName = rnd.Next() + ".jpg";
                    if (!File.Exists(Path.Combine(pathToFolder, fileName)))
                    {
                        bitmap.Save(Path.Combine(pathToFolder, fileName));
                        return fileName;
                    }
                }
            }
        }
    }
}
