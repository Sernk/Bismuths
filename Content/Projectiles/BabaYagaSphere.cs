using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class BabaYagaSphere : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Dark Orb");
            //DisplayName.AddTranslation(GameCulture.Russian, "Темная сфера");
        }
        public bool isspawnedone = false;
        public override void SetDefaults()
        {
            Projectile.height = 10;
            Projectile.width = 10;
            Projectile.friendly = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.alpha = 255;
            Projectile.timeLeft = 300;
            Projectile.damage = 35;
            Projectile.hostile = true;
            Projectile.penetrate = int.MaxValue;
        }
        Vector2 BabkaCenter = new Vector2(0, 0);
        float deg = 0f;
        double dist = 64;
        public override void AI()
        {
            if (BabkaCenter == new Vector2(0, 0))
            {
                BabkaCenter = Projectile.position + new Vector2(6, 6);
            }
            deg = Projectile.ai[1];
            Projectile.position.X = BabkaCenter.X - (int)(Math.Cos(MathHelper.ToRadians(deg)) * dist);
            Projectile.position.Y = BabkaCenter.Y - (int)(Math.Sin(MathHelper.ToRadians(deg)) * dist);
            for (int k = 0; k < 12; k++)
            {
                int teleportdust = Dust.NewDust(new Vector2(Projectile.position.X - Projectile.width / 2 - 8, Projectile.position.Y - Projectile.height - 2), 20, 20, 173);
                Main.dust[teleportdust].scale = 0.9f;
                Main.dust[teleportdust].noGravity = true;
            }
            Projectile.ai[1] += 6f;
        }
    }
}
 