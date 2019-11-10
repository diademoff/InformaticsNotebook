using MyNotebook.Forms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNotebook.Models.MissionTypes
{
    [Serializable]
    public class ChoosePictureMission : MissionBase
    {
        string Question;
        bool AnswerGiven = false;
        Bitmap[] Pictures;
        int IndexOfRightAnswer;
        int IndexOfAnswerGiven;

        public override string String_AnswerExpecting { get; set; }
        public override string String_AnswerGiven => (IndexOfAnswerGiven + 1).ToString();

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
            MaxNumInTest = 4;
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
                    AnswerGiven = true;
                    IndexOfAnswerGiven = (int)currIndex;

                    if (!showAnswerAtOnce)
                    {
                        tp.Text = "*";
                    }
                    else
                    {
                        tp.Text = IsSolvedRight() ? "✓" : "✖";
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
                    if (IsAnswerGiven())
                    {
                        return;
                    }
                    isBigger = true;
                    picture.Width -= animationStrength;
                    picture.Height -= animationStrength;
                    new Task(() =>
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                        if (isBigger)
                        {
                            if (!isAnyPictureOpend && !AnswerGiven)
                            {
                                Bitmap clone = currPicture.Clone() as Bitmap;
                                isAnyPictureOpend = true;
                                var win = new BitmapViewer(clone)
                                {
                                    TopMost = true
                                };
                                win.LostFocus += (se, ev) => win.Close();
                                win.ShowDialog();
                                isAnyPictureOpend = false;
                            }
                        }
                    }).Start();
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

            tp.Controls.AddRange(pictures.ToArray());
            tp.Controls.Add(lbl_title);

            return tp;
        }

        public override bool IsAnswerGiven()
        {
            return AnswerGiven;
        }

        public override bool IsSolvedRight()
        {
            if (!IsAnswerGiven())
            {
                return false;
            }
            return IndexOfAnswerGiven == IndexOfRightAnswer;
        }
    }
}
