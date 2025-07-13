using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class KillingSpreeI : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.GetDamage(DamageClass.Ranged) += 0.1f;
        }
    }
}