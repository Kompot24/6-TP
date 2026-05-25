using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public abstract class IImpactPoint
    {
        public float X;
        public float Y;

        public abstract void ImpactParticle(Particle particle);

        public virtual void Render(Graphics g)
        {
            g.FillEllipse(
                    new SolidBrush(Color.Red),
                    X - 5,
                    Y - 5,
                    10,
                    10
                );
        }
    }

    public class CounterPoint : IImpactPoint
    {
        public int Radius = 30;
        public int Count = 0;

        public override void ImpactParticle(Particle particle)
        {
            float dx = X - particle.X;
            float dy = Y - particle.Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);

            if (distance < Radius)
            {
                Count++;
                particle.Life = 0;
            }
        }

        public override void Render(Graphics g)
        {
            int redValue = Math.Min(50 + Count * 2, 255);

            SolidBrush brush = new SolidBrush(Color.FromArgb(redValue, 0, 0));
            Pen pen = new Pen(Color.Red, 2);

            g.FillEllipse(brush, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            g.DrawEllipse(pen, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            brush.Dispose();
            pen.Dispose();

            Font font = new Font("Verdana", 10, FontStyle.Bold);
            SolidBrush textBrush = new SolidBrush(Color.White);

            string text = Count.ToString();

            SizeF textSize = g.MeasureString(text, font);
            g.DrawString(text, font, textBrush, X - textSize.Width / 2, Y - textSize.Height / 2);

            font.Dispose();
            textBrush.Dispose();
        }
    }

    public class BouncePoint : IImpactPoint
    {
        public int Radius = 40;

        public override void ImpactParticle(Particle particle)
        {
            float dx = particle.X - X;
            float dy = particle.Y - Y;
            double distance = Math.Sqrt(dx * dx + dy * dy);

            if (distance < Radius)
            {
                // Нахождение нормали
                float nx = dx / (float)distance;
                float ny = dy / (float)distance;

                particle.X = X + nx * Radius;
                particle.Y = Y + ny * Radius;

                // Скалярное произведение вектора скорости на нормаль
                float dotProduct = particle.SpeedX * nx + particle.SpeedY * ny;

                // По ормуле отражения вектора
                particle.SpeedX = particle.SpeedX - 2 * dotProduct * nx;
                particle.SpeedY = particle.SpeedY - 2 * dotProduct * ny;
            }
        }

        public override void Render(Graphics g)
        {
            Pen pen = new Pen(Color.White, 3);
            SolidBrush brush = new SolidBrush(Color.FromArgb(40, Color.White));

            g.FillEllipse(brush, X - Radius, Y - Radius, Radius * 2, Radius * 2);
            g.DrawEllipse(pen, X - Radius, Y - Radius, Radius * 2, Radius * 2);

            pen.Dispose();
            brush.Dispose();
        }
    }

}
