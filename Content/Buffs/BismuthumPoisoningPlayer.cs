using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class BismuthumPoisoningPlayer : ModBuff
    { 
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = false;
            Main.buffNoTimeDisplay[Type] = true;       
        }           
    }
}
