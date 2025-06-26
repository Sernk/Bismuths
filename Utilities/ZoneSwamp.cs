using Bismuth.Backgrounds;
using Bismuth.Waters;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Utilities
{
    public class ZoneSwamp : ModBiome
    {
        public override bool IsBiomeActive(Player player)
        {
            bool inSwamp = BiomeTileCounterSystem.ZoneSwampBiom > 150;
            BismuthPlayer.ZoneSwamp = inSwamp;
            return inSwamp;
        }
        public override SceneEffectPriority Priority => SceneEffectPriority.BiomeMedium;
        public override int Music => MusicID.UndergroundCrimson;
        public override ModSurfaceBackgroundStyle SurfaceBackgroundStyle => ModContent.GetInstance<ZoneSwampBgStyle>();
        public override ModWaterStyle WaterStyle => ModContent.GetInstance<SwampWaterStyle>();
    }
}
