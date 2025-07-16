using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class DwarvenCoin : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.rare = 3;
            Item.maxStack = 9999;
        }
    }
}