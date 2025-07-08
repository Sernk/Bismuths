using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class StilettoP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 16;
        }
        public override void SetDefaults()
        {
            Projectile.width = 128;
            Projectile.height = 32;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.damage = 0;
            Projectile.ignoreWater = true;
        }
        public override bool PreAI()
        {
            Projectile.damage = 0;
            Player player = Main.player[Projectile.owner];
            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
            Vector2 vel = Main.MouseWorld - Main.LocalPlayer.Center;
            vel.Normalize();
            if (Projectile.frame == 0 || Projectile.frame == 8)
            {               
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Main.LocalPlayer.Center, vel * 20f, ModContent.ProjectileType<StilettoHitboxP>(), 20, 4f, Main.player[Projectile.owner].whoAmI);
            }
            if(Projectile.frame == 0)
                Projectile.rotation = (float)Math.Atan2((double)(Main.MouseWorld.Y - Main.LocalPlayer.Center.Y), (double)(Main.MouseWorld.X - Main.LocalPlayer.Center.X));
            if (Projectile.frame == 8)
                SoundEngine.PlaySound(SoundID.Item1);
            Projectile.frame++;
            if (Projectile.frame >= 16)
                Projectile.Kill();
            Projectile.position = vector - Projectile.Size / 2f;
            if (Main.MouseWorld.X >= Main.LocalPlayer.Center.X)
                Projectile.direction = 1;
            else
                Projectile.direction = -1;
            Projectile.spriteDirection = Projectile.direction;
            player.ChangeDir(Projectile.direction);
            player.heldProj = Projectile.whoAmI;
            player.itemTime = 10;
            player.itemAnimation = 10;
            player.itemRotation = (float)Math.Atan2((double)(Projectile.velocity.Y * (float)Projectile.direction), (double)(Projectile.velocity.X * (float)Projectile.direction));
            return false;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Main.spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/Projectiles/StilettoP").Value, Main.LocalPlayer.Center - Main.screenPosition, new Rectangle?(new Rectangle(0, Projectile.frame * 32, 128, 32)), Color.White, Projectile.rotation, new Vector2(Projectile.width / 4, Projectile.height / 2), 1f, Projectile.direction == -1 ? SpriteEffects.FlipVertically : SpriteEffects.None, 0f);
            return false;
        }
    }
}