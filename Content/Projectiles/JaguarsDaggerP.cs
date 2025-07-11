using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class JaguarsDaggerP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.penetrate = 1;
            Projectile.extraUpdates = 1;
            Projectile.aiStyle = 1;
            AIType = ProjectileID.ThrowingKnife;
            Projectile.tileCollide = true;
            Projectile.CloneDefaults(ProjectileID.ThrowingKnife);
        }
        const int dust_count = 10;
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for (int counter = 0; counter < dust_count; counter++)
            {
                Vector2 velocity = Projectile.velocity * ((float)Main.rand.Next(20, 140) / 100f);
                Dust.NewDust(Projectile.Center, 1, 1, 2, velocity.X, velocity.Y);
                SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            }
            return true;
        }
    }
}