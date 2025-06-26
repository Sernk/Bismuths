using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class UnchargedLuceat : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Uncharged Luceat");
            // Tooltip.SetDefault("Has to be charged first");
           // DisplayName.AddTranslation(GameCulture.Russian, "Незаряженный луцеат");
           // Tooltip.AddTranslation(GameCulture.Russian, "Для начала должен быть заряжен");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = 3;
            Item.material = true;
        }

    }
}
