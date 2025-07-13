using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class TeleportCooldown : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
    }
}