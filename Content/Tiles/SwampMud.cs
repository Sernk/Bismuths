using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Tiles
{
    public class SwampMud : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            //this.SetModTree(new SwampTreeTile())/* tModPorter Note: Removed. Assign GrowsOnTileId to this tile type in ModTree.SetStaticDefaults instead */;
            Main.tileMerge[Type][ModContent.TileType<SwampMud>()] = true;
            Main.tileBlendAll[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(65, 89, 60));
           // HitSound = SoundID.Item;
        }
        public static bool PlaceObject(int x, int y, int type, bool mute = false, int style = 0, int alternate = 0, int random = -1, int direction = -1)
        {
            TileObject objectData;
            if (!TileObject.CanPlace(x, y, type, style, direction, out objectData, false))
                return false;
            objectData.random = random;
            if (TileObject.Place(objectData) && !mute)
                WorldGen.SquareTileFrame(x, y, true);
            return false;
        }
        public override void RandomUpdate(int i, int j)
        {
            if (Framing.GetTileSafely(i, j - 1).HasTile)
                return;
            switch (Main.rand.Next(5))
            {
                case 0:
                    PlaceObject(i, j - 1, ModContent.TileType<SwampGrass1>(), false, 0, 0, -1, -1);
                    NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<SwampGrass1>(), 0, 0, -1, -1);
                    break;
                case 1:
                    PlaceObject(i, j - 1, ModContent.TileType<SwampGrass2>(), false, 0, 0, -1, -1);
                    NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<SwampGrass2>(), 0, 0, -1, -1);
                    break;
                case 2:
                    PlaceObject(i, j - 1, ModContent.TileType<SwampGrass3>(), false, 0, 0, -1, -1);
                    NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<SwampGrass3>(), 0, 0, -1, -1);
                    break;
                case 3:
                    PlaceObject(i, j - 1, ModContent.TileType<SwampGrass4>(), false, 0, 0, -1, -1);
                    NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<SwampGrass4>(), 0, 0, -1, -1);
                    break;
                default:
                    PlaceObject(i, j - 1, ModContent.TileType<SwampGrass5>(), false, 0, 0, -1, -1);
                    NetMessage.SendObjectPlacement(-1, i, j - 1, ModContent.TileType<SwampGrass5>(), 0, 0, -1, -1);
                    break;
            }
        }
        //public override int SaplingGrowthType(ref int style)/* tModPorter Note: Removed. Use ModTree.SaplingGrowthType */
        //{
        //    style = 0;
        //    return ModContent.TileType<SwampTreeSaplingTile>();        
        //}

    }
}