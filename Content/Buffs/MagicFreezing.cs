using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class MagicFreezing : ModBuff
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
            player.controlJump = false;
            player.controlDown = false;
            player.controlLeft = false;
            player.controlRight = false;
            player.controlUp = false;
            player.controlUseItem = false;
            player.controlUseTile = false;
            player.controlThrow = false;
            if (player.statLife <= 0)
                player.statLife = 2;
            player.lifeRegen += 30;
            player.immune = true;
            player.immuneNoBlink = true;
            player.immuneAlpha = 0;
            if (player.statMana > 0)
                player.statMana--;
            else
                player.QuickMana();
        }
    }
}