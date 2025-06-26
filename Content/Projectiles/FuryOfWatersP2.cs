using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class FuryOfWatersP2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Waters Quill");
            //DisplayName.AddTranslation(GameCulture.Russian, "Водяной лепесток");
        }
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.aiStyle = 1;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.penetrate = 50;
            Projectile.extraUpdates = 1;
            Projectile.timeLeft = 120;
            Projectile.damage = 50;
            AIType = ProjectileID.Bullet;
            Projectile.tileCollide = false;
        }

        Vector2 save;
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            Projectile.ai[1]++;
            if (Projectile.ai[1] % 12 == 6)
            {
                float count = 25.0f;
                for (int k = 0; (double)k < (double)count; k++)
                {
                    Vector2 vector2 = (Vector2.UnitX * 0.0f + -Vector2.UnitY.RotatedBy((double)k * (6.22 / (double)count), new Vector2()) * new Vector2(2.0f, 8.0f)).RotatedBy((double)Projectile.velocity.ToRotation(), new Vector2());
                    int dust = Dust.NewDust(Projectile.Center - new Vector2(0.0f, 4.0f), 0, 0, 132, 0.0f, 0.0f, 0, new Color(), 1.0f);
                    Main.dust[dust].scale = 1.25f;
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].position = Projectile.Center + vector2;
                    Main.dust[dust].velocity = Projectile.velocity * 0.0f + vector2.SafeNormalize(Vector2.UnitY) * 1.0f;
                }
            }
            for (int i = 0; i < 5; i++)

            {
                int dust2 = Dust.NewDust(Projectile.Center, 0, 0, 132, 0.0f, 0.0f, 0, new Color(), 1.0f);
                Main.dust[dust2].scale = 1.1f;
                Main.dust[dust2].noGravity = true;
                Main.dust[dust2].velocity = Vector2.Zero;
            }
            if (Projectile.ai[1] < 50)
            {
                save = Projectile.velocity;
            }
            if (Projectile.ai[1] >= 50 && Projectile.ai[1] < 60)
            {
                Projectile.velocity -= save / 10;
            }
            if (Projectile.ai[1] >= 60 && Projectile.ai[1] < 70)
            {
                Projectile.velocity += -save / 10;
            }
        }      
    }
}