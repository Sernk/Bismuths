using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class ShamansStaffP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.aiStyle = -1;
            Projectile.tileCollide = false;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 120;
        }
        float mult = 1.5f;
        public override void AI()
        {
            Projectile.timeLeft = 120;
            Projectile.alpha = 255;
            Player player = Main.player[Projectile.owner];
            var source = Projectile.GetSource_FromThis();
            if (Main.myPlayer == Projectile.owner && Projectile.ai[0] == 0f)
            {
                Vector2 center;
                center.X = Main.MouseWorld.X + 4f;
                center.Y = Main.MouseWorld.Y + 4f;
                Projectile.Center = center;
                Projectile.netUpdate = true;
            }
            if ((!player.channel && Projectile.ai[0] < 60) || Projectile.ai[0] > 100f)
            {
                Projectile.Kill();
            }
            if ((Projectile.ai[0] == 60f && !player.channel) || Projectile.ai[0] > 60f)
            {
                Projectile.ai[0]++;
            }
            if (Projectile.ai[0] > 60f && Projectile.ai[0] % 20 == 5)
            {
                Projectile.NewProjectile(source, Projectile.Center, new Vector2(12f * mult, 0f), ModContent.ProjectileType<SandWaveP>(), 50, 4f, Main.player[Projectile.owner].whoAmI);
                Projectile.NewProjectile(source, Projectile.Center, new Vector2(-12f * mult, 0f), ModContent.ProjectileType<SandWaveP>(), 50, 4f, Main.player[Projectile.owner].whoAmI);
                Projectile.NewProjectile(source, Projectile.Center, new Vector2(0f, 12f * mult), ModContent.ProjectileType<SandWaveP>(), 50, 4f, Main.player[Projectile.owner].whoAmI);
                Projectile.NewProjectile(source, Projectile.Center, new Vector2(0f, -12f * mult), ModContent.ProjectileType<SandWaveP>(), 50, 4f, Main.player[Projectile.owner].whoAmI);
            }
            if (Projectile.ai[0] > 60f && Projectile.ai[0] % 20 == 15)
            {
                Projectile.NewProjectile(source, Projectile.Center, new Vector2(8.484f * mult, 8.484f * mult), ModContent.ProjectileType<SandWaveP>(), 50, 4f, Main.player[Projectile.owner].whoAmI);
                Projectile.NewProjectile(source, Projectile.Center, new Vector2(-8.484f * mult, 8.484f * mult), ModContent.ProjectileType<SandWaveP>(), 50, 4f, Main.player[Projectile.owner].whoAmI);
                Projectile.NewProjectile(source, Projectile.Center, new Vector2(8.484f * mult, - 8.484f * mult), ModContent.ProjectileType<SandWaveP>(), 50, 4f, Main.player[Projectile.owner].whoAmI);
                Projectile.NewProjectile(source, Projectile.Center, new Vector2(-8.484f * mult, -8.484f * mult), ModContent.ProjectileType<SandWaveP>(), 50, 4f, Main.player[Projectile.owner].whoAmI);
            }
            if (Projectile.ai[0] < 60f)
                Projectile.ai[0]++;
            if (Projectile.ai[0] > 0f && Projectile.ai[0] <= 60f)
            {

                float num = 200f;
                int num2 = 0;
                while ((float)num2 < num)
                {
                    Vector2 vector = Vector2.UnitX * 0f;
                    vector += -Utils.RotatedBy(Vector2.UnitY, num2 * (6.28318548f / num), default(Vector2)) * new Vector2(200f - 2.6f * Projectile.ai[0], 200f - 2.6f * Projectile.ai[0]);
                    vector = Utils.RotatedBy(vector, Projectile.velocity.ToRotation(), default(Vector2));
                    int num3 = Dust.NewDust(Projectile.Center + vector, 0, 0, 169, 0f, 0f, 0, default(Color), 1f);
                    Main.dust[num3].noGravity = true;
                    Main.dust[num3].velocity = Vector2.Zero;
                    num2++;
                }

            }              
        }
    }
}
