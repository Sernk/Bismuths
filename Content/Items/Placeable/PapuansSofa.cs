using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class PapuansSofa : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 16;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 0, 60);
            Item.createTile = ModContent.TileType<Tiles.PapuansSofa>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(2504, 5);
            recipe.AddIngredient(225, 2);
            recipe.AddTile(106);
            recipe.Register();
        }
    }
}