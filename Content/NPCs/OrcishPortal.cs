using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Bismuth.Utilities;

namespace Bismuth.Content.NPCs
{
    public class OrcishPortal : ModNPC
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Orcish Portal");
            //DisplayName.AddTranslation(GameCulture.Russian, "Орочий портал");
        }
        public override void SetDefaults()
        {         
            NPC.width = 124;
            NPC.height = 160;
            NPC.damage = 0;
            NPC.defense = 0;
            NPC.friendly = false;
            NPC.lifeMax = 1500;         
            NPC.value = Item.buyPrice(0, 0, 15, 0);
            NPC.knockBackResist = 1f;          
            Main.npcFrameCount[NPC.type] = 8;           
            AnimationType = 549;
            NPC.noGravity = true;
            NPC.noTileCollide = true;
            NPC.alpha = 255;
        }
        public override void AI()
        {
            var source = NPC.GetSource_FromAI();

            if (NPC.alpha > 0)
                NPC.alpha--;
            if (Main.rand.Next(3500) == 0)
            {
                NPC.NewNPC(source, (int)NPC.position.X + NPC.width / 2, (int)NPC.position.Y + NPC.width / 2, ModContent.NPCType<Orc>());
            }
            if (Main.rand.Next(1800) == 0)
            {
                NPC.NewNPC(source, (int)NPC.position.X + NPC.width / 2, (int)NPC.position.Y + NPC.width / 2, ModContent.NPCType<OrcCrossbower>());
            }
            if (Main.rand.Next(2300) == 0)
            {
                NPC.NewNPC(source, (int)NPC.position.X + NPC.width / 2, (int)NPC.position.Y + NPC.width / 2, ModContent.NPCType<OrcDefender>());
            }
            if (Main.rand.Next(3000) == 0)
            {
                NPC.NewNPC(source, (int)NPC.position.X + NPC.width / 2, (int)NPC.position.Y + NPC.width / 2, ModContent.NPCType<OrcWizard>());
            }
            if (BismuthWorld.DefeatedPortals > 0 && Main.rand.Next(6000) == 0 && !BismuthWorld.SpawnedRhino)
            {
                NPC.NewNPC(source, (int)NPC.position.X + NPC.width / 2, (int)NPC.position.Y + NPC.width / 2, ModContent.NPCType<RhinoOrc>());
                BismuthWorld.SpawnedRhino = true;               
            }
            NPC.velocity = Vector2.Zero;
        }
        public override void OnKill()
        {
            BismuthWorld.DefeatedPortals++;
            if (BismuthWorld.DefeatedPortals > 3)
            {
                //Item.NewItem((int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, mod.ItemType("OrcishKey"));
                BismuthWorld.OrcishInvasionStage = 2;
            }
        }
    }
}