using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Projectiles
{
    public class TyphoonP2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Water Quill");
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
            Projectile.timeLeft = 65;
            AIType = ProjectileID.Bullet;
            Projectile.tileCollide = false;
            Projectile.alpha = 255;
        }
        Vector2 start;
        Vector2 save;
        Vector2 perp;
        public override void AI()
        {
            Projectile.alpha = 255;
            Player player = Main.player[Projectile.owner];
            if (Projectile.ai[1] == 0.0f)
                start = Projectile.position;
            Projectile.ai[1]++;
            perp = UtilsAI.Perpendicular(Projectile.velocity);
            if (Projectile.ai[1] < 29)
            {
                save = Projectile.velocity;
            }
            if (Projectile.ai[1] >= 30 && Projectile.ai[1] < 47)
            {
                Projectile.velocity += perp / 4.7f;
            }
            for (int i = 0; i < 5; i++)

            {
                int dust2 = Dust.NewDust(Projectile.Center, 0, 0, 132, 0.0f, 0.0f, 0, new Color(), 1.0f);
                Main.dust[dust2].scale = 1.1f;
                Main.dust[dust2].noGravity = true;
                Main.dust[dust2].velocity = Vector2.Zero;
            }
        }
        public override void OnKill(int timeLeft)
        {

        }
    }
}