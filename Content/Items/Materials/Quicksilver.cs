using Terraria.ModLoader;
using Terraria;
using Bismuth.Content.Tiles;

namespace Bismuth.Content.Items.Materials
{
    public class Quicksilver : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Quicksilver");
            //DisplayName.AddTranslation(GameCulture.Russian, "Ртуть");
        }
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
