using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PlaneTest.Model
{
    public class About
    {
        public void Draw(Graphics g)
        {
            g.DrawRectangle(Pens.Gray, new Rectangle(165, 240, 150, 200));
            g.DrawLine(Pens.Gray, 165, 265, 315, 265);
            g.DrawString("Help", new Font("arial", 12), Brushes.Gray, new Point(200, 244));
            g.DrawString("A to ultimate", new Font("arial", 12), Brushes.Gray, new PointF(190, 290));
            g.DrawString("Space to pause", new Font("arial", 12), Brushes.Gray, new PointF(190, 330));
            g.DrawString("ESC to quit", new Font("arial", 12), Brushes.Gray, new PointF(190, 370));
            g.DrawString("F1 to continue", new Font("arial", 12), Brushes.Gray, new PointF(190, 410));
        }

        public void DrawAbout(Graphics g)
        {
            g.DrawString("F1 Help", new Font("arial", 12), Brushes.Gray, new Point(10, 610));
        }
    }
}
