using Terraria;
using Terraria.ID;
using Bismuth.Utilities;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class GalvornScroll : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Galvorn Scroll");
            //DisplayName.AddTranslation(GameCulture.Russian, "Галворновый свиток");
            // Tooltip.SetDefault("You can create galvorn bars having this scroll");
            //Tooltip.AddTranslation(GameCulture.Russian, "Вы можете создавать галворновые слитки, имея этот свиток");
        }
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = 0;
        }
        public override void UpdateInventory(Player player)
        {
            BismuthPlayer.GalvornResearch = true;
        }
    }
}
