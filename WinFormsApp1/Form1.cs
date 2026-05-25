using static WinFormsApp1.Emitter;
using static WinFormsApp1.Particle;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        List<Emitter> emitters = new List<Emitter>();
        Emitter emitter;

        GravityPoint point1;

        TeleportPoint teleport;

        List<CounterPoint> counters = new List<CounterPoint>();
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
                ColorFrom = Color.Gold,
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlePerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };

            emitters.Add(this.emitter);

            point1 = new GravityPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2
            };

            emitter.impactPoints.Add(point1);

            teleport = new TeleportPoint(
                picDisplay.Width / 2 - 150,
                picDisplay.Height / 2,
                picDisplay.Width / 2,
                picDisplay.Height / 2 - 100
            );
            emitter.impactPoints.Add(teleport);

            picDisplay.MouseClick += picDisplay_MouseClick;
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            emitter.UpdateState();

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.Black);
                emitter.Render(g);

            }

            picDisplay.Invalidate();
        }

        private void picDisplay_MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var emitter in emitters)
            {
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;
            }
        }

        private void tbDirection_Scroll(object sender, EventArgs e)
        {
            emitter.Direction = tbDirection.Value;
            lblDirection.Text = $"{tbDirection.Value}°";
        }

        private void tbGravitation_Scroll(object sender, EventArgs e)
        {
            point1.Power = tbGravitation.Value;
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
    }
}
