using Terraria.GameContent;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Bismuth.Content.Projectiles
{
    public class SphereOfLight : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sphere Of Light");
            //DisplayName.AddTranslation(GameCulture.Russian, "Сфера света");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 8; //длина трэйла
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.width = 34;
            Projectile.height = 90;
            Projectile.friendly = true;
            Projectile.penetrate = 3;
            Projectile.light = 0.5f;
            Projectile.scale *= 0.8f;
            Projectile.damage = 50;
            AIType = ProjectileID.Bullet;
            Projectile.aiStyle = 1;
            Projectile.tileCollide = false;

        }
        public override bool PreDraw(ref Color lightColor)
        {
            var drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            for (var k = 0; k < Projectile.oldPos.Length; k++)
            {
                var drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                var color = Projectile.GetAlpha(lightColor) * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                Main.spriteBatch.Draw(TextureAssets.Projectile[Projectile.type].Value, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
        public override void AI()
        {

            for (int i = 0; i < 6; i++)
            {
                Dust.NewDust(new Microsoft.Xna.Framework.Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 133);
            }
        }
    }
}