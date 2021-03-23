using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PlaneTest.Properties;
using PlaneTest.Model;

namespace PlaneTest
{
    public partial class GamePlane : Form
    {
        static void Main(string[] args)
        {
            new GamePlane().ShowDialog();
        }

        Timer timer;
        Map map;
        UniqueSkill uniqueSkill;

        public GamePlane()
        {
            this.Width = 480;//窗口
            this.Height = 640;
            this.FormBorderStyle = FormBorderStyle.None;//无边界
            this.StartPosition = FormStartPosition.CenterScreen;//屏幕中间
            this.DoubleBuffered = true;
            Cursor.Hide();
            //定时器设置
            timer = new Timer();
            timer.Interval = 37;
            timer.Tick += new EventHandler(Timer_Tick);
            timer.Start();

            //初始化地图
            map = new Map();
            uniqueSkill = new UniqueSkill();
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            map.UpdateData();
        /*    if (map.gameover)
                Cursor.Show();*/
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            map.UpdateFrame(e.Graphics);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            map.mouseLocation = e.Location;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            Cursor.Hide();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            Cursor.Show();
        }

        protected override void OnKeyDown(KeyEventArgs e)//键盘按下
        {
            if (e.KeyCode == Keys.Space)
            {
                map.pause = !map.pause;
            }
            //if (e.KeyCode == Keys.Enter&&map.gameover)
            //{
            //    map.Restart();
            //}
            if (e.KeyCode == Keys.Escape&&map.gameover)
            {
                Close();
            }
            if (e.KeyCode == Keys.A)
            {
                map.ClearSkill();
            }
            if (e.KeyCode == Keys.F1)
            {
                map.AboutGame();
            }
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (map.gameover)
            {
                map.Restart();
            }
            if (!map.startGame)
            {
                map.StartGame();
            }
        }

        private void GamePlane_Load(object sender, EventArgs e)
        {

        }
    }
}
