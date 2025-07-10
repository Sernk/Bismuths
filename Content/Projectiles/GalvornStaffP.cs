using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class GalvornStaffP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 99999;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.alpha = 255;
            Projectile.tileCollide = false;
        }
        public override void AI()
        {
            CreateDust();
        }
        public void CreateDust()
        {
            int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 61);
            Main.dust[dust].scale = 1.1f;
            Main.dust[dust].velocity = Vector2.Zero;
            Main.dust[dust].noGravity = true;
            int dust1 = Dust.NewDust(Projectile.position, 4, 4, 61, 10f, -0.2f);
            Main.dust[dust1].scale = 1.1f;
            Main.dust[dust1].noGravity = true;
            int dust2 = Dust.NewDust(Projectile.position, 4, 4, 61, -10f, -0.2f);
            Main.dust[dust2].scale = 1.1f;
            Main.dust[dust2].noGravity = true;
        }
        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 25; k++)
            {
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 220, Projectile.oldVelocity.X * 0.7f, Projectile.oldVelocity.Y * 0.7f);
            }
        }
    }
}