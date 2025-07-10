using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using System;

namespace Bismuth.Content.Projectiles
{
    public class Marker : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.friendly = true;
            AIType = 1;
            Projectile.aiStyle = 1;
            Projectile.alpha = 255;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 100;
        }

        int counter = 0;
        bool flag = false;
        public override void AI()
        {
            if (!flag)
            {
                flag = true;
                OnSpawn();
            }
            Projectile.velocity = new Vector2(0, 0);
            Vector2 From = new Vector2(Projectile.position.X + Main.rand.Next(-150, 150), Main.LocalPlayer.position.Y - Main.screenHeight / 2 - 200);
            Vector2 To = new Vector2(Projectile.position.X + Main.rand.Next(-100, 100), Projectile.position.Y);
            float Speed = 30f;
            Vector2 Move = (To - From);
             
            Projectile.velocity.Y = 0;
            counter++;

            if (counter % 10 == 0)
            {
                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), From, Move * (Speed / (float)Math.Sqrt(Move.X * Move.X + Move.Y * Move.Y)), ModContent.ProjectileType<SolarBall>(), 100, 5f, Main.player[Main.myPlayer].whoAmI);
                SoundEngine.PlaySound(SoundID.Item20, Main.projectile[proj].position);
            }            
        }
        public void OnSpawn()
        {
            Projectile.position = Main.MouseWorld;
        }
    }
}