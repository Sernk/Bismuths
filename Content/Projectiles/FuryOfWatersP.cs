using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class FuryOfWatersP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Fury of Waters");
            //DisplayName.AddTranslation(GameCulture.Russian, "Ярость вод");
        }
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
                Projectile.velocity.Y -= 0.01f;
            else
                Projectile.velocity.Y *= 1.02f;
        }

        const int dust_count = 10;
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity * 0.65f, ModContent.ProjectileType<FuryOfWatersP2>(), 60, 4f, Projectile.owner);
        }
        public override void OnKill(int timeLeft)
        {
            for (int counter = 0; counter < dust_count; counter++)
            {
                Vector2 velocity = Projectile.velocity * ((float)Main.rand.Next(20, 140) / 100f);

                int dust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y + 2f), Projectile.width, Projectile.height, 132, 5, 5, 100, default(Color), 1.4f);
                Main.dust[dust].noLight = true;
                SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            }
        }
    }
}