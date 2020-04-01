using MyNotebook.Models;
using System;
using System.Drawing;
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
            this.DoubleClick += Form_DoubleClick_Feature;
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

            // for game
            updateFrame = new System.Windows.Forms.Timer()
            {
                Enabled = false,
                Interval = 200
            };
            updateFrame.Tick += (ss, ee) => UpdateFrame();
        }
        #region pacman game
        enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
        class Pacman
        {
            PictureBox picture;
            bool isClosedImage = false;
            Control control;

            public Action ScoreUpdate;
            public bool isAlive { get; private set; } = false;
            public Point location => picture.Location;
            public int speed;
            public Direction direction;
            public int score = 0;
            Eat eat;
            public Pacman(Eat eat)
            {
                picture = new PictureBox()
                {
                    Location = new Point(33, 32),
                    Size = new Size(32, 32)
                };
                speed = 32;
                direction = Direction.Right;
                this.eat = eat;
            }

            public void move()
            {
                if (!isAlive)
                {
                    return;
                }

                picture.Invoke(new MethodInvoker(() =>
                {
                    #region set image
                    switch (direction)
                    {
                        case Direction.Up:
                            picture.BackgroundImage = Properties.Resources.pm_U;
                            picture.Location = new Point(picture.Location.X, picture.Location.Y - speed);
                            break;
                        case Direction.Down:
                            picture.BackgroundImage = Properties.Resources.pm_D;
                            picture.Location = new Point(picture.Location.X, picture.Location.Y + speed);
                            break;
                        case Direction.Left:
                            picture.BackgroundImage = Properties.Resources.pm_L;
                            picture.Location = new Point(picture.Location.X - speed, picture.Location.Y);
                            break;
                        case Direction.Right:
                            picture.BackgroundImage = Properties.Resources.pm_R;
                            picture.Location = new Point(picture.Location.X + speed, picture.Location.Y);
                            break;
                    }
                    isClosedImage = !isClosedImage;
                    if (isClosedImage)
                    {
                        picture.BackgroundImage = Properties.Resources.pm_closed;
                    }
                    #endregion

                    if (picture.Bounds.IntersectsWith(eat.picture.Bounds))
                    {
                        eat.ReSpawn();
                        score++;
                        ScoreUpdate?.Invoke();
                    }
                }));
            }
            public void addToForm(Control c)
            {
                isAlive = true;
                c.Controls.Add(picture);
                c.Controls.Add(eat.picture);
                control = c;
                
            }

            public void Kill()
            {
                isAlive = false;
                control.Controls.Remove(picture);
                control.Controls.Remove(eat.picture);
            }
        }
        class Eat
        {
            public PictureBox picture;
            Random rnd = new Random();
            
            public Eat()
            {
                picture = new PictureBox();
                picture.Size = new Size(16, 16);
                picture.BackgroundImage = Properties.Resources.pm_eat;
                ReSpawn();
            }

            public void ReSpawn()
            {
                int x = rnd.Next(32, 500);
                int y = rnd.Next(32, 395);

                x -= x % 32 + 1;
                y -= y % 32;

                picture.Location = new Point(x, y);
            }
        }
        Pacman pacman;
        Eat eat;
        System.Windows.Forms.Timer updateFrame;
        void Form_DoubleClick_Feature(object sender, EventArgs e)
        {
            lbl_score.Visible = true;

            eat = new Eat();
            pacman = new Pacman(eat);

            pacman.ScoreUpdate += () => lbl_score.Text = $"Очки: {pacman.score}";

            HideAllElements();
            pacman.addToForm(this);
            updateFrame.Enabled = true;

            this.KeyDown += FormSelectStartType_KeyDown;
        }

        private void UpdateFrame()
        {
            if (!pacman.isAlive)
            {
                return;
            }

            HideAllElements();
            pacman.move();

            if (pacman.location.X > 535)
            {
                pm_death();
            }
            else if (pacman.location.X < 0)
            {
                pm_death();
            }
            else if (pacman.location.Y < 32)
            {
                pm_death();
            }
            else if (pacman.location.Y > 400)
            {
                pm_death();
            }
        }

        void pm_death()
        {
            pacman.Kill();
            pacman = new Pacman(eat);
            ShowAllElements();
            lbl_score.Visible = false;
        }

        void FormSelectStartType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W || e.KeyCode == Keys.Up)
            {
                pacman.direction = Direction.Up;
            }
            else if (e.KeyCode == Keys.A || e.KeyCode == Keys.Left)
            {
                pacman.direction = Direction.Left;
            }
            else if (e.KeyCode == Keys.S || e.KeyCode == Keys.Down)
            {
                pacman.direction = Direction.Down;
            }
            else if (e.KeyCode == Keys.D || e.KeyCode == Keys.Right)
            {
                pacman.direction = Direction.Right;
            }
        }

        #endregion

        void HideAllElements()
        {
            btn_update.Visible = false;
            button1.Visible = false;
            button2.Visible = false;

            btn_update.Enabled = false;
            button1.Enabled = false;
            button2.Enabled = false;
        }

        void ShowAllElements()
        {
            btn_update.Visible = true;
            button1.Visible = true;
            button2.Visible = true;

            btn_update.Enabled = true;
            button1.Enabled = true;
            button2.Enabled = true;
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
