using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{

    public class MarbleArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Marble Arrow");
            //DisplayName.AddTranslation(GameCulture.Russian, "Мраморная стрела");
        }
        public override void SetDefaults()
        {
            base.Projectile.width = (base.Projectile.height = 14);
            base.Projectile.arrow = true;
            base.Projectile.friendly = true;
            base.Projectile.penetrate = 1;
            base.Projectile.aiStyle = 1;
        }
        public override void AI()
        {
            for (int i = 0; i < 2; i++)
            {
                int dust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width / 2, Projectile.height / 2, 204);
                Main.dust[dust].scale = 0.9f;
            }
            if (Projectile.velocity == Vector2.Zero)
            {

            }
        }
        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width / 2, Projectile.height / 2, 204);
                Main.dust[dust].scale = 1.2f;

            }
        }
    }
}