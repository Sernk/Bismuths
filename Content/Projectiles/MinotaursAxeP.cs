using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace Bismuth.Content.Projectiles
{
    public class MinotaursAxeP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Minotaur's Axe");
            //DisplayName.AddTranslation(GameCulture.Russian, "Топор минотавра");
        }
        public override void SetDefaults()
        {
            Projectile.width = 34;
            Projectile.height = 76;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.penetrate = 1;
            Projectile.extraUpdates = 1;
            AIType = ProjectileID.Bullet;
            Projectile.tileCollide = false;
        }
        public override void AI()
        {
            if(Projectile.velocity.X >= 0.0f)
                Projectile.rotation -= 0.2f;
            else
                Projectile.rotation += 0.2f;
        }
    }
}