using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class HealthDevourment : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = false;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }
    }
}