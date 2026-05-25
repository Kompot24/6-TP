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

    public class GravityPoint : IImpactPoint
    {
        public int Power = 100;

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY);
            if (r + particle.Radius < Power / 2)
            {
                float r2 = (float)Math.Max(100, gX * gX + gY * gY);
                particle.SpeedX += gX * Power / r2;
                particle.SpeedY += gY * Power / r2;
            }
        }

        public override void Render(Graphics g)
        {
            g.DrawEllipse(
                new Pen(Color.Red),
                X - Power / 2,
                Y - Power / 2,
                Power,
                Power
                );

            var stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.LineAlignment = StringAlignment.Center;

            var text = $"Я гравитон\nc силой {Power}";
            var font = new Font("Verdana", 10);

            var size = g.MeasureString(text, font);

            g.FillRectangle(
                new SolidBrush(Color.Red),
                X - size.Width / 2,
                Y - size.Height / 2,
                size.Width,
                size.Height
            );

            g.DrawString(
                text,
                font,
                new SolidBrush(Color.White),
                X,
                Y,
                stringFormat
            );
        }
    }
    public class AntiGravityPoint : IImpactPoint
    {
        public int Power = 100;

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            float r2 = (float)Math.Max(100, gX * gX + gY * gY);

            particle.SpeedX -= gX * Power / r2; 
            particle.SpeedY -= gY * Power / r2;
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


}
