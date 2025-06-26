using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Bismuth.Content.Items.Materials
{
    class IceCrystal : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ice Crystal");
            //DisplayName.AddTranslation(GameCulture.Russian, "Ледяной кристалл");
        }
        public override void SetDefaults()
        {          
            Item.width = 40;
            Item.height = 20;
            Item.rare = 0;
            Item.maxStack = 999;
            Item.material = true;
        }
        public override void AddRecipes()  //How to craft this item
        {
            Recipe recipe = CreateRecipe(3);
            recipe.AddIngredient(ItemID.IceBlock, 1);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}