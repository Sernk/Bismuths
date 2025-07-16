using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class MagicPot : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 64;
            Item.height = 26;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 4, 0);
            Item.createTile = ModContent.TileType<Tiles.MagicPot>();
        }       
    }
}