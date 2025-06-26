using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class UnchargedTruePhilosopherStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("True Philosopher Stone");
            // Tooltip.SetDefault("Has to be charged first");
            //DisplayName.AddTranslation(GameCulture.Russian, "Незаряженный истинный филосовский камень");
            //Tooltip.AddTranslation(GameCulture.Russian, "Для начала должен быть заряжен");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(1, 0, 0, 0);
            Item.rare = 0;
        }

    }
}
