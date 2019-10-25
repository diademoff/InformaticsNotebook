using MyNotebook.Models;
using System;
using System.Windows.Forms;

namespace MyNotebook.Forms
{
    public partial class TestResultForm : Form
    {
        Test Test;
        public TestResultForm(Test test)
        {
            InitializeComponent();
            Test = test;

            lbl_state.Text = test.Finished ? $"Статус: завершен" : "Статус: не завершен";
            lbl_timeStart.Text = "Время начала: " + test.TimeStart.ToString();
            lbl_timeEnd.Text = "Время завершения: " + test.TimeFinish.ToString();
            lbl_wasCalcDiabled.Text = test.IsCalcBlockEnabled ? "Калькулятор: заблокирован" : "Калькулятор: не заблокирован";
            lbl_timeSpend.Text = "Время затрачено: " + ($"{(DateTime.Now - Test.TimeStart).TotalMinutes.ToString("00")}:{(DateTime.Now - Test.TimeStart).Seconds.ToString("00")}");
            lbl_topmost.Text = test.IsTopMost ? "Монополный режим: включен" : "Монополный режим: выключен";

            int numOfSolved = 0;
            txtbx_log.Text += "Краткая информация:\n";
            for (int i = 0; i < test.AllMissions.Count; i++)
            {
                var currMission = test.AllMissions[i];
                if (currMission.IsSolvedRight())
                {
                    numOfSolved += 1;
                }
                txtbx_log.Text += $"\t{currMission.ToString()}:\n";

                string answerGiven = currMission.String_AnswerGiven;
                string answerTrue = "";

                txtbx_log.Text += currMission.IsSolvedRight() ? $"\tЗадача решена верно\n" : "\tЗадача решена не верно\n";
                txtbx_log.Text += $"\tОтвет дан: {answerGiven}\n\n";
            }
            double percentSolved = ((double)numOfSolved / (double)test.AllMissions.Count) * 100;
            lbl_solvedPercent.Text = $"Решено: {percentSolved.ToString("#.##")}%";
            int mark = GetMark(percentSolved);
            lbl_mark.Text = $"Оценка: {mark}";
            test.Mark = mark;
        }

        private static int GetMark(double percentSolved)
        {
            int mark = 0;
            if (percentSolved < 50)
            {
                mark = 2;
            }
            else if ((50 <= percentSolved) && (percentSolved <= 74))
            {
                mark = 3;
            }
            else if ((75 <= percentSolved) && (percentSolved <= 91))
            {
                mark = 4;
            }
            else if ((92 <= percentSolved) && (percentSolved <= 100))
            {
                mark = 5;
            }
            return mark;
        }
    }
}
