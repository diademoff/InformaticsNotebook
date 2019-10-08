using MyNotebook.Forms;
using MyNotebook.Models;
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

            UpdateUsersList();
            Test test;

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                MessageBox.Show("Выберите тест");
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        test = Test.Deserialize(ofd.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось загрузить тест");
                        return;
                    }
                    disableCalc = test.IsCalcBlockEnabled;
                    MissionSolveForm msf = new MissionSolveForm(selectedUser, test);
                    this.FullHideForm();
                    msf.ShowDialog();
                    this.FullShowForm();
                }
            }
            txtbx_class.Text = txtbx_name.Text = "";
        }

        private void Btn_createTest_Click(object sender, System.EventArgs e)
        {
            this.FullHideForm();
            SelectMissionsForm smf = new SelectMissionsForm();
            smf.ShowDialog();
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

        private void Lbl_about_Click(object sender, System.EventArgs e)
        {
            AboutBox aboutBox = new AboutBox();
            aboutBox.ShowDialog();
        }

        private void Btn_update_Click(object sender, System.EventArgs e)
        {
            GitUpdater updater = new GitUpdater();
            if (updater.NeedUpdate)
            {
                if (MessageBox.Show("Найдена новая версия, хотите обновить программу?", "Проверка обновлений", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    updater.Update();
                }
            }
            else
            {
                MessageBox.Show("Обновления не найдены", "Проверка обновлений", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
