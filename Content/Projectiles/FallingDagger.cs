using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class FallingDagger : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Falling Dagger");
            //DisplayName.AddTranslation(GameCulture.Russian, "Падающий клинок");
        }
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 28;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = 2;
        }       
    }
}
