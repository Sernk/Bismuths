using System.Reflection;
using MonoMod.RuntimeDetour;          
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

            return settings;
        }
    }
}