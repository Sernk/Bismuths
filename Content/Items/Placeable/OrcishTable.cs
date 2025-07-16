using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class OrcishTable : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 32;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.buyPrice(0, 0, 0, 60);
            Item.createTile = ModContent.TileType<Tiles.OrcishTable>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(129, 10);
            recipe.AddIngredient(ModContent.ItemType<Materials.OrcishFragment>(), 1);
            recipe.AddTile(18);
            recipe.Register();
        }
    }
}