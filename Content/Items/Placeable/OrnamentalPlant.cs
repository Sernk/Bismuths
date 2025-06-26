using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class OrnamentalPlant : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ornamental Plant");
            //DisplayName.AddTranslation(GameCulture.Russian, "Декоративное растение");
        }
        public override void SetDefaults()
        {

            Item.width = 22;
            Item.height = 32;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.rare = 1;
            Item.value = Item.buyPrice(0, 0, 15, 0);
            Item.createTile = ModContent.TileType<Tiles.OrnamentalPlant>();
            Item.maxStack = 99;
        }
    }
}