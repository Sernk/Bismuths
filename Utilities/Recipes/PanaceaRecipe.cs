using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Utilities.Recipes
{
    public class PanaceaRecipe
    {
        public static Condition PanaceaRecipes = new Condition(ModContent.GetInstance<LocalizationSystem>().PanaceaRecipe,() => BismuthPlayer.PanaceaResearch);
    }
}