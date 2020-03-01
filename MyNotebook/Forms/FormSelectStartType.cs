using MyNotebook.Models;
using System;
using System.Threading;
using System.Windows.Forms;

namespace MyNotebook.Forms
{
    public partial class FormSelectStartType : Form
    {
        public FormSelectStartType()
        {
            InitializeComponent();
            StyleApply.ForForm(this);
            TopMost = true;
            this.Shown += (s, e) =>
            {
                new Thread(() =>
                {
                    bool needUpdate = new GitUpdater().NeedUpdate;
                    if (needUpdate)
                    {
                        btn_update.Invoke(new MethodInvoker(() =>
                        {
                            btn_update.Visible = true;
                        }));
                    }
                    else
                    {
                        try
                        {
                            btn_update.Invoke(new MethodInvoker(() =>
                            {
                                btn_update.Visible = true;
                                btn_update.Enabled = false;
                                btn_update.Text = "Обновлений нет";
                            }));
                        }
                        catch { }
                    }
                }).Start();
                new Thread(() =>
                {
                    try
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(2));
                        Invoke(new MethodInvoker(() =>
                        {
                            TopMost = false;
                        }));
                    }
                    catch { }
                }).Start();
            };
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TopMost = false;
            this.FullHideForm();
            FormUsers uf = new FormUsers();
            uf.ShowDialog();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TopMost = false;
            this.FullHideForm();
            FormTeacher tf = new FormTeacher();
            tf.ShowDialog();
            this.FullShowForm();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            new GitUpdater().AskAndUpdate();
        }
    }
}
