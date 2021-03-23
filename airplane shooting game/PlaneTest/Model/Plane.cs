using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PlaneTest.Properties;

namespace PlaneTest.Model
{
    public class Plane
    {
        Image[] images;
        public Point location;
        int state;

        public Plane()
        {
            images = new Image[2];
            images[0] = new Bitmap(62, 75);
            images[1] = new Bitmap(62, 68);

            Graphics g = Graphics.FromImage(images[0]);
            g.DrawImage(Resources.plane, new Rectangle(0, 0, 62, 75), new Rectangle(2, 168, 62, 75), GraphicsUnit.Pixel);
            g.Dispose();
            Graphics g2 = Graphics.FromImage(images[1]);
            g2.DrawImage(Resources.plane, new Rectangle(0, 0, 62, 68), new Rectangle(66, 168, 62, 68), GraphicsUnit.Pixel);
            g2.Dispose();

        }

        public void Update()
        {
            state = 1 - state;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(images[state], location.X-31,location.Y);
        }

        public Bullet Fire()
        {
            return new Bullet() { location = this.location };
        }

        public Bullet DoubleFire1()
        {
            return new Bullet() { location = new Point(this.location.X + 25, this.location.Y + 25) };
        }

        public Bullet DoubleFire2()
        {
            return new Bullet() { location = new Point(this.location.X - 25, this.location.Y + 25) };
        }

        public void Move(Point dest)
        {
            location = dest;
        }
    }
}
