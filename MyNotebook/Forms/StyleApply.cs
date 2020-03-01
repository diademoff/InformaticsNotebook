using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyNotebook.Forms
{
    public static class StyleApply
    {
        static List<Control> GetAllControls(Control container)
        {
            List<Control> ControlList = new List<Control>();
            foreach (Control c in container.Controls)
            {
                ControlList.AddRange(GetAllControls(c));
                ControlList.Add(c);
            }
            return ControlList;
        }

        public static void ForForm(Control container)
        {
            if (container is Form)
            {
                container.BackColor = Color.FromArgb(255, 255, 255);
            }

            var controls = GetAllControls(container);
            foreach (Control control in controls)
            {
                if (control.Tag != null)
                {
                    if (control.Tag.ToString() == "no")
                    {
                        continue;
                    }
                }

                if (control is Button)
                {
                    var btn = control as Button;

                    btn.MouseEnter += (s, e) => { btn.FlatAppearance.BorderSize = 1; };
                    btn.MouseLeave += (s, e) => { btn.FlatAppearance.BorderSize = 0; };
                    //btn.MouseMove += (s, e) => { btn.BackColor = Color.FromArgb(255, 240, 188); };
                    //btn.MouseUp += (s, e) => { btn.BackColor = Color.Transparent; };

                    btn.Cursor = Cursors.Hand;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.BorderColor = Color.FromArgb(229, 229, 229);
                    btn.ForeColor = Color.FromArgb(20, 20, 20);
                    btn.BackColor = Color.Transparent;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.MouseDownBackColor = Color.FromArgb(255, 240, 188);
                    btn.FlatAppearance.MouseOverBackColor = Color.Transparent;

                    //if (!btn.Enabled)
                    //{
                    //    btn.BackColor = Color.FromArgb(160, 160, 160);
                    //}
                }
                //else if (control is GroupBox)
                //{
                //    var gb = control as GroupBox;
                //    gb.FlatStyle = FlatStyle.Flat;
                //    gb.BackColor = Color.FromArgb(242, 242, 242);
                //    gb.ForeColor = Color.FromArgb(51, 51, 51);
                //    gb.Paint += (s, e) =>
                //    {
                //        Graphics gfx = e.Graphics;
                //        Pen p = new Pen(Color.FromArgb(242, 242, 242), 3);
                //        gfx.DrawLine(p, 0, 8, 0, e.ClipRectangle.Height - 2);
                //        gfx.DrawLine(p, 0, 5, 10, 5);
                //        gfx.DrawLine(p, e.ClipRectangle.Width - 2, 5, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2);
                //        gfx.DrawLine(p, e.ClipRectangle.Width - 2, e.ClipRectangle.Height - 2, 0, e.ClipRectangle.Height - 2);
                //    };
                //}
                else if (control is Label)
                {
                    var lbl = control as Label;
                    lbl.ForeColor = Color.FromArgb(128, 128, 128);
                }
            }
        }
    }
}
