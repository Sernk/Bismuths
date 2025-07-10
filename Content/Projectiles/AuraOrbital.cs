using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Content.Buffs;

namespace Bismuth.Content.Projectiles
{
    public class AuraOrbital : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Aura Orbital");
            //DisplayName.AddTranslation(GameCulture.Russian, "");
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
            return PreAI();
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
