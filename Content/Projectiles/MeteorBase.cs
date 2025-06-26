using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Bismuth.Utilities;
using System.Diagnostics.Metrics;

namespace Bismuth.Content.Projectiles
{
    public class MeteorBase : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.friendly = true;
            AIType = 1;
            Projectile.aiStyle = 1;
            Projectile.alpha = 255;
            Projectile.tileCollide = false;
            Projectile.timeLeft = 200;
        }

        int counter = 0;
        bool flag = false;
        public override void AI()
        {
            if (!flag)
            {
                flag = true;
                OnSpawn();
            }
            Projectile.velocity = new Vector2(0, 0);
            Projectile.velocity.Y = 0;
            counter++;
            if (counter % (Main.LocalPlayer.GetModPlayer<BismuthPlayer>().skill141lvl == 0 ? 20 : 10) == 0)
            {
                Vector2 vector2_1 = new Vector2((float)((double)Main.LocalPlayer.position.X + (double)Main.LocalPlayer.width * 0.5 + (double)(Main.rand.Next(100) * -Main.LocalPlayer.direction) + ((double)Main.mouseX + (double)Main.screenPosition.X - (double)Main.LocalPlayer.position.X)), (float)((double)Main.LocalPlayer.position.Y + (double)Main.LocalPlayer.height * 0.5 - 800.0) );   //this defines the projectile width, direction and position
                vector2_1.X = (float)(((double)vector2_1.X + (double)Main.LocalPlayer.Center.X) / 2.0) + (float)Main.rand.Next(-200, 200);
                // vector2_1.Y -= (float)(100 * index);
                float num12 = (float)Main.mouseX + Main.screenPosition.X - vector2_1.X;
                float num13 = (float)Main.mouseY + Main.screenPosition.Y - vector2_1.Y;
                if ((double)num13 < 0.0) num13 *= -1f;
                if ((double)num13 < 20.0) num13 = 20f;
                float num14 = (float)Math.Sqrt((double)num12 * (double)num12 + (double)num13 * (double)num13);
                float num15 = 27f / num14;
                float num16 = num12 * num15;
                float num17 = num13 * num15;
                float SpeedX = (num16 + (float)Main.rand.Next(-10, 11) * 0.04f) / 2;  //this defines the projectile X position speed and randomnes
                float SpeedY = (num17 + (float)Main.rand.Next(-40, 41) * 0.04f) * 0.9f;  //this defines the projectile Y position speed and randomnes                
                int MeteorP = ModContent.ProjectileType<Meteor1>() + Main.rand.Next(1,4);
                int meteor = Projectile.NewProjectile(Projectile.GetSource_FromThis(), vector2_1.X, vector2_1.Y, SpeedX, SpeedY, MeteorP, 50, 12, Main.myPlayer, 0.0f, (float)Main.rand.Next(5));
            }
        }
        public void OnSpawn()
        {
            Projectile.position = Main.MouseWorld;
        }
    }
}