using Terraria.ModLoader;

namespace Bismuth.Content.Items.Materials
{
    public class Elessar : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Gaermire");
            // Tooltip.SetDefault("Holds the hidden power of the sea folk");
            //DisplayName.AddTranslation(GameCulture.Russian, "Гаэрмир");
            //Tooltip.AddTranslation(GameCulture.Russian, "Хранит скрытую силу морского народа");
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
