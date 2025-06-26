using Terraria.ModLoader;
using Terraria;

namespace Bismuth.Content.Items.Materials
{
    public class ToadsEye : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Toad's Eye");
            //DisplayName.AddTranslation(GameCulture.Russian, "Жабий глаз");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 0, 2, 50);
            Item.rare = 0;
            Item.maxStack = 9999;
            Item.material = true;
        }
    }
}
