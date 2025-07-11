using Bismuth.Content.Items.Materials;
using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Utilities.Global
{
    public class Skin : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            if (npc.type == NPCID.Bunny || npc.type == NPCID.Squirrel || npc.type == NPCID.SquirrelRed)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AnimalSkin>(), 2, 2, 3));
            }
        }
    }
}