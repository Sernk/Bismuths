using Bismuth.Content.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Materials
{
    public class GalvornBar : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = 100;
            Item.rare = 1;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
        }
        public override void AddRecipes()
        {

            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PeatPowder>(), 3);
            recipe.AddIngredient(ItemID.MeteoriteBar);
            recipe.AddTile(ModContent.TileType<BlastFurnace>());
            recipe.AddCondition(GalvornRecipe.GalvornRecipes);
            recipe.Register();
        }
    }
}