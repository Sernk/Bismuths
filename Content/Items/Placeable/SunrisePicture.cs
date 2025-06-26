using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class SunrisePicture : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 10;
            Item.height = 24;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 2, 0);
            Item.createTile = ModContent.TileType<Tiles.SunrisePicture>();
            Item.placeStyle = 0;
        }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sunrise");
            // Tooltip.SetDefault("Unknown Author");
            //DisplayName.AddTranslation(GameCulture.Russian, "Рассвет");
            //Tooltip.AddTranslation(GameCulture.Russian, "Неизвестный автор");
        }
    }
}
