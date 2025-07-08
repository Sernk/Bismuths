using Terraria.ModLoader;
using Terraria.ID;

namespace Bismuth.Content.Projectiles
{
    public class ThrowingAxeP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.WoodenBoomerang);
            Projectile.width = 30;
            Projectile.height = 30;
            Projectile.friendly = true;
            Projectile.penetrate = 3;
            Projectile.aiStyle = 3;
            AIType = ProjectileID.WoodenBoomerang;
        }           
    }
}