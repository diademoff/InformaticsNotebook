// thx for github.com/Egolds/WinFormsUserInterface <3
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MyNotebook.Forms
{
    internal class FormStyle
    {
        public static class FlatColors
        {
            public static Color Green = ColorTranslator.FromHtml("#2ecc71");
            public static Color GreenDark = ColorTranslator.FromHtml("#27ae60");

            public static Color Red = ColorTranslator.FromHtml("#e74c3c");
            public static Color RedDark = ColorTranslator.FromHtml("#c0392b");

            public static Color Blue = ColorTranslator.FromHtml("#3498db");
            public static Color BlueDark = ColorTranslator.FromHtml("#2980b9");

            public static Color Orange = ColorTranslator.FromHtml("#e67e22");
            public static Color OrangeDark = ColorTranslator.FromHtml("#d35400");

            public static Color GreenSea = ColorTranslator.FromHtml("#1abc9c");
            public static Color GreenSeaDark = ColorTranslator.FromHtml("#16a085");

            public static Color Purple = ColorTranslator.FromHtml("#9b59b6");
            public static Color PurpleDark = ColorTranslator.FromHtml("#8e44ad");

            public static Color Gray = ColorTranslator.FromHtml("#bdc3c7");
            public static Color GrayDark = ColorTranslator.FromHtml("#7f8c8d");
            public static Color GrayLight = ColorTranslator.FromHtml("#ecf0f1");
        }
        public static class Drawer
        {
            public static GraphicsPath RoundedRectangle(Rectangle rect, float RoundSize)
            {
                GraphicsPath gp = new GraphicsPath();

                gp.AddArc(rect.X, rect.Y, RoundSize, RoundSize, 180, 90);
                gp.AddArc(rect.X + rect.Width - RoundSize, rect.Y, RoundSize, RoundSize, 270, 90);
                gp.AddArc(rect.X + rect.Width - RoundSize, rect.Y + rect.Height - RoundSize, RoundSize, RoundSize, 0, 90);
                gp.AddArc(rect.X, rect.Y + rect.Height - RoundSize, RoundSize, RoundSize, 90, 90);

                gp.CloseFigure();

                return gp;
            }

            public static void DrawBlurredLine(Graphics graph, Color lineColor, Point p1, Point p2, int maxAlpha, int penWidth)
            {
                float stepAlpha = (float)maxAlpha / penWidth;

                float actualAlpha = stepAlpha;
                for (int pWidth = penWidth; pWidth > 0; pWidth--)
                {
                    Color BlurredColor = Color.FromArgb((int)actualAlpha, lineColor);
                    Pen BlurredPen = new Pen(BlurredColor, pWidth);
                    BlurredPen.StartCap = LineCap.Round;
                    BlurredPen.EndCap = LineCap.Round;

                    graph.DrawLine(BlurredPen, p1, p2);

                    actualAlpha += stepAlpha;
                }
            }

            public static void DrawBlurredRectangle(Graphics graph, Color lineColor, Rectangle rect, int maxAlpha, int penWidth)
            {
                float stepAlpha = (float)maxAlpha / penWidth;

                float actualAlpha = stepAlpha;
                for (int pWidth = penWidth; pWidth > 0; pWidth--)
                {
                    Color BlurredColor = Color.FromArgb((int)actualAlpha, lineColor);
                    Pen BlurredPen = new Pen(BlurredColor, pWidth);
                    BlurredPen.StartCap = LineCap.Round;
                    BlurredPen.EndCap = LineCap.Round;

                    graph.DrawRectangle(BlurredPen, rect);

                    actualAlpha += stepAlpha;
                }
            }
        }
        #region -- Свойста --

        public Form Form { get; set; }

        private fStyle formStyle = fStyle.None;
        public fStyle StyleForForm
        {
            get => formStyle;
            set
            {
                formStyle = value;
                Sign();
            }
        }
        public enum fStyle
        {
            None,

            SimpleDark
        }

        public bool EnableControlBoxMouseLight { get; set; }

        public bool EnableControlBoxIconsLight { get; set; }

        public int HeaderHeight { get; set; } = 38;

        public Color HeaderColor { get; set; } = Color.DimGray;

        public bool MaximizeButtonEnabled = true;

        #endregion
        #region -- Переменные --

        private Size IconSize = new Size(14, 14);

        private StringFormat SF = new StringFormat();
        private Font Font = new Font("Arial", 8.75F, FontStyle.Regular);

        Pen WhitePen = new Pen(Color.White) { Width = 1.55F };
        Pen GrayPen = new Pen(Color.Gray) { Width = 1.55F };

        bool MousePressed = false; // Кнопка мыши нажата
        Point clickPosition; // Начальная позиция курсора в момент клика
        Point moveStartPosition; // Начальная позиция формы в момент клика

        Rectangle rectBtnClose = new Rectangle();
        Rectangle rectBtnMax = new Rectangle();
        Rectangle rectBtnMin = new Rectangle();

        bool btnCloseHovered = false;
        bool btnMaximizeHovered = false;
        bool btnMinimizeHovered = false;

        #endregion


        private void Sign()
        {
            if (Form != null)
            {
                Form.Load += Form_HandleCreated;
            }
        }

        private void Apply()
        {
            SF.Alignment = StringAlignment.Near;
            SF.LineAlignment = StringAlignment.Center;

            Form.FormBorderStyle = FormBorderStyle.None;

            SetDoubleBuffered(Form);

            OffsetControls();

            Form.Paint += (s, e) => { if (s as Form != null) Form_Paint(s, e); };
            Form.MouseDown += (s, e) => { if (s as Form != null) Form_MouseDown(s, e); };
            Form.MouseUp += (s, e) => { if (s as Form != null) Form_MouseUp(s, e); };
            Form.MouseMove += (s, e) => { if (s as Form != null) Form_MouseMove(s, e); };
            Form.MouseLeave += (s, e) => { if (s as Form != null) Form_MouseLeave(s, e); };
            Form.SizeChanged += (s, e) => { if (s as Form != null) Form_SizeChanged(s, e); };
            Form.DoubleClick += (s, e) => { if (s as Form != null) Form_DoubleClick(s, e); };
        }

        bool isAlreadyOffset = false;
        private void OffsetControls()
        {
            if (isAlreadyOffset)
            {
                return;
            }
            isAlreadyOffset = true;

            Form.Height = Form.Height + HeaderHeight;

            foreach (Control ctrl in Form.Controls)
            {
                ctrl.Location = new Point(ctrl.Location.X, ctrl.Location.Y + HeaderHeight);
                ctrl.Refresh();
            }
        }

        #region -- Form Events --

        private void Form_Load(object sender, EventArgs e)
        {
            //Apply();
        }

        // В этом событии выполняется раньше чем в Load
        private void Form_HandleCreated(object sender, EventArgs e)
        {
            Apply();
        }

        private void Form_Paint(object sender, PaintEventArgs e)
        {
            DrawStyle(e.Graphics);
        }

        private void Form_SizeChanged(object sender, EventArgs e)
        {
            Form.Refresh();
        }

        private void Form_MouseLeave(object sender, EventArgs e)
        {
            btnCloseHovered = false;
            btnMaximizeHovered = false;
            btnMinimizeHovered = false;
            Form.Invalidate();
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (MousePressed)
            {
                if (Form.WindowState == FormWindowState.Maximized)
                {
                    // Change WindowState if is Maximized
                    Form.WindowState = FormWindowState.Normal;
                    Form.Location = new Point(Cursor.Position.X - Form.Width / 2, Cursor.Position.Y - HeaderHeight / 2);
                    moveStartPosition = Form.Location;
                }
                else
                {
                    // Moving
                    Size frmOffset = new Size(Point.Subtract(Cursor.Position, new Size(clickPosition)));
                    Form.Location = Point.Add(moveStartPosition, frmOffset);
                }
            }
            else
            {
                // Close Button
                if (rectBtnClose.Contains(e.Location))
                {
                    if (btnCloseHovered == false)
                    {
                        btnCloseHovered = true;

                        if (EnableControlBoxMouseLight == false)
                            Form.Invalidate();
                    }

                    if (EnableControlBoxMouseLight == true)
                        Form.Invalidate();
                }
                else
                {
                    if (btnCloseHovered == true)
                    {
                        btnCloseHovered = false;
                        Form.Invalidate();
                    }
                }

                // Maximize Button
                if (rectBtnMax.Contains(e.Location))
                {
                    if (btnMaximizeHovered == false)
                    {
                        btnMaximizeHovered = true;

                        if (EnableControlBoxMouseLight == false)
                            Form.Invalidate();
                    }

                    if (EnableControlBoxMouseLight == true)
                        Form.Invalidate();
                }
                else
                {
                    if (btnMaximizeHovered)
                    {
                        btnMaximizeHovered = false;
                        Form.Invalidate();
                    }
                }

                // Minimize Button
                if (rectBtnMin.Contains(e.Location))
                {
                    if (btnMinimizeHovered == false)
                    {
                        btnMinimizeHovered = true;

                        if (EnableControlBoxMouseLight == false)
                            Form.Invalidate();
                    }

                    if (EnableControlBoxMouseLight == true)
                        Form.Invalidate();
                }
                else
                {
                    if (btnMinimizeHovered)
                    {
                        btnMinimizeHovered = false;
                        Form.Invalidate();
                    }
                }
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            MousePressed = false;

            try
            {
                // Если окно поднять вверх -> разворачиваем на весь экран
                if (Form.MaximizeBox)
                {
                    if (Cursor.Position.Y == Screen.FromHandle(Form.Handle).WorkingArea.Y
                        && Form.WindowState == FormWindowState.Normal)
                    {
                        Form.WindowState = FormWindowState.Maximized;
                    }
                }
            }
            catch { return; }

            // Огранечение по Y
            if (Form.Location.Y < Screen.FromHandle(Form.Handle).WorkingArea.Y)
            {
                Form.Location = new Point(Form.Location.X, Screen.FromHandle(Form.Handle).WorkingArea.Y);
            }

            if (e.Button == MouseButtons.Left && Form.ControlBox == true)
            {
                // Close Button Click
                if (rectBtnClose.Contains(e.Location))
                    Form.Close();

                // Max Button Click
                if (rectBtnMax.Contains(e.Location) && Form.MaximizeBox == true)
                {
                    if (Form.WindowState == FormWindowState.Maximized)
                    {
                        Form.WindowState = FormWindowState.Normal;
                    }
                    else if (Form.WindowState == FormWindowState.Normal)
                    {
                        Form.WindowState = FormWindowState.Maximized;
                    }
                }

                // Min Button Click
                if (rectBtnMin.Contains(e.Location) && Form.MinimizeBox == true)
                    Form.WindowState = FormWindowState.Minimized;
            }
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Location.Y <= HeaderHeight
                && !rectBtnClose.Contains(e.Location)
                && !rectBtnMax.Contains(e.Location)
                && !rectBtnMin.Contains(e.Location))
            {
                MousePressed = true;
                clickPosition = Cursor.Position;
                moveStartPosition = Form.Location;
            }
        }

        private void Form_DoubleClick(object sender, EventArgs e)
        {
            if (!Form.MaximizeBox)
            {
                return;
            }

            if (MousePressed)
            {
                if (Form.WindowState == FormWindowState.Maximized)
                {
                    Form.WindowState = FormWindowState.Normal;
                }
                else if (Form.WindowState == FormWindowState.Normal)
                {
                    Form.WindowState = FormWindowState.Maximized;
                }
            }
        }

        #endregion

        private void DrawStyle(Graphics graph)
        {
            graph.SmoothingMode = SmoothingMode.HighQuality;

            Rectangle rectHeader = new Rectangle(0, 0, Form.Width - 1, HeaderHeight);
            Rectangle rectBorder = new Rectangle(0, 0, Form.Width - 1, Form.Height - 1);

            Rectangle rectIcon = new Rectangle(
                rectHeader.Height / 2 - IconSize.Width / 2,
                rectHeader.Height / 2 - IconSize.Height / 2,
                IconSize.Width, IconSize.Height
                );

            Rectangle rectTitleText = new Rectangle(rectIcon.Right + 5, rectHeader.Y, rectHeader.Width, rectHeader.Height);

            rectBtnClose = new Rectangle(rectHeader.Width - rectHeader.Height, rectHeader.Y, rectHeader.Height, rectHeader.Height);
            Rectangle rectCrosshair = new Rectangle(
                rectBtnClose.X + rectBtnClose.Width / 2 - 5,
                rectBtnClose.Height / 2 - 5,
                10, 10);

            rectBtnMax = new Rectangle(rectBtnClose.X - rectHeader.Height, rectHeader.Y, rectHeader.Height, rectHeader.Height);
            Rectangle rectMaxButtonIcon = new Rectangle(
                rectBtnMax.X + rectBtnMax.Width / 2 - 5,
                rectBtnMax.Height / 2 - 5,
                10, 10);

            rectBtnMin = new Rectangle(rectBtnMax.X - rectHeader.Height, rectHeader.Y, rectHeader.Height, rectHeader.Height);

            // Шапка
            graph.DrawRectangle(new Pen(HeaderColor), rectHeader);
            graph.FillRectangle(new SolidBrush(HeaderColor), rectHeader);

            // Текст заголовка
            graph.DrawString(Form.Text, Font, new SolidBrush(Color.White), rectTitleText, SF);

            // Иконка
            graph.DrawImage(Form.Icon.ToBitmap(), rectIcon);

            if (Form.ControlBox == true)
            {
                // Кнопка Х
                graph.DrawRectangle(new Pen(btnCloseHovered ? FlatColors.Red : HeaderColor), rectBtnClose);
                graph.FillRectangle(new SolidBrush(btnCloseHovered ? FlatColors.Red : HeaderColor), rectBtnClose);
                DrawCrosshair(graph, rectCrosshair, WhitePen);

                // Кнопка [MAX]
                graph.DrawRectangle(new Pen(btnMaximizeHovered && Form.MaximizeBox ? FlatColors.Gray : HeaderColor), rectBtnMax);
                graph.FillRectangle(new SolidBrush(btnMaximizeHovered && Form.MaximizeBox ? FlatColors.Gray : HeaderColor), rectBtnMax);

                if (EnableControlBoxIconsLight)
                {
                    Drawer.DrawBlurredRectangle(graph, Color.White, rectMaxButtonIcon, 8, 20);
                }

                graph.DrawRectangle(Form.MaximizeBox ? WhitePen : GrayPen, rectMaxButtonIcon);

                // Кнопка [ _ ] 
                graph.DrawRectangle(new Pen(btnMinimizeHovered && Form.MinimizeBox ? FlatColors.Gray : HeaderColor), rectBtnMin);
                graph.FillRectangle(new SolidBrush(btnMinimizeHovered && Form.MinimizeBox ? FlatColors.Gray : HeaderColor), rectBtnMin);
                Point p1 = new Point(rectBtnMin.X + rectBtnMin.Width / 2 - 5, rectBtnMin.Height / 2 + 5);
                Point p2 = new Point(rectBtnMin.X + rectBtnMin.Width / 2 + 5, rectBtnMin.Height / 2 + 5);

                if (EnableControlBoxIconsLight)
                {
                    Drawer.DrawBlurredLine(graph, Color.White, p1, p2, 8, 20);
                }

                graph.DrawLine(Form.MinimizeBox ? WhitePen : GrayPen, p1, p2);

                // Свечение от курсора
                if (EnableControlBoxMouseLight && (btnCloseHovered || btnMaximizeHovered || btnMinimizeHovered))
                {
                    Point cursorPoint1 = Form.PointToClient(Cursor.Position);
                    Point cursorPoint2 = new Point(cursorPoint1.X, cursorPoint1.Y + 1);
                    Drawer.DrawBlurredLine(graph, Color.White, cursorPoint1, cursorPoint2, 10, 70);
                }
            }

            // Обводка
            graph.DrawRectangle(new Pen(Color.Black), rectBorder);
        }

        private void DrawCrosshair(Graphics graph, Rectangle rect, Pen pen)
        {
            if (EnableControlBoxIconsLight)
            {
                Drawer.DrawBlurredLine(
                    graph,
                    Color.White,
                    new Point(rect.X, rect.Y),
                    new Point(rect.X + rect.Width, rect.Y + rect.Height),
                    8,
                    20);

                Drawer.DrawBlurredLine(graph,
                    Color.White,
                    new Point(rect.X + rect.Width, rect.Y),
                    new Point(rect.X, rect.Y + rect.Height),
                    8,
                    20);
            }

            graph.DrawLine(
                pen,
                rect.X,
                rect.Y,
                rect.X + rect.Width,
                rect.Y + rect.Height);

            graph.DrawLine(
                pen,
                rect.X + rect.Width,
                rect.Y,
                rect.X,
                rect.Y + rect.Height);
        }

        public static void SetDoubleBuffered(Control c)
        {
            if (SystemInformation.TerminalServerSession)
                return;

            System.Reflection.PropertyInfo pDoubleBuffered =
                  typeof(Control).GetProperty(
                        "DoubleBuffered",
                        System.Reflection.BindingFlags.NonPublic |
                        System.Reflection.BindingFlags.Instance);

            pDoubleBuffered.SetValue(c, true, null);
        }
    }
}
