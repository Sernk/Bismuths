using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class DwarvenCoin : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Dwarven Coin");
           // DisplayName.AddTranslation(GameCulture.Russian, "Гномья монета");
            // Tooltip.SetDefault("Currency for trading with the Blacksmith");
           // Tooltip.AddTranslation(GameCulture.Russian, "Валюта для торговли с кузнецом");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = 3;
            Item.maxStack = 99;
        }
    }
}
