using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class WhirlpoolP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 6;
        }
        public override void SetDefaults()
        {
            Projectile.width = 210;
            Projectile.height = 96;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.damage = 12;
            Projectile.ignoreWater = true;
            Projectile.ownerHitCheck = true;
            Projectile.hide = false;
        }
        public override bool PreAI()
        {
            Player player = Main.player[Projectile.owner];
            Vector2 vector = player.RotatedRelativePoint(player.MountedCenter, true);
            Projectile.ai[0]++;
            if (Main.myPlayer == Projectile.owner)
            {
                bool channeling = Projectile.ai[0] < 120 && (player.controlUseItem || Projectile.ai[0] < 11) && !player.noItems && !player.CCed;
                if (!channeling)
                {
                    Projectile.Kill();
                }
            }
            if (Projectile.ai[0] % 2 == 0)
                Projectile.frame++;
            if (Projectile.frame >= 6)
                Projectile.frame = 0;
            if (Projectile.ai[0] % 6 == 0)
            {
                //SoundEngine.PlaySound(SoundID.Trackable, Projectile.position); //  "SoundID" не содержит определение для "Trackable". но public const int Trackable = 42; бред
            }
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 45, Projectile.velocity.X * 20, 0, 100, default(Color), (0.8f + (Main.rand.Next(5) / 10)));
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 45, Projectile.velocity.X * -20, 0, 100, default(Color), (0.8f + (Main.rand.Next(5) / 10)));
            player.ChangeDir(Projectile.direction * (Projectile.frame >= 3 ? -Projectile.direction : Projectile.direction));
            Projectile.position = vector - Projectile.Size / 2f;
            Projectile.rotation = 0;
            Projectile.spriteDirection = Projectile.direction;
            player.heldProj = Projectile.whoAmI;
            player.itemTime = 10;
            player.itemAnimation = 10;
            player.itemRotation = (float)Math.Atan2((double)(Projectile.velocity.Y * (float)Projectile.direction), (double)(Projectile.velocity.X * (float)Projectile.direction));
            return false;
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            if (target.Center.X > Main.player[Projectile.owner].Center.X)
                modifiers.HitDirectionOverride = 1;
            else
                modifiers.HitDirectionOverride = -1;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Main.spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/Projectiles/WhirlpoolP").Value, Projectile.position - Main.screenPosition, new Rectangle?(new Rectangle(0, Projectile.frame * 96, Projectile.width, Projectile.height)), Color.White);
            return false;
        }
    }
}