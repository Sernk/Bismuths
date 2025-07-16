using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class GalvornScroll : ModItem
    {
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