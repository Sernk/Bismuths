using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Bismuth.Content.Items.Other
{
    public class TruePhilosopherStone : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("True Philosopher Stone");
            // Tooltip.SetDefault("Gives you a second chance...");
            //DisplayName.AddTranslation(GameCulture.Russian, "Истинный филосовский камень");
            //Tooltip.AddTranslation(GameCulture.Russian, "Даёт вам второй шанс...");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(1, 0, 0, 0);
            Item.rare = 10;
        }

    }
}
