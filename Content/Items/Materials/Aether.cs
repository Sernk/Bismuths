using Bismuth.Content.Tiles;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Materials
{
    public class Aether : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 0, 35, 0);
            Item.rare = 6;
            Item.maxStack = 30;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<FireEssence>());
            recipe.AddIngredient(ModContent.ItemType<WaterEssence>());
            recipe.AddIngredient(ModContent.ItemType<EarthEssence>());
            recipe.AddIngredient(ModContent.ItemType<AirEssence>());
            recipe.AddCondition(AetherRecipe.AetherRecipes);
            recipe.AddTile(ModContent.TileType<AlchemicalShelf>());
            recipe.Register();
        }
    }
}