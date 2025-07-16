using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class PapuansBed : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 64;
            Item.height = 26;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 4, 0);
            Item.createTile = ModContent.TileType<Tiles.PapuansBed>();
        }      
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(2504, 15);
            recipe.AddIngredient(225, 5);            
            recipe.AddTile(86);   
            recipe.Register();
        }
    }
}