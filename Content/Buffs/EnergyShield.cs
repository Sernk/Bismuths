using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class EnergyShield : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.endurance += 0.25f;
            if (player.GetModPlayer<BismuthPlayer>().skill107lvl > 0)
                player.lifeRegen += 16;          
        }
    }
}