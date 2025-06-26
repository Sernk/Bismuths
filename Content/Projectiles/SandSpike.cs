using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace Bismuth.Content.Projectiles
{
    public class SandSpike : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sand Spike");
            //DisplayName.AddTranslation(GameCulture.Russian, "Песчаный шип");
        }
        public override void SetDefaults()
        {
            Projectile.width = 28;
            Projectile.height = 62;
            Projectile.aiStyle = 0;
            Projectile.DamageType = DamageClass.Magic;
            Main.projFrames[this.Projectile.type] = 12;
            Projectile.hostile = true;
            Projectile.friendly = false;
            Projectile.damage = 50;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
        }
        int counter = 0;
        public override bool CanHitPlayer(Player target)
        {
            if (Projectile.frame < 2)
                return false;
            else
                return true;
        }
        public override void AI()
        {
            counter++;
            if (counter % 8 == 0)
                Projectile.frame++;
            if (Projectile.frame >= 12)
            {
                Projectile.Kill();

            }
        }
    }
}