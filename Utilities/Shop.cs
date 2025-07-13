using MonoMod.RuntimeDetour;
using System.Reflection;
using Terraria;
using Terraria.GameContent;          
using Terraria.ID;                  
using Terraria.ModLoader;

namespace Bismuth.Utilities
{
    /// <summary>
    /// Возможно цену можно поменять и по легче но я не знаю как.
    /// Снижает цены у NPC‑продавцов в зависимости от навыков игрока.
    /// </summary>
    public sealed class Shop : ModSystem
    {
        private Hook _getShoppingSettingsHook;

        public override void Load()
        {
            // Берём целевой метод: ShopHelper.GetShoppingSettings(Player,NPC)
            MethodInfo target = typeof(ShopHelper).GetMethod(nameof(ShopHelper.GetShoppingSettings), BindingFlags.Instance | BindingFlags.Public);
            _getShoppingSettingsHook = new Hook(target, (GetShoppingSettingsDetour)Detour_GetShoppingSettings);
        }

        public override void Unload()
        {
            _getShoppingSettingsHook?.Dispose();
        }

        /// <summary>Сигнатура оригинального метода.</summary>
        private delegate ShoppingSettings Orig_GetShoppingSettings(ShopHelper self, Player player, NPC npc);

        /// <summary>
        /// Сигнатура detour‑метода: первым идёт trampoline «orig».
        /// </summary>
        private delegate ShoppingSettings GetShoppingSettingsDetour(Orig_GetShoppingSettings orig, ShopHelper self, Player player, NPC npc);

        private ShoppingSettings Detour_GetShoppingSettings(Orig_GetShoppingSettings orig, ShopHelper self, Player player, NPC npc)
        {
            ShoppingSettings settings = orig(self, player, npc);

            var bismuth = player.GetModPlayer<BismuthPlayer>();

            if (bismuth.skill132lvl > 0 && npc.type == NPCID.Demolitionist) settings.PriceAdjustment *= 0.6f;
            if (bismuth.skill83lvl > 0) settings.PriceAdjustment *= 0.65f;
            if (bismuth.Charm >= 40) settings.PriceAdjustment *= 0.60f;
            if (bismuth.Charm == 30) settings.PriceAdjustment *= 0.70f;
            if (bismuth.Charm == 20) settings.PriceAdjustment *= 0.80f;
            if (bismuth.Charm == 15) settings.PriceAdjustment *= 0.85f;
            if (bismuth.Charm == 10) settings.PriceAdjustment *= 0.80f;
            if (bismuth.Charm == 5) settings.PriceAdjustment *= 0.95f;
            if (bismuth.Charm == 0) settings.PriceAdjustment *= 1.00f;
            if (bismuth.Charm == -5) settings.PriceAdjustment *= 1.05f;
            if (bismuth.Charm == -10) settings.PriceAdjustment *= 1.10f;
            if (bismuth.Charm == -15) settings.PriceAdjustment *= 1.15f;
            if (bismuth.Charm == -20) settings.PriceAdjustment *= 1.20f;
            if (bismuth.Charm <= -30) settings.PriceAdjustment *= 1.30f;

            return settings;
        }
    }
}