using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class BorealTableNoSettle : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.addTile(Type);
            //ModTranslation name = CreateMapEntryName();
            //name.SetDefault("Table");
            AddMapEntry(new Color(191, 142, 111), CreateMapEntryName());
            //name.AddTranslation(GameCulture.Russian, "Стол");
            DustType = 214;
            TileObjectData.newTile.DrawYOffset = 2;
        }    
    }
}