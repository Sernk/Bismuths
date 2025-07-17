using Bismuth.Content.Items.Other;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.NPCs
{
    public class SkeletonDwarf : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.width = 40;
            NPC.height = 40;
            NPC.damage = 14;
            NPC.defense = 10;
            NPC.lifeMax = 60;
            NPC.HitSound = SoundID.NPCHit2;
            NPC.DeathSound = SoundID.NPCDeath2;
            NPC.value = Item.buyPrice(0, 0, 15, 0);
            NPC.knockBackResist = 0.7f;
            NPC.aiStyle = 3;
            Main.npcFrameCount[NPC.type] = 15;
            AIType = 31;
            AnimationType = NPCID.AngryBones;
            Banner = NPC.type;
            //bannerItem = mod.ItemType("SkeletonDwarf");
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 1.5f);
            NPC.damage = (int)(NPC.damage * 1.5f);
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            for(int i = 0; i < 12; i++)
                Dust.NewDust(NPC.position, NPC.width, NPC.height, 26, (float)hit.HitDirection, -1f, 0, default(Color), 1f);
            if (NPC.life <= 0)
            {
             
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, 42, 1f);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, 43, 1f);
                Gore.NewGore(NPC.GetSource_FromThis(), NPC.position, NPC.velocity, 44, 1f);
               
            }
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DwarvenBrokenArmor>()));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DwarvenCoin>(), 1, 1, 3));
        }
        public override float SpawnChance(NPCSpawnInfo spawnInfo)
        {
            return spawnInfo.Player.ZoneUnderworldHeight && Main.hardMode ? 1f : 0f; 
        }
    }
}