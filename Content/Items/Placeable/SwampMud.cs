using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class SwampMud : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.SwampMud>();
            Item.value = Item.sellPrice(0, 0, 0, 0);
            Item.rare = 0;
        }
    }
}