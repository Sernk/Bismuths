using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{ 
    public class BismuthumDrillP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 22;
            Projectile.height = 22;
            Projectile.aiStyle = 20;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.hide = true;
            Projectile.frame = 0;
            Projectile.ownerHitCheck = true;
            Projectile.DamageType = DamageClass.Melee;
        }
    }
}