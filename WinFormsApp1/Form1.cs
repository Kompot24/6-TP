using static WinFormsApp1.Emitter;
using static WinFormsApp1.Particle;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;

        TeleportPoint teleport;

        List<CounterPoint> counters = new List<CounterPoint>();
        BouncePoint mouseBouncePoint;
        public Form1()
        {
            InitializeComponent();

            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            this.emitter = new Emitter
            {
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = Color.BlueViolet,
                ColorTo = Color.FromArgb(0, Color.RoyalBlue),
                ParticlePerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            emitters.Add(this.emitter);

            teleport = new TeleportPoint(
                picDisplay.Width / 2 - 150,
                picDisplay.Height / 2,
                picDisplay.Width / 2,
                picDisplay.Height / 2 - 100
            );
            emitter.impactPoints.Add(teleport);

            picDisplay.MouseClick += picDisplay_MouseClick;

            BouncePoint staticPoint1 = new BouncePoint { X = 300, Y = picDisplay.Height / 2 - 100 };
            BouncePoint staticPoint2 = new BouncePoint { X = 450, Y = picDisplay.Height / 2 + 100 };

            emitter.impactPoints.Add(staticPoint1);
            emitter.impactPoints.Add(staticPoint2);
            mouseBouncePoint = new BouncePoint { X = picDisplay.Width / 2, Y = picDisplay.Height / 2 };
            emitter.impactPoints.Add(mouseBouncePoint);

            picDisplay.MouseMove += picDisplay_MouseMove;
            picDisplay.MouseWheel += picDisplay_MouseWheel;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.FromArgb(10, 15, 30));
                emitter.Render(g);

            }

            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseBouncePoint != null)
            {
                mouseBouncePoint.X = e.X;
                mouseBouncePoint.Y = e.Y;
            }
        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
            lblDirection.Text = $"{tbDirection.Value}°";
        }

        private void picDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys == Keys.Alt)
            {
                if (e.Button == MouseButtons.Left)
                {
                    CounterPoint newCounter = new CounterPoint
                    {
                        X = e.X,
                        Y = e.Y
                    };

                    counters.Add(newCounter);
                    emitter.impactPoints.Add(newCounter);
                }
                else if (e.Button == MouseButtons.Right)
                {
                    CounterPoint targetCounter = null;

                    foreach (var counter in counters)
                    {
                        float dx = counter.X - e.X;
                        float dy = counter.Y - e.Y;
                        double distance = Math.Sqrt(dx * dx + dy * dy);

                        if (distance < counter.Radius)
                        {
                            targetCounter = counter;
                            break;
                        }
                    }

                    if (targetCounter != null)
                    {
                        counters.Remove(targetCounter);
                        emitter.impactPoints.Remove(targetCounter);
                    }
                }
            }
            else
            {
                if (e.Button == MouseButtons.Left)
                {
                    teleport.X = e.X;
                    teleport.Y = e.Y;
                }
                else if (e.Button == MouseButtons.Right)
                {
                    teleport.ExitX = e.X;
                    teleport.ExitY = e.Y;
                }
            }
        }

        private void tbTeleportRad_Scroll(object sender, EventArgs e)
        {
            if (teleport != null)
            {
                teleport.Radius = tbTeleportRad.Value;
            }
        }

        private void tbTeleportDirect_Scroll(object sender, EventArgs e)
        {
            if (teleport != null)
            {
                if (tbTeleportDirect.Value == 0)
                {
                    teleport.ChangeDirection = false;
                }
                else
                {
                    teleport.ChangeDirection = true;
                    teleport.ExitDirection = tbTeleportDirect.Value;
                }
            }
        }

        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            if (mouseBouncePoint != null)
            {
                if (e.Delta > 0)
                {
                    mouseBouncePoint.Radius += 5;
                }
                else
                {
                    mouseBouncePoint.Radius -= 5;
                }

                if (mouseBouncePoint.Radius < 10)
                {
                    mouseBouncePoint.Radius = 10;
                }
                if (mouseBouncePoint.Radius > 222)
                {

                    mouseBouncePoint.Radius = 200;
                }
            }
        }
    }
}
