using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PlaneTest.Properties;

namespace PlaneTest.Model
{
    public class Bullet
    {
        Image image;
        public Point location;

        public Bullet()
        {
            image = new Bitmap(9, 17);
            Graphics g = Graphics.FromImage(image);
            g.DrawImage(Resources.plane, new Rectangle(0, 0, 9, 17),new Rectangle(112, 2, 9, 17), GraphicsUnit.Pixel);
            g.Dispose();
        }

        public void Move()
        {
            location.Y -= 20;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(image, location.X - 4, location.Y);
        }
    }
}
