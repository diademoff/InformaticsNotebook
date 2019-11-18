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

        private void btn_folderImport_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string path = fbd.SelectedPath;
                Users = UserCollection.Instance.DeserializeFolder(path);
                UpdateUsersList();
            }
        }
    }
}
