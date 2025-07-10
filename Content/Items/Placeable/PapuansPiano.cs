using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class PapuansPiano : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 62;
            Item.height = 32;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 0, 60);
            Item.createTile = ModContent.TileType<Tiles.PapuansPiano>();
        }
        public override void AddRecipes()  
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(154, 4);
            recipe.AddIngredient(2504, 15);         
            recipe.AddIngredient(149, 1);
            recipe.AddTile(106);  
            recipe.Register();
        }
    }
}