using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Tiles
{
    public class BismuthumOre : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;           
            Main.tileLighted[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileBlockLight[Type] = true;
            MinPick = 200;
            //name.SetDefault("Bismuthum");
            //name.AddTranslation(GameCulture.Russian, "Висмут");
            AddMapEntry(new Color(13, 88, 130), CreateMapEntryName());
            DustType = 11;
            HitSound = SoundID.Tink;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }      
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 3 : 9;
        }
    }
}
