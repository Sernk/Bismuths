using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class TeleportCooldown : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Teleport Cooldown");
            // Description.SetDefault("You can't use teleportation");
            //DisplayName.AddTranslation(GameCulture.Russian, "Кулдаун телепортации");
            //Description.AddTranslation(GameCulture.Russian, "Вы не можете телепортироваться");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
    }
}