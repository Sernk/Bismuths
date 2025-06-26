using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Bismuth.Content.Dusts;
using Terraria.ID;

namespace Bismuth.Content.Tiles
{
    public class SwampAmbientB3 : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.addTile(Type);
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            Main.tileSolid[Type] = false;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = false;       
            TileObjectData.newTile.CoordinateHeights = new int[]
            {
        18
            };
            DustType = ModContent.DustType<SwampDust>();
            HitSound = SoundID.Dig;
            TileObjectData.addTile(Type);
        }
    }
}
