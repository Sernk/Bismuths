using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class OrcishKey : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Orcish Key");
            // Tooltip.SetDefault("Opens the orcish chest");
            //DisplayName.AddTranslation(GameCulture.Russian, "Орочий ключ");
            //Tooltip.AddTranslation(GameCulture.Russian, "Открывает орочий сундук");
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
