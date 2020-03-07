using MyNotebook.Models;
using MyNotebook.Models.Network;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MyNotebook.Forms
{
    public partial class FormSendTest : Form
    {
        NetworkServer server;
        public FormSendTest()
        {
            InitializeComponent();
            StyleApply.ForForm(this);
            this.FormClosing += (s, e) => isOpen = false;
            server = new NetworkServer(88); // port never changes
            lbl_ip.Text = $"IP: {server.Ip}";
        }

        bool isOpen = false;
        Test testToSend;
        List<Test> Tests = new List<Test>();
        private void btn_send_Click(object sender, EventArgs e)
        {
            if (!isOpen)
            {
                return;
            }

            Text = "[Раздаётся]";
            btn_send.Enabled = false;

            new Thread(() =>
            {
                do
                {
                    try
                    {
                        var feedback = server.Listen(new NetworkMessage(NetworkMessageType.TestRequest, "", testToSend));
                        switch (feedback.NetworkMessageType)
                        {
                            case NetworkMessageType.TestRequest:
                                listbx_userGotTest.Items.Add($"\"{feedback.UTF8String}\" получил(а) тест {DateTime.Now.ToShortTimeString()}");
                                break;
                            case NetworkMessageType.TestStatisticsFeedback:
                                listbx_userGotTest.Items.Add($"\"{feedback.UTF8String}\" прошел(а) тест {DateTime.Now.ToShortTimeString()}. Оценка \"{feedback.Test.Mark}\"");
                                Tests.Add(feedback.Test);
                                break;
                        }
                    }
                    catch { }
                } while (isOpen);
            })
            {
                IsBackground = true
            }.Start();
        }
        void btn_chooseTest_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Тесты | *.test";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        btn_send.Enabled = true;
                        isOpen = true;
                        testToSend = Test.Deserialize(ofd.FileName);
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось загрузить тест");
                        return;
                    }
                }
            }
        }
    }
}
