using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Bismuth.Content.Items.Other
{
    public class GreenKey : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Green Key");
            // Tooltip.SetDefault("Opens the green maze chest and door");
            //DisplayName.AddTranslation(GameCulture.Russian, "Зеленый ключ");
            //Tooltip.AddTranslation(GameCulture.Russian, "Открывает зеленые сундук и дверь лабиринта");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 0, 15, 0);
            Item.rare = 3;
            Item.consumable = true;
        }

    }
}
