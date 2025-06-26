using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class RuneTable : ModItem
    {
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
            Item.value = Item.buyPrice(0, 30, 0, 0);
            Item.createTile = ModContent.TileType<Tiles.RuneTable>();
        }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Rune Table");
            //DisplayName.AddTranslation(GameCulture.Russian, "Рунический стол");
        }
    }
}
