using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Projectiles
{
    public class Fireball2 : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Fireball");
           // DisplayName.AddTranslation(GameCulture.Russian, "Огненный шар");
        }
        public bool isspawnedone = false;
        public override void SetDefaults()
        {
            Projectile.height = 10;
            Projectile.width = 10;
            Projectile.netImportant = true;
            Projectile.friendly = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.alpha = 255;       
            Projectile.penetrate = int.MaxValue;
        }

        public override void AI()
        {
            Player player = Main.player[Main.myPlayer];
            BismuthPlayer bismuthp = player.GetModPlayer<BismuthPlayer>();
            //угол под которым проджектайл находится от центра игрока
            float deg = Projectile.ai[1];
            //расстояние от игрока
            double dist = 64;

            Projectile.position.X = player.Center.X - (int)(Math.Cos(MathHelper.ToRadians(deg)) * dist);
            Projectile.position.Y = player.Center.Y - (int)(Math.Sin(MathHelper.ToRadians(deg)) * dist);
            for (int i = 0; i < 8; i++)
            {
                int teleportdust = Dust.NewDust(new Vector2(Projectile.position.X - Projectile.width / 2 - 8, Projectile.position.Y - Projectile.height - 2), 20, 20, 6);
                Main.dust[teleportdust].scale = 1f;
                Main.dust[teleportdust].noGravity = true;
            }
            Projectile.ai[1] += 3f;
            if (Projectile.ai[1] > 120 && !isspawnedone)
            {

                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Projectile.velocity, ModContent.ProjectileType<Fireball3>(), 50, 4f, Main.myPlayer);
                isspawnedone = true;
            }

            if (!player.GetModPlayer<BismuthPlayer>().OrbitalAlive)
                Projectile.Kill();

            base.AI();
        }
    }
}