using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class SwampWoodWall : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 7;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.createWall = ModContent.WallType<Walls.SwampWoodWall>();
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(4);           
            recipe.AddIngredient(ModContent.ItemType<SwampWood>());
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }
    }
}