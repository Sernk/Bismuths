using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class AlchemicalShelf : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(97, 67, 47), CreateMapEntryName());
            TileObjectData.newTile.DrawYOffset = 2;
        }     
    }
}