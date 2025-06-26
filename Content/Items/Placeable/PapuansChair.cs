using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class PapuansChair : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 16;
            Item.height = 32;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
            Item.consumable = true;            
            Item.createTile = ModContent.TileType<Tiles.PapuansChair>();
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Papuan's Chair");
            //DisplayName.AddTranslation(GameCulture.Russian, "Стул папуасов");
        }

        public override void AddRecipes()  //How to craft this item
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(2504, 4);       
            recipe.AddTile(106);   //at work bench
            recipe.Register();
        }
    }
}
