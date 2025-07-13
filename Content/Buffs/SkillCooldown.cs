using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class SkillCooldown : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = false;
            Main.persistentBuff[Type] = true;
        }
    }
}