﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class PapuansWorkbench : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            TileObjectData.addTile(Type);
            AdjTiles = new int[] { TileID.WorkBenches };
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTable);
            AddMapEntry(new Color(233, 211, 123), CreateMapEntryName());
            DustType = 79;
            TileObjectData.newTile.DrawYOffset = 2;
        }
    }
}