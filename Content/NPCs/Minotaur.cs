using Bismuth.Content.Items.Other;
using Bismuth.Content.Items.Tools;
using Bismuth.Content.Items.Weapons.Melee;
using Bismuth.Content.Projectiles;
using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.NPCs
{
    [AutoloadBossHead]
    public class Minotaur : ModNPC
    {
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MinotaursWaraxe>(), 100000));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Narsil>(), 100000));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MinotaurHorn>(), 100000));
        }
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 1;
            NPCID.Sets.MustAlwaysDraw[NPC.type] = true;
        }
        int currentframe = 0;
        int tick = 0;
        int currentphase = 0; // 0 - статик, выбор фазы; 1 - ходьба; 2 - удар; 3 - шоквейв; 4 - метание, 5 - таран
        bool dead = false;
        public override void SetDefaults()
        {
            NPC.width = 50;
            NPC.height = 80;
            NPC.damage = 30;
            NPC.lifeMax = 5000;
            NPC.rarity = 3;
            NPC.HitSound = SoundID.NPCHit52;
            NPC.DeathSound = SoundID.NPCDeath25;
            NPC.knockBackResist = 0.0f;
            NPC.aiStyle = -1;
            NPC.friendly = false;
            NPC.noGravity = false;
            NPC.alpha = 255;
            Music = MusicID.Boss3;
        }
        Player player;
        int WalkingTimeMax = 0;
        int ThrowingCountMax = 0;
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 1.5f);
            NPC.damage = (int)(NPC.damage * 1.5f);
        }
        public override void AI()
        {
            player = Main.player[Main.myPlayer];
            if(dead && (currentframe == 0 || currentframe == 4 || currentframe == 13 || currentframe == 23 || currentframe == 34 || currentframe == 43))
            {
                Vector2 vec = NPC.position + new Vector2((NPC.direction == 1 ? 10f : -60f), 80f);
                NPC.NewNPC(NPC.GetSource_FromThis(), (int)vec.X, (int)vec.Y, ModContent.NPCType<MinotaurDeath>(), 0, -1 * NPC.direction);
                NPC.direction = NPC.direction;
                NPC.spriteDirection = NPC.spriteDirection;
                player.GetModPlayer<BismuthPlayer>().downedMinotaur = true;
                NPC.active = false;
                return;
            }
            if (currentphase == 0)
            {
                if (NPC.direction == 0)
                    UpdateDirection();
                if (currentframe > 3)
                    currentframe = 0;
                tick++;
                if (tick >= 9)
                {
                    tick = 0;
                    currentframe++;
                    if (currentframe > 3)
                        currentframe = 0;
                }
                /* if (currentframe == 3)
                     ChoosePhase();*/
                if (Main.player[Main.myPlayer].Center.ToTileCoordinates().X > BismuthWorld.MazeStartX && Main.player[Main.myPlayer].Center.ToTileCoordinates().X < BismuthWorld.MazeStartX + 58 && Main.player[Main.myPlayer].Center.ToTileCoordinates().Y > BismuthWorld.MazeStartY && Main.player[Main.myPlayer].Center.ToTileCoordinates().Y < BismuthWorld.MazeStartY + 57)
                    ChoosePhase();
                NPC.velocity.X = 0.0f;
            }
            if (currentphase == 1)
            {
               
                if (WalkingTimeMax == 0)
                    WalkingTimeMax = Main.rand.Next(40, 80);
                NPC.ai[1]++;
                if (NPC.ai[1] >= WalkingTimeMax)
                    ChoosePhase();
                if (currentframe >= 13 || currentframe <= 3)
                    currentframe = 4;
                tick++;
                if (tick >= 9)
                {
                    tick = 0;
                    currentframe++;
                    if (currentframe >= 13 || currentframe <= 3)
                        currentframe = 4;
                }
                NPC.velocity.X = 1.2f * NPC.direction;
            }
            else
            {
                NPC.ai[1] = 0f;
                WalkingTimeMax = 0;
            }
            if (currentphase == 2)
            {
                if (currentframe >= 23 || currentframe <= 12)
                    currentframe = 13;
                tick++;
                if (tick >= 6)
                {
                    tick = 0;
                    currentframe++;
                }
                if (currentframe == 19 && tick == 0)
                {
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(NPC.direction * 70f, -10f), Vector2.Zero, ModContent.ProjectileType<MinotaurAttack>(), 25, 8f);
                    SoundEngine.PlaySound(SoundID.Seagull, NPC.position); // 44 а нужно 42 
                }
                if (currentframe == 23)
                    ChoosePhase();
                NPC.velocity.X = 0.0f;
            }
            if (currentphase == 3)
            {
                if (currentframe >= 34 || currentframe <= 22)
                    currentframe = 23;
                tick++;
               
                if (currentframe == 31)
                {
                    if (tick >= 30)
                    {
                        tick = 0;
                        currentframe++;
                    }
                }
                else
                {
                    if (tick >= 6)
                    {
                        tick = 0;
                        currentframe++;
                    }
                }
                if (currentframe == 28 && tick == 0)
                {
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(NPC.direction * 30f, 16f), new Vector2(8f * NPC.direction, 0f), ModContent.ProjectileType<MinosBlastCallP>(), 0, 0f);
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(NPC.direction * 30f, 16f), new Vector2(8f * NPC.direction * -1, 0f), ModContent.ProjectileType<MinosBlastCallP>(), 0, 0f);
                    SoundEngine.PlaySound(SoundID.Seagull, NPC.position);
                }
                if (currentframe == 34)
                    ChoosePhase();
                NPC.velocity.X = 0.0f;
            }
            if (currentphase == 4)
            {
                if (currentframe >= 43 || currentframe <= 33)
                    currentframe = 34;
                if (ThrowingCountMax == 0)
                    ThrowingCountMax = Main.rand.Next(1, 4);
                tick++;
                if (tick >= 6)
                {
                    tick = 0;
                    currentframe++;
                }
                if (currentframe == 39 && tick == 0)
                {
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center + new Vector2(NPC.direction * 20f, -15f), UtilsAI.VelocityToPoint(NPC.Center, player.Center, 13f), ModContent.ProjectileType<MinotaursAxeP>(), 10, 4f);
                    SoundEngine.PlaySound(SoundID.Seagull, NPC.position);
                }
                if (currentframe == 43)
                {
                    NPC.ai[0]++;
                    if (NPC.ai[0] >= ThrowingCountMax)
                        ChoosePhase();
                    else
                    {
                        UpdateDirection();
                        currentframe = 34;
                    }
                }
                NPC.velocity.X = 0.0f;
            }
            else
            {
                NPC.ai[0] = 0f;
                ThrowingCountMax = 0;
            }
            if (currentphase == 5)
            {
                if (currentframe <= 42 || currentframe >= 52)
                    currentframe = 43;
                tick++;
                if (tick >= 6)
                {
                    tick = 0;
                    currentframe++;
                }
                if (currentframe == 51)
                {
                    if (dead)
                        ChoosePhase();
                    if (((NPC.direction == 1 && player.Center.X >= NPC.Center.X) || (NPC.direction == -1 && player.Center.X < NPC.Center.X)) && tick == 0)
                        currentframe = 45;
                    else if ((NPC.direction == 1 && player.Center.X < NPC.Center.X) || (NPC.direction == -1 && player.Center.X >= NPC.Center.X) || NPC.velocity.X == 0.0f)
                    {
                        ChoosePhase();
                    }
                }
                NPC.velocity.X = 4.5f * NPC.direction;               
            }
        }
        public override bool PreAI()
        {
            if ((currentphase == 5 || currentphase == 1) && NPC.velocity.X == 0.0f)
                ChoosePhase();
            return base.PreAI();
        }
        public void ChoosePhase()
        {
           
            UpdateDirection();
            if (!(Main.player[Main.myPlayer].Center.ToTileCoordinates().X > BismuthWorld.MazeStartX && Main.player[Main.myPlayer].Center.ToTileCoordinates().X < BismuthWorld.MazeStartX + 58 && Main.player[Main.myPlayer].Center.ToTileCoordinates().Y > BismuthWorld.MazeStartY && Main.player[Main.myPlayer].Center.ToTileCoordinates().Y < BismuthWorld.MazeStartY + 57))
            {
                currentphase = 0;
            }
            else if (currentphase > 1)
            {
                currentphase = 1;
                NPC.ai[1] = 0f;
                WalkingTimeMax = 0;
            }
            else if (Math.Abs(player.Center.X - NPC.Center.X) < 100f && Math.Abs(player.Center.Y - NPC.Center.Y) < 100f)
            {

                currentphase = 2;
            }
            else
            {
                currentphase = Main.rand.Next(3, 6);
            }
            switch (currentphase)
            {
                case 0:
                    currentframe = 0;
                    break;
                case 1:
                    currentframe = 4;
                    break;
                case 2:
                    currentframe = 13;
                    break;
                case 3:
                    currentframe = 23;
                    break;
                case 4:
                    currentframe = 34;
                    break;
                case 5:
                    currentframe = 43;
                    break;
                default:
                    currentframe = 0;
                    break;
            }
        }
        public void UpdateDirection()
        {
            if (player.position.X >= NPC.position.X)
            {
                NPC.direction = 1;
                NPC.spriteDirection = 1;
            }
            else
            {
                NPC.direction = -1;
                NPC.spriteDirection = -1;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {           
            if (currentframe <= 3)
            {
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/MinotaurActually").Value, NPC.position - Main.screenPosition + new Vector2((NPC.direction == 1 ? -46f : -114f), -30f), new Rectangle?(new Rectangle(0, currentframe * 116, 208, 116)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/Minotaur_Glow").Value, NPC.position - Main.screenPosition + new Vector2((NPC.direction == 1 ? -46f : -114f), -30f), new Rectangle?(new Rectangle(0, currentframe * 116, 208, 116)), Color.White, NPC.rotation, Vector2.Zero, 1f, NPC.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
            }
            else if (currentframe >= 4 && currentframe <= 12)
            {
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/MinotaurActually").Value, NPC.position - Main.screenPosition + new Vector2((NPC.direction == 1 ? -50f : -100f), -30f), new Rectangle?(new Rectangle(208, (currentframe - 4) * 116, 208, 116)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/Minotaur_Glow").Value, NPC.position - Main.screenPosition + new Vector2((NPC.direction == 1 ? -50f : -100f), -30f), new Rectangle?(new Rectangle(208, (currentframe - 4) * 116, 208, 116)), Color.White, NPC.rotation, Vector2.Zero, 1f, NPC.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
            }
            else if (currentframe >= 13 && currentframe <= 22)
            {
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/MinotaurActually").Value, NPC.position - Main.screenPosition + new Vector2((NPC.direction == 1 ? -50f : -100f), -30f), new Rectangle?(new Rectangle(416, (currentframe - 13) * 116, 208, 116)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/Minotaur_Glow").Value, NPC.position - Main.screenPosition + new Vector2((NPC.direction == 1 ? -50f : -100f), -30f), new Rectangle?(new Rectangle(416, (currentframe - 13) * 116, 208, 116)), Color.White, NPC.rotation, Vector2.Zero, 1f, NPC.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
            }
            else if (currentframe >= 23 && currentframe <= 33)
            {
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/MinotaurActually").Value, NPC.position - Main.screenPosition + new Vector2((NPC.direction == 1 ? -50f : -100f), -30f), new Rectangle?(new Rectangle(624, (currentframe - 23) * 116, 208, 116)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/Minotaur_Glow").Value, NPC.position - Main.screenPosition + new Vector2((NPC.direction == 1 ? -50f : -100f), -30f), new Rectangle?(new Rectangle(624, (currentframe - 23) * 116, 208, 116)), Color.White, NPC.rotation, Vector2.Zero, 1f, NPC.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
            }
            else if (currentframe >= 34 && currentframe <= 42)
            {
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/MinotaurActually").Value, NPC.position - Main.screenPosition + new Vector2((NPC.direction == 1 ? -50f : -100f), -30f), new Rectangle?(new Rectangle(832, (currentframe - 34) * 116, 208, 116)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/Minotaur_Glow").Value, NPC.position - Main.screenPosition + new Vector2((NPC.direction == 1 ? -50f : -100f), -30f), new Rectangle?(new Rectangle(832, (currentframe - 34) * 116, 208, 116)), Color.White, NPC.rotation, Vector2.Zero, 1f, NPC.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
            }
            else if (currentframe >= 43 && currentframe <= 51)
            {
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/MinotaurActually").Value, NPC.position - Main.screenPosition + new Vector2((NPC.direction == 1 ? -50f : -100f), -30f), new Rectangle?(new Rectangle(1040, (currentframe - 43) * 116, 208, 116)), drawColor, NPC.rotation, Vector2.Zero, 1f, NPC.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/Minotaur_Glow").Value, NPC.position - Main.screenPosition + new Vector2((NPC.direction == 1 ? -50f : -100f), -30f), new Rectangle?(new Rectangle(1040, (currentframe - 43) * 116, 208, 116)), Color.White, NPC.rotation, Vector2.Zero, 1f, NPC.direction == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0.0f);
            }
            return false;
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                dead = true;
                NPC.immortal = true;
                NPC.life = 1;
                NPC.ai[0] = ThrowingCountMax;
                NPC.ai[1] = WalkingTimeMax;
                Player player = Main.LocalPlayer;
                if (!Main.LocalPlayer.GetModPlayer<BismuthPlayer>().NoRPGGameplay)
                {
                    player.GetModPlayer<Levels>().XP += (int)(ModContent.GetInstance<BismuthConfig>().XPMultiplier * (NPC.lifeMax / 5 + NPC.defense));
                    if (player.GetModPlayer<BismuthPlayer>().skill67lvl > 0 && !Main.dayTime)
                    {
                        player.GetModPlayer<Levels>().XP += (int)(ModContent.GetInstance<BismuthConfig>().XPMultiplier * (NPC.lifeMax / 5 + NPC.defense) * 0.2f);
                    }
                    if (player.GetModPlayer<BismuthPlayer>().skill133lvl > 0)
                    {
                        player.GetModPlayer<Levels>().XP += (int)(ModContent.GetInstance<BismuthConfig>().XPMultiplier * (NPC.lifeMax / 5 + NPC.defense) * 0.15f);
                    }
                    if (player.GetModPlayer<BismuthPlayer>().IsBoSRead)
                    {
                        player.GetModPlayer<Levels>().XP += (int)(ModContent.GetInstance<BismuthConfig>().XPMultiplier * (NPC.lifeMax / 5 + NPC.defense) * 0.1f);
                    }
                }
            }
        }
    }
}