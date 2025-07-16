using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Materials
{
    public class OrcishBar : ModItem
    {
        public override void SetDefaults()
        {            
            Item.width = 40;
            Item.height = 20;
            Item.value = 100;
            Item.rare = 2;
            Item.maxStack = 9999;
            Item.createTile = ModContent.TileType<Tiles.OrcishBar>();
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
            Item.consumable = true;      
        }
        public override void AddRecipes() 
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<OrcishFragment>(), 3);
            recipe.AddTile(77);
            recipe.Register();
        }
    }
}