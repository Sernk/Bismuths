using Bismuth.Content.Tiles;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Materials
{
    public class Quicksilver : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 0, 2, 0);
            Item.rare = 0;
            Item.maxStack = 9999;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Cinnabar>(), 3);         
            recipe.AddTile(ModContent.TileType<BlastFurnace>());
            recipe.Register();
        }
    }
}