using Bismuth.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class SwampGrass5 : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.addTile(Type);
            Main.tileCut[Type] = true;
            Main.tileNoFail[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            Main.tileSolid[Type] = false;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = false;
            DustType = ModContent.DustType<SwampDust>();
            MineResist = 1f;
            TileObjectData.newTile.CoordinateHeights = new int[] { 18 };
            TileObjectData.addTile(Type);
            HitSound = SoundID.Grass;
        }
    }
}