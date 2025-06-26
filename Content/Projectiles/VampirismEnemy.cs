using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Projectiles
{
    public class VampirismEnemy : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 6;
            Projectile.height = 6;
            //   projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.alpha = 255;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 600;
            // projectile.extraUpdates = 10;
        }
        NPC projowner = null;
        public override void AI()
        {
            for (int i = 0; i < Main.npc.Length; i++)
            {
                if (Main.npc[i].active && Main.npc[i].whoAmI == (int)Projectile.ai[0] && Main.npc[i].life > 0)
                    projowner = Main.npc[i];
            }
            if (!projowner.active || projowner == null)
                Projectile.Kill();
            if (Projectile.position.X < projowner.position.X + (float)projowner.width && Projectile.position.X + (float)Projectile.width > projowner.position.X && Projectile.position.Y < projowner.position.Y + (float)projowner.height && Projectile.position.Y + (float)Projectile.height > projowner.position.Y)
            {
                if (projowner.life < projowner.lifeMax)
                {
                    int k = projowner.lifeMax - projowner.life;
                    k = k > 20 ? 20 : k;
                    projowner.life += k;
                    projowner.HealEffect(k);
                }
                Projectile.Kill();
            }
            // projectile.velocity.X = (projectile.velocity.X * 15f + num502) / 16f;
            // projectile.velocity.Y = (projectile.velocity.Y * 15f + num503) / 16f;
            Projectile.Navigate(projowner.Center, 10f, 14f);
            for (int num493 = 0; num493 < 9; num493++)
            {
                int dust = Dust.NewDust(Projectile.position, 8, 8, 183, 0f, 0f, 100, Color.White, 1.2f);
                Main.dust[dust].velocity = Vector2.Zero;
                Main.dust[dust].noGravity = true;
            }
            // return;
        }
        // return;
    }
}

