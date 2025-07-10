using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class PapuansChandelier : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 22;
            Item.height = 32;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 6, 0);
            Item.createTile = ModContent.TileType<Tiles.PapuansChandelier>();
        }
        public override void AddRecipes() 
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(2504, 4);
            recipe.AddIngredient(8, 4);
            recipe.AddIngredient(85, 1);          
            recipe.AddTile(106);   
            recipe.Register();
        }
    }
}