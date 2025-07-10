using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class BismuthumSawP : ModProjectile
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
            Projectile.ownerHitCheck = true;
            Projectile.DamageType = DamageClass.Melee;
            Main.projFrames[Projectile.type] = 2;
        }
    }
}