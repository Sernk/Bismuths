using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class UnchargedTruePhilosopherStone : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(1, 0, 0, 0);
            Item.rare = 0;
        }
    }
}