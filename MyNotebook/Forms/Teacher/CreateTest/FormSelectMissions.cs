﻿using MyNotebook.Models;
using MyNotebook.MissionsModels;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace MyNotebook.Forms
{
    public partial class FormSelectMissions : Form
    {
        List<int> selectedNumsOfMissions
        {
            get
            {
                List<int> result = new List<int>();
                foreach (var cat in CategoryControls)
                {
                    foreach (var raw in cat.RawControls)
                    {
                        if (raw.CheckBox.Checked)
                        {
                            result.Add(raw.NumOfMission);
                        }
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
                foreach (var cc in CategoryControls)
                {
                    foreach (var raw in cc.RawControls)
                    {
                        if (raw.CheckBox.Checked)
                        {
                            result.Add((int)raw.Numeric.Value);
                        }
                    }
                }
                return result.ToArray();
            }
        }

        List<CategoryControl> CategoryControls = new List<CategoryControl>();
        public FormSelectMissions()
        {
            InitializeComponent();

            int yPosition = 5;
            foreach (var catagory in MissionGeneratorCollection.Categories)
            {
                CategoryControl categoryControl = new CategoryControl(catagory, yPosition, RefreshUITotal, RefreshLabels);
                yPosition = categoryControl.AddToPanel(panel_missions);

                CategoryControls.Add(categoryControl);
                yPosition += 35;
            }

            RefreshUITotal();
            StyleApply.ForForm(this);
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
                RandomOrder = checkbx_randomOrder.Checked,
                EnableMistakesCorrection = checkbx_mistakesCorrect.Checked
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

        void RefreshUITotal()
        {
            RefreshLabels();

            int prepos = panel_missions.AutoScrollPosition.Y;
            panel_missions.AutoScroll = false;
            int yPos = 5;
            foreach (var cat_control in CategoryControls)
            {
                yPos = cat_control.RefreshControlsAddedToPanel(yPos);
                yPos += 35;
            }
            panel_missions.AutoScroll = true;

            panel_missions.AutoScrollPosition = new Point(0, Math.Abs(prepos));
            panel_missions.Invalidate();
        }

        void RefreshLabels()
        {
            lbl_numOfMissionsSelected.Text = $"Заданий выбрано: {numOfEachMission.Sum()}";
            int timeNeed = 0;
            for (int i = 0; i < selectedNumsOfMissions.Count; i++)
            {
                var mission = MissionGeneratorCollection.GetMissionByNum(selectedNumsOfMissions[i]);
                for (int j = 0; j < numOfEachMission[i]; j++)
                {
                    timeNeed += mission.TimeToSolveMission;
                }
            }
            lbl_timeNeed.Text = $"Времяни потребуется: {timeNeed / 60} мин";
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

                foreach (var category in CategoryControls)
                {
                    foreach (var item in category.RawControls)
                    {
                        item.SetMissionConfig(test.AllMissions.ToArray());
                    }
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
            FormMissionSolve form = new FormMissionSolve(new User("Предпросмотр", "*"), test, false);
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

        void btn_print_Click(object sender, EventArgs e)
        {
            var test = GetCreatedTest();

            btn_print.Enabled = false;
            ud_numOfVariants.Enabled = false;
            checkbx_breakpage.Enabled = false;

            var src = new CancellationTokenSource();
            LoadingAnimationGeneratingHTML(btn_print, src.Token);

            CreateHtmlPageAsync(
                generator: () => { test.RegenerateMissions(); test.OpenHTMLMissionSolve(GetPathOnDesktop(), (int)ud_numOfVariants.Value, checkbx_breakpage.Checked); },
                callback: () => { src.Cancel(); btn_print.Enabled = true; ud_numOfVariants.Enabled = true; checkbx_breakpage.Enabled = true; });
        }

        async void LoadingAnimationGeneratingHTML(Button btn, CancellationToken cancellation)
        {
            string textWas = btn.Text;
            Action<string> setText = (string text) =>
            {
                try
                {
                    btn.Invoke(new MethodInvoker(() => btn.Text = text));
                }
                catch { }
            };

            await Task.Run(() =>
            {
                while (true)
                {
                    for (int i = 0; i <= 3; i++)
                    {
                        setText("Генерация" + new string('.', i));
                        Thread.Sleep(200);
                        if (cancellation.IsCancellationRequested)
                        {
                            setText(textWas);
                            return;
                        }
                    }
                }
            });
        }

        async void CreateHtmlPageAsync(Action generator, Action callback)
        {
            await Task.Run(generator);
            callback();
        }

        Random rnd = new Random();
        string GetPathOnDesktop()
        {
            while (true)
            {
                string folderName = rnd.Next().ToString();
                if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + folderName))
                {
                    Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + folderName);
                    return Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + folderName;
                }                
            }
        }
    }

    public class CategoryControl
    {
        public Label Title { get; set; }

        public string Name => Title.Text;
        public List<RawControls> RawControls = new List<RawControls>();
        Action RefreshUI;
        public bool Hidden { get; private set; } = false;
        int intervalBetweenRaws = 28;
        public CategoryControl(MissionGeneratorCategory category, int yPosition, Action RefreshUITotal, Action RefreshLabels)
        {
            this.RefreshUI = RefreshUITotal;
            Title = new Label()
            {
                Text = category.CategoryName,
                Location = new Point(5, yPosition),
                Font = new Font("Arial", 16),
                AutoSize = true,
                Cursor = Cursors.Hand,
                ForeColor = Color.FromArgb(51, 51, 51),
            };
            Title.Click += (s, e) =>
            {
                if (Hidden)
                {
                    Show();
                }
                else
                {
                    Hide();
                }
            };

            yPosition += intervalBetweenRaws;

            foreach (var item in category.Missions)
            {
                yPosition += intervalBetweenRaws;
                RawControls.Add(new RawControls(item, yPosition));
                RawControls.Last().Numeric.ValueChanged += (s, e) => RefreshLabels();
                RawControls.Last().CheckBox.CheckedChanged += (s, e) => RefreshLabels();
            }
        }
        public int AddToPanel(Panel pnl)
        {
            pnl.Controls.Add(Title);
            int lastY = Title.Location.Y;
            foreach (var item in RawControls)
            {
                item.AddToPanel(pnl);
                lastY = item.CheckBox.Location.Y;
            }

            return lastY;
        }
        public int RefreshControlsAddedToPanel(int yPos)
        {
            Title.Location = new Point(Title.Location.X, yPos);
            yPos += intervalBetweenRaws;
            if (Hidden)
            {
                return yPos;
            }
            foreach (var item in RawControls)
            {
                item.RefreshControlsAddedToPanel(yPos);
                yPos += intervalBetweenRaws;
            }
            return yPos;
        }
        public void Hide()
        {
            foreach (var item in RawControls)
            {
                item.VisibleControls(false);
            }
            Hidden = true;
            RefreshUI();
        }
        public void Show()
        {
            foreach (var item in RawControls)
            {
                item.VisibleControls(true);
            }
            Hidden = false;
            RefreshUI();
        }
    }

    public class RawControls
    {
        public CheckBox CheckBox { get; set; }
        public NumericUpDown Numeric { get; set; }
        public Label OfMax { get; set; } // 1 из 10
        public Button Preview { get; set; }
        public Label TimeToSolve { get; set; }
        public Label MissionType { get; set; }

        public int NumOfMission { get; set; }
        public int yPosition { get; set; }
        public MissionGenerator MissionGenerator { get; set; }

        public RawControls(MissionGenerator mg, int yPosition)
        {
            this.yPosition = yPosition;
            MissionGenerator = mg;

            NumOfMission = mg.NumOfMission;

            CheckBox = new CheckBox()
            {
                Location = new Point(25, yPosition),
                Checked = false,
                Font = new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel),
                Text = $"{mg.MissionName}",
                AutoSize = true
            };
#if DEBUG
            this.CheckBox.Text = $"{NumOfMission}. {this.CheckBox.Text}";
#endif
            Numeric = new NumericUpDown()
            {
                Location = new Point(CheckBox.Location.X + 500, CheckBox.Location.Y),
                Maximum = mg.MaxNumInTest,
                Value = 1,
                Width = 50,
                Enabled = false
            };
            OfMax = new Label()
            {
                Location = new Point(CheckBox.Location.X + 500, CheckBox.Location.Y),
                Text = $"из {mg.MaxNumInTest}",
                Visible = true
            };
            string timeToSolve = ((double)mg.TimeToSolveMission / 60.0).ToString("0.#") + " мин";
            TimeToSolve = new Label()
            {
                Location = new Point(CheckBox.Location.X + 600, yPosition),
                Text = timeToSolve,
                Font = new Font(new FontFamily("Arial"), 12, FontStyle.Regular, GraphicsUnit.Pixel),
                AutoSize = false
            };
            MissionType = new Label()
            {
                Location = new Point(CheckBox.Location.X + 700, yPosition),
                Text = GlobalExtentions.GetStringMissionType(mg.TypeOfMission),
                Font = new Font(new FontFamily("Arial"), 12, FontStyle.Regular, GraphicsUnit.Pixel),
                AutoSize = false
            };
            Preview = new Button()
            {
                //Text = "Предпросмотр",
                Location = new Point(CheckBox.Location.X + 800, CheckBox.Location.Y),
                Width = 30,
                Height = 15,
                BackgroundImage = Properties.Resources.view,
                BackgroundImageLayout = ImageLayout.Stretch
            };

            Preview.Click += (s, e) =>
            {
                TabPage tab = mg.Generate().GetTabPage(true);
                Form previewForm = new Form()
                {
                    Width = 900,
                    Height = 550,
                    Icon = Properties.Resources.icon,
                    Text = $"Предпросмотр задания {NumOfMission} \"{mg.MissionName}\"",
                    StartPosition = FormStartPosition.CenterScreen
                };

                TabControl tc = new TabControl()
                {
                    Dock = DockStyle.Fill
                };
                tc.Controls.Add(tab);

                previewForm.Controls.Add(tc);

                StyleApply.ForForm(previewForm, changeHeader:false);

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
            pnl.Controls.Add(TimeToSolve);
            pnl.Controls.Add(MissionType);
            pnl.Controls.Add(Preview);

            // help line
            Graphics g = pnl.CreateGraphics();
            Pen p = new Pen(Color.Black, 1.2f);
            CheckBox.MouseHover += (s, e) =>
            {
                g = pnl.CreateGraphics();
                g.DrawLine(p, CheckBox.Location.X, CheckBox.Location.Y + 24, Preview.Location.X + 30, CheckBox.Location.Y + 24);
            };
            CheckBox.MouseLeave += (s, e) =>
            {
                g.Clear(pnl.BackColor);
            };
        }

        public void VisibleControls(bool visible)
        {
            CheckBox.Visible = visible;
            Numeric.Visible = visible;
            OfMax.Visible = visible;
            Preview.Visible = visible;
            MissionType.Visible = visible;
            TimeToSolve.Visible = visible;
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

        public void RefreshControlsAddedToPanel(int yPos)
        {
            changeYposTo(CheckBox, yPos);
            changeYposTo(Numeric, yPos);
            changeYposTo(OfMax, yPos);
            changeYposTo(TimeToSolve, yPos);
            changeYposTo(MissionType, yPos);
            changeYposTo(Preview, yPos);
        }
        void changeYposTo(Control control, int yPos)
        {
            control.Location = new Point(control.Location.X, yPos);
        }
    }
}
