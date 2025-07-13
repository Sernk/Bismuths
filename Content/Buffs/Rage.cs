using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class Rage : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.GetModPlayer<BismuthPlayer>().skill22lvl > 0 && player.GetModPlayer<BismuthPlayer>().skill23lvl == 0)
            {
                player.GetAttackSpeed(DamageClass.Melee) += 0.3f;
                player.endurance -= 0.15f;
            }
            else if (player.GetModPlayer<BismuthPlayer>().skill23lvl > 0 && player.GetModPlayer<BismuthPlayer>().skill24lvl == 0)
            {
                player.GetAttackSpeed(DamageClass.Melee) += 0.4f;
                player.endurance -= 0.1f;
            }
            else if (player.GetModPlayer<BismuthPlayer>().skill24lvl > 0)
            {
                player.GetAttackSpeed(DamageClass.Melee) += 0.5f;
                player.GetCritChance(DamageClass.Melee) += 15;
            }
        }
    }
}