using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class NoLimit : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {        
            if (player.GetModPlayer<BismuthPlayer>().skill61lvl > 0 && player.GetModPlayer<BismuthPlayer>().skill62lvl == 0)
            {
                player.manaCost = 0;
            }
            if (player.GetModPlayer<BismuthPlayer>().skill62lvl > 0)
            {
                player.manaCost = 0;
                player.GetCritChance(DamageClass.Magic) += 25;
            }
        }
    }
}