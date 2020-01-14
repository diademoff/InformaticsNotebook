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
        List<int> selectedNumsOfMissions
        {
            get
            {
                List<int> result = new List<int>();
                foreach (var raw in RawControls)
                {
                    if (raw.CheckBox.Checked)
                    {
                        result.Add(raw.NumOfMission);
                    }
                }
                return result;
            }
        }
        int[] numOfEachMission
        {
            get
            {
                List<int> result = new List<int>();
                foreach (var raw in RawControls)
                {
                    if (raw.CheckBox.Checked)
                    {
                        result.Add((int)raw.Numeric.Value);
                    }
                }
                return result.ToArray();
            }
        }

        List<RawControls> RawControls = new List<RawControls>();

        public SelectMissionsForm()
        {
            InitializeComponent();

            int yPosition = 0;
            foreach (var catagory in MissionGeneratorCollection.Categories)
            {
                string catagoryName = catagory.CategoryName;
                var missionsInCategory = catagory.Missions;

                CategoryNameLabel(yPosition, catagoryName);

                yPosition += 35;

                for (int i = 0; i < missionsInCategory.Length; i++)
                {
                    RawControls.Add(new RawControls(missionsInCategory[i], yPosition));
                    RawControls.Last().AddToPanel(panel_missions);
                    RawControls.Last().Numeric.ValueChanged += (s, e) => RefreshUI();
                    RawControls.Last().CheckBox.CheckedChanged += (s, e) => RefreshUI();
                    yPosition += 23;
                }

                yPosition += 50;
            }
        }

        private void CategoryNameLabel(int yPosition, string catagoryName)
        {
            Label lbl_catagoryName = new Label()
            {
                Text = catagoryName,
                Location = new Point(5, yPosition),
                Font = new Font("Arial", 16),
                AutoSize = true
            };
            panel_missions.Controls.Add(lbl_catagoryName);
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
            //throw new Exception("Не реализовано");
            try
            {
                Test test = Test.Deserialize(path);
                test.RegenerateMissions();

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

                foreach (var item in RawControls)
                {
                    item.SetMissionConfig(test.AllMissions.ToArray());
                }
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


    public class RawControls
    {
        public CheckBox CheckBox { get; set; }
        public NumericUpDown Numeric { get; set; }
        public Label OfMax { get; set; } // 1 из 10
        public Button Preview { get; set; }

        public int NumOfMission { get; set; }
        public int yPosition { get; set; }
        public MissionGenerator MissionGenerator { get; set; }

        public RawControls(MissionGenerator mg, int yPosition)
        {
            this.yPosition = yPosition;
            MissionGenerator = mg;

            var generatedMission = mg.Generate();
            NumOfMission = generatedMission.NumOfMission;

            CheckBox = new CheckBox()
            {
                Location = new Point(25, yPosition),
                Checked = false,
                Font = new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                Text = $"{generatedMission.Title}",
                AutoSize = true
            };
            Numeric = new NumericUpDown()
            {
                Location = new Point(CheckBox.Location.X + 450, CheckBox.Location.Y),
                Maximum = generatedMission.MaxNumInTest,
                Value = 1,
                Width = 50,
                Enabled = false
            };
            OfMax = new Label()
            {
                Location = new Point(CheckBox.Location.X + 500, CheckBox.Location.Y),
                Text = $"из {generatedMission.MaxNumInTest}",
                Visible = true
            };
            Preview = new Button()
            {
                Text = "Предпросмотр",
                Location = new Point(CheckBox.Location.X + 600, CheckBox.Location.Y),
                Width = 100
            };
            Preview.Click += (s, e) =>
            {
                TabPage tab = generatedMission.GetTabPage(true);
                Form previewForm = new Form()
                {
                    Width = 800,
                    Height = 500,
                    Icon = Properties.Resources.icon,
                    Text = $"Предпросмотр задания {NumOfMission} \"{generatedMission.Title}\""
                };

                TabControl tc = new TabControl()
                {
                    Dock = DockStyle.Fill
                };
                tc.Controls.Add(tab);

                previewForm.Controls.Add(tc);

                previewForm.ShowDialog();
            };
            RegisterEventsToControls();
        }

        void RegisterEventsToControls()
        {
            CheckBox.CheckedChanged += (s, e) =>
            {
                Numeric.Enabled = CheckBox.Checked;
            };
        }

        public void AddToPanel(Panel pnl)
        {
            pnl.Controls.Add(CheckBox);
            pnl.Controls.Add(Numeric);
            pnl.Controls.Add(OfMax);
            pnl.Controls.Add(Preview);
        }

        public void SetMissionConfig(MissionBase[] mb)
        {
            int num = 0;
            foreach (var mission in mb)
            {
                if (mission.NumOfMission != NumOfMission)
                {
                    continue;
                }
                CheckBox.Checked = true;
                num++;
            }
            Numeric.Value = num;
        }
    }
}
