using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Media;
using PlaneTest.Properties;

namespace PlaneTest
{

    public class SoundController
    {
        UnmanagedMemoryStream shoot;
        UnmanagedMemoryStream explosion;
        SoundPlayer shootPlayer;
        SoundPlayer explosionPlayer;
        int shootTime;

        public SoundController()
        {
            shoot = Resources.Shoot;
            explosion = Resources.Explosion;
            shootPlayer = new SoundPlayer(shoot);
            explosionPlayer = new SoundPlayer(explosion);
        }

        public void PlayShoot()
        {
            try
            {
                if (shootTime != 0)
                    shootTime--;
                else
                    shootPlayer.Play();
            }
            catch(Exception)
            {

            }
        }

        public void PlayExplosion()
        {
            try
            {
                shootTime = 3;
                explosionPlayer.Play();
            }
            catch (Exception)
            {

            }
        }
    }
}
