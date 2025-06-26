using Terraria;
using Terraria.ModLoader;
using Bismuth.Content.Items.Materials;

namespace Bismuth.Content.Items.Accessories
{
    public class TheRingOfTheBlood : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The Ring Of The Blood");
            // Tooltip.SetDefault("Turns you into a vampire");
            //DisplayName.AddTranslation(GameCulture.Russian, "Кольцо крови");
            //Tooltip.AddTranslation(GameCulture.Russian, "Превращает вас в вампира");
        }
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 10;
            Item.accessory = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RingRim>(), 1);
            recipe.AddIngredient(ModContent.ItemType<Sanguinem>(), 1);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}