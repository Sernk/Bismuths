using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class PeatBlock : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Peat Block");
            //DisplayName.AddTranslation(GameCulture.Russian, "Блок торфа");
        }
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.PeatBlock>();
            Item.value = Item.sellPrice(0, 0, 0, 75);
            Item.rare = 0;
        }
    }
}
