using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class Specularity : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Specularity");
            // Description.SetDefault("You are immortal");
            //DisplayName.AddTranslation(GameCulture.Russian, "Зеркальность");
            //Description.AddTranslation(GameCulture.Russian, "Вы неуязвимы");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.immune = true;
            player.immuneAlpha = 0;
            player.immuneNoBlink = true;
        }
    }
}