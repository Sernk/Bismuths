using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Tools
{
    public class PrometheusFire : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 5, 0, 0);
            Item.rare = 4;
            Item.createTile = TileID.Torches;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
        }
        public override void SetStaticDefaults()
        {
            ItemID.Sets.Torches[Item.type] = true;
        }
    }
}