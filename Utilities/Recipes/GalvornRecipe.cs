using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth
{
    public static class GalvornRecipe
    {
        public static Condition GalvornRecipes = new Condition(ModContent.GetInstance<LocalizationSystem>().GalvornRecipe, () => BismuthPlayer.GalvornResearch);
    }
}