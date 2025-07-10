using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class BismuthumGloveP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 38;
            Projectile.height = 52;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 5;
            Projectile.extraUpdates = 1;
            AIType = ProjectileID.DeathSickle;
            Projectile.tileCollide = false;
            Projectile.alpha = 0;
            Projectile.timeLeft = 255;
        }
        public override void AI()
        {
            Projectile.rotation += 0.2f;
            Projectile.alpha++;

        }
    }
}