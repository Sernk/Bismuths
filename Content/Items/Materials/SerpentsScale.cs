using Terraria.ModLoader;
using Terraria;

namespace Bismuth.Content.Items.Materials
{
    class SerpentsScale : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The Scale of a Serpent");
            //DisplayName.AddTranslation(GameCulture.Russian, "Чешуйка змея");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 0, 2, 0);
            Item.rare = 0;
            Item.maxStack = 9999;
        }

    }
}