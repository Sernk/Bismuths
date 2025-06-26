using Bismuth.Content.Dusts;
using Terraria.ModLoader;

namespace Bismuth.Waters
{
    public class SwampWaterStyle : ModWaterStyle
    {

        public override int ChooseWaterfallStyle()
        {
            return ModContent.GetInstance<SwampWaterfallStyle>().Slot;
        }

        public override int GetSplashDust()
        {
            return ModContent.DustType<SwampWaterSplash>();
        }

        public override int GetDropletGore()
        {
            return ModContent.GoreType<Gores.SwampWaterDroplet>();
        }
        public override void LightColorMultiplier(ref float r, ref float g, ref float b)
        {
            r = 1f;
            g = 1f;
            b = 1f;
        }
    }
}
