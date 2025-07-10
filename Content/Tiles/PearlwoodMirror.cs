using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class PearlwoodMirror : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.Width = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            Main.tileFrameImportant[Type] = true;
            TileObjectData.addTile(Type);
            DustType = 7;
            AddMapEntry(new Color(120, 85, 60), CreateMapEntryName());
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}