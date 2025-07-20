using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Utilities
{
    public class TribeTotemBiome : ModBiome
    {
        public override bool IsBiomeActive(Player player)
        {
            bool Totem = BiomeTileCounterSystem.ZoneTotem >= 1;
            BismuthWorld.IsTotemActive = Totem;
            return Totem;
        }
    }
}