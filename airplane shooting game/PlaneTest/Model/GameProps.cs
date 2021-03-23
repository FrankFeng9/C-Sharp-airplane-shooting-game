using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PlaneTest.Properties;

namespace PlaneTest.Model
{
    public class GameProps
    {
        Image[] image;
        public Point location;
        public int state;
        Random random;

        public GameProps()
        {
            image = new Image[2];
            image[0] = new Bitmap(30, 46);
            image[1] = new Bitmap(29, 46);
            random = new Random();

            Graphics g = Graphics.FromImage(image[0]);
            g.DrawImage(Resources.plane, new Rectangle(0, 0, 30, 46), new Rectangle(112, 117, 30, 46), GraphicsUnit.Pixel);
            g.Dispose();
            g = Graphics.FromImage(image[1]);
            g.DrawImage(Resources.plane, new Rectangle(0, 0, 29, 46), new Rectangle(144, 134, 29, 46), GraphicsUnit.Pixel);
            g.Dispose();

            state = random.Next(0, 2);
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(image[state], location);
        }

        public void Move()
        {
            location.Y += 3;
        }
    }
}
