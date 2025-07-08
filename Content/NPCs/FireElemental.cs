using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Linq;
using Bismuth.Utilities;
namespace Bismuth.Content.NPCs
{
    public class FireElemental : ModNPC
    {
        public int tick = 0;
        public int currentframe = 0;
        float acceleration = 0f;
        int accelerationtick = 0;
        int AIProtocol = 0; // 0 - статик, 1 - перемещение к игроку, 2 - отсутствие угла для атаки, 3 - угол есть, но дистанция большая, 4 - атака.
        int attacking = 1; // 1 - не атакует, 2 - атакует
        NPC target;
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 1;
            NPCID.Sets.MustAlwaysDraw[NPC.type] = true;
        }
        public override void SetDefaults()
        {
            NPC.width = 110;
            NPC.height = 108;
            NPC.damage = 30;
            NPC.lifeMax = 1000;
            NPC.dontTakeDamageFromHostiles = true;
            NPC.rarity = 3;
            NPC.HitSound = SoundID.NPCHit3;
            NPC.DeathSound = SoundID.NPCDeath37;
            NPC.knockBackResist = 0.0f;
            NPC.aiStyle = -1;
            NPC.noTileCollide = true;
            NPC.friendly = true;
            NPC.noGravity = true;
           // npc.alpha = 255;
        }
        Player player = Main.player[Main.myPlayer];
        public override void AI()
        {
            NPC.dontTakeDamage = true;
            if (player.dead || player.FindBuffIndex(ModContent.BuffType<Buffs.FireElemental>()) == -1)
            {
                NPC.life = -1;
                NPC.checkDead();
            }
            TeleportToPlayer();
            ChooseProtocol();
            if (target == null || target.life <= 0 || (target != null && target.life > 0 && Vector2.Distance(NPC.Center, target.Center) > 800f))            
                target = UtilsAI.GetNearestNPCDirect(NPC.Center, 800f, false, false);
            if (NPC.velocity != Vector2.Zero)
            {
                accelerationtick++;
                acceleration += 0.015f * accelerationtick;
                if (acceleration > 1f)
                    acceleration = 1f;
            }
            else
            {
                acceleration = 0f;
                accelerationtick = 0;
            }
            if (AIProtocol == 0)
                NPC.velocity = Vector2.Zero;
            if (AIProtocol == 1)
                NPC.velocity = UtilsAI.VelocityToPoint(NPC.Center, new Vector2(player.Center.X - 30 * player.direction, player.Center.Y), 2.2f) * (acceleration + 0.01f);
            if (AIProtocol == 3 && target != null)            
                NPC.velocity = UtilsAI.VelocityToPoint(NPC.position, target.position, 4f);            
            if (AIProtocol == 4)            
                NPC.velocity = Vector2.Zero;           
            if (target != null)
            {
                if (Vector2.Distance(NPC.position, target.position) > 400f && attacking == 1)
                    AIProtocol = 3;
                if (Vector2.Distance(NPC.position, target.position) <= 400f)
                {
                    AIProtocol = 4;
                    attacking = 2;
                }
            }
            else
                attacking = 1;
            UpdateDirection();
            Lighting.AddLight(NPC.Center, new Vector3(0.663f, 0.033f, 0.081f));
            tick++;
            if (tick >= 5)
            {
                tick = 0;
                currentframe++;
            }
            if (attacking == 1)
            {
                if (currentframe > 7)
                    currentframe = 0;
            }
            else
            {
                if (currentframe < 8 || currentframe > 28)
                    currentframe = 8;
            }
            if (currentframe == 28 && tick == 1)
                Attack();
            if (attacking == 2 && currentframe < 8)
                currentframe = 8;
            if (attacking == 1 && currentframe > 7)
                currentframe = 0;
        }
        public void TeleportToPlayer()
        {
            if (Vector2.Distance(NPC.Center, player.Center) > 2000f)
            {
                for (int i = 0; i < 50; i++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Torch);
                }
                NPC.position = player.position;
                for (int i = 0; i < 50; i++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Torch);
                }
            }
        }
        public void ChooseProtocol()
        {
            if (target == null)
            {               
                if (Vector2.Distance(NPC.Center, new Vector2(player.Center.X - 30 * player.direction, player.Center.Y)) > 15f)
                    AIProtocol = 1;
                if (Vector2.Distance(NPC.Center, new Vector2(player.Center.X - 30 * player.direction, player.Center.Y)) < 5f)
                    AIProtocol = 0;
                if (AIProtocol == 4)
                    AIProtocol = 1;
            }
        }
        public void Attack()
        {
            if (currentframe == 28 && target != null && attacking == 2)
            {
                if (NPC.direction == 1) // налево
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(NPC.Center.X - 50, NPC.Center.Y), UtilsAI.VelocityToPoint(new Vector2(NPC.Center.X - 50, NPC.Center.Y - 16), target.Center, 30f), ModContent.ProjectileType<Projectiles.FireElementalFireball>(), 30, 4f, Main.myPlayer);
                else
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(NPC.Center.X + 50, NPC.Center.Y), UtilsAI.VelocityToPoint(new Vector2(NPC.Center.X + 50, NPC.Center.Y - 16), target.Center, 30f), ModContent.ProjectileType<Projectiles.FireElementalFireball>(), 30, 4f, Main.myPlayer);
                SoundEngine.PlaySound(SoundID.Item20, NPC.position);
                attacking = 1;
            }
           
        }
        public void UpdateDirection()
        {
            if (NPC.velocity.X < 0.0f)
                NPC.spriteDirection = NPC.direction = 1;
            else if (NPC.velocity.X > 0.0f)
                NPC.spriteDirection = NPC.direction = -1;
            if (AIProtocol == 0)
            {
                NPC.direction = NPC.spriteDirection = -player.direction;
            }
            if (attacking == 2)
            {
                if (NPC.Center.X > target.Center.X)
                    NPC.direction = NPC.spriteDirection = 1;
                else
                    NPC.direction = NPC.spriteDirection = -1;
            }
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.frame.Height = NPC.height;
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            if (attacking == 1)
            {
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/FireElementalActually").Value, NPC.position - Main.screenPosition, new Rectangle?(new Rectangle(0, currentframe * 108, 110, 108)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/FireElemental_Glow").Value, NPC.position - Main.screenPosition, new Rectangle?(new Rectangle(0, currentframe * 108, 110, 108)), Color.White, NPC.rotation, Vector2.Zero, 1f, NPC.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);

            }
            else
            {

                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/FireElementalActually").Value, NPC.position - Main.screenPosition, new Rectangle?(new Rectangle(currentframe > 20 ? 220 : 110, currentframe > 20 ? (currentframe - 21) * 108 : (currentframe - 8) * 108, 110, 108)), drawColor, NPC.rotation, Vector2.Zero, 1f, target != null && target.Center.X < NPC.Center.X ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/FireElemental_Glow").Value, NPC.position - Main.screenPosition, new Rectangle?(new Rectangle(currentframe > 20 ? 220 : 110, currentframe > 20 ? (currentframe - 21) * 108 : (currentframe - 8) * 108, 110, 108)), Color.White, NPC.rotation, Vector2.Zero, 1f, target != null && target.Center.X < NPC.Center.X ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
            }
            return false;
        }
        public override void OnKill()
        {
            for (int i = 0; i < 50; i++)
            {
                Dust.NewDust(NPC.position, NPC.width, NPC.height, DustID.Torch);
            }
        }
    }
}