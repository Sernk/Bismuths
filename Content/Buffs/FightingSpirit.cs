using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class FightingSpirit : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = false;
            Main.buffNoTimeDisplay[Type] = false;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Melee) += 0.5f;
            player.GetDamage(DamageClass.Ranged) += 0.5f;
            player.GetDamage(DamageClass.Magic) += 0.5f;
            player.GetDamage(DamageClass.Summon) += 0.5f;
            player.GetDamage(DamageClass.Throwing) += 0.5f;
            player.GetModPlayer<ModP>().assassinDamage += 0.5f;
            player.endurance -= 0.5f;
        }     
    }
}