using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class SolarWave : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5; 
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }
        public override void SetDefaults()
        {
            Projectile.width = 42;
            Projectile.height = 26;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.light = 0.5f;
            Projectile.damage = 50;
            Projectile.DamageType = DamageClass.Melee;
            AIType = ProjectileID.Bullet;
            Projectile.aiStyle = 1;

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

                Dust.NewDust(new Microsoft.Xna.Framework.Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6);
            }
        }
        public override void OnKill(int timeLeft)
        {
            int exp = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 0), ModContent.ProjectileType<SolarBlast>(), 50, 5f, Main.player[Main.myPlayer].whoAmI);
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(0, 0), 612, 50, 5f, Main.player[Main.myPlayer].whoAmI);

        }
    }
}