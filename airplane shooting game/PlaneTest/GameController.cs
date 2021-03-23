using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using PlaneTest.Properties;

namespace PlaneTest.Model
{
    public class Map
    {
        Plane player;
        BackGround background;
        Random random;
        CheckPoint checkPoint;
        UniqueSkill uniqueSkill;
        Start start;
        Button button;
        Board board;
        Boss boss;
        About about;
        List<Explosion> explosiones;
        List<Bullet> bullet;
        List<BossBullet> bossBullet;
        List<Enemy> enemies;
        List<Enemy_m> enemy_ms;
        List<GameProps> gameProps;
        SoundController soundController;
        public bool gameover;
        public bool pause;
        public bool aboutGame;
        public bool startGame;
        public Point mouseLocation;
        int propsState;
        int propsDuration;
        int bossFireTime;
        int outTime;
        int planeTime;
        int enemy_mTime;
        int bombTime;
        int propsStopTime;
        int aboutTime;

        public Map()
        {
            this.Restart();
        }

        public void Restart()
        {
            bullet = new List<Bullet>();
            enemies = new List<Enemy>();
            explosiones = new List<Explosion>();
            enemy_ms = new List<Enemy_m>();
            gameProps = new List<GameProps>();
            bossBullet = new List<BossBullet>();
            player = new Plane();
            player.location = new Point(220, 500);
            background = new BackGround();
            random = new Random();
            soundController = new SoundController();
            button = new Button();
            board = new Board();
            start = new Start();
            checkPoint = new CheckPoint();
            uniqueSkill = new UniqueSkill();
            boss = new Boss();
            about = new About();
            pause = false;
            gameover = false;
            startGame = false;
            aboutGame = false;
            bombTime = 0;
            propsState = 1;
            propsDuration = 0;
            bossFireTime = 0;
            outTime = 0;
            planeTime = 0;
            propsStopTime = 500;
            enemy_mTime = 300;
            aboutTime = 0;

        }

        public void StartGame()
        {
            startGame = true;
        }

        public void ClearSkill()
        {
            if (uniqueSkill.num > 0)
            {
                uniqueSkill.num--;
                if (boss.lifeb > 0 && board.score > 100)
                {
                    explosiones.Add(boss.Bomb());
                    boss.lifeb -= 20;
                }
                for (int i = 0; i < enemies.Count; i++)
                {
                    explosiones.Add(enemies[i].Bomb());
                    enemies.RemoveAt(i);
                    i--;

                }
                for (int i = 0; i < enemy_ms.Count; i++)
                {
                    explosiones.Add(enemy_ms[i].Bomb());
                    enemy_ms.RemoveAt(i);
                    i--;
                }
            }
        }

        public void AboutGame()
        {
            if (aboutTime == 0)
            {
                aboutGame = true;
                aboutTime = 1;
            }
            else if (aboutTime == 1)
            {
                aboutGame = false;
                aboutTime = 0;
            }
        }

        private void Fire()
        {
            GameProps p = new GameProps();
            if (outTime == 0)
            {
                if (propsState == 1)
                {
                    bullet.Add(player.Fire());
                }
                else if (propsState == 2 && propsDuration > 0)
                {
                    bullet.Add(player.DoubleFire1());
                    bullet.Add(player.DoubleFire2());
                    propsDuration--;
                }
                if (propsDuration == 0)
                {
                    propsState = 1;
                }
                outTime = 3;
                if (bombTime == 0)
                {
                    soundController.PlayShoot();
                }
            }
            outTime--;
        }

        private void BossFire()
        {
            if (bossFireTime == 0)
            {
                bossBullet.Add(boss.Fire1());
                bossBullet.Add(boss.Fire2());
                bossFireTime = 11;
            }
            bossFireTime--;
        }

        private void UpdateBullet()
        {
            for (int i = 0; i < bullet.Count; i++)
            {
                if (bullet[i].location.Y < -17)
                {
                    bullet.RemoveAt(i);
                    i--;
                    continue;
                }
                bullet[i].Move();
            }
        }

        private void UpdateBossBullet()
        {
            for (int i = 0; i < bossBullet.Count; i++)
            {
                if (bossBullet[i].location.Y > 815)
                {
                    bossBullet.RemoveAt(i);
                    i--;
                    continue;
                }
                bossBullet[i].Move();
            }
        }

        private void BuileEnemy()
        {

            if (planeTime == 0)
            {
                Enemy e = new Enemy();
                e.location.X = random.Next(442);
                enemies.Add(e);
                planeTime = random.Next(6, 20);
            }
            planeTime--;
        }

