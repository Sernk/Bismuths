using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class RedKey : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 0, 15, 0);
            Item.rare = 3;
            Item.consumable = true;
        }
    }
}