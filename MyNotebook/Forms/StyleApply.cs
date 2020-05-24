using MyNotebook.StaticCollections;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyNotebook.Forms
{
    public class StyleNotebook
    {
        public string Name;

        public Color ContainerBackColor;

        public Color ButtonForeColor;
        public Color ButtonMouseDownBackColor;
        public Color ButtonFlatAppearanceBorderColor;

        public Color TextForeColor;

        public Color GroupBoxForeColor;

        public Color PanelsBackColor;
    }

    public static class StyleApply
    {
        public static StyleNotebook CurrentStyle = StyleCollection.Styles[0];

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

        public static void ForForm(Control container, bool changeHeader = true)
        {
            if (container is Form && changeHeader)
            {
                container.BackColor = CurrentStyle.ContainerBackColor;
                SetFormStyle(container as Form);
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

                    btn.Cursor = Cursors.Hand;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.FlatAppearance.BorderColor = CurrentStyle.ButtonFlatAppearanceBorderColor;
                    btn.ForeColor = CurrentStyle.ButtonForeColor;
                    btn.BackColor = Color.Transparent;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.MouseDownBackColor = CurrentStyle.ButtonMouseDownBackColor;
                    btn.FlatAppearance.MouseOverBackColor = Color.Transparent;
                }
                else if (control is Label)
                {
                    var lbl = control as Label;
                    lbl.ForeColor = CurrentStyle.TextForeColor;
                }
                else if (control is GroupBox)
                {
                    var gb = control as GroupBox;
                    gb.ForeColor = CurrentStyle.GroupBoxForeColor;
                }
                else if (control is CheckBox)
                {
                    var checkbx = control as CheckBox;
                    checkbx.ForeColor = CurrentStyle.TextForeColor;
                }
                else if (control is ListBox)
                {
                    var listbx = control as ListBox;
                    listbx.BackColor = CurrentStyle.PanelsBackColor;
                    listbx.DrawMode = DrawMode.OwnerDrawFixed;
                    listbx.DrawItem += new DrawItemEventHandler(listbx_SetColor);
                    listbx.Refresh();
                    void listbx_SetColor(object sender, DrawItemEventArgs e)
                    {
                        try
                        {
                            e.DrawBackground();
                            SolidBrush myBrush = new SolidBrush(CurrentStyle.TextForeColor);

                            e.Graphics.DrawString(((ListBox)sender).Items[e.Index].ToString(),
                                e.Font, myBrush, e.Bounds, StringFormat.GenericDefault);

                            e.DrawFocusRectangle();
                        }
                        catch
                        {

                        }
                    }
                }
                else if (control is Panel)
                {
                    var panel = control as Panel;
                    panel.BackColor = CurrentStyle.PanelsBackColor;
                }
                else if (control is TextBox)
                {
                    var txtbx = control as TextBox;
                    txtbx.BackColor = CurrentStyle.PanelsBackColor;
                    txtbx.ForeColor = CurrentStyle.TextForeColor;
                }
                else if (control is RichTextBox)
                {
                    var rtxtbx = control as RichTextBox;
                    rtxtbx.BackColor = CurrentStyle.PanelsBackColor;
                    rtxtbx.ForeColor = CurrentStyle.TextForeColor;
                }

                if (control is Panel || control is GroupBox)
                {
                    ForForm(control);
                }
            }
        }

        private static void SetFormStyle(Form form)
        {
            FormStyle fs = new FormStyle();
            fs.Form = form;
            fs.MaximizeButtonEnabled = form.MaximizeBox;
            fs.StyleForForm = FormStyle.fStyle.SimpleDark; // header theme
            fs.HeaderHeight = 28;
            fs.EnableControlBoxIconsLight = false;
            fs.EnableControlBoxMouseLight = false;
        }
    }
}
