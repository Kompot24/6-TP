using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WinFormsApp1.Particle;

namespace WinFormsApp1
{
    class Emitter
    {
        public float GravitationX = 0;
        public float GravitationY = 0;

        List<Particle> particles = new List<Particle>();

        public int MousePositionX = 0;
        public int MousePositionY = 0;

        public List<IImpactPoint> impactPoints = new List<IImpactPoint>();

        public int ParticlesCount = 500;

        public int X;
        public int Y;
        public int Direction = 0;
        public int Spreading = 360;
        public int SpeedMin = 1;
        public int SpeedMax = 10;
        public int RadiusMin = 2;
        public int RadiusMax = 10;
        public int LifeMin = 20;
        public int LifeMax = 100;
        public int ParticlePerTick = 1;

        public Color ColorFrom = Color.White;
        public Color ColorTo = Color.FromArgb(0, Color.Black);
        public void UpdateState()
        {
            int particlesToCreate = ParticlePerTick;

            foreach (var particle in particles)
            {

                if (particle.Life <= 0)
                {
                    if(particlesToCreate > 0)
                    {
                        particlesToCreate -= 1;
                        ResetParticle(particle);
                    }
                }
                else
                {
                    particle.X += particle.SpeedX;
                    particle.Y += particle.SpeedY;
                    foreach (var point in impactPoints)
                    {
                        point.ImpactParticle(particle);
                    }
                    particle.SpeedX += GravitationX;
                    particle.SpeedY += GravitationY;
                }
            }

            for (var i = 0; i < 10; i++)
            {
                if (particles.Count < ParticlesCount)
                {
                    var particle = CreateParticle();
                    ResetParticle(particle);
                    particles.Add(particle);
                }
                else
                {
                    break;
                }
            }
            while(particlesToCreate >= 1)
            {
                particlesToCreate -= 1;
                var particle = CreateParticle();
                ResetParticle(particle);
                particles.Add(particle);
            }
        }

        public virtual void ResetParticle(Particle particle)
        {
            particle.Life = Particle.rand.Next(LifeMin, LifeMax);
            particle.X = X;
            particle.Y = Y;

            var direction = Direction + (double)Particle.rand.Next(Spreading) - Spreading / 2;
            var speed = Particle.rand.Next(SpeedMin, SpeedMax);

            particle.SpeedX = (float)(Math.Cos(direction / 180 * Math.PI) * speed);
            particle.SpeedY = -(float)(Math.Sin(direction / 180 * Math.PI) * speed);

            particle.Radius = Particle.rand.Next(RadiusMin, RadiusMax);
        }

        public virtual Particle CreateParticle()
        {
            var particle = new ParticleColorful();
            particle.FromColor = ColorFrom;
            particle.ToColor = ColorTo;

            return particle;
        }

        public void Render(Graphics g)
        {
            foreach (var particle in particles)
            {
                particle.Draw(g);
            }

            foreach (var point in impactPoints)
            {
                point.Render(g);
            }
        }

        public class TopEmitter : Emitter
        {
            public int width;

            public override void ResetParticle(Particle particle)
            {
                base.ResetParticle(particle);

                particle.X = Particle.rand.Next(width);
                particle.Y = 0;

                particle.SpeedY = 1;
                particle.SpeedX = Particle.rand.Next(-2, 2);
            }
        }
    }

}
