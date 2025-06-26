using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class ScytheSlashHitboxP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Soul Scythe");
            //DisplayName.AddTranslation(GameCulture.Russian, "Коса душ");
        }
        public override void SetDefaults()
        {
            Projectile.width = 54;
            Projectile.height = 56;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.damage = 12;
            Projectile.ignoreWater = true;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.idStaticNPCHitCooldown = 60;
            Projectile.localNPCHitCooldown = 60;
        }
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            
            Projectile.ai[0]++;
            Projectile.direction = player.direction;
            if (player.direction == 1)
                Projectile.position.X = player.Center.X + 10;
            else
                Projectile.position.X = player.Center.X - 66;
            Projectile.position.Y = player.position.Y - 10;
            Lighting.AddLight(Projectile.position + new Vector2(30f, 20f), new Vector3(0.42f, 0.12f, 0.6f));
            if (Projectile.ai[0] % 3 == 0)
                Projectile.ai[1]++;
            if (Projectile.ai[0] == 20)
                Projectile.Kill();
        }
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            int id = target.type;
            if (id == NPCID.GiantWormBody || id == NPCID.GiantWormTail || id == NPCID.GiantWormHead || id == NPCID.DiggerBody || id == NPCID.DiggerHead || id == NPCID.DiggerTail || id == NPCID.TombCrawlerBody || id == NPCID.TombCrawlerHead || id == NPCID.TombCrawlerTail || id == NPCID.ManEater || id == NPCID.Harpy || id == NPCID.WyvernBody || id == NPCID.WyvernBody2 || id == NPCID.WyvernBody3 || id == NPCID.WyvernHead || id == NPCID.WyvernLegs || id == NPCID.WyvernTail || id == NPCID.AngryNimbus || id == NPCID.FireImp || id == NPCID.LavaSlime || id == NPCID.Demon || id == NPCID.VoodooDemon || id == NPCID.Shark || id == NPCID.GreenJellyfish || id == NPCID.BlueJellyfish || id == NPCID.PinkJellyfish || id == NPCID.Piranha)
            {
                modifiers.FinalDamage *= 50;
            }
            if (Main.player[Projectile.owner].direction == -1) { }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Main.spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/Projectiles/SoulScytheSlashP").Value, Projectile.position - Main.screenPosition, new Rectangle?(new Rectangle(0, (int)Projectile.ai[1] * 56, 54, 56)), Color.White, 0f, Vector2.Zero, 1f, Main.LocalPlayer.direction == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally, 0f);
            return false;
        }
    }
}