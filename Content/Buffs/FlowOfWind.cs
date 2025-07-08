using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class FlowOfWind : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed += 0.5f;
            player.slowFall = true;
        }
    }
}