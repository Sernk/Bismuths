using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class UnchargedElessar : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Gaermire");
            // Tooltip.SetDefault("Needs something to be charged...");
            //DisplayName.AddTranslation(GameCulture.Russian, "Незаряженный гаэрмир");
            //Tooltip.AddTranslation(GameCulture.Russian, "Требует что-то для активации...");
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
