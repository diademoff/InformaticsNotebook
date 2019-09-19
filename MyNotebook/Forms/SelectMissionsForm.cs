using MyNotebook.Models;
using MyNotebook.ViewModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MyNotebook.Forms
{
    public partial class SelectMissionsForm : Form
    {
        public User CurrentUser { get; set; }
        List<CheckBox> checkBoxes = new List<CheckBox>();
        bool calcBlocked;
        public SelectMissionsForm(User currentUser, bool isCalcBlocked)
        {
            InitializeComponent();
            CurrentUser = currentUser;
            this.calcBlocked = isCalcBlocked;

            for (int i = 0; i < MissionGeneratorCollection.Missions.Length; i++)
            {
                checkBoxes.Add(new CheckBox()
                {
                    Location = new Point(17, 60 + (40 * i)), 
                    Checked = false,
                    Text = $"{i + 1}. {MissionGeneratorCollection.Missions[i].Generate().Title}",
                    AutoSize = true
                });
            }
            Controls.AddRange(checkBoxes.ToArray());
        }

        private void Btn_next_Click(object sender, EventArgs e)
        {
            List<int> selectedNumsOfMissions = new List<int>();
            for (int i = 0; i < checkBoxes.Count; i++)
            {
                if (checkBoxes[i].Checked)
                {
                    selectedNumsOfMissions.Add(i);
                }
            }


            if (selectedNumsOfMissions.Count == 0)
            {
                MessageBox.Show("Вы ничего не выбрали!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.FullHideForm();
            CurrentUser.UserTests.Add(new Test(selectedNumsOfMissions.ToArray(), isCalcBlockEnabled:calcBlocked));
            MissionSolveForm msf = new MissionSolveForm(CurrentUser, CurrentUser.UserTests.Last());
            msf.ShowDialog();
            this.FullShowForm();
        }
    }
}
