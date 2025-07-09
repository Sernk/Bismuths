using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class DugWarriorsTombstone : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.addTile(Type);
            //ModTranslation name = CreateMapEntryName();
            TileObjectData.newTile.DrawYOffset = 2;
            //name.SetDefault("Warriors Tombstone");
            //name.AddTranslation(GameCulture.Russian, "Могила воина");
            AddMapEntry(new Color(193, 138, 104), CreateMapEntryName());
            DustType = 1;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 3 : 9;
        }      
    }
}