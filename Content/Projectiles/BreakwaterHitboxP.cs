using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class BreakwaterHitboxP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("");
        }
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.aiStyle = 1;
            Projectile.penetrate = -1;
            Projectile.extraUpdates = 1;
            AIType = ProjectileID.Bullet;
            Projectile.tileCollide = false;
            Projectile.alpha = 255;
        }
        public override void AI()
        {
              
            Projectile.alpha = 255;
            Projectile.ai[1]++;
            if (Projectile.ai[1] % 2 == 1)
                Projectile.frame++;

            if (Projectile.ai[0] == 0f)
            {
                if (Projectile.ai[1] > 15f)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Main.LocalPlayer.Center, new Vector2(5.656f * Main.LocalPlayer.direction, 5.656f), ModContent.ProjectileType<BreakwaterHitboxP>(), 10, 4f, Main.player[Main.myPlayer].whoAmI, 1f, 8f);
                    Projectile.Kill();
                    SoundEngine.PlaySound(SoundID.Item1);
                }
            }
            if (Projectile.ai[0] == 1f)
            {
                if (Projectile.ai[1] > 31f)
                {
                    Projectile.NewProjectile(Projectile.GetSource_FromThis(), Main.LocalPlayer.Center, new Vector2(8 * Main.LocalPlayer.direction, 0f), ModContent.ProjectileType<BreakwaterHitboxP>(), 10, 4f, Main.player[Main.myPlayer].whoAmI, 2f);
                    Projectile.Kill();
                    SoundEngine.PlaySound(SoundID.Item1);
                }
            }
            if (Projectile.ai[0] == 2f)
            {
                if (Projectile.ai[1] > 15f)
                {
                    Projectile.Kill();
                }
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            if (Projectile.ai[0] == 0f)
                Main.spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/Projectiles/BreakwaterP").Value, Main.LocalPlayer.RotatedRelativePoint(Main.LocalPlayer.MountedCenter, true) - Main.screenPosition + (Main.LocalPlayer.direction == 1 ? new Vector2(-20f, -30f) : new Vector2(-10f, 30f)), new Rectangle?(new Rectangle(0, Projectile.frame * 60, 128, 60)), Color.White, (float)Math.Atan2((double)(Projectile.velocity.Y), (double)(Projectile.velocity.X)), Vector2.Zero, 1f, Main.LocalPlayer.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipVertically, 0f);
            else if(Projectile.ai[0] == 1f)
                Main.spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/Projectiles/BreakwaterP").Value, Main.LocalPlayer.RotatedRelativePoint(Main.LocalPlayer.MountedCenter, true) - Main.screenPosition + (Main.LocalPlayer.direction == 1 ? new Vector2(20f, -26f) : new Vector2(10f, 30f)), new Rectangle?(new Rectangle(0, Projectile.frame * 60, 128, 60)), Color.White, (float)Math.Atan2((double)(Projectile.velocity.Y), (double)(Projectile.velocity.X)), Vector2.Zero, 1f, Main.LocalPlayer.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipVertically, 0f);
            else
                Main.spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/Projectiles/BreakwaterP").Value, Main.LocalPlayer.RotatedRelativePoint(Main.LocalPlayer.MountedCenter, true) - Main.screenPosition + (Main.LocalPlayer.direction == 1 ? new Vector2(0f, -30f) : new Vector2(0f, 30f)), new Rectangle?(new Rectangle(0, Projectile.frame * 60, 128, 60)), Color.White, (float)Math.Atan2((double)(Projectile.velocity.Y), (double)(Projectile.velocity.X)), Vector2.Zero, 1f, Main.LocalPlayer.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipVertically, 0f);
            return base.PreDraw(ref lightColor);
        }
    }
}