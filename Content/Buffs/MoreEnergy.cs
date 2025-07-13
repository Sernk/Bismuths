using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class MoreEnergy : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.GetModPlayer<BismuthPlayer>().skill33lvl > 0 && player.GetModPlayer<BismuthPlayer>().skill34lvl == 0)
            {
                player.GetDamage(DamageClass.Melee) *= 3;
            }
            if (player.GetModPlayer<BismuthPlayer>().skill34lvl > 0)
            {
                player.GetDamage(DamageClass.Melee) *= 5;
            }
        }
    }
}