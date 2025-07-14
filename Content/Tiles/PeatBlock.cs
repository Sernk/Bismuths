using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Tiles
{
    public class PeatBlock : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileBlockLight[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileSpelunker[Type] = true;
            AddMapEntry(new Color(74, 61, 36), CreateMapEntryName());
            DustType = 53;
            HitSound = SoundID.Tink;
        }
    }
}
