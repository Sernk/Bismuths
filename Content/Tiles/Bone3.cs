using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class Bone3 : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(153, 153, 117), CreateMapEntryName());
            DustType = DustID.Stone;
            TileObjectData.newTile.DrawYOffset = 2;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 3 : 9;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(Main.LocalPlayer.GetSource_FromThis(), i * 16, j * 16, 16, 32, ItemID.Bone, Main.rand.Next(1, 5));
        }
    }
}