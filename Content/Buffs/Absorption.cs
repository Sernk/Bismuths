using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class Absorption : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        int timealive = 0;
        public override void Update(Player player, ref int buffIndex)
        {
            timealive++;
            if (timealive > 480)
                player.endurance += 0.5f;
        }
    }
}