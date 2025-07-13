using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class Stealth : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.GetModPlayer<BismuthPlayer>().skill86lvl > 0)
            {
                player.GetModPlayer<ModP>().assassinDamage += 0.66f;
                player.GetModPlayer<ModP>().assassinCrit += 30;
                player.endurance -= 0.5f;
                player.statDefense -= 25;
                if (player.GetModPlayer<BismuthPlayer>().skill87lvl > 0)
                {
                    player.GetModPlayer<BismuthPlayer>().DodgeChance += 40;
                }
            }           
        }
    }
}