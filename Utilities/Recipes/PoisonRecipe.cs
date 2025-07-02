using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Utilities.Recipes
{
    public static class PoisonRecipe
    {
        public static Condition PoisonRecipes = new Condition(ModContent.GetInstance<LocalizationSystem>().PoisonRecipe, () => BismuthPlayer.ZoneSwamp);
    }
}