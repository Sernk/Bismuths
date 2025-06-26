using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class Fountain : ModTile
    {
        public override void SetStaticDefaults()
        {

            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = false;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.Height = 6;
            TileObjectData.newTile.Width = 6;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16, 18 };
            TileObjectData.addTile(Type);
            AnimationFrameHeight = 108;
            //ModTranslation name = CreateMapEntryName();
            //name.SetDefault("Fountain");
            AddMapEntry(new Color(204, 204, 191), CreateMapEntryName());
            TileObjectData.newTile.DrawYOffset = 2;

        }
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if (frameCounter > 3)
            {
                frameCounter = 0;
                frame++;
                frame %= 5;
            }
        }       
    }
}