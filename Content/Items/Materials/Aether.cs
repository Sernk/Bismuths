using Terraria.ModLoader;
using Terraria;
using Bismuth.Content.Tiles;

namespace Bismuth.Content.Items.Materials
{
    public class Aether : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Aether");
            //DisplayName.AddTranslation(GameCulture.Russian, "Эфир");
            // Tooltip.SetDefault("Used to charge philosopher stone");
            //Tooltip.AddTranslation(GameCulture.Russian, "Используется для зарядки филосовского камня");
        }
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
            recipe.AddTile(ModContent.TileType<AlchemicalShelf>());
            recipe.Register();
        }
    }
}
