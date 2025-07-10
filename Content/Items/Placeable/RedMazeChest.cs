using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class RedMazeChest : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 22;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.createTile = ModContent.TileType<Tiles.RedMazeChest>();
        }
    }
}