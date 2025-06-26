using Terraria.ModLoader;
using Terraria;

namespace Bismuth.Content.Items.Materials
{
    public class LightPartOfArchmagesAmulet : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Light Fragment of the Archmage's Amulet");
            //DisplayName.AddTranslation(GameCulture.Russian, "Светлый осколок амулета архимага");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 0, 5, 0);
            Item.rare = 6;
            Item.material = true;
        }

    }
}