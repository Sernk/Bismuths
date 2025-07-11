using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class SharkJavelinP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.aiStyle = 1;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.penetrate = 1;
            Projectile.extraUpdates = 1;
            AIType = ProjectileID.BoneJavelin;
            Projectile.tileCollide = true;
        }

        public override void AI()
        {
            if (Projectile.velocity.Y < 0)
                Projectile.velocity.Y -= 0.06f;
            else
                Projectile.velocity.Y *= 1.02f;
        }

        const int dust_count = 10;

        public override bool OnTileCollide(Vector2 oldVelosity)
        {
            for (int counter = 0; counter < dust_count; counter++)
            {
                Vector2 velocity = Projectile.velocity * ((float)Main.rand.Next(20, 140) / 100f);
                Dust.NewDust(Projectile.Center, 1, 1, DustID.Dirt, velocity.X, velocity.Y);
                SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            }
            return true;
        }
    }
}