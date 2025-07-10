using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.Localization;

namespace Bismuth.Content.Projectiles
{
    public class Meteor1 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Meteor");
            //DisplayName.AddTranslation(GameCulture.Russian, "Метеорит");
        }
        public override void SetDefaults()
        {
            Projectile.width = 40;
            Projectile.height = 40;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = 1;
            Projectile.timeLeft = 99999;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = true;
            Projectile.friendly = true;
            Projectile.damage = 30;
        }

        public override void AI()
        {
            CreateDust();          
            Projectile.tileCollide = (Main.player[Projectile.owner].Center.Y < Projectile.Center.Y);
        }

        public void CreateDust()
        {
            Dust.NewDust(Projectile.position + new Vector2(0f, 20f), 2, 2, 6, -4f, 0);
            Dust.NewDust(Projectile.position + new Vector2(30f, 20f), 2, 2, 6, 4f, 0);
        }
        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 40; k++)
            {
                int dust = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 6, Projectile.oldVelocity.X * 0.7f, Projectile.oldVelocity.Y * 0.7f);
            }
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        }
    }
}

