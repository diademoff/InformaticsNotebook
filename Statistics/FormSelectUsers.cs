using MyNotebook;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Statistics
{
    public partial class FormSelectUsers : Form
    {
        List<User> InputUsers = new List<User>();
        public List<User> ResultUsers = new List<User>();
        public FormSelectUsers(List<User> users)
        {
            InitializeComponent();
            this.InputUsers = users;
            this.ResultUsers = new List<User>();
            ResultUsers.AddRange(users);
            foreach (var item in users)
            {
                listbx_users.Items.Add(item);
            }
        }

        private void btn_delete_Click(object sender, System.EventArgs e)
        {
            while (listbx_users.SelectedIndex >= 0)
            {
                ResultUsers.RemoveAt(listbx_users.SelectedIndex);
                listbx_users.Items.RemoveAt(listbx_users.SelectedIndex);
            }
        }

        private void btn_reset_Click(object sender, System.EventArgs e)
        {
            listbx_users.Items.Clear();
            foreach (var item in InputUsers)
            {
                listbx_users.Items.Add(item);
            }
            ResultUsers = InputUsers;
        }

        private void btn_done_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
