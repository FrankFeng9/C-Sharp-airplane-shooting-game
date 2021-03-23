using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PlaneTest.Properties;

namespace PlaneTest.Model
{
    public class Enemy_m
    {
        Image image;
        public Point location;
        public int lifem;
        public int stopTime;

        public Enemy_m()
        {
            image = new Bitmap(69, 89);
            Graphics g = Graphics.FromImage(image);
            g.DrawImage(Resources.plane, new Rectangle(0, 0, 69, 89), new Rectangle(130, 2, 69, 89), GraphicsUnit.Pixel);
            g.Dispose();

            lifem = 10;
        }

        public void Move()
        {
            location.Y += 3;
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
