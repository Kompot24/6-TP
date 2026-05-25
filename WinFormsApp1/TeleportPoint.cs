using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace WinFormsApp1
{
    public class TeleportPoint : IImpactPoint
    {
        public int Radius = 40;
        public float ExitX;
        public float ExitY;

        public int ExitDirection = 0;
        public bool ChangeDirection = false;

        public TeleportPoint(float startX, float startY, float exitX, float exitY)
        {
            X = startX;
            Y = startY;
            ExitX = exitX;
            ExitY = exitY;
        }

        public override void ImpactParticle(Particle particle)
        {
            float dx = X - particle.X;
            float dy = Y - particle.Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);

            if (distance < Radius)
            {
                particle.X = ExitX;
                particle.Y = ExitY;

                if (ChangeDirection)
                {
                    float currentSpeed = (float)Math.Sqrt(particle.SpeedX * particle.SpeedX + particle.SpeedY * particle.SpeedY);

                    double angleRad = ExitDirection * Math.PI / 180.0;

                    particle.SpeedX = (float)(Math.Cos(angleRad) * currentSpeed);
                    particle.SpeedY = -(float)(Math.Sin(angleRad) * currentSpeed);
                }
            }
        }

        public override void Render(Graphics g)
        {
            Pen penIn = new Pen(Color.DeepSkyBlue, 2);
            SolidBrush brushIn = new SolidBrush(Color.FromArgb(50, Color.DeepSkyBlue));
            g.FillEllipse(brushIn, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            g.DrawEllipse(penIn, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            penIn.Dispose();
            brushIn.Dispose();

            int exitRadius = 15;
            Pen penOut = new Pen(Color.OrangeRed, 2);
            SolidBrush brushOut = new SolidBrush(Color.FromArgb(70, Color.Red));
            g.FillEllipse(brushOut, ExitX - exitRadius, ExitY - exitRadius, exitRadius * 2, exitRadius * 2);
            g.DrawEllipse(penOut, ExitX - exitRadius, ExitY - exitRadius, exitRadius * 2, exitRadius * 2);
            penOut.Dispose();
            brushOut.Dispose();

            Font font = new Font("Verdana", 8, FontStyle.Bold);
            SolidBrush textBrush = new SolidBrush(Color.White);
            g.DrawString("ВХОД", font, textBrush, X - 18, Y - 6);
            g.DrawString("ВЫХОД", font, textBrush, ExitX - 22, ExitY - 6);
            font.Dispose();
            textBrush.Dispose();
        }
    }
}