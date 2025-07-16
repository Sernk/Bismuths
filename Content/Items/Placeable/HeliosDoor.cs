using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class HeliosDoor : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 14;
            Item.height = 28;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 0, 40);
            Item.createTile = ModContent.TileType<Tiles.HeliosDoorClosed>();
        }
    }
}