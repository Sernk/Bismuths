using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class Picklock : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Lockpick");
            // Tooltip.SetDefault("A tool for prying locks open");
            //DisplayName.AddTranslation(GameCulture.Russian, "Отмычка");
            //Tooltip.AddTranslation(GameCulture.Russian, "Инструмент для взлома замков");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 30;
            Item.value = Item.buyPrice(0, 0, 10, 0);
            Item.rare = 0;
        }
    }
}