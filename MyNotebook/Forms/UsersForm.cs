using MyNotebook.Forms;
using MyNotebook.ViewModels;
using System.Drawing;
using System.Windows.Forms;

namespace MyNotebook
{
    public partial class UsersForm : Form
    {
        public UsersForm()
        {
            InitializeComponent();
            txtbx_name.UpperTextBox();
            txtbx_class.UpperTextBox();
            listbx_users.Items.AddRange(UserCollection.Instance.GetUsers);

            listbx_users.SelectedIndexChanged += (s, e) =>
            {
                var selectedUserName = listbx_users.SelectedItem.ToString();
                var selectedUser = UserCollection.Instance[selectedUserName];
                txtbx_name.Text = selectedUser.Name;
                txtbx_class.Text = selectedUser.Class;
            };
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
            //TODO: check input txtbx
            User selectedUser;
            if (UserCollection.Instance.UserExists(txtbx_name.Text))
            {
                selectedUser = UserCollection.Instance[txtbx_name.Text];
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
                    selectedUser = UserCollection.Instance[txtbx_name.Text];
                }
                else
                    return;
            }

            this.FullHideForm();
            SelectMissionsForm smf = new SelectMissionsForm(selectedUser);
            smf.ShowDialog();
            this.FullShowForm();

            txtbx_name.Text = "";
            txtbx_class.Text = "";
        }
    }
}
