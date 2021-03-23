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
            g.DrawString("游戏帮助", new Font("宋体", 12), Brushes.Gray, new Point(200, 244));
            g.DrawString("A键绝招", new Font("宋体", 12), Brushes.Gray, new PointF(190, 280));
            g.DrawString("空格键暂停", new Font("宋体", 12), Brushes.Gray, new PointF(190, 310));
            g.DrawString("按ESC退出游戏", new Font("宋体", 12), Brushes.Gray, new PointF(190, 340));
            g.DrawString("帮助文档F1", new Font("宋体", 12), Brushes.Gray, new PointF(190, 370));
            g.DrawString("按F1继续游戏", new Font("宋体", 12), Brushes.Gray, new PointF(190, 400));
        }

        public void DrawAbout(Graphics g)
        {
            g.DrawString("F1帮助", new Font("宋体", 12), Brushes.Gray, new Point(10, 610));
        }
    }
}
