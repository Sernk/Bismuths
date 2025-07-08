using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Terraria.Localization;

namespace Bismuth.Content.Projectiles
{
    public class SnakeProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Snake Spit");
            //DisplayName.AddTranslation(GameCulture.Russian, "Змеиный плевок");
        }
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.light = 0.5f;
            Projectile.damage = 30;
            AIType = ProjectileID.Bullet;
            Projectile.aiStyle = 1;
            Projectile.tileCollide = false;

        }
        public override void AI()
        {
            for (int i = 0; i < 12; i++)
            {
                Dust.NewDust(new Microsoft.Xna.Framework.Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 61);
            }
        }
        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 25; i++)
            {
                Dust.NewDust(new Microsoft.Xna.Framework.Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 61, Projectile.oldVelocity.X * 0.7f, Projectile.oldVelocity.Y * 0.7f);
            }
        }
    }
}