using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Buffs
{
    public class Paralisys : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Paralisys");
            // Description.SetDefault("Azaza, etovo nikto ne uvidit");
            //DisplayName.AddTranslation(GameCulture.Russian, "чич");
            //Description.AddTranslation(GameCulture.Russian, "фыф");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.position.X = npc.oldPosition.X;
            npc.frameCounter = 0;    
            if(npc.noGravity)
                npc.position.Y = npc.oldPosition.Y;
            //npc.GetGlobalNPC<GlobalNPCs>().stundef = true;
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill96lvl > 0)
                npc.defense = 0;
        }
    }
}