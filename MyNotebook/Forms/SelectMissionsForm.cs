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
        List<CheckBox> checkBoxes = new List<CheckBox>();
        public SelectMissionsForm()
        {
            InitializeComponent();

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

        private void Btn_save_Click(object sender, EventArgs e)
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

            var test = new Test(selectedNumsOfMissions.ToArray(), isCalcBlockEnabled: cb_disableCalc.Checked);
            test.IsTopMost = cb_topMost.Checked;
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    test.Serialize(sfd.FileName);
                    this.Close();
                }
            }
        }
    }
}
