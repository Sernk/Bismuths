using Bismuth.Content.Buffs;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.BismuthLayerInPlayer
{
    public class EnergyShieldLayer : PlayerDrawLayer
    {
        public override Position GetDefaultPosition() => new AfterParent(PlayerDrawLayers.IceBarrier);
        public override bool GetDefaultVisibility(PlayerDrawSet drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModContent.GetInstance<Bismuth>();
            BismuthPlayer modPlayer = drawPlayer.GetModPlayer<BismuthPlayer>();
            return drawPlayer.FindBuffIndex(ModContent.BuffType<EnergyShield>()) != -1;
        }

        protected override void Draw(ref PlayerDrawSet drawInfo)
        {
            Player drawPlayer = drawInfo.drawPlayer;
            Mod mod = ModContent.GetInstance<Bismuth>();
            BismuthPlayer modPlayer = drawPlayer.GetModPlayer<BismuthPlayer>();
            if (drawPlayer.FindBuffIndex(ModContent.BuffType<EnergyShield>()) != -1)
            {
                Texture2D texture = ModContent.Request<Texture2D>("Bismuth/Glow/EnergyShield").Value;
                Texture2D bolvanka = ModContent.Request<Texture2D>("Bismuth/Content/Projectiles/EnergyShield").Value;
                int visualFrame2 = modPlayer.EnergyShieldFrame;
                int height = texture.Height / 5;
                int num1 = (int)((double)drawInfo.Position.X + (double)drawPlayer.width / 2.0 - (double)Main.screenPosition.X);
                int num2 = (int)((double)drawInfo.Position.Y + 292 - (double)Main.screenPosition.Y);
                DrawData drawData = new DrawData(texture, new Vector2((float)num1, (float)num2), new Rectangle?(new Rectangle(0, height * visualFrame2, texture.Width, height)), new Color(255, 255, 255, modPlayer.EnergyShieldAlpha), 0.0f, new Vector2((float)texture.Width / 2f, (float)texture.Height), 1f, SpriteEffects.None, 0);
                drawInfo.DrawDataCache.Add(drawData);
            }
            if (drawPlayer.dead)
            {
                return;
            }  
        }
    }
}
