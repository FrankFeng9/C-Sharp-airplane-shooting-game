using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PlaneTest.Properties;

namespace PlaneTest.Model
{
    public class BossBullet
    {
        Image image;
        public Point location;

        public BossBullet()
        {
            image = new Bitmap(8, 15);
            Graphics g = Graphics.FromImage(image);
            g.DrawImage(Resources.plane, new Rectangle(0, 0, 8, 15), new Rectangle(66, 238, 8, 15), GraphicsUnit.Pixel);
            g.Dispose();
        }

        public void Move()
        {
            location.Y += 11;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(image, location.X + 54, location.Y + 150);
        }
    }
}
