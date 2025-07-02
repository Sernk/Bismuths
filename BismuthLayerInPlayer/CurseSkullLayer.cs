using Bismuth.Utilities;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Bismuth.BismuthLayerInPlayer
{
    public class CurseSkullLayer: PlayerDrawLayer
    {
        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.IceBarrier);
        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModContent.GetInstance<Bismuth>();
            BismuthPlayer modPlayer = drawPlayer.GetModPlayer<BismuthPlayer>();
            return modPlayer.TribeCurse;
        }
        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModContent.GetInstance<Bismuth>();
            BismuthPlayer modPlayer = drawPlayer.GetModPlayer<BismuthPlayer>();
            if (modPlayer.TribeCurse)
            {
                Texture2D texture = ModContent.Request<Texture2D>("Bismuth/Glow/CurseSkull").Value;
                int frame = modPlayer.TribeCurseFrame;
                int height = texture.Height / 10;
                Vector2 pos = new Vector2(drawInfo.Position.X + drawPlayer.width / 2f - Main.screenPosition.X, drawInfo.Position.Y + 350 - 4f - Main.screenPosition.Y);
                DrawData drawData = new DrawData(texture, pos, new Rectangle(0, height * frame, texture.Width, height), new Color(255, 255, 255, 185), 0f, new Vector2(texture.Width / 2f, texture.Height), 1f, drawPlayer.direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
                drawInfo.DrawDataCache.Add(drawData);
            }
            if (modPlayer.TribeCurse)
            {
                Texture2D texture = ModContent.Request<Texture2D>("Bismuth/Glow/CurseSkull").Value;

                int visualFrame2 = modPlayer.TribeCurseFrame;
                int height = texture.Height / 10;
                int num1 = (int)((double)drawInfo.Position.X + (double)drawPlayer.width / 2.0 - (double)Main.screenPosition.X);
                int num2 = (int)((double)drawInfo.Position.Y + 350 - 4.0 - (double)Main.screenPosition.Y);
                DrawData drawData = new DrawData(texture, new Vector2((float)num1, (float)num2), new Rectangle?(new Rectangle(0, height * visualFrame2, texture.Width, height)), new Color(255, 255, 255, 185), 0.0f, new Vector2((float)texture.Width / 2f, (float)texture.Height), 1f, Main.player[Main.myPlayer].direction == 1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0);
                drawInfo.DrawDataCache.Add(drawData);
            }
            if (drawPlayer.dead)
            {
                return;
            }
        }
    }
}