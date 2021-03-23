using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PlaneTest.Properties;

namespace PlaneTest.Model
{
    public class UniqueSkill
    {
        Image image;
        public int num;
        public Point location;

        public UniqueSkill()
        {
            image = new Bitmap(30, 29);
            Graphics g = Graphics.FromImage(image);
            g.DrawImage(Resources.plane, new Rectangle(0, 0, 30, 29), new Rectangle(184, 117, 30, 29),GraphicsUnit.Pixel);
            g.Dispose();
            num = 1;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(image, new Point(420, 600));
            g.DrawString(this.num + "", new Font("arial", 20), Brushes.Gray, new Point(390, 600));
        }
    }
}
