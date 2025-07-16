using Bismuth.Content.Tiles;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class FernSpore : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.rare = 0;
            Item.maxStack = 9999;
            Item.createTile = ModContent.TileType<FernFlower>();
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
        }   
    }
}
