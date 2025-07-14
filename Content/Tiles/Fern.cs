using Bismuth.Content.Dusts;
using Bismuth.Content.Items.Placeable;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class Fern : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 18 };
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.AnchorValidTiles = new int[]
            {              
				ModContent.TileType<SwampMud>()
            };
            DustType = ModContent.DustType<SwampDust>();
            AddMapEntry(new Color(31, 43, 25), CreateMapEntryName());
            TileObjectData.addTile(Type);
            TileObjectData.newTile.DrawYOffset = 2;
        }
        public override bool CanDrop(int i, int j) 
        {
            return true;
        }
        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            if (Main.rand.Next(0, 2) == 0)
            {
                 yield return new Item(ModContent.ItemType<FernSpore>(),1,2);
            }
        }
    }
}