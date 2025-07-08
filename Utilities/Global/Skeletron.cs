using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Utilities.Global
{
    public class Skeletron : GlobalNPC
    {
        public override void OnKill(NPC npc)
        {
            if (npc.type == NPCID.SkeletronHead)
            {
                if (BismuthWorld.downedSkeletron == false)
                {
                    BismuthWorld.downedSkeletron = true;
                }
            }
        }
    }
}
