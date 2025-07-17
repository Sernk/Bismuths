using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth
{
    public static class AetherRecipe
    {
        public static Condition AetherRecipes = new Condition(ModContent.GetInstance<LocalizationSystem>().AetherRecipe, () => Main.LocalPlayer.GetModPlayer<BismuthPlayer>().TabulaResearch);
        public static Condition PhilosopherStone = new Condition(ModContent.GetInstance<LocalizationSystem>().PhilosopherStone, () => TempNPCs.RecipePhilosopherStone);
    }
}