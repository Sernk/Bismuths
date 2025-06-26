using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace Bismuth.Content.Projectiles
{
    public class InkStainP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ink Stain");
            //DisplayName.AddTranslation(GameCulture.Russian, "Чернильное пятно");
        }
        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 32;
            Projectile.aiStyle = 0;
            Main.projFrames[this.Projectile.type] = 8;
            Projectile.hostile = false;
            Projectile.friendly = true;
            Projectile.damage = 0;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 600;
        }
        public override void AI()
        {
            Projectile.frameCounter++;
            if (Projectile.frameCounter % 6 == 0)
                Projectile.frame++;
            if (Projectile.frame >= 6)
                Projectile.Kill();
        }
    }
}