using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class BookOfSecrets : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(255, 153, 51), CreateMapEntryName());
        }
        public override bool CanDrop(int i, int j) 
        {
            return true;
        }
        public override bool RightClick(int i, int j)
        {
            Player player = Main.player[Main.myPlayer];
            WorldGen.KillTile(i, j, false, false, false);
            return true;
        }
        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            player.cursorItemIconID = ModContent.ItemType<Items.Other.BookOfSecrets>();
            player.cursorItemIconEnabled = true;
        }
        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            yield return new Item(ModContent.ItemType<Items.Other.BookOfSecrets>());
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
    }
}