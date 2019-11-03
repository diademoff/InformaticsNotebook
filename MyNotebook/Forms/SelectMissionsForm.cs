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
        int numOfSelected => checkBoxes.Where(x => x.Checked).Count();
        List<int> selectedNumsOfMissions
        {
            get
            {
                List<int> result = new List<int>();
                for (int i = 0; i < checkBoxes.Count; i++)
                {
                    if (checkBoxes[i].Checked)
                    {
                        result.Add(i);
                    }
                }
                return result;
            }
        }
        List<int> numOfEachMission
        {
            get
            {
                List<int> res = new List<int>();
                for (int i = 0; i < numerics.Count; i++)
                {
                    if (checkBoxes[i].Checked)
                    {
                        res.Add((int)numerics[i].Value);
                    }
                }
                return res;
            }
        }
        List<CheckBox> checkBoxes = new List<CheckBox>();
        List<NumericUpDown> numerics = new List<NumericUpDown>();
        public SelectMissionsForm()
        {
            InitializeComponent();

            for (int i = 0; i < MissionGeneratorCollection.Missions.Length; i++)
            {
                var mission = MissionGeneratorCollection.Missions[i].Generate();

                checkBoxes.Add(new CheckBox()
                {
                    Location = new Point(0, (25 * i)),
                    Checked = false,
                    Font = new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                    Text = $"{i + 1}. {mission.Title}",
                    AutoSize = true                   
                });
                checkBoxes.Last().CheckedChanged += (s, e) => RefreshUI();

                numerics.Add(new NumericUpDown()
                {
                    Location = new Point(checkBoxes.Last().Location.X + 500, checkBoxes.Last().Location.Y),
                    Maximum = 10,
                    Value = 1,
                    Width = 50
                });
                numerics.Last().ValueChanged += (s, e) => RefreshUI();

                Button btn = new Button()
                {
                    Text = "Предпросмотр",
                    Location = new Point(checkBoxes.Last().Location.X + 600, checkBoxes.Last().Location.Y),
                    Width = 100
                };
                btn.Click += (s, e) =>
                {
                    var tab = mission.GetTabPage(showAnswerAtOnce: checkbx_showAnswerAtOnce.Checked);
                    Form previewForm = new Form()
                    {
                        Width = 800,
                        Height = 500,
                        Icon = Properties.Resources.icon,
                        Text = $"Предпросмотр задания {i + 1} \"{mission.Title}\""
                    };

                    var tc = new TabControl()
                    {
                        Dock = DockStyle.Fill
                    };
                    tc.Controls.Add(tab);

                    previewForm.Controls.Add(tc);

                    previewForm.ShowDialog();
                };

                panel_missions.Controls.Add(btn);

                ToolTip toolTip = new ToolTip()
                {
                    AutoPopDelay = 0,
                    InitialDelay = 0,
                    ReshowDelay = 0,
                    ShowAlways = true
                };
                toolTip.SetToolTip(checkBoxes.Last(), mission.Tooltip);
            }
            panel_missions.Controls.AddRange(checkBoxes.ToArray());
            panel_missions.Controls.AddRange(numerics.ToArray());
        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
            if (selectedNumsOfMissions.Count == 0)
            {
                MessageBox.Show("Вы ничего не выбрали!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var test = new Test(selectedNumsOfMissions.ToArray(), numOfEachMission.ToArray(), isCalcBlockEnabled: checkbx_disableCalc.Checked);
            test.IsTopMost = checkbx_topMost.Checked;
            test.ShowAnswerAtOnce = checkbx_showAnswerAtOnce.Checked;
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

        public void RefreshUI()
        {
            lbl_numOfMissionsSelected.Text = $"Заданий выбрано: {numOfEachMission.Sum()}";
        }
    }
}
