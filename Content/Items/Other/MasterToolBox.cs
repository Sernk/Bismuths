using Terraria.ModLoader;
using Terraria;

namespace Bismuth.Content.Items.Other
{
    public class MasterToolBox : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.buyPrice(5, 0, 0, 0);
            Item.rare = 7;
        }
    }
}