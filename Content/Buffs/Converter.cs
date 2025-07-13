using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class Converter : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.manaRegenCount = 0;
           
        }
    }
}