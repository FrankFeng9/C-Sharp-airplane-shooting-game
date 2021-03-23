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
            g.DrawString("第一关", new Font("宋体", 15), Brushes.Gray, new Point(200, 270));
        }

        public void Draw1(Graphics g)
        {
            g.DrawString("第二关", new Font("宋体", 15), Brushes.Gray, new Point(200, 270));
        }
    }
}
