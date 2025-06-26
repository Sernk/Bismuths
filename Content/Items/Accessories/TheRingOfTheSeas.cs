using Terraria;
using Terraria.ModLoader;
using Bismuth.Content.Items.Materials;

namespace Bismuth.Content.Items.Accessories
{
    public class TheRingOfTheSeas : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The Ring Of The Seas");
            // Tooltip.SetDefault("Turns you into a naga");
            //DisplayName.AddTranslation(GameCulture.Russian, "Кольцо морей");
            //Tooltip.AddTranslation(GameCulture.Russian, "Превращает вас в нагу");
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
            recipe.AddIngredient(ModContent.ItemType<RingRim>());
            recipe.AddIngredient(ModContent.ItemType<Elessar>());
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}