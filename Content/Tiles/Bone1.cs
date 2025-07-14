using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class Bone1 : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
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

        public override bool CanDrop(int i, int j) 
        {
            return true;
        }
        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            yield return new Item(ItemID.Bone);
        }
    }
}