using Terraria.ModLoader;
using Terraria;

namespace Bismuth.Content.Items.Materials
{
    public class DarkEngraving : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Dark Engraving");
            //DisplayName.AddTranslation(GameCulture.Russian, "Темная гравировка");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 0, 2, 50);
            Item.rare = 6;
            Item.maxStack = 9999;
            Item.material = true;
        }
       
    }
}
