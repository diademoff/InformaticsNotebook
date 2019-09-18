using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyNotebook
{
    public static class Extentions
    {
        public static void FullHideForm(this Form form)
        {
            form.Hide();
            form.ShowInTaskbar = false;
            form.Visible = false;
        }

        public static void FullShowForm(this Form form)
        {
            form.Show();
            form.ShowInTaskbar = true;
            form.Visible = true;
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
                var oldForecolor = textBox.BackColor;
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
    }
}
