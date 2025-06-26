using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Bismuth.Content.Tiles;

namespace Bismuth.Content.Items.Placeable
{
    class FernSpore : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Fern Spore");
           // DisplayName.AddTranslation(GameCulture.Russian, "Споры папоротника");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.rare = 0;
            Item.maxStack = 999;
            Item.createTile = ModContent.TileType<FernFlower>();
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
        }   
    }
}
