using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class DeathWish : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetCritChance(DamageClass.Melee) = 100;
            player.GetCritChance(DamageClass.Ranged) = 100;
            player.GetCritChance(DamageClass.Magic) = 100;
            player.GetCritChance(DamageClass.Throwing) = 100;
            player.GetModPlayer<ModP>().assassinCrit = 100;          
            player.GetModPlayer<BismuthPlayer>().killordietaimer++;
        }
    }
}