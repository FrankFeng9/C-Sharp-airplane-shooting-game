using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PlaneTest.Model
{
    public class Board
    {
        public int score;

        public void setScore(int score)
        {
            if (score == 1)
            {
                this.score += score * 10;
            }
            else if (score == 2)
            {
                this.score += score * 20;
            }
            else if (score == 3)
            {
                this.score += 2000;
            }
        }

        public void DrawScore(Graphics g)
        {
            g.DrawString(this.score + "", new Font("arial", 20), Brushes.Gray, new Point(40, 10));
        }

        public void Draw(Graphics g)
        {
            //g.FillRectangle(new SolidBrush(Color.FromArgb(238, 238, 238)), new Rectangle(165, 240, 150, 200));
            g.DrawRectangle(Pens.Gray, new Rectangle(165, 240, 150, 200));
            g.DrawLine(Pens.Gray, 165, 265, 315, 265);
            g.DrawString("Score", new Font("arial", 12), Brushes.Gray, new Point(170, 244));
            g.DrawString(this.score + "", new Font("arial", 11), Brushes.Gray, new Point(170, 270));
            g.DrawString("click to continue", new Font("arial", 12), Brushes.Gray, new PointF(190, 390));
            g.DrawString("Esc to quit", new Font("arial", 12), Brushes.Gray, new PointF(190, 415));
        }
    }
}
