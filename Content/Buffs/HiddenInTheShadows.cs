using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class HiddenInTheShadows : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Hidden in the Shadown");
            // Description.SetDefault("You are invisible");
            //DisplayName.AddTranslation(GameCulture.Russian, "Прячущийся в тенях");
            //Description.AddTranslation(GameCulture.Russian, "Вы невидимы");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            player.invis = true;
        }
    }
}