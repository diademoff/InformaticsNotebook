using System.Drawing;
using System.Windows.Forms;

namespace MyNotebook.Forms
{
    public partial class FormBitmapViewer : Form
    {
        Graphics graphics;
        private bool isPressed = false;
        public FormBitmapViewer(Bitmap bitmap)
        {
            InitializeComponent();

            Width = bitmap.Width;
            Height = bitmap.Height;
            pictureBox.Image = bitmap;
            
            pictureBox.Paint += PictureBox_Paint;
            pictureBox.MouseDown += PictureBox_MouseDown;
            pictureBox.MouseUp += PictureBox_MouseUp;
            pictureBox.MouseMove += PictureBox_MouseMove;
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isPressed = false;
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isPressed)
            {
                return;
            }
            graphics.FillEllipse(new SolidBrush(Color.Black), e.X, e.Y, 5, 5);
        }

        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            isPressed = true;
        }

        private void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            graphics = pictureBox.CreateGraphics();
        }
    }
}
