using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class MoonlightStaffP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 4;
            Projectile.timeLeft = 99999;          
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.alpha = 255;
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.penetrate--;
            if (Projectile.penetrate <= 0)
            {
                Projectile.Kill();
            }
            else
            {
                if (Projectile.velocity.X != oldVelocity.X)
                {
                    Projectile.velocity.X = -oldVelocity.X;
                }
                if (Projectile.velocity.Y != oldVelocity.Y)
                {
                    Projectile.velocity.Y = -oldVelocity.Y;
                }               
            }
            return false;
        }
        public override void AI()
        {
            CreateDust();
        }
        public void CreateDust()
        {
            for (int i = 0; i < 8; i++)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 226);
                Main.dust[dust].scale = 0.75f;
                Main.dust[dust].noGravity = true;
            }
        }
        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 25; k++)
            {
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 226, Projectile.oldVelocity.X * 0.7f, Projectile.oldVelocity.Y * 0.7f);
            }
            SoundEngine.PlaySound(SoundID.Splash, Projectile.position);
        }
    }
}