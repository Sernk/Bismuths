using System;
using Terraria.ModLoader;
using Bismuth.Content.Tiles;

namespace Bismuth.Utilities
{
    public class BiomeTileCounterSystem : ModSystem
    {
        public static int ZoneSwampBiom = 0;
        public static int ZoneTotem;

        public override void ResetNearbyTileEffects()
        {
            ZoneSwampBiom = 0;
            ZoneTotem = 0;
        }

        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            ZoneSwampBiom = tileCounts[ModContent.TileType<SwampMud>()];
            ZoneTotem = tileCounts[ModContent.TileType<TotemOfCurse>()];
        }
    }
}