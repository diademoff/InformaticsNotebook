using MyNotebook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MyNotebook.Forms
{
    public partial class TeacherForm : Form
    {
        List<User> Users = new List<User>();
        public TeacherForm()
        {
            InitializeComponent();

            listbx_users.DoubleClick += (s, e) =>
            {
                btn_info.PerformClick();
            };

            Users = UserCollection.Instance.GetUsers.ToList();
            UpdateUsersList();
        }

        private void UpdateUsersList()
        {
            listbx_users.Items.Clear();
            listbx_users.Items.AddRange(Users.ToArray());
        }

        User GetUser(string name, string _class)
        {
            for (int i = 0; i < Users.Count; i++)
            {
                if (Users[i].Name == name && Users[i].Class == _class)
                {
                    return Users[i];
                }
            }
            return null;
        }
        User GetUser(string str)
        {
            var t = str.Split('-');
            return GetUser(t[0].Trim(), t[1].Trim());
        }
        private void Btn_createTest_Click(object sender, System.EventArgs e)
        {
            SelectMissionsForm smf = new SelectMissionsForm();
            smf.ShowDialog();
        }

        private void btn_info_Click(object sender, EventArgs e)
        {
            if (!(listbx_users.SelectedIndex >= 0))
            {
                return;
            }
            var t = listbx_users.SelectedItem.ToString().Split('-');
            UserInfoForm uif = new UserInfoForm(GetUser(t[0].Trim(), t[1].Trim()));
            uif.ShowDialog();
        }
        void LockForm()
        {
            txtbx_name.Visible = txtbx_class.Visible = lbl_newUser.Visible = btn_cancel.Visible = true;

            btn_info.Enabled = false;
            btn_createTest.Enabled = false;
        }
        void UnlockForm()
        {
            txtbx_name.Visible = txtbx_class.Visible = lbl_newUser.Visible = btn_cancel.Visible = false;

            btn_info.Enabled = true;
            btn_createTest.Enabled = true;
        }
        
        private void btn_union_Click(object sender, EventArgs e)
        {
            if (btn_union.Text == "Выберите учеников для объеденения")
            {
                //после выбора сюда
                List<User> selected = new List<User>();
                foreach (var item in listbx_users.SelectedItems)
                {
                    selected.Add(GetUser(item.ToString()));
                }
                if (CheckNullOrEmpty(txtbx_name.Text) || CheckNullOrEmpty(txtbx_class.Text))
                {
                    MessageBox.Show("Укажите имя и класс");
                    return;
                }

                User newUser = new User(txtbx_name.Text, txtbx_class.Text);
                foreach (var item in selected)
                {
                    newUser.UserTests.AddRange(item.UserTests);
                    Users.Remove(item);
                }

                Users.Add(newUser);                               

                listbx_users.Items.Clear();
                listbx_users.Items.AddRange(Users.ToArray());

                UserCollection.Instance.Users = Users;

                listbx_users.SelectionMode = SelectionMode.One;
                UnlockForm();
                btn_union.Text = "Объеденить учеников";

            }
            else if (btn_union.Text == "Объеденить учеников")
            {
                LockForm();
                btn_union.Text = "Выберите учеников для объеденения";
                listbx_users.SelectionMode = SelectionMode.MultiExtended;
                if (listbx_users.SelectedIndex >= 0)
                {
                    txtbx_name.Text = listbx_users.SelectedItem.ToString();
                }

            }
        }

        private bool CheckNullOrEmpty(string text)
        {
            if (text == null)
            {
                return false;
            }
            return string.IsNullOrWhiteSpace(text);
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            listbx_users.SelectionMode = SelectionMode.One;
            UnlockForm();
        }
    }
}
