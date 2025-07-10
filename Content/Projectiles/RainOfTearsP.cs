using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class RainOfTearsP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 99999;          
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
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 226);
                Main.dust[dust].scale = 0.75f;
            }
        }
        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 25; k++)
            {
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 226, Projectile.oldVelocity.X * 0.7f, Projectile.oldVelocity.Y * 0.7f);
            }
            SoundEngine.PlaySound(SoundID.Splash, Projectile.position);
        }
    }
}