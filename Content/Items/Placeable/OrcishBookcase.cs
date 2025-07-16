using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class OrcishBookcase : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 14;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 0, 60); 
            Item.createTile = ModContent.TileType<Tiles.OrcishBookcase>();
        }
        public override void AddRecipes()  
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(129, 20);
            recipe.AddIngredient(149, 10);
            recipe.AddIngredient(ModContent.ItemType<Materials.OrcishFragment>(), 1);
            recipe.AddTile(TileID.WorkBenches);   
            recipe.Register();
        }
    }
}