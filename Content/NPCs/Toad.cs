using Bismuth.Content.Items.Materials;
using Bismuth.Content.Items.Weapons.Melee;
using Bismuth.Utilities;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.NPCs
{
    public class Toad : ModNPC
    {
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 6;
        }
        public override void SetDefaults()
        {
            NPC.width = 46;
            NPC.height = 38;
            NPC.damage = 20;
            NPC.defense = 12;
            NPC.lifeMax = 50;
            NPC.aiStyle = 1;
            NPC.knockBackResist = 0.5f;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = Item.buyPrice(0, 0, 0, 70);
            AIType = 183;
            AnimationType = -1;
            Banner = NPC.type;
            //bannerItem = mod.ItemType("ToadBanner");
        }

        private double frameCounter = 0.0;
        private int frame = 0;
        bool quack = false;
        public override void FindFrame(int frameHeight)
        {
            Player player = Main.player[NPC.target];
            if (NPC.velocity.Y == 0.0f)
            {
                if (NPC.velocity.X == 0.0f)
                {
                    UpdateDirection(player);
                    frame = 0;
                    quack = false;
                }
            }
            else if (NPC.velocity.Y < 0.0f)
            {
                if (frame == 3)
                    return;
                if (!quack)
                {
                    SoundEngine.PlaySound(SoundID.Zombie1, NPC.position); // Zombie1 или Shatter
                    quack = true;
                }
              
                ++frameCounter;
                if (frameCounter >= 3.0)
                {
                    frame++;
                    frameCounter = 0.0;
                }
            }
            else
            {
               
                if (frame == 5)
                    return;
                ++frameCounter;
                if (frameCounter >= 3.0)
                {
                    frame++;
                    frameCounter = 0.0;
                }
               
            }
            if (frame >= Main.npcFrameCount[NPC.type]) frame = 0;
            NPC.frame.Y = frame * frameHeight;
        }

        public void UpdateDirection(Player player)
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
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ToadHead").Type, 1f);
                //Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ToadBody").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ToadFrontPaw").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("ToadBackPaw").Type, 1f);
            }
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo) { return BismuthPlayer.ZoneSwamp && spawnInfo.SpawnTileY < Main.rockLayer && Main.dayTime ? 7.0f : 0.0f; }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ToadsEye>(), 3));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ToadGun>(), 50));
        }
    }
}
