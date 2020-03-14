using MyNotebook;
using MyNotebook.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Statistics
{
    public partial class FormSelectTests : Form
    {
        List<Test> InputTests = new List<Test>();
        public List<Test> ResultTests = new List<Test>();
        public FormSelectTests(List<Test> tests)
        {
            InitializeComponent();
            this.InputTests = tests;
            
            lbl_totalTests.Text = $"Всего тестов: {tests.Count}";
        }

        void SetResultTests()
        {
            ResultTests.Clear();
            foreach (var test in InputTests)
            {
                if (IsOK(test))
                {
                    ResultTests.Add(test);
                }
            }
        }

        private bool IsOK(Test test)
        {
            // проверка по процентам

            int min = 0;
            int max = 100;
            try
            {
                min = Convert.ToInt32(txtbx_percentSolveMin.Text);
                max = Convert.ToInt32(txtbx_percentSolveMax.Text);
            }
            catch { }
            if (test.PercentSolvedRight < min ||
                test.PercentSolvedRight > max)
            {
                return false;
            }
            return true;
        }

        private void btn_done_Click(object sender, EventArgs e)
        {
            SetResultTests();
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
