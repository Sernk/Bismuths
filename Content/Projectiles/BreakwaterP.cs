using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class BreakwaterP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Breakwater");
            //DisplayName.AddTranslation(GameCulture.Russian, "Волнорез");
            Main.projFrames[Projectile.type] = 16;
        }
        public override void SetDefaults()
        {
            Projectile.width = 128;
            Projectile.height = 60;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.ignoreWater = true;
            Projectile.ownerHitCheck = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
        }
        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner];
            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
            if (Main.myPlayer == Projectile.owner)
            {
                bool channeling = Projectile.ai[0] < 25 && !player.noItems && !player.CCed;
                if (!channeling)
                {
                    Projectile.Kill();
                }
            }
            if (Projectile.ai[0] == 0f)
            {
                if (Projectile.frame >= 8)
                    Projectile.Kill();
            }
            else if (Projectile.ai[0] == 1f)
            {
                if (Projectile.frame < 8)
                    Projectile.frame = 8;
                if (Projectile.frame >= 16)
                    Projectile.Kill();
            }

            Projectile.frame++;
            Projectile.position = (Projectile.velocity + vector) - Projectile.Size / 2f;
            Projectile.rotation = Projectile.velocity.ToRotation() + (Projectile.direction == -1 ? 3.14f : 0);
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
            Main.spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/Projectiles/BabaYagaPreBlast").Value, Projectile.position - Main.screenPosition, new Rectangle(0, 0, Projectile.width, Projectile.height), Color.Black);
            return true;
        }
    }
}