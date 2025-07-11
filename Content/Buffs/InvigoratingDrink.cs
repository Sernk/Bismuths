using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class InvigoratingDrink : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Melee) += 0.2f;
            player.GetCritChance(DamageClass.Melee) += 20;
            player.GetAttackSpeed(DamageClass.Melee) += 0.2f;
        }
    }
}