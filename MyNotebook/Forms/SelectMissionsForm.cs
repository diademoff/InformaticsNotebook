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
                var mission = MissionGeneratorCollection.Missions[i].Generate();
                checkBoxes.Add(new CheckBox()
                {
                    Location = new Point(17, 60 + (25 * i)),
                    Checked = false,
                    Font = new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                    Text = $"{i + 1}. {mission.Title}",
                    AutoSize = true
                });

                // Create the ToolTip and associate with the Form container.
                ToolTip toolTip1 = new ToolTip();

                // Set up the delays for the ToolTip.
                toolTip1.AutoPopDelay = 0;
                toolTip1.InitialDelay = 0;
                toolTip1.ReshowDelay = 0;
                // Force the ToolTip text to be displayed whether or not the form is active.
                toolTip1.ShowAlways = true;

                // Set up the ToolTip text for the Button and Checkbox.
                toolTip1.SetToolTip(checkBoxes.Last(), mission.Note);
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
                sfd.Filter = "Тесты | .test";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    test.Serialize(sfd.FileName);
                    this.Close();
                }
            }
        }
    }
}