        private void BuileEnemy_m()
        {
            if (enemy_mTime == 0)
            {
                Enemy_m m = new Enemy_m();
                m.location.X = random.Next(442);
                enemy_ms.Add(m);
                enemy_mTime = random.Next(250, 350);
            }
            enemy_mTime--;
        }

        //private void BuileBoss()
        //{
        //    boss.location.X = 100;
        //    boss.location.Y = -164;
        //    boss.Move();
        //}

        private void BuileProps()
        {
            if (propsStopTime == 0)
            {
                GameProps p = new GameProps();
                p.location.X = random.Next(442);
                gameProps.Add(p);
                propsStopTime = random.Next(500, 600);
            }
            propsStopTime--;
        }

        private void UpdateEnemy_m()
        {
            for (int i = 0; i < enemy_ms.Count; i++)
            {
                if (enemy_ms[i].location.Y > 680)
                {
                    enemy_ms.RemoveAt(i);
                    i--;
                    continue;
                }
                enemy_ms[i].Move();
            }
        }

        private void UpdateEnemy()
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].location.Y > 680)
                {
                    enemies.RemoveAt(i);
                    i--;
                    continue;
                }
                enemies[i].Move();
            }
        }

        public void UpdateProps()
        {
            for (int i = 0; i < gameProps.Count; i++)
            {
                if (gameProps[i].location.Y > 680)
                {
                    gameProps.RemoveAt(i);
                    i--;
                    continue;
                }
                gameProps[i].Move();
            }
        }

        private void HitEnemy()
        {
            if (bombTime != 0)
                bombTime--;
            for (int i = 0; i < bullet.Count; i++)
            {
                Rectangle bulletRect = new Rectangle(bullet[i].location.X + 4, bullet[i].location.Y, 9, 17);
                for (int j = 0; j < enemies.Count; j++)
                {
                    Rectangle enemyRect = new Rectangle(enemies[j].location.X, enemies[j].location.Y, 39, 27);
                    if (bulletRect.IntersectsWith(enemyRect))
                    {
                        bullet.RemoveAt(i);
                        i--;
                        enemies[j].life--;
                        enemies[j].stopTime = 10;
                        if (enemies[j].life == 0)
                        {
                            soundController.PlayExplosion();
                            explosiones.Add(enemies[j].Bomb());
                            board.setScore(1);
                            enemies.RemoveAt(j);
                            bombTime = 4;
                        }
                        break;
                    }
                }
            }
        }

        private void HitEnemy_m()
        {
            if (bombTime != 0)
                bombTime--;
            for (int i = 0; i < bullet.Count; i++)
            {
                Rectangle bulletRect = new Rectangle(bullet[i].location.X + 4, bullet[i].location.Y, 9, 17);
                for (int j = 0; j < enemy_ms.Count; j++)
                {
                    Rectangle enemy_mRect = new Rectangle(enemy_ms[j].location.X, enemy_ms[j].location.Y, 69, 89);
                    if (bulletRect.IntersectsWith(enemy_mRect))
                    {
                        bullet.RemoveAt(i);
                        i--;
                        enemy_ms[j].lifem--;
                        enemy_ms[j].stopTime = 10;
                        if (enemy_ms[j].lifem == 0)
                        {
                            soundController.PlayExplosion();
                            explosiones.Add(enemy_ms[j].Bomb());
                            board.setScore(2);
                            enemy_ms.RemoveAt(j);
                            bombTime = 4;
                        }
                        break;
                    }
                }
            }
        }

        private void HitBoss()
        {
            for (int i = 0; i < bullet.Count; i++)
            {
                Rectangle bulletRect = new Rectangle(bullet[i].location.X + 4, bullet[i].location.Y, 9, 17);
                Rectangle bossRect = new Rectangle(boss.location.X, boss.location.Y, 108, 164);
                if (boss.lifeb > 0)
                {
                    if (bossRect.IntersectsWith(bulletRect))
                    {
                        bullet.RemoveAt(i);
                        i--;
                        boss.lifeb--;
                        if (boss.lifeb == 0)
                        {
                            soundController.PlayExplosion();
                            explosiones.Add(boss.Bomb());
                            board.setScore(3);
                        }
                        break;
                    }
                }
            }
        }

        private void HitPlayer()
        {
            Rectangle playerRect = new Rectangle(player.location.X - 9, player.location.Y, 18, 56);
            for (int i = 0; i < enemies.Count; i++)
            {
                Rectangle enemyRect = new Rectangle(enemies[i].location.X, enemies[i].location.Y, 39, 27);
                if (enemyRect.IntersectsWith(playerRect))
                {
                    gameover = true;
                    break;
                }
            }
            for (int i = 0; i < enemy_ms.Count; i++)
            {
                Rectangle enemy_mRect = new Rectangle(enemy_ms[i].location.X, enemy_ms[i].location.Y, 39, 27);
                if (enemy_mRect.IntersectsWith(playerRect))
                {
                    gameover = true;
                    break;
                }
            }
            if (boss.lifeb > 0)
            {
                for (int i = 0; i < bossBullet.Count; i++)
                {
                    Rectangle bossRect = new Rectangle(bossBullet[i].location.X + 54, bossBullet[i].location.Y, 8, 15);
                    if (bossRect.IntersectsWith(playerRect))
                    {
                        gameover = true;
                        break;
                    }
                }
                Rectangle bRect = new Rectangle(boss.location.X + 54, boss.location.Y, 8, 15);
                if (bRect.IntersectsWith(playerRect))
                {
                    gameover = true;
                }
            }
        }

        private void HitProps()
        {
            Rectangle playerRect = new Rectangle(player.location.X - 9, player.location.Y, 18, 56);
            for (int i = 0; i < gameProps.Count; i++)
            {
                Rectangle propsRect = new Rectangle(gameProps[i].location.X, gameProps[i].location.Y, 30, 46);
                if (propsRect.IntersectsWith(playerRect))
                {
                    GameProps p = new GameProps();
                    if (p.state == 0)
                    {
                        propsState = 2;
                        propsDuration = 150;
                    }
                    else if (p.state == 1)
                    {
                        uniqueSkill.num++;
                    }
                    gameProps.RemoveAt(i);
                    break;
                }
            }
        }

        private void UpdateExplosion()
        {
            for (int i = 0; i < explosiones.Count; i++)
            {
                if (explosiones[i].state == 2)
                {
                    explosiones.RemoveAt(i);
                    i--;
                    continue;
                }
                explosiones[i].Play();
            }
        }

        public void UpdateData()
        {
            if (startGame)
            {
                if (!aboutGame)
                {
                    if (!gameover)
                    {
                        if (!pause)
                        {
                            if (board.score > 150)
                            {
                                this.BossFire();
                                this.HitBoss();
                                this.UpdateBossBullet();
                                boss.Move();
                            }
                            player.Move(mouseLocation);
                            player.Update();
                            background.Update();

                            this.Fire();
                            this.UpdateBullet();
                            this.BuileEnemy();
                            this.UpdateEnemy();
                            this.BuileEnemy_m();
                            this.UpdateEnemy_m();
                            this.HitEnemy();
                            this.UpdateExplosion();
                            this.HitPlayer();
                            this.HitEnemy_m();
                            this.BuileProps();
                            this.UpdateProps();
                            this.HitProps();



                        }
                        if (!pause)
                            button.Pause();
                        else
                            button.Resume();
                    }
                }
            }
        }

        public void UpdateFrame(Graphics g)
        {
            background.Draw(g);
            if (startGame)
            {
                if (!aboutGame)
                {
                    if (!gameover)
                    {
                        player.Draw(g);
                        button.Draw(g);
                        board.DrawScore(g);
                        uniqueSkill.Draw(g);
                        about.DrawAbout(g);
                        if (board.score >= 0 && board.score < 40)
                        {
                            checkPoint.Draw(g);
                        }
                        else if (board.score >= 100 && board.score < 140)
                        {
                            checkPoint.Draw1(g);
                        }
                        if (board.score > 150)
                        {
                            if (boss.lifeb > 0)
                            {
                                boss.Draw(g);
                                boss.DrawBlood(g);
                                boss.DrawLife(g);
                                foreach (var item in bossBullet)
                                {
                                    item.Draw(g);
                                }
                            }
                        }

                        foreach (var item in bullet)
                        {
                            item.Draw(g);
                        }
                        foreach (var item in enemies)
                        {
                            item.Draw(g);
                        }
                        foreach (var item in explosiones)
                        {
                            item.Draw(g);
                        }
                        foreach (var item in enemy_ms)
                        {
                            item.Draw(g);
                        }
                        foreach (var item in gameProps)
                        {
                            item.Draw(g);
                        }
                    }
                    else
                    {
                        board.Draw(g);

                    }
                }
                else
                {
                    about.Draw(g);
                }
            }
            else
            {
                start.Draw(g);
            }
        }

    }
}
