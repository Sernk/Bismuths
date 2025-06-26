using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Bismuth.Content.Buffs;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria.Audio;
using Bismuth.Utilities;

namespace Bismuth.Content.NPCs
{
    [AutoloadBossHead]
    public class Banshee : ModNPC
    {
        public int currentframe = 0;
        public int currentphase = 1;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Banshee");
            Main.npcFrameCount[NPC.type] = 25;
        }

        public override void SetDefaults()
        {
            NPC.width = 68;
            NPC.height = 56;
            NPC.damage = 5000;
            NPC.defense = 15;
            NPC.lifeMax = 500;
            NPC.rarity = 3;
            NPC.HitSound = SoundID.NPCHit54;
            NPC.DeathSound = SoundID.NPCDeath52;
            NPC.value = (float)Item.buyPrice(0, 4, 0, 0);
            NPC.knockBackResist = 0.0f;
            NPC.aiStyle = -1;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.alpha = 80;
            //npc.scale = 1f;
        }
        Player player;
        int FlyingTime = 0;
        bool justspawned = true;
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 1.5f);
            NPC.damage = (int)(NPC.damage * 1.5f);
        }
        public override void AI()
        {
            if (justspawned)
            {

                for (int i = 0; i < 15; i++)
                {
                    int dust = Dust.NewDust(NPC.position, NPC.width, NPC.height, 62);
                    Main.dust[dust].velocity = Vector2.Zero;
                    Main.dust[dust].noGravity = true;
                }
                justspawned = false;
            }
            NPC.TargetClosest(true);
            player = Main.player[NPC.target];
            if (currentphase == 0)
            {
                UpdateDirection();
                if (FlyingTime == 0)
                    FlyingTime = Main.rand.Next(360, 420);
                NPC.Navigate(player.position, 2f, 15f);
                NPC.ai[0]++;
                if (Vector2.Distance(NPC.Center, player.Center) < 100f)
                    currentphase = 2;
                else if (NPC.ai[0] >= FlyingTime)
                    currentphase = 1;
            }
            else if (currentphase == 1)
            {
                NPC.ai[1]++;
                if (NPC.ai[1] == 36f)
                {
                    player.AddBuff(ModContent.BuffType<BansheesScream>(), 240);
                    SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/BansheesScream"), NPC.position);
                }
                NPC.velocity = Vector2.Zero;
                if (NPC.ai[1] >= 180f)
                {
                    if (Vector2.Distance(NPC.Center, player.Center) < 100f)
                        currentphase = 2;
                    else
                        currentphase = 0;
                }
            }
            else if (currentphase == 2)
            {
                if (NPC.ai[2] == 0f)
                {
                    NPC.velocity = UtilsAI.VelocityToPoint(NPC.Center, player.Center, 6f);
                    NPC.ai[2] = 1f;
                }
                NPC.ai[3]++;
                if (NPC.ai[3] >= 54)
                    currentphase = 1;
            }
            if (currentphase != 0)
            {
                NPC.ai[0] = 0f;
                FlyingTime = 0;
            }
            if (currentphase != 1)
            {
                NPC.ai[1] = 0f;
            }
            if (currentphase != 2)
            {
                NPC.ai[2] = 0f;
                NPC.ai[3] = 0f;
            }
        }
        int tick = 0;
        public override void FindFrame(int frameHeight)
        {
            NPC.frame.Y = frameHeight * currentframe;
            tick++;
            if (tick >= 6)
            {
                tick = 0;
                currentframe++;
            }
            if (currentphase == 0)
            {
                if (currentframe >= 4)
                    currentframe = 0;
            }
            if (currentphase == 1)
            {
                if (currentframe <= 3 || currentframe >= 16)
                    currentframe = 4;
                if (currentframe == 15 && tick == 5)
                    currentframe = 10;
            }
            if (currentphase == 2)
            {
                if (currentframe <= 15 || currentframe >= 25)
                    currentframe = 16;
            }
        }
        public void UpdateDirection()
        {
            if (Main.player[Main.myPlayer].position.X >= NPC.position.X)
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
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life < 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 63);
                }
            }
        }
        public override void OnKill()
        {
            //Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("BansheesHead"));
            //BismuthWorld.downedBanshee = true;
            if (Main.netMode == 2)
            {
                NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
            }
        }
    }
}