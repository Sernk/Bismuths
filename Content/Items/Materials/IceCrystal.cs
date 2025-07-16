using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Materials
{
    class IceCrystal : ModItem
    {
        public override void SetDefaults()
        {          
            Item.width = 40;
            Item.height = 20;
            Item.rare = 0;
            Item.maxStack = 9999;
            Item.material = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(3);
            recipe.AddIngredient(ItemID.IceBlock, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}