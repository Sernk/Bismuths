using Bismuth.Content.Buffs;
using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace Bismuth.BismuthLayerInPlayer
{
    public class BansheesScreamLayer : PlayerDrawLayer
    {
        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.IceBarrier);
        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModContent.GetInstance<Bismuth>();
            BismuthPlayer modPlayer = drawPlayer.GetModPlayer<BismuthPlayer>();
            return drawPlayer.FindBuffIndex(ModContent.BuffType<BansheesScream>()) != -1;
        }
        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModContent.GetInstance<Bismuth>();
            BismuthPlayer modPlayer = drawPlayer.GetModPlayer<BismuthPlayer>();
            if (drawPlayer.FindBuffIndex(ModContent.BuffType<BansheesScream>()) != -1)
            {
                if (BismuthPlayer.alphabanshee == 230)
                {
                    BismuthPlayer.growbanshee = -1;
                }
                else if (BismuthPlayer.alphabanshee == 180)
                {
                    BismuthPlayer.growbanshee = 1;
                }
                BismuthPlayer.alphabanshee += 2 * BismuthPlayer.growbanshee;
            }
            if (BismuthPlayer.alphabanshee != 0)
            {
                Color color = new Color(0, 0, 0, BismuthPlayer.alphabanshee);
                DrawData rect1 = new DrawData(TextureAssets.MagicPixel.Value, Vector2.Zero + new Vector2(-300, -300), new Rectangle(0, 0, Main.screenWidth + 600, Main.screenHeight + 600), color);
                drawInfo.DrawDataCache.Add(rect1);
            }
            if (drawPlayer.dead)
            {
                return;
            }
        }
    }
}
