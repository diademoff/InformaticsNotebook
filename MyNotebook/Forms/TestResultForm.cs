using MyNotebook.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace MyNotebook.Forms
{
    public partial class TestResultForm : Form
    {
        Test Test;
        User User;
        public TestResultForm(Test test, User user)
        {
            InitializeComponent();
            Test = test;
            User = user;

            lbl_name.Text = user.Name;
            lbl_state.Text = test.Finished ? $"Статус: завершен" : "Статус: не завершен";
            lbl_timeStart.Text = "Время начала: " + test.TimeStart.ToString();
            lbl_timeEnd.Text = "Время завершения: " + test.TimeFinish.ToString();
            lbl_wasCalcDiabled.Text = test.IsCalcBlockEnabled ? "Калькулятор: заблокирован" : "Калькулятор: не заблокирован";
            lbl_timeSpend.Text = "Время затрачено: " + ($"{(Test.TimeFinish - Test.TimeStart).TotalMinutes.ToString("00")}:{(Test.TimeFinish - Test.TimeStart).Seconds.ToString("00")}");
            lbl_topmost.Text = test.IsTopMost ? "Монополный режим: включен" : "Монополный режим: выключен";

            int numOfSolved = 0;
            txtbx_log.Text += "Краткая информация:\n";
            int numOfprinted = 0;
            for (int i = 0; i < test.AllMissions.Count; i++)
            {
                var currMission = test.AllMissions[i];
                if (currMission.IsSolvedRight())
                {
                    numOfSolved += 1;
                    continue; //skip right solved missions
                }
                numOfprinted++;
                txtbx_log.Text += $"\t{currMission.ToString()}:\n";

                string answerGiven = currMission.String_AnswerGiven;

                txtbx_log.Text += $"\tЗатрачено времени: {currMission.TimeSpanOnMission.Seconds} сек\n";
                txtbx_log.Text += currMission.IsSolvedRight() ? $"\tЗадача решена верно\n" : "\tЗадача решена не верно\n";
                txtbx_log.Text += $"\tОтвет дан: {answerGiven}\n\n";
            }
            if (numOfprinted == 0)
            {
                txtbx_log.Text += "Всё решено верно";
            }
            lbl_solvedPercent.Text = $"Решено: {test.PercentSolved.ToString("#.##")}%";
            lbl_mark.Text = $"Оценка: {test.Mark}";

            DrawDiagramOnForm((decimal)numOfSolved, (decimal)(test.AllMissions.Count - numOfSolved));
        }

        public void DrawDiagramOnForm(decimal numOfrightAnswers, decimal numOfwrongAnswers)
        {
            Color myColor = this.BackColor;
            picture_diagram.Image = DiagramOnBitmap(myColor, 150, 150, numOfrightAnswers, numOfwrongAnswers);//Создаем картинку
        }

        public Bitmap DiagramOnBitmap(Color bgCol, int width, int height, decimal rightAnswers, decimal wrongAnswers)
        {
            // Создаем новый образ и стираем фон
            Bitmap mybit = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(mybit);
            SolidBrush brush = new SolidBrush(bgCol);
            graphics.FillRectangle(brush, 0, 0, width, height);
            brush.Dispose();

            decimal sumOfInput = rightAnswers + wrongAnswers;

            // Рисуем круговую диаграмму
            float startZ = 0.0f;
            float endZ = 0.0f;
            decimal current = 0.0m;

            current += rightAnswers;
            startZ = endZ;
            endZ = (float)(current / sumOfInput) * 360.0f;
            graphics.FillPie(new SolidBrush(Color.Green), 0.0f, 0.0f, width, height, startZ, endZ - startZ);

            current += wrongAnswers;
            startZ = endZ;
            endZ = (float)(current / sumOfInput) * 360.0f;
            graphics.FillPie(new SolidBrush(Color.Red), 0.0f, 0.0f, width, height, startZ, endZ - startZ);

            return mybit;
        }

        private void btn_preview_Click(object sender, System.EventArgs e)
        {
            Form previewForm = new Form();
            previewForm.Width = 800;
            previewForm.Height = 600;

            previewForm.Controls.Add(new TabControl()
            {
                Dock = DockStyle.Fill,
                Name = "tabControl"
            });
            
            List<int> numOfMissionsAdded = new List<int>();
            int indexOfTab = 0;
            for (int i = 0; i < Test.AllMissions.Count; i++)
            {
                if (numOfMissionsAdded.Contains(Test.AllMissions[i].NumOfMission) || Test.AllMissions[i].IsSolvedRight())
                {
                    continue;
                }
                int currNumOfMission = Test.AllMissions[i].NumOfMission;
                numOfMissionsAdded.Add(currNumOfMission);
               
                var subTab = new TabControl()
                {
                    Width = 880,
                    Height = 430,
                    Location = new Point(5, 5),
                    Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right,
                    Dock = DockStyle.Fill
                };

                for (int j = i; j < Test.AllMissions.Count; j++)
                {
                    if (Test.AllMissions[j].NumOfMission == currNumOfMission) 
                    {
                        var tab = Test.AllMissions[j].GetSolvedTabPage(); 
                        tab.Text = currNumOfMission.ToString();
                        subTab.TabPages.Add(tab); 
                    }
                }
                (previewForm.Controls["tabControl"] as TabControl).TabPages.Add(new TabPage()
                {
                    Text = Test.AllMissions[i].ToString()
                });
                (previewForm.Controls["tabControl"] as TabControl).TabPages[indexOfTab].Controls.Add(subTab); 

                object currIndex = indexOfTab;

                indexOfTab++;
            }

            previewForm.ShowDialog();
        }

        private void btn_showHTML_Click(object sender, System.EventArgs e)
        {
            Test.OpenHTMLPage(User);
        }
    }
}
