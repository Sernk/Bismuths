using Bismuth.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.NPCs
{
    public class BoneHand : ModNPC
    {
        public int currentframe = 0;
        public int currentphase = 0; // 0 - появление, 1 - статик, 2 - атака, 3 - рассыпание.
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 27;
        }

        public override void SetDefaults()
        {
            NPC.width = 30;
            NPC.height = 48;
            NPC.damage = 0;
            NPC.defense = 15;
            NPC.lifeMax = 1;
            NPC.dontTakeDamageFromHostiles = true;
            NPC.lavaImmune = true;
            NPC.immortal = true;
            NPC.friendly = true;
            NPC.rarity = 3;
            NPC.HitSound = SoundID.NPCHit3;
            NPC.DeathSound = SoundID.NPCDeath37;
            NPC.value = (float)Item.buyPrice(0, 4, 0, 0);
            NPC.knockBackResist = 0.0f;
            NPC.aiStyle = -1;
            NPC.noGravity = false;
            NPC.noTileCollide = false;
        }
        int tick = 0;
        public override void AI()
        {
            tick++;
            NPC.ai[0]++;
            if (currentphase == 1)
            {
                if (NPC.ai[0] > 1200)
                    currentphase = 3;
                else
                {
                    for (int i = 0; i < Main.npc.Length; i++)
                    {
                        if (Main.npc[i].active && !Main.npc[i].friendly && Main.npc[i].life > 0)
                        {
                            if (Main.npc[i].Hitbox.Intersects(new Rectangle((int)NPC.position.X + 66, (int)NPC.position.Y + 22, 26, 22)))
                            {
                                currentphase = 2;
                                NPC.direction = -1;
                            }
                            if (Main.npc[i].Hitbox.Intersects(new Rectangle((int)NPC.position.X, (int)NPC.position.Y + 22, 26, 22)))
                            {
                                currentphase = 2;
                                NPC.direction = 1;
                            }
                        }
                    }
                }
            }
            NPC.spriteDirection = NPC.direction;
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.frame.Y = frameHeight * currentframe;
            if (tick >= 6)
            {
                tick = 0;                
                currentframe++;
            }
            if (currentphase == 0)
            {
                if (currentframe >= 8)
                    currentphase = 1;
            }
            if (currentphase == 1)
            {
                currentframe = 8;
            }
            if (currentphase == 2)
            {
                if (currentframe <= 8 || currentframe >= 17)
                    currentframe = 9;
                if (currentframe == 12 && tick == 4)
                    Projectile.NewProjectile(NPC.GetSource_FromThis(), new Vector2(NPC.position.X + (NPC.direction == -1 ? 66 : 0), NPC.position.Y + 22), Vector2.Zero, ModContent.ProjectileType<BoneHandP>(), 50, 4f, Main.LocalPlayer.whoAmI);
                if (currentframe == 16)
                    currentphase = 1;
            }
            if (currentphase == 3)
            {
                if (currentframe < 17)
                    currentframe = 17;
                if (currentframe == 26)
                    NPC.active = false;
            }
        }      
    }
}