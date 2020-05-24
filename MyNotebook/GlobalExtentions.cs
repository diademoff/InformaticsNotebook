using MyNotebook.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyNotebook
{
    public static class GlobalExtentions
    {
        public static void FullHideForm(this Form form)
        {
            form.Invoke(new MethodInvoker(() =>
            {
                form.Hide();
                form.ShowInTaskbar = false;
                form.Visible = false;
            }));
        }

        public static void FullShowForm(this Form form)
        {
            form.Invoke(new MethodInvoker(() =>
            {
                form.Show();
                form.ShowInTaskbar = true;
                form.Visible = true;
            }));
        }

        /// <summary>
        /// Makes textbox all input convert to upper chars
        /// </summary>
        /// <param name="textBox"></param>
        public static void UpperTextBox(this TextBox textBox)
        {
            textBox.TextChanged += (s, e) =>
            {
                textBox.Text = textBox.Text.ToUpper();
                textBox.SelectionStart = textBox.Text.Length;
            };
        }

        /// <summary>
        /// Makes textbox red, on first click make normal
        /// </summary>
        /// <param name="textBox"></param>
        public static void ErrorTextBox(this TextBox textBox)
        {
            textBox.Invoke(new MethodInvoker(() =>
            {
                Color oldForecolor = textBox.BackColor;
                textBox.BackColor = Color.Red;
                textBox.Click += TextBox_Click;

                void TextBox_Click(object sender, System.EventArgs e)
                {
                    textBox.Click -= TextBox_Click;
                    textBox.BackColor = oldForecolor;
                }
            }));
        }

        public static bool RandomBool(this Random rnd)
        {
            return rnd.Next(0, 2) == 0;
        }

        static Random rnd = new Random();
        public static string RandomElement(this string[] array)
        {
            if (array == null || array.Length == 0)
            {
                throw new ArgumentException($"{array} is null or empty");
            }

            return array[rnd.Next(0, array.Length - 1)];
        }

        public static string GetStringMissionType(this MissionType missionType)
        {
            switch (missionType)
            {
                case MissionType.Theory:
                    return "Теория";
                case MissionType.Practice:
                    return "Практика";
                default:
                    throw new Exception("Mission type to string exeption");
            }
        }

        public static void SearchListBoxUsingTextBox(this TextBox search, ListBox listBoxToSearchIn)
        {
            List<string> beginElements = new List<string>();
            foreach (object item in listBoxToSearchIn.Items)
            {
                beginElements.Add(item.ToString());
            }

            search.Text = "Поиск";
            search.ForeColor = Color.Gray;

            bool canSearch = true;

            search.LostFocus += (s, e) =>
            {
                search.Text = "Поиск";
                search.ForeColor = Color.Gray;
                canSearch = false;

                foreach (string item in beginElements)
                {
                    listBoxToSearchIn.Items.Add(item.ToString());
                }
            };

            search.Click += (s, e) =>
            {
                search.Text = "";
                search.ForeColor = Color.Black;
                canSearch = true;
            };

            search.TextChanged += (s, e) =>
            {
                if (!canSearch)
                {
                    return;
                }

                List<string> elementsMatch = new List<string>();

                foreach (string item in beginElements)
                {
                    if (item.ToString().ToUpper().Contains(search.Text.ToUpper()))
                    {
                        elementsMatch.Add(item.ToString());
                    }
                }

                listBoxToSearchIn.Items.Clear();
                elementsMatch.ForEach(x => listBoxToSearchIn.Items.Add(x));
            };
        }
    }
}
