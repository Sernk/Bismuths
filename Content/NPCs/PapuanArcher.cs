using Bismuth.Content.Items.Accessories;
using Bismuth.Content.Items.Weapons.Ranged;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.NPCs
{
    public class PapuanArcher : ModNPC
    {
        public override void SetDefaults()
        {
            NPC.width = 24;
            NPC.height = 44;
            NPC.damage = 10;
            NPC.defense = 6;
            NPC.lifeMax = 45;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.value = Item.buyPrice(0, 0, 3, 7);
            NPC.knockBackResist = 0.5f;
            NPC.aiStyle = 3;
            Main.npcFrameCount[NPC.type] = 21;
            AIType = 111;
            AnimationType = 111;
            //banner = npc.type;
            //bannerItem = mod.ItemType("PapuanArcherBanner");
        }
        public override void ApplyDifficultyAndPlayerScaling(int numPlayers, float balance, float bossAdjustment)
        {
            NPC.lifeMax = (int)(NPC.lifeMax * 1.5f);
            NPC.damage = (int)(NPC.damage * 1.5f);
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hit.HitDirection, -2.5f, 0, default, 0.7f);
                }
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PapuanArcherArm").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PapuanArcherBody").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PapuanArcherHead").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PapuanLeg").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PapuanArcherWeapon").Type, 1f);
            }
        }
        public override void AI()
        {
            NPC.TargetClosest(true);
        }
        public override void ModifyNPCLoot(NPCLoot npcLoot)
        {
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TribalBow>(), 50));
            npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<TribalQuiver>(), 50));
        }
    }
}