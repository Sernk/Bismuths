using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class HeroBootsJumpEffect : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // this.DisplayName.SetDefault("");
        }

        public override void SetDefaults()
        {
            this.Projectile.width = 12;
            this.Projectile.height = 12;
            this.Projectile.hide = true;
            this.Projectile.friendly = true;
            this.Projectile.DamageType = DamageClass.Ranged;
            this.Projectile.timeLeft = 60;
            this.Projectile.alpha = (int)byte.MaxValue;
        }

        public override void OnKill(int timeLeft)
        {
            for (int index = 0; index < 2; ++index)
                Dust.NewDust(this.Projectile.position, this.Projectile.width, this.Projectile.height, 244, 0.0f, 0.0f, 0, new Color(), 1f);
        }

        public override void AI()
        {
            Projectile projectile = this.Projectile;
            Vector2 vector2 = projectile.velocity * 0.95f;
            projectile.velocity = vector2;
            int index1 = Dust.NewDust(this.Projectile.position + this.Projectile.velocity, this.Projectile.width, this.Projectile.height, 244, 0.0f, 0.0f, 0, new Color(), 1f);
            int index2 = Dust.NewDust(this.Projectile.position + this.Projectile.velocity, this.Projectile.width, this.Projectile.height, 244, 0.0f, 0.0f, 0, new Color(), 1f);
            Main.dust[index1].noGravity = true;
            Main.dust[index2].noGravity = true;
            Main.dust[index1].velocity = Vector2.Zero;
            Main.dust[index2].velocity = Vector2.Zero;
            Main.dust[index1].scale = 0.9f;
            Main.dust[index2].scale = 0.9f;
        }
    }
}
