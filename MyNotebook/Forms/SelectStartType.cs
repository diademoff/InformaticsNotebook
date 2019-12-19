using MyNotebook.Models;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNotebook.Forms
{
    public partial class SelectStartType : Form
    {
        public SelectStartType()
        {
            new Task(() =>
            {
                bool needUpdate = new GitUpdater().NeedUpdate;
                if (needUpdate)
                {
                    btn_update.Invoke(new MethodInvoker(() =>
                    {
                        btn_update.Visible = true;
                    }));
                }
            }).Start();
            InitializeComponent();
            TopMost = true;
            new Task(() =>
            {
                Thread.Sleep(TimeSpan.FromSeconds(2));
                Invoke(new MethodInvoker(() =>
                {
                    TopMost = false;
                }));
            }).Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.FullHideForm();
            UsersForm uf = new UsersForm();
            uf.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.FullHideForm();
            TeacherForm tf = new TeacherForm();
            tf.ShowDialog();
            Close();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            new GitUpdater().AskAndUpdate();
        }
    }
}
