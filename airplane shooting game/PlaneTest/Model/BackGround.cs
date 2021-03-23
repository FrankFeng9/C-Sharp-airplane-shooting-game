using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PlaneTest.Properties;

namespace PlaneTest.Model
{
    public class BackGround
    {
        Image images;
        int y;

        public BackGround()
        {
            images = Resources.background;
        }

        public void Update()
        {
            if (y == 800)
                y = 0;
            y += 2;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(images, 0, y, 480, 800);
            g.DrawImage(images, 0, y - 800, 480, 800);
        }
    }
}
