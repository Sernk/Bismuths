using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class Crowd : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.GetModPlayer<BismuthPlayer>().skill39lvl > 0 && player.GetModPlayer<BismuthPlayer>().skill40lvl == 0)
            {
                player.maxMinions += 4;
            }     
            if (player.GetModPlayer<BismuthPlayer>().skill40lvl > 0)
            {
                player.maxMinions *= 2;               
            }
        }
    }
}