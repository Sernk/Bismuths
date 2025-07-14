using Bismuth.Content.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class SwampAmbientA2 : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            TileObjectData.addTile(Type);
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x1);
            Main.tileSolid[Type] = false;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = false;
            DustType = ModContent.DustType<SwampDust>();
            HitSound = SoundID.Grass;
            TileObjectData.newTile.CoordinateHeights = new int[] { 18 };
            TileObjectData.addTile(Type);          
        }
    }
}