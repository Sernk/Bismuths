using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class StunningWeapons : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }     
    }
}