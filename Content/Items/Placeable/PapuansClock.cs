using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class PapuansClock : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 74;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 0, 60);
            Item.createTile = ModContent.TileType<Tiles.PapuansClock>();
        }
        public override void AddRecipes() 
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(2504, 10);
            recipe.AddIngredient(22, 3);
            recipe.AddIngredient(170, 6);
            recipe.RequireGroup(RecipeGroupID.IronBar);
            recipe.AddTile(18);   
            recipe.Register();
        }
    }
}