using MyNotebook.Forms;
using MyNotebook.Models;
using MyNotebook.Models.Network;
using MyNotebook.MissionsModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNotebook
{
    public partial class FormUsers : Form
    {

        public FormUsers()
        {
            InitializeComponent();            

            //start monitoring if calc is active, method depends on bool disable calc
            new Thread(() => DisableCalc()) { IsBackground = true }.Start();

            txtbx_name.UpperTextBox();
            txtbx_class.UpperTextBox();

            UpdateUsersList();

            txtbx_searchUsers.TextChanged += (s, e) => UpdateUsersList(txtbx_searchUsers.Text);

            // animate search btn
            txtbx_searchUsers.ForeColor = Color.Gray;
            new Thread(() => AnimateSearchBtn()) { IsBackground = true }.Start();
            txtbx_searchUsers.GotFocus += (s, e) =>
            {
                isAnimatingSearch = false;
                txtbx_searchUsers.Text = "";
                txtbx_searchUsers.ForeColor = Color.Black;
            };
            txtbx_searchUsers.LostFocus += (s, e) =>
            {
                isAnimatingSearch = true;
                txtbx_searchUsers.ForeColor = Color.Gray;
            };

            StyleApply.ForForm(this);
        }

        bool isAnimatingSearch = true;
        private void AnimateSearchBtn()
        {
            while (true)
            {
                for (int i = 1; i <= 4; i++)
                {
                    Thread.Sleep(500);
                    if (!isAnimatingSearch)
                    {
                        continue;
                    }
                    txtbx_searchUsers.Invoke(new MethodInvoker(() =>
                    {
                        switch (i)
                        {
                            case 1:
                                txtbx_searchUsers.Text = "Поиск.";
                                break;
                            case 2:
                                txtbx_searchUsers.Text = "Поиск..";
                                break;
                            case 3:
                                txtbx_searchUsers.Text = "Поиск...";
                                break;
                            case 4:
                                txtbx_searchUsers.Text = "Поиск..";
                                break;
                        }
                    }));
                }
            }
        }

        List<Label> usersLabels = new List<Label>();
        void UpdateUsersList(string search = "")
        {
            if (usersLabels.Count != 0)
            {
                foreach (var lbl in usersLabels)
                {
                    pnl_users.Controls.Remove(lbl);
                }
                usersLabels.Clear();
            }
            int y = 0;
            foreach (var usr in UserCollection.Instance.GetUsers)
            {
                if (search != "" && !isAnimatingSearch)
                {
                    if (!usr.ToString().Contains(search))
                    {
                        continue;
                    }
                }

                usersLabels.Add(new Label()
                {
                    Text = usr.ToString(),
                    Location = new System.Drawing.Point(0, y),
                    Font = new Font("Arial", 10.0f)
                });

                usersLabels.Last().Click += (s, e) =>
                {
                    txtbx_name.Text = usr.Name;
                    txtbx_class.Text = usr.Class;
                    (s as Label).ForeColor = Color.Blue;
                };

                usersLabels.Last().DoubleClick += (s, e) =>
                {
                    btn_chooseTest.PerformClick();
                };

                usersLabels.Last().MouseEnter += (s, e) => (s as Label).ForeColor = Color.Blue;
                usersLabels.Last().MouseLeave += (s, e) => (s as Label).ForeColor = StyleApply.CurrentStyle.TextForeColor;

                usersLabels.Last().Cursor = Cursors.Hand;
                usersLabels.Last().ForeColor = StyleApply.CurrentStyle.TextForeColor;
                usersLabels.Last().AutoSize = true;
                usersLabels.Last().Tag = "no";
                pnl_users.Controls.Add(usersLabels.Last());
                y += 15;
            }
        }

        void Btn_choose_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbx_name.Text))
            {
                txtbx_name.ErrorTextBox();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtbx_class.Text))
            {
                txtbx_class.ErrorTextBox();
                return;
            }

            Test test;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Тесты | *.test";
                MessageBox.Show("Выберите тест");
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        test = Test.Deserialize(ofd.FileName);
                        StartTest(test);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show($"Не удалось загрузить тест\n{ex.ToString()}");
                        return;
                    }
                }
            }
            txtbx_class.Text = txtbx_name.Text = "";
        }

        void StartTest(Test test)
        {
            User selectedUser;
            if (UserCollection.Instance.UserExists($"{txtbx_name.Text} - {txtbx_class.Text}"))
            {
                selectedUser = UserCollection.Instance[$"{txtbx_name.Text} - {txtbx_class.Text}"];
            }
            else
            {
                if (MessageBox.Show("Добавить нового ученика?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (string.IsNullOrWhiteSpace(txtbx_name.Text.Trim()) || string.IsNullOrWhiteSpace(txtbx_class.Text.Trim()))
                    {
                        MessageBox.Show("Имя ученика или класс не заполнены", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    UserCollection.Instance.AddNewUser(new User(txtbx_name.Text.Trim(), txtbx_class.Text.Trim()));
                    selectedUser = UserCollection.Instance[$"{txtbx_name.Text} - {txtbx_class.Text}"];
                }
                else
                    return;
            }

            UpdateUsersList();

            test.RegenerateMissions();
            disableCalc = test.IsCalcBlockEnabled;
            selectedUser.UserTests.Add(test);
            this.FullHideForm();
            FormMissionSolve msf = new FormMissionSolve(selectedUser, test, false);
            msf.ShowDialog();
            this.FullShowForm();
        }

        void KillCalcProcess()
        {
            var p = Process.GetProcessesByName("Calculator").ToList();
            p.AddRange(Process.GetProcessesByName("calc"));
            for (int i = 0; i < p.Count; i++)
            {
                p[i].Kill();
            }
        }
        bool disableCalc = false;
        void DisableCalc()
        {
            if (disableCalc)
            {
                KillCalcProcess();
            }
            Thread.Sleep(500);
            DisableCalc();//recursion
        }

        void Lbl_about_Click(object sender, System.EventArgs e)
        {
            FormAboutBox aboutBox = new FormAboutBox();
            aboutBox.ShowDialog();
        }

        void txtbx_class_TextChanged(object sender, System.EventArgs e)
        {
            txtbx_class.Text = string.Join("", txtbx_class.Text.Split(' '));
        }

        void btn_getTest_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtbx_name.Text))
            {
                txtbx_name.ErrorTextBox();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtbx_class.Text))
            {
                txtbx_class.ErrorTextBox();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtbx_ip.Text))
            {
                MessageBox.Show("Введите адрес");
                return;
            }

            if (!IPAddress.TryParse(txtbx_ip.Text, out IPAddress res))
            {
                MessageBox.Show("Адрес введён не корректно");
                return;
            }

            try
            {
                NetworkClient nc = new NetworkClient(txtbx_ip.Text, 88);
                var test = nc.Send(new NetworkMessage(NetworkMessageType.TestRequest, $"{txtbx_name.Text} - {txtbx_class.Text}")).Test;
                new Task(() =>
                {
                    while (!test.Finished)
                    {
                        Thread.Sleep(250);
                    }
                    nc = new NetworkClient(txtbx_ip.Text, 88); // recreate connection
                    nc.Send(new NetworkMessage(NetworkMessageType.TestStatisticsFeedback, $"{txtbx_name.Text} - {txtbx_class.Text}", test));
                }).Start();
                StartTest(test);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Что-то пошло не так\n{ex.ToString()}");
            }
        }
    }
}
