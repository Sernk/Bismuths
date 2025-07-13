using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class SwampQuagmire : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.moveSpeed /= 3;
            
        }
    }
}