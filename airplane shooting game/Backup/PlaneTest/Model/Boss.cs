using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PlaneTest.Properties;

namespace PlaneTest.Model
{
    public class Boss
    {
        Image image;
        public Point location;
        public int lifeb;
        int x = -2;
        int y = 3;

        public Boss()
        {
            image = new Bitmap(108, 164);

            Graphics g = Graphics.FromImage(image);
            g.DrawImage(Resources.plane, new Rectangle(0, 0, 108, 164), new Rectangle(2, 2, 108, 164), GraphicsUnit.Pixel);
            g.Dispose();

            lifeb = 200;

        }

        public BossBullet Fire1()
        {
            return new BossBullet() { location = new Point(this.location.X + 20, this.location.Y) };
        }

        public BossBullet Fire2()
        {
            return new BossBullet() { location = new Point(this.location.X - 20, this.location.Y) };
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(image, location);
        }

        public void DrawBlood(Graphics g)
        {
            if (lifeb > 100)
            {
                g.FillRectangle(Brushes.Red, 300, 1, 100, 30);
                g.FillRectangle(Brushes.Orange, 300, 1, lifeb - 100, 30);
            }
            else
            {
                g.FillRectangle(Brushes.Red, 300, 1, lifeb, 30);
            }
        }

        public void DrawLife(Graphics g)
        {
            g.DrawString(this.lifeb + "", new Font("宋体", 20), Brushes.Gray, new Point(320, 1));
        }

        public Explosion Bomb()
        {
            return new Explosion() { location = this.location };
        }

        public void Move()
        {

            if (location.Y > 480 || location.Y < 0)
                y *= -1;
            location.Y += y;
            if (location.X < 0 || location.X > 372)
            {
                x *= -1;
            }

            location.X += x;



            //if (location.X <= 15)
            //{
            //    location.X++;
            //    state = 1;
            //}
            //if (location.X >= 350)
            //{
            //    location.X--;
            //    state = 0;
            //}
            //if (location.X >= 15 && location.X<=350)
            //{
            //    if (state == 1)
            //        location.X++;
            //    else
            //        location.X--;

            //}
        }

    }
}
