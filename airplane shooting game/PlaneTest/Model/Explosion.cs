using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PlaneTest.Properties;

namespace PlaneTest.Model
{
    public class Explosion
    {
        Image[] image;
        public Point location;
        public int state;

        public Explosion()
        {
            image = new Image[3];
            image[0] = new Bitmap(26, 26);
            image[1] = new Bitmap(38, 39);
            image[2] = new Bitmap(40, 42);

            Graphics g = Graphics.FromImage(image[0]);
            g.DrawImage(Resources.plane, new Rectangle(0, 0, 26, 26), new Rectangle(216, 117, 26, 26), GraphicsUnit.Pixel);
            g.Dispose();
            g = Graphics.FromImage(image[1]);
            g.DrawImage(Resources.plane, new Rectangle(0, 0, 38, 39), new Rectangle(144, 93, 38, 39), GraphicsUnit.Pixel);
            g.Dispose();
            g = Graphics.FromImage(image[2]);
            g.DrawImage(Resources.plane, new Rectangle(0, 0, 40, 42), new Rectangle(201, 44, 40, 42), GraphicsUnit.Pixel);
            g.Dispose();

            state = 0;
        }

        public void Play()
        {
            if (state < 2)
            {
                state++;
            }
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(image[state], location);
        }
    }
}
