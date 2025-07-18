using Bismuth.Content.Items.Accessories;
using Bismuth.Content.Items.Materials;
using Bismuth.Content.Items.Other;
using Bismuth.Content.Items.Weapons.Assassin;
using Bismuth.Content.Projectiles;
using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.NPCs
{
    [AutoloadBossHead]
    public class EvilBabaYaga : ModNPC
    {
        public int tick = 0;
        public int currentframe = 0;
        public int currentphase = 0;
        public int firstphasecount = 0;
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 31;
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<LightPartOfArchmagesAmulet>(), 9999));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PanaceaScroll>(), 9999));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TransmutationAmulet>(), 9999));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<SnakesFang>(), 9999));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PoisonFlask>(), 9999, 5, 10));
        }
        public override void SetDefaults()
        {
            NPC.width = 26;
            NPC.height = 48;
            NPC.damage = 30;
            NPC.defense = 15;
            NPC.lifeMax = 2000;
            NPC.rarity = 3;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.value = (float)Item.buyPrice(0, 4, 0, 0);
            NPC.knockBackResist = 0.0f;
            NPC.aiStyle = -1;
            Music = MusicID.Boss5;
            //npc.scale = 1f;
        }
        bool flag = false;
        bool flag2 = false;
        bool flag3 = false;
        bool dead = false;
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                dead = true;
                NPC.immortal = true;
                NPC.life = 1;
                firstphasecount = 5;
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
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 1.5f);
            NPC.damage = (int)(NPC.damage * 1.5f);
        }
        public override void AI()
        {
            
            if (currentphase == 2)
            {
                if (currentframe == 15)
                {
                   
                    if (NPC.ai[2] == 0)
                    {
                        for (int i = 0; i < Main.rand.Next(2, 3); i++)
                        {
                            NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X + Main.rand.Next(-20, 20), (int)NPC.Center.Y - 6, ModContent.NPCType<SwampHound>());
                        }
                        NPC.ai[2] = 1;
                    }
                }
            }
            if (currentphase == 0)
            {
                UpdateDirection();
                ChoosePhase();
            }
            if (currentphase == 1)
            {
                NPC.ai[2] = 0;
                if (NPC.ai[0] % 30 + Main.rand.Next(-15, 10) == 0)
                {
                    Vector2 Blastpos = new Vector2(Main.rand.Next((int)NPC.Center.X - 300, (int)NPC.Center.X + 300), (int)NPC.Center.Y - 100);
                    while (!WorldGen.SolidTile(Blastpos.ToTileCoordinates().X, Blastpos.ToTileCoordinates().Y))
                    {
                        Blastpos.Y++;
                    }
                    Blastpos.Y -= 25;
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), Blastpos, new Vector2(0, 0), ModContent.ProjectileType<BabaYagaPreBlast>(), 0, 0f);
                 
                }
                if (NPC.ai[0] % 70 + Main.rand.Next(-10, 10) == 0)
                {
                    NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.Center.X, (int)NPC.Center.Y, ModContent.NPCType<SwampWraith>());
                }

                if (NPC.ai[0] % 16 == 0)
                {
                    Player player = Main.player[Main.myPlayer];
                    float startX = NPC.position.X + ((NPC.position.X - Main.screenPosition.X) * NPC.direction) + Main.rand.Next(-15, 15);
                    float startY = NPC.position.Y - Main.rand.Next(20, 500);
                    float Speed = 18f;
                    Vector2 FixedProj = new Vector2(startX, startY).RotatedByRandom(MathHelper.ToRadians(10));
                    float rotation = (float)Math.Atan2(startY - (player.position.Y + (player.height * 0.5f)), startX - (player.position.X + (player.width * 0.5f)));
                    int num54 = Projectile.NewProjectile(NPC.GetSource_FromThis(), startX, startY, (float)((Math.Cos(rotation) * Speed) * -1), (float)((Math.Sin(rotation) * Speed) * -1), ProjectileID.Fireball, 8, 0f, 0);
                    Main.projectile[num54].tileCollide = false;
                }
                NPC.ai[0]++;
            }
            if (currentphase == 3)
            {
                NPC.ai[1]++;
                if (!flag)
                {
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, 0), ModContent.ProjectileType<BabaYagaSphere>(), 14, 4f, 0);
                    flag = true;
                }
                if (!flag2 && NPC.ai[1] == 40f)
                {
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, 0), ModContent.ProjectileType<BabaYagaSphere>(), 14, 4f, 0);
                    flag2 = true;
                }
                if (!flag3 && NPC.ai[1] == 80f)
                {
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center, new Vector2(0, 0), ModContent.ProjectileType<BabaYagaSphere>(), 14, 4f, 0);
                    flag3 = true;
                }
                Vector2 v = -new Vector2(NPC.Center.X, NPC.Center.Y - 200) + new Vector2(NPC.Center.X, NPC.Center.Y + 50);
                float ai1 = (float)Main.rand.Next(100);
                Vector2 vector2 = Vector2.Normalize(v) * 20;
                Player player = Main.player[Main.myPlayer];
                if (NPC.ai[1] % (20 + Main.rand.Next(-10, 20)) == 0)
                {
                    int proj = Projectile.NewProjectile(NPC.GetSource_FromThis(), NPC.Center.X + Main.rand.Next(-500, 500), NPC.Center.Y - 600, vector2.X, vector2.Y, 580, 10, 0.5f, player.whoAmI, v.ToRotation(), ai1);
                    Main.projectile[proj].damage = 15;

                   
                    // Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/Lightning"));
                }
            }
            if (currentphase != 3)
            {
                flag = false;
                flag2 = false;
                flag3 = false;
                NPC.ai[1] = 0f;
            }
        }
        public override bool PreDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Vector2 pos = new Vector2((int)(NPC.position.X - Main.screenPosition.X) - 108, (int)(NPC.position.Y - Main.screenPosition.Y) - 75);
            if (currentframe > 7 && currentframe < 18)
            {
                spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/Blast").Value, new Rectangle((int)pos.X, (int)pos.Y, 244, 130), new Rectangle(0, 130 * (currentframe - 8), 244, 130), Color.White);
            }
            return true;
        }
        public void UpdateDirection()
        {
            if (Main.player[Main.myPlayer].position.X >= NPC.position.X)
            {
                NPC.direction = -1;
                NPC.spriteDirection = -1;
            }
            else
            {
                NPC.direction = 1;
                NPC.spriteDirection = 1;
            }
        }
        public void ChoosePhase()
        {
            if (dead)
            {
                Vector2 vec = NPC.position + new Vector2((NPC.spriteDirection == 1 ? -34f : -14f), 40f);
                NPC.NewNPC(NPC.GetSource_FromThis(), (int)vec.X, (int)vec.Y, ModContent.NPCType<SwampWitchDeath>(), 0, NPC.spriteDirection);
                NPC.direction = NPC.direction;
                NPC.spriteDirection = NPC.spriteDirection;
                NPC.active = false;
                NPC.checkDead();
                return;
            }
            if (currentphase == 1 && NPC.life > (NPC.lifeMax / 2))
                currentphase = 2;
            else if (currentphase == 1 && NPC.life <= (NPC.lifeMax / 2))
                currentphase = 3;
            else if (currentphase == 2 || currentphase == 3 || currentphase == 0)
                currentphase = 1;
            UpdateDirection();
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.frame.Y = currentframe * frameHeight;
            if (currentphase == 1)
            {
                tick++;
                if (tick == 5)
                {
                    tick = 0;
                    if (currentframe == 0)
                        currentframe = 21;
                    else if (currentframe == 28 && firstphasecount < 5)
                    {
                        currentframe = 22;
                        firstphasecount++;
                    }
                    else if (currentframe == 29 && firstphasecount == 5)
                    {
                        currentframe = 0;
                        firstphasecount = 0;
                        ChoosePhase();
                    }                   
                    else
                        currentframe++;                    
                }                                             
            }
            if (currentphase == 2)
            {
                tick++;
                if (tick == 5)
                {
                    tick = 0;
                    if (currentframe < 20)
                    {
                        currentframe++;
                    }
                    if (currentframe == 20)
                    {
                        currentframe = 0;
                        ChoosePhase();
                    }
                }
            }
            if (currentphase == 3)
            {
                tick++;
                currentframe = 30;
                if (tick >= 300)
                {
                    tick = 0;
                    currentframe = 0;
                    ChoosePhase();
                }
            }
        }
    }
}
