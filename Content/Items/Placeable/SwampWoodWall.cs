using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class SwampWoodWall : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Swamp Wood Wall");
            //DisplayName.AddTranslation(GameCulture.Russian, "Стена из болотной древесины");
        }

        public override void SetDefaults()
        {
            Item.width = 12;
            Item.height = 12;
            Item.maxStack = 999;
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