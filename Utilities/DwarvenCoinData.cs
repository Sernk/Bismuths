using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Utilities
{
    public class DwarvenCoinData : CustomCurrencySingleCoin
    {
        public Color CustomCurrencytextcolor = Color.LightYellow; 

        public DwarvenCoinData(int coinItemID, long currencyCap) : base(coinItemID, currencyCap)
        {

        }

        public override void GetPriceText(string[] lines, ref int currentLine, long price)
        { 
            Color color = CustomCurrencytextcolor * ((float)Main.mouseTextColor / 255f);
            lines[currentLine++] = string.Format("[c/{0:X2}{1:X2}{2:X2}:{3} {4} {5}]", new object[]
            {
                    color.R,
                    color.G,
                    color.B,
                    Lang.tip[50],
                    price,
                    Language.GetTextValue(ModContent.GetInstance<LocalizationSystem>().DwarvenCoin)
            });
        }
    }
}