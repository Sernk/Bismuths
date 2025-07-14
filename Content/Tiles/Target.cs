using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class Target : ModTile
    {
        public override void SetStaticDefaults()
        {

            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Height = 3;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(191, 142, 111), CreateMapEntryName());
            TileObjectData.newTile.DrawYOffset = 2;
        }              
    }
}