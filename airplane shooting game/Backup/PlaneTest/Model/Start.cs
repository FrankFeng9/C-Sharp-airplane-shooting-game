using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PlaneTest.Model
{
    public class Start
    {
        //Bitmap animatedImage = new Bitmap("loading.gif");
        //bool currentlyAnimating = false;

        //public Start()
        //{
        //    ImageAnimator.Animate(animatedImage, new EventHandler(this.OnFrameChanged));
        //    currentlyAnimating = true;
        //}

        public void Draw(Graphics g)
        {
            g.DrawString("飞机大战", new Font("宋体", 45), Brushes.Gray, new Point(110, 244));
            g.DrawString("点击鼠标开始", new Font("宋体", 15), Brushes.Gray, new Point(170, 330));
        }

        //private void OnFrameChanged(object o, EventArgs e)
        //{

        //    //Force a call to the Paint event handler.
        //    this.Invalidate();
        //}
        ////Application.Run(new animateImage());
        //protected override void OnPaint(PaintEventArgs e)
        //{

        //    //Begin the animation.
        //    AnimateImage();

        //    //Get the next frame ready for rendering.
        //    ImageAnimator.UpdateFrames();

        //    //Draw the next frame in the animation.
        //    e.Graphics.DrawImage(this.animatedImage, new Point(0, 0));
        //}

    }
}
