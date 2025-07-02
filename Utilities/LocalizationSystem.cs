using Bismuth.Utilities.Recipes;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Utilities
{
    public class LocalizationSystem : ModPlayer, ILocalizedModType
    {
        public string LocalizationCategory => "CoinSystem";

        public string DwarvenCoin = Language.GetTextValue("Mods.Bismuth.CoinSystem.CoinLocalization.CoinSystem.DwarvenCoin");
        public string Ocrea = Language.GetTextValue("Mods.Bismuth.CoinSystem.CoinLocalization.CoinSystem.Ocrea");
        public string ImperianHelmet = Language.GetTextValue("Mods.Bismuth.CoinSystem.CoinLocalization.CoinSystem.ImperianHelmet");
        public string Lorica = Language.GetTextValue("Mods.Bismuth.CoinSystem.CoinLocalization.CoinSystem.Lorica");
        public string AetherRecipe = Language.GetTextValue("Mods.Bismuth.CoinSystem.CoinLocalization.CoinSystem.AetherRecipe");
        public string GalvornRecipe = Language.GetTextValue("Mods.Bismuth.CoinSystem.CoinLocalization.CoinSystem.GalvornRecipe");
        public string PoisonRecipe = Language.GetTextValue("Mods.Bismuth.CoinSystem.CoinLocalization.CoinSystem.PoisonRecipe");
        public string PanaceaRecipe = Language.GetTextValue("Mods.Bismuth.CoinSystem.CoinLocalization.CoinSystem.PanaceaRecipe");

        public override void Load()
        {
            _ = this.GetLocalization("CoinSystem.DwarvenCoin").Value; // Ru: Монета гномов: En: Dwarven Coin
            _ = this.GetLocalization("CoinSystem.Ocrea").Value; // Ru: Охра : En: Ocrea
            _ = this.GetLocalization("CoinSystem.ImperianHelmet").Value; // Ru: Императорский шлем: En: Imperian Helmet
            _ = this.GetLocalization("CoinSystem.Lorica").Value; // Ru: Лорика: En: Lorica
            _ = this.GetLocalization("CoinSystem.AetherRecipe").Value; // Ru: Рецепт эфира En: Aether Recipe
            _ = this.GetLocalization("CoinSystem.GalvornRecipe").Value; // Ru: Рецепт Галворна En: GalvornRecipe
            _ = this.GetLocalization("CoinSystem.PoisonRecipe").Value; // Ru: Рецепт яда En: PoisonRecipe
            _ = this.GetLocalization("CoinSystem.PanaceaRecipe").Value; // Ru: Рецепт панацеи En: Panacea Recipe
        }
    }
}
