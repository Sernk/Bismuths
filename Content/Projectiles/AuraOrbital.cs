using Bismuth.Content.Buffs;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class AuraOrbital : ModProjectile
    {
        public bool isspawnedone = false;
        public override void SetDefaults()
        {
            Projectile.height = 10;
            Projectile.width = 10;
            Projectile.friendly = false;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.alpha = 255;
            Projectile.timeLeft = 3600;
            Projectile.damage = 35;
            Projectile.hostile = false;
        }
        float deg = 0f;
        double dist = 64;
        public override bool PreAI()
        {
            if (Main.LocalPlayer.FindBuffIndex(ModContent.BuffType<MagiciansAura>()) == -1)
                Projectile.Kill();
            return base.PreAI();
        }
        public override void AI()
        {           
            deg = Projectile.ai[1];
            Projectile.position.X = Main.LocalPlayer.Center.X - (int)(Math.Cos(MathHelper.ToRadians(deg)) * dist);
            Projectile.position.Y = Main.LocalPlayer.Center.Y - (int)(Math.Sin(MathHelper.ToRadians(deg)) * dist);
            for (int k = 0; k < 6; k++)
            {
                int teleportdust = Dust.NewDust(new Vector2(Projectile.position.X - Projectile.width / 2 - 8, Projectile.position.Y - Projectile.height - 2), 20, 20, 59);
                Main.dust[teleportdust].scale = 1f;
                Main.dust[teleportdust].noGravity = true;
                Main.dust[teleportdust].velocity = Vector2.Zero;
            }
            Projectile.ai[1] += 6f;
        }
    }
}
