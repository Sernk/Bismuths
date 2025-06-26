using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.Localization;

namespace Bismuth.Content.Items.Materials
{
    public class MirrorRim : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Mirror Rim");
            // DisplayName.AddTranslation(GameCulture.Russian, "Оправа зеркала");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.buyPrice(0, 0, 50, 0);
            Item.rare = 0;
            Item.material = true;
        }
    }
}