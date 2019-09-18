using MyNotebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MyNotebook.Forms
{
    public partial class SelectMissionsForm : Form
    {
        public User CurrentUser { get; set; }
        public SelectMissionsForm(User currentUser)
        {
            InitializeComponent();
            CurrentUser = currentUser;
        }

        private void Btn_next_Click(object sender, EventArgs e)
        {
            List<int> selectedNumsOfMissions = new List<int>();
            if (cb_task1.Checked)
            {
                selectedNumsOfMissions.Add(1);
            }
            if (cb_task2.Checked)
            {
                selectedNumsOfMissions.Add(2);
            }
            if (cb_task3.Checked)
            {
                selectedNumsOfMissions.Add(3);
            }
            if (cb_task4.Checked)
            {
                selectedNumsOfMissions.Add(4);
            }
            //TODO: add more tasks


            if (selectedNumsOfMissions.Count == 0)
            {
                MessageBox.Show("Вы ничего не выбрали!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.FullHideForm();
            CurrentUser.UserTests.Add(new Test(selectedNumsOfMissions.ToArray()));
            MissionSolveForm msf = new MissionSolveForm(CurrentUser, CurrentUser.UserTests.Last());
            msf.ShowDialog();
            this.FullShowForm();
        }
    }
}
