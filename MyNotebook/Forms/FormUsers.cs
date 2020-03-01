using MyNotebook.Forms;
using MyNotebook.Models;
using MyNotebook.Models.Network;
using MyNotebook.ViewModels;
using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
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
            StyleApply.ForForm(this);

            listbx_users.DoubleClick += (s, e) =>
            {
                btn_chooseTest.PerformClick();
            };

            //start monitoring if calc is active, method depends on bool disable calc
            new Task(() => DisableCalc()).Start();

            txtbx_name.UpperTextBox();
            txtbx_class.UpperTextBox();

            UpdateUsersList();

            listbx_users.SelectedIndexChanged += (s, e) =>
            {
                if (listbx_users.SelectedItem == null)
                {
                    return;
                }
                var selectedUserName = listbx_users.SelectedItem.ToString();
                var selectedUser = UserCollection.Instance[selectedUserName];
                txtbx_name.Text = selectedUser.Name;
                txtbx_class.Text = selectedUser.Class;
            };

            txtbx_searchUsers.SearchListBoxUsingTextBox(listbx_users);
        }

        private void UpdateUsersList()
        {
            listbx_users.Items.Clear();
            listbx_users.Items.AddRange(UserCollection.Instance.GetUsers);
        }

        private void Btn_choose_Click(object sender, System.EventArgs e)
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
                    catch
                    {
                        MessageBox.Show("Не удалось загрузить тест");
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

        void Btn_update_Click(object sender, System.EventArgs e)
        {
            
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
