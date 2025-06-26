using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Materials
{
    public class PoisonFlask : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Poison Flask");
            //DisplayName.AddTranslation(GameCulture.Russian, "Бутыль яда");
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;
            Item.maxStack = 30;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 2;
            Item.value = 100;
            Item.rare = 1;
            Item.UseSound = SoundID.Item3;
            Item.consumable = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddCondition(Condition.NearWater);
            recipe.AddIngredient(ItemID.Bottle);
            recipe.Register();
        }
    }
}
