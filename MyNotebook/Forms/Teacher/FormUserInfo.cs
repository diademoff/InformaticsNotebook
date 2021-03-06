﻿using System;
using System.Windows.Forms;

namespace MyNotebook.Forms
{
    public partial class FormUserInfo : Form
    {
        User User;
        public FormUserInfo(User user)
        {
            InitializeComponent();
            StyleApply.ForForm(this);

            listBox.DoubleClick += (s, e) =>
            {
                btn_moreInfo.PerformClick();
            };

            if (user == null)
            {
                throw new ArgumentNullException($"{nameof(user)} is null");
            }

            this.User = user;

            Timer moreInfoEnable = new Timer()
            {
                Interval = 100,
                Enabled = true
            };
            moreInfoEnable.Tick += MoreInfoEnable_Tick;

            lbl_name.Text = user.Name;
            lbl_class.Text = user.Class;
            int i = 0;
            foreach (var test in user.UserTests)
            {
                listBox.Items.Add($"{i} Время начала: {test.TimeStart}; Оценка {test.Mark}; Кол-во заданий {test.AllMissions?.Count}");
                i++;
            }
        }

        private void MoreInfoEnable_Tick(object sender, EventArgs e)
        {
            btn_moreInfo.Enabled = listBox.SelectedIndex >= 0;
        }

        private void btn_moreInfo_Click(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(listBox.SelectedItem.ToString().Split(' ')[0]);
            FormTestResult testResultForm = new FormTestResult(User.UserTests[index], User);
            testResultForm.ShowDialog();
        }

        private void btn_OpenHTML_Click(object sender, EventArgs e)
        {
            User.OpenHTMLPage();
        }
    }
}
