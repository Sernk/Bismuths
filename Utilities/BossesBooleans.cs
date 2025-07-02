using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Utilities
{
    public class BossesBooleans : GlobalNPC
    {
        public override void OnKill(NPC npc)
        {
        
            if ((npc.type == 125 || npc.type == 126 || npc.type == 134 || npc.type == 127) && !BismuthWorld.downedAnyMechBoss)
            {
                BismuthWorld.KilledBossesInWorld++;
                BismuthWorld.downedAnyMechBoss = true;
                if (Main.netMode == 0)
                    Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledAnyMechBoss = true;
            }
            
            if (npc.type == NPCID.EyeofCthulhu && !BismuthWorld.downedEoC)
            {
                BismuthWorld.KilledBossesInWorld++;
                if (Main.netMode == 0)
                    Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledEoC = true;
                // BismuthWorld.downedEoC = true;
            }
           
            if (npc.type == NPCID.SkeletronHead && !BismuthWorld.downedSkeletron)
            {
                BismuthWorld.KilledBossesInWorld++;
                if (Main.netMode == 0)
                    Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledSkeletron = true;
                // BismuthWorld.downedSkeletron = true;
            }
          
            if (npc.type == NPCID.WallofFlesh && !BismuthWorld.downedWoF)
            {
                if (Main.netMode == 0)
                    Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledWoF = true;
                BismuthWorld.KilledBossesInWorld++;
               // BismuthWorld.downedWoF = true;
            }
           
            if (npc.type == NPCID.Plantera && !BismuthWorld.downedPlantera)
            {
                if (Main.netMode == 0)
                    Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledPlantera = true;
                BismuthWorld.KilledBossesInWorld++;
                BismuthWorld.downedPlantera = true;
            }
            
            if (npc.type == NPCID.Golem && !BismuthWorld.downedGolem)
            {
                if (Main.netMode == 0)
                    Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledGolem = true;
                BismuthWorld.KilledBossesInWorld++;
               // BismuthWorld.downedGolem = true;
            }
           
        }
    }
}
