using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class OrcishCoatOfArms : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 10;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 2, 0);
            Item.createTile = ModContent.TileType<Tiles.OrcishCoatOfArms>();
            Item.placeStyle = 0;
        }       
    }  
}