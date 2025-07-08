using Terraria.ModLoader;
using Terraria;

namespace Bismuth.Content.Projectiles
{
    public class PapuanWarriorPunch : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 6;
            Projectile.height = 30;
            Projectile.aiStyle = 0;
            Projectile.alpha = 255;
            Projectile.light = 0.3f;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 21;
            Projectile.tileCollide = false;
            Projectile.hostile = true;
            Projectile.friendly = false;
            Projectile.damage = 35;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 8;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.usesLocalNPCImmunity = true;
        }      
    }
}