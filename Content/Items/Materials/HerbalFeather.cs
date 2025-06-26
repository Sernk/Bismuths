using Terraria.ModLoader;
using Terraria;

namespace Bismuth.Content.Items.Materials
{
    class HerbalFeather : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Herbal Feather");
            //DisplayName.AddTranslation(GameCulture.Russian, "Травяное перо");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 12, 50, 0);
            Item.rare = 4;
            Item.material = true;
        }
    }
}
