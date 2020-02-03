using MyNotebook.Models;
using System;
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
            this.FormClosing += (s, e) => isOpen = false;
            server = new NetworkServer(88); // port never changes
            lbl_ip.Text = $"IP: {server.Ip}";
        }

        bool isOpen = false;
        byte[] bytesToSend;
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
                        var UserName = Encoding.UTF8.GetString(server.Listen(bytesToSend));
                        listbx_userGotTest.Items.Add($"\"{UserName}\" получил(а) тест {DateTime.Now.ToShortTimeString()}");
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
            Test test;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Тесты | *.test";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        test = Test.Deserialize(ofd.FileName); // try deserialize

                        btn_send.Enabled = true;
                        isOpen = true;
                        bytesToSend = File.ReadAllBytes(ofd.FileName);
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
