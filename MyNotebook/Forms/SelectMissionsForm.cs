﻿using MyNotebook.Models;
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
        List<int> selectedNumsOfMissions { get; set; } = new List<int>(); // elements add here on checkbox active
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

            int xPosition = 0;
            List<Label> of_max = new List<Label>();
            foreach (var catagory in MissionGeneratorCollection.Categories)
            {
                string catagoryName = catagory.CategoryName;
                var missions = catagory.Missions;

                Label lbl_catagoryName = new Label()
                {
                    Text = catagoryName,
                    Location = new Point(5, xPosition),
                    Font = new Font("Arial", 16),
                    AutoSize = true
                };
                xPosition += 35;

                for (int i = 0; i < missions.Length; i++)
                {
                    object i_clone = i;
                    var generatedMission = missions[i].Generate();

                    checkBoxes.Add(new CheckBox()
                    {
                        Location = new Point(25, xPosition),
                        Checked = false,
                        Font = new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                        Text = $"{generatedMission.Title}",
                        AutoSize = true
                    });
                    checkBoxes.Last().CheckedChanged += (s, e) =>
                    {
                        numerics[(int)i_clone].Enabled = ((CheckBox)s).Checked;
                        if (((CheckBox)s).Enabled)
                        {
                            selectedNumsOfMissions.Add(generatedMission.NumOfMission);
                            selectedNumsOfMissions = selectedNumsOfMissions.Distinct().ToList();
                        }
                        RefreshUI();
                    };
                    numerics.Add(new NumericUpDown()
                    {
                        Location = new Point(checkBoxes.Last().Location.X + 450, checkBoxes.Last().Location.Y),
                        Maximum = generatedMission.MaxNumInTest,
                        Value = 1,
                        Width = 50,
                        Enabled = false
                    });
                    of_max.Add(new Label()
                    {
                        Location = new Point(checkBoxes.Last().Location.X + 500, checkBoxes.Last().Location.Y),
                        Text = $"из {generatedMission.MaxNumInTest}",
                        Visible = true
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
                        TabPage tab = generatedMission.GetTabPage(showAnswerAtOnce: checkbx_showAnswerAtOnce.Checked);
                        Form previewForm = new Form()
                        {
                            Width = 800,
                            Height = 500,
                            Icon = Properties.Resources.icon,
                            Text = $"Предпросмотр задания {i + 1} \"{generatedMission.Title}\""
                        };

                        TabControl tc = new TabControl()
                        {
                            Dock = DockStyle.Fill
                        };
                        tc.Controls.Add(tab);

                        previewForm.Controls.Add(tc);

                        previewForm.ShowDialog();
                    };

                    xPosition += 23;

                    panel_missions.Controls.Add(btn);
                    panel_missions.Controls.Add(lbl_catagoryName);
                }

                xPosition += 50;
            }

            panel_missions.Controls.AddRange(of_max.ToArray());
            panel_missions.Controls.AddRange(checkBoxes.ToArray());
            panel_missions.Controls.AddRange(numerics.ToArray());
        }

        void Btn_save_Click(object sender, EventArgs e)
        {
            if (selectedNumsOfMissions.Count == 0)
            {
                MessageBox.Show("Вы ничего не выбрали!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Test test = GetCreatedTest();
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Тесты | .test";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    test.Serialize(sfd.FileName);
                    MessageBox.Show("Тест сохранён", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        Test GetCreatedTest()
        {
            Test test = new Test(selectedNumsOfMissions.ToArray(), numOfEachMission.ToArray(), isCalcBlockEnabled: checkbx_disableCalc.Checked)
            {
                IsTopMost = checkbx_topMost.Checked,
                ShowAnswerAtOnce = checkbx_showAnswerAtOnce.Checked,
                RandomOrder = checkbx_randomOrder.Checked
            };
            if (checkbx_onebyoneBlocks.Checked)
            {
                test.ShowType = TestShowType.OneByOneBlocks;
            }
            else if (checkbx_onebyoneMissions.Checked)
            {
                test.ShowType = TestShowType.OneByOneMissions;
            }
            else
            {
                test.ShowType = TestShowType.OnOneForm;
            }
            return test;
        }

        void RefreshUI()
        {
            lbl_numOfMissionsSelected.Text = $"Заданий выбрано: {numOfEachMission.Sum()}";
        }

        void btn_load_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = "Тесты (*.test)|*.test"
            })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    LoadTestFromFile(ofd.FileName);
                }
            }
        }

        void LoadTestFromFile(string path)
        {
            try
            {

                Test test = Test.Deserialize(path);
                test.RegenerateMissions();

                foreach (CheckBox item in checkBoxes)
                {
                    item.Checked = false;
                }
                foreach (NumericUpDown item in numerics)
                {
                    item.Value = 1;
                }

                foreach (MissionBase item in test.AllMissions)
                {
                    if (checkBoxes[item.NumOfMission - 1].Checked)
                    {
                        numerics[item.NumOfMission - 1].Value += 1;
                    }
                    checkBoxes[item.NumOfMission - 1].Checked = true;
                }

                checkbx_disableCalc.Checked = test.IsCalcBlockEnabled;
                switch (test.ShowType)
                {
                    case TestShowType.OneByOneBlocks:
                        checkbx_onebyoneBlocks.Checked = true;
                        break;
                    case TestShowType.OneByOneMissions:
                        checkbx_onebyoneMissions.Checked = true;
                        break;
                    case TestShowType.OnOneForm:
                        checkbx_onebyoneBlocks.Checked = false;
                        checkbx_onebyoneMissions.Checked = false;
                        break;
                    default:
                        throw new Exception("Unknown show type");
                }
                checkbx_randomOrder.Checked = test.RandomOrder;
                checkbx_showAnswerAtOnce.Checked = test.ShowAnswerAtOnce;
                checkbx_topMost.Checked = test.IsTopMost;
            }
            catch (Exception ex) { MessageBox.Show("Не удалось загузить тест " + ex.ToString()); }
        }

        void btn_preview_Click(object sender, EventArgs e)
        {
            if (selectedNumsOfMissions.Count == 0)
            {
                MessageBox.Show("Вы ничего не выбрали!", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Test test = GetCreatedTest();
            test.RegenerateMissions();
            MissionSolveForm form = new MissionSolveForm(new User("Предпросмотр", "*"), test);
            if (test.ShowType != TestShowType.OnOneForm)
            {
                try
                {
                    form.Show();
                }
                catch { }
            }
            else
            {
                form.ShowDialog();
            }
        }

        void checkbx_onebyoneBlocks_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                checkbx_onebyoneMissions.Checked = false;
                checkbx_randomOrder.Enabled = checkbx_onebyoneBlocks.Checked || checkbx_onebyoneMissions.Checked;
            }
            checkbx_randomOrder.Enabled = checkbx_onebyoneBlocks.Checked || checkbx_onebyoneMissions.Checked;
        }

        void checkbx_onebyoneMissions_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked)
            {
                checkbx_onebyoneBlocks.Checked = false;
            }
            checkbx_randomOrder.Enabled = checkbx_onebyoneBlocks.Checked || checkbx_onebyoneMissions.Checked;
        }
    }
}
