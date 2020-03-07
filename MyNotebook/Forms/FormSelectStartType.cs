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
                    bool waiting = true;
                    #region wait animation
                    new Thread(() =>
                    {
                        btn_update.Invoke(new MethodInvoker(() =>
                        {
                            btn_update.Visible = true;
                            btn_update.Enabled = false;
                        }));
                        int animatoinStep = 1;
                        do
                        {
                            try
                            {

                                btn_update.Invoke(new MethodInvoker(() =>
                                {
                                    switch (animatoinStep)
                                    {
                                        case 1:
                                            btn_update.Text = @" / / / ";
                                            animatoinStep++;
                                            break;
                                        case 2:
                                            btn_update.Text = @" | | | ";
                                            animatoinStep++;
                                            break;
                                        case 3:
                                            btn_update.Text = @" \ \ \ ";
                                            animatoinStep = 1;
                                            break;
                                    }
                                }));
                                Thread.Sleep(250);
                            }
                            catch { }
                        } while (waiting);
                    })
                    { IsBackground = true }.Start();
                    #endregion
                    var updater = new GitUpdater();
                again:
                    bool needUpdate = updater.NeedUpdate;
                    if (needUpdate)
                    {
                        waiting = false;
                        btn_update.Invoke(new MethodInvoker(() =>
                        {
                            btn_update.Visible = true;
                            btn_update.Enabled = true;
                            btn_update.Text = "Обновить";
                        }));
                    }
                    else
                    {
                        if (!GitUpdater.IsInternetExists())
                        {
                            goto again;
                        }
                        try
                        {
                            waiting = false;
                            btn_update.Invoke(new MethodInvoker(() =>
                            {
                                btn_update.Visible = true;
                                btn_update.Enabled = false;
                                btn_update.Text = "Обновлений нет";
                            }));
                        }
                        catch { }
                    }
                })
                { IsBackground = true }.Start();
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
