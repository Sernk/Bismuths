using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class PanaceaScroll : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = 0;
            Item.useStyle = 1;
            Item.useTime = 15;
            Item.useAnimation = 15;
        }
        public override void UpdateInventory(Player player)
        {
            BismuthPlayer.PanaceaResearch = true;
        }
    }
}
