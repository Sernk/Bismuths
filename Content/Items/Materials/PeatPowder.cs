using Terraria.ModLoader;
using Terraria;
using Bismuth.Content.Items.Placeable;

namespace Bismuth.Content.Items.Materials
{
    public class PeatPowder : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Peat Powder");
            //DisplayName.AddTranslation(GameCulture.Russian, "Торфяной порошок");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 0, 0, 50);
            Item.rare = 0;
            Item.material = true;
            Item.maxStack = 9999;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe(2);
            recipe.AddIngredient(ModContent.ItemType<PeatBlock>());
            recipe.Register();
        }
    }
}