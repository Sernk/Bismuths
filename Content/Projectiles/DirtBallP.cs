using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Bismuth.Content.Projectiles
{
    public class DirtBallP : ModProjectile
    {
        public override void SetDefaults()
        {
            AIType = ProjectileID.Bullet;
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.penetrate = -1;
            Projectile.friendly = true;
            Projectile.alpha = 0;
            Projectile.timeLeft = 600;
            Projectile.knockBack = 8f;
        }
        void CreateDust()
        {
            for (int i = 0; i < 2; i++)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 0);
            }
        }
        public override void AI()
        {
            if (Projectile.position.Y > Main.LocalPlayer.position.Y)
                Projectile.tileCollide = true;
            else
                Projectile.tileCollide = false;
            CreateDust();
        }
        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 4; i++)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 0);
            }
        }
    }
}