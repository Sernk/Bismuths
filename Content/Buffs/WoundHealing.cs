using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class WoundHealing : ModBuff
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Wound Healing");
            // Description.SetDefault("Your life regeneration is increased");
            //DisplayName.AddTranslation(GameCulture.Russian, "Лечение ранений");
            //Description.AddTranslation(GameCulture.Russian, "Ваша регенерация здоровья увеличена");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;           
        }

        public override void Update(Player player, ref int buffIndex)
        {
            player.lifeRegen += 8;
        }
    }
}