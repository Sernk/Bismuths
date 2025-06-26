using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Terraria.Localization;

namespace Bismuth.Content.Items.Placeable
{
    public class PapuansPlatform : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 8;
            Item.height = 10;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.PapuansPlatform>();
        }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Papuan's Platform");
           // DisplayName.AddTranslation(GameCulture.Russian, "Платформа папуасов");
        }

        public override void AddRecipes()  
        {
            Recipe recipe = CreateRecipe(4);
            recipe.AddIngredient(2504, 1);      
            recipe.AddTile(106);   
            recipe.Register();
        }
    }
}
