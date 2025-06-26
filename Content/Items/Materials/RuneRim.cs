using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Materials
{
    class RuneRim : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Rune Rim");
            //DisplayName.AddTranslation(GameCulture.Russian, "Руническая оправа");
        }
        public override void SetDefaults()
        {     
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.buyPrice(0, 3, 50, 0);
            Item.rare = 5;             
        }
    }
}