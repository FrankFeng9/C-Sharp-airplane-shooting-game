using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PlaneTest.Properties;

namespace PlaneTest.Model
{
    public class Button
    {
        Image[] images;
        public int state;

        public Button()
        {
            images = new Image[2];
            images[0] = new Bitmap(22, 23);
            images[1] = new Bitmap(25, 27);

            Graphics g = Graphics.FromImage(images[0]);
            g.DrawImage(Resources.plane, new Rectangle(0, 0, 22, 23), new Rectangle(175, 148, 22, 23), GraphicsUnit.Pixel);
            g.Dispose();
            g = Graphics.FromImage(images[1]);
            g.DrawImage(Resources.plane, new Rectangle(0, 0, 25, 27), new Rectangle(216, 145, 25, 27), GraphicsUnit.Pixel);
            g.Dispose();
        }

        public void Pause()
        {
            state = 0;
        }

        public void Resume()
        {
            state = 1;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(images[state], new Point(10, 10));
        }
    }
}
