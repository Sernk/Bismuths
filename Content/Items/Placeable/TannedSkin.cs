using Bismuth.Content.Items.Materials;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class TannedSkin : ModItem
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
            Item.value = 3500;
            Item.createTile = ModContent.TileType<Tiles.TannedSkin>();
        }
        public override void AddRecipes()  
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(9, 10);
            recipe.AddIngredient(ModContent.ItemType<AnimalSkin>(), 3);
            recipe.AddTile(18);  
            recipe.Register();
        }
    }
}