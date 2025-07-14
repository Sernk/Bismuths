using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class WallCarpet : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.Height = 4;
            TileObjectData.newTile.Width = 6;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16 };
            Main.tileFrameImportant[Type] = true;
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(120, 85, 60), CreateMapEntryName());
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}