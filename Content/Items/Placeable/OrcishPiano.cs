using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class OrcishPiano : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 62;
            Item.height = 32;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.buyPrice(0, 0, 0, 60);
            Item.createTile = ModContent.TileType<Tiles.OrcishPiano>();
        }
        public override void AddRecipes() 
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(154, 4);
            recipe.AddIngredient(129, 14);
            recipe.AddIngredient(ModContent.ItemType<Materials.OrcishFragment>(), 1);
            recipe.AddIngredient(149, 1);
            recipe.AddTile(18);  
            recipe.Register();
        }
    }
}