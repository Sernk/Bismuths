using Terraria.ModLoader;
using Terraria;

namespace Bismuth.Content.Items.Materials
{
    public class Cinnabar : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Cinnabar");
           // DisplayName.AddTranslation(GameCulture.Russian, "Киноварь");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 0, 5, 0);
            Item.rare = 0;
            Item.maxStack = 9999;
            Item.material = true;
            Item.material = true;
        }      
    }
}