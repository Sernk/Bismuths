using Terraria;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Utilities
{
    public class LocalizationSystem : ModSystem, ILocalizedModType
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

        public static int GetProgress()
        {
            int progress = 0;
            if (NPC.downedBoss1) progress++;
            if (NPC.downedBoss2) progress++;
            if (NPC.downedBoss3) progress++;
            if (Main.hardMode) progress++;
            if (NPC.downedMechBossAny) progress++;
            if (NPC.downedPlantBoss) progress++;
            if (NPC.downedGolemBoss) progress++;
            return progress;
        }
    }
}