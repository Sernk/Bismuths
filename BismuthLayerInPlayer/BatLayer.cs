using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;
using static Terraria.ModLoader.PlayerDrawLayer;

namespace Bismuth.BismuthLayerInPlayer
{
    public class BatLayer : Transformation
    {
        protected override void PreDraw(ref PlayerDrawSet drawInfo)
        {
            List<PlayerDrawLayer> Layer = new List<PlayerDrawLayer>();
            drawInfo.drawPlayer.invis = true;
            ModifyDrawLayers(Layer);
        }

        void ModifyDrawLayers(List<PlayerDrawLayer> layers)
        {
            layers.RemoveAll(layer =>layer.Name.Contains("Head") ||   layer.Name.Contains("Body") || layer.Name.Contains("Legs") ||layer.Name.Contains("HandsOn") || layer.Name.Contains("HandsOff") || layer.Name.Contains("Back") || layer.Name.Contains("Front") ||layer.Name.Contains("Shoes") || layer.Name.Contains("Waist") || layer.Name.Contains("Wings") || layer.Name.Contains("Shield") || layer.Name.Contains("Balloon") || layer.Name.Contains("Neck") || layer.Name.Contains("Face") || layer.Name.Contains("Beard"));
        }

        protected override void PostDraw(ref PlayerDrawSet drawInfo)
        {
            Player player = drawInfo.drawPlayer;
            Texture2D texture = ModContent.Request<Texture2D>("Bismuth/Content/Mounts/VampireBatMount_Back2").Value;

            Vector2 position = player.MountedCenter - Main.screenPosition;

            float scale = 32f / texture.Width;

            Main.EntitySpriteDraw(texture, position, null, Color.White, player.fullRotation, texture.Size() * 0.5f, scale, SpriteEffects.None, 0);
        }
    }
}
