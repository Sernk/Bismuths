using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class WallCarpet : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 62;
            Item.height = 32;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.buyPrice(0, 1, 0, 0);
            Item.createTile = ModContent.TileType<Tiles.WallCarpet>();
        }
    }
}