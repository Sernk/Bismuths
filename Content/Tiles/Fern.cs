using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Enums;
using Bismuth.Content.Dusts;
using Terraria.Localization;
using System.Collections.Generic;
using Bismuth.Content.Items.Placeable;

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
            //ModTranslation name = CreateMapEntryName();
            //name.SetDefault("Fern");
            //name.AddTranslation(GameCulture.Russian, "Папоротник");
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