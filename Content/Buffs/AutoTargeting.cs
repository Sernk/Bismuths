using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Buffs
{
    public class AutoTargeting : ModBuff
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Auto Targeting");
            //Description.SetDefault("Your arrows, bullets and rockets aim on enemy");
            //DisplayName.AddTranslation(GameCulture.Russian, "Автонаведение");
            //Description.AddTranslation(GameCulture.Russian, "Стрелы, пули и ракеты наводятся на врага");
            Main.debuff[Type] = false;
            Main.pvpBuff[Type] = true;
            Main.buffNoSave[Type] = true;
        }
    }
}