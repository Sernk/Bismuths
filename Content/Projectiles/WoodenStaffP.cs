using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.ID;
using Terraria.Localization;

namespace Bismuth.Content.Projectiles
{
    public class WoodenStaffP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Shard of Light");
            //DisplayName.AddTranslation(GameCulture.Russian, "Осколок света");
        }
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 1;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.alpha = 255;
        }
       
        public override void AI()
        {
            CreateDust();
        }

        public void CreateDust()
        {
            for (int i = 0; i < 14; i++)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 156);
                Main.dust[dust].scale = 0.6f;
                Main.dust[dust].noGravity = true;
            }

        }
        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 25; k++)
            {
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 156, Projectile.oldVelocity.X * 0.2f, Projectile.oldVelocity.Y * 0.2f);
                Main.dust[dust].scale = 0.5f;
            }
            SoundEngine.PlaySound(SoundID.Splash, Projectile.position);
        }
    }
}

