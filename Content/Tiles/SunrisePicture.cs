using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class SunrisePicture : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3Wall);
            TileObjectData.newTile.Width = 4;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            Main.tileFrameImportant[Type] = true;
            TileObjectData.addTile(Type);
            DustType = 7;
           // ModTranslation name = CreateMapEntryName();
            //name.SetDefault("Picture");
            //name.AddTranslation(GameCulture.Russian, "Картина");
            AddMapEntry(new Color(253, 151, 49), CreateMapEntryName());
        }
    }
}