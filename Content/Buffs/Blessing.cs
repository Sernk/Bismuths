using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class Blessing : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        int tick = 0;
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.GetModPlayer<BismuthPlayer>().IsFTRead)
            {
                player.statLifeMax2 += player.statLifeMax2 / 5;
                player.lifeRegen += 16;
                tick++;
                if (tick % 6 == 0)
                    player.statMana += 2;
            }
            else
            {
                player.statLifeMax2 += player.statLifeMax2 / 10;
                player.lifeRegen += 8;
                tick++;
                if (tick % 6 == 0)
                    player.statMana += 1;
            }           
        }
    }
}