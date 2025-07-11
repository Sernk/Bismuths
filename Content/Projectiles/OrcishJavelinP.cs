using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class OrcishJavelinP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.aiStyle = 1;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.penetrate = 2;
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
          
                int dust1 =  Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y + 2f), Projectile.width, Projectile.height, 65, 5, 5, 100, default(Color), 1.4f);
                Main.dust[dust1].noLight = true;
        }

        const int dust_count = 10;

        public override void OnKill(int timeLeft)
        {
            for (int counter = 0; counter < dust_count; counter++)
            {
                int dust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y + 2f), Projectile.width, Projectile.height, 65, 5, 5, 100, default(Color), 1.4f);
                Main.dust[dust].noLight = true;
                SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            }
        }
    }
}