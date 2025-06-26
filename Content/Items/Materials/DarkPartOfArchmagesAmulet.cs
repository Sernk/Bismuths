using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.Localization;

namespace Bismuth.Content.Items.Materials
{
    public class DarkPartOfArchmagesAmulet : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Dark Fragment of the Archmage's Amulet");
            //DisplayName.AddTranslation(GameCulture.Russian, "Темный осколок амулета архимага");
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