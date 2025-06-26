using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class LichP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 6;
            Projectile.height = 6;
            Projectile.aiStyle = 52;
            Projectile.alpha = 255;
            Projectile.tileCollide = false;
            Projectile.extraUpdates = 10;
        }
        public override void AI()
        {
            for (int num493 = 0; num493 < 3; num493++)
            {
                float num494 = Projectile.velocity.X * 0.334f * (float)num493;
                float num495 = -(Projectile.velocity.Y * 0.334f) * (float)num493;
                int num496 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 62, 0f, 0f, 100, default(Color), 1.1f);
                Main.dust[num496].noGravity = true;
                Main.dust[num496].velocity *= 0f;
                Dust expr_15516_cp_0 = Main.dust[num496];
                expr_15516_cp_0.position.X = expr_15516_cp_0.position.X - num494;
                Dust expr_15535_cp_0 = Main.dust[num496];
                expr_15535_cp_0.position.Y = expr_15535_cp_0.position.Y - num495;
            }
            return;
        }
    }
}
