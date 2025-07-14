using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class BlastFurnace : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.addTile(Type);
            AnimationFrameHeight = 38;
            AddMapEntry(new Color(144, 148, 144), CreateMapEntryName());
            Main.tileLighted[Type] = true;
            TileObjectData.newTile.DrawYOffset = 2;
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.7f;
            g = 0.35f;
            b = 0f;
        }
        public override void AnimateTile(ref int frame, ref int frameCounter)
        {
            frameCounter++;
            if (frameCounter > 3)
            {
                frameCounter = 0;
                frame++;
                frame %= 12;
            }
        }     
    }
}