using MyNotebook.Forms;
using MyNotebook.ViewModels;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNotebook
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();

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
        }

        private void UpdateUsersList()
        {
            listbx_users.Items.Clear();
            listbx_users.Items.AddRange(UserCollection.Instance.GetUsers);
        }

        private void Btn_next_Click(object sender, System.EventArgs e)
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

            User selectedUser;
            if (UserCollection.Instance.UserExists($"{txtbx_name.Text} - {txtbx_class.Text}"))
            {
                selectedUser = UserCollection.Instance[$"{txtbx_name.Text} - {txtbx_class.Text}"];
                if (MessageBox.Show($"Запустить профиль ученика: {selectedUser.ToString()}", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                if (MessageBox.Show("Добавить нового ученика?", "Внимание", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UserCollection.Instance.AddNewUser(new User(txtbx_name.Text, txtbx_class.Text));
                    selectedUser = UserCollection.Instance[$"{txtbx_name.Text} - {txtbx_class.Text}"];
                }
                else
                    return;
            }


            this.FullHideForm();
            SelectMissionsForm smf = new SelectMissionsForm(selectedUser);
            smf.ShowDialog();
            this.FullShowForm();

            txtbx_class.Text = txtbx_name.Text = "";

            UpdateUsersList();
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
        bool disableCalc => cb_disableCalc.Checked;
        private void DisableCalc()
        {
            if (disableCalc)
            {
                KillCalcProcess();
            }
            Thread.Sleep(500);
            DisableCalc();//recursion
        }

        private void Btn_folderImport_Click(object sender, System.EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                string path = fbd.SelectedPath;
                UserCollection.Instance = UserCollection.DeserializeFolder(path);
                UpdateUsersList();
            }
        }
    }
}
