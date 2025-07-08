using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class StilettoHitboxP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.aiStyle = 1;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 1;
            AIType = ProjectileID.Bullet;
            Projectile.tileCollide = false;
            Projectile.alpha = 255;
            Projectile.timeLeft = 6;
            Projectile.ownerHitCheck = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = 6;
        }
        public override void AI()
        {
            Projectile.alpha = 255;
        }
    }
}