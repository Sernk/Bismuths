using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Bismuth.Content.Dusts;

namespace Bismuth.Content.Projectiles
{
    public class BladeOfWoeP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("");
        }
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 180;
            Projectile.ignoreWater = true;
            Projectile.alpha = 255;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            Projectile.ai[0]++;
            if (Projectile.ai[0] > 30f)
                Projectile.velocity = Vector2.Zero;
            else
                CreateDust();
            /*if (projectile.velocity == Vector2.Zero)
            {
                projectile.velocity = (Main.player[projectile.owner].position - projectile.position) / 15;
            }*/

        }

        public void CreateDust()
        {
            for (int i = 0; i < 30; i++)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<BladeOfWoeDust>());
            }

        }
    }
}

