using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class StarOfTheDunedainP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 48;
            Projectile.height = 34;
            Projectile.penetrate = -1;
            Projectile.scale = 1.0f;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.friendly = true;
            Projectile.timeLeft = 120;
            Projectile.extraUpdates = 1;
            Projectile.tileCollide = false;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Star Of The Dunedain");
            //DisplayName.AddTranslation(GameCulture.Russian, "Звезда Дунедайн");
            Main.projFrames[Projectile.type] = 1;
        }

        public override bool TileCollideStyle(ref int width, ref int height, ref bool fallThrough, ref Vector2 hitboxCenterFrac)
        {
            width = 4;
            height = 4;
            return true;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            int byUUID = Projectile.GetByUUID(Projectile.owner, (int)Projectile.ai[0]);
            if (byUUID != -1)
            {
                if (Main.myPlayer != Projectile.owner) return;
                var mainProj = Main.projectile[byUUID];
                if (!mainProj.active && mainProj.type != ModContent.ProjectileType<StarOfTheDunedainBase>()) Projectile.Kill();
                Projectile.ai[1]++;
                float offset = 2.4f * (float)Math.Sin((Projectile.ai[1] / 30 + Projectile.ai[1]) * Math.PI) * 50;
                 Projectile.rotation += /*Math.Abs(projectile.velocity.X) */0.04f * (float)Projectile.direction;
              //  projectile.rotation += projectile.ai[1];
                Projectile.position = mainProj.position + ((float)Projectile.rotation).ToRotationVector2() * offset;
                Projectile.netUpdate = true;
                for (int k = 0; k < 18; k++)
                {
                    int dust = Dust.NewDust(Projectile.Center, 1, 1, 135);
                 //   Main.dust[dust]. = true;
                    Main.dust[dust].noGravity = true;
                    Main.dust[dust].velocity = Vector2.Zero;
                  //  Main.dust[dust].a
                }
            }
        }

        public override void OnKill(int timeLeft)
        {
            for (int k = 0; k < 15; k++)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 135);
               // Main.dust[dust].scale = 1.1f;
            }
        }
    }
}
