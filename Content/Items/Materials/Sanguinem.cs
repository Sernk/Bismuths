using Terraria.ModLoader;
using Terraria;

namespace Bismuth.Content.Items.Materials
{
    public class Sanguinem : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sanguinem");
            //DisplayName.AddTranslation(GameCulture.Russian, "Сангуинем");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.buyPrice(0, 5, 0, 0);
            Item.rare = 0;
        }
    }
}
