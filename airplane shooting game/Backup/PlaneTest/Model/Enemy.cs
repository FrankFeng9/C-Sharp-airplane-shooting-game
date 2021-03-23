using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PlaneTest.Properties;

namespace PlaneTest.Model
{
    public class Enemy
    {
        Image image;
        public Point location;
        public int life;
        public int stopTime;

        public Enemy()
        {
            image = new Bitmap(39, 27);
            Graphics g = Graphics.FromImage(image);
            g.DrawImage(Resources.plane, new Rectangle(0, 0, 39, 27), new Rectangle(201, 88, 39, 27), GraphicsUnit.Pixel);
            g.Dispose();

            life = 2;
            stopTime = -1;
        }

        public void Move()
        {
            stopTime--;
            if (stopTime < 0)
            {
                location.Y += 3;
            }
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(image, location);
        }

        public Explosion Bomb()
        {
            return new Explosion() { location = this.location };
        }
    }
}
