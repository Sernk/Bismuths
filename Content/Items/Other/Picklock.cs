using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class Picklock : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 9999;
            Item.value = Item.buyPrice(0, 0, 10, 0);
            Item.rare = 0;
        }
    }
}