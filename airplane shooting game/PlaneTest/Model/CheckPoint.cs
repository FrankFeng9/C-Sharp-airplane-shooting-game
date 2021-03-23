using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PlaneTest.Model
{
    public class CheckPoint
    {
        public void Draw(Graphics g)
        {
            g.DrawString("stage one", new Font("arial", 15), Brushes.Gray, new Point(200, 270));
        }

        public void Draw1(Graphics g)
        {
            g.DrawString("stage two", new Font("arial", 15), Brushes.Gray, new Point(200, 270));
        }
    }
}
