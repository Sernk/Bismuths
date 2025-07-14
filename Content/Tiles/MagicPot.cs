using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class MagicPot : ModTile
    {
        public override void SetStaticDefaults()
        {

            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.addTile(Type);
            AnimationFrameHeight = 36;
            AddMapEntry(new Color(59, 58, 66), CreateMapEntryName());
            TileObjectData.newTile.DrawYOffset = 2;
        }      
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if (frameCounter > 3)
            {
                frameCounter = 0;
                frame++;
                frame %= 14;
            }
        }
    }
}