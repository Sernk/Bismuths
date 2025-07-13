using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class PhoenixBlessing : ModBuff
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
            player.endurance += 0.5f;
        }
    }
}