using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class RuneTable : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.CoordinateHeights = new int[]{16, 16, 16};
            TileObjectData.addTile(Type);
            AnimationFrameHeight = 54;
            AddMapEntry(new Color(79, 83, 117), CreateMapEntryName());
            TileObjectData.newTile.DrawYOffset = 2;

        }
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if (frameCounter > 3)
            {
                frameCounter = 0;
                frame++;
                frame %= 7;
            }
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.42f;
            g = 0.6f;
            b = 0.6f;
        }
    }
}