using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class QuicksilverMirrorP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.aiStyle = 1;
            Projectile.penetrate = 50;
            Projectile.extraUpdates = 1;
            AIType = ProjectileID.Bullet;
            Projectile.tileCollide = false;
            Projectile.alpha = 255;
        }
        public override void AI()
        {
            Projectile.alpha = 255;  
            for (int i = 0; i < 5; i++)

            {
                int dust2 = Dust.NewDust(Projectile.Center, 0, 0, 20, 0.0f, 0.0f, 0, new Color(), 1.0f);
                Main.dust[dust2].scale = 1.1f;
                Main.dust[dust2].noGravity = true;
                Main.dust[dust2].velocity = Vector2.Zero;
            }
        }
    }
}