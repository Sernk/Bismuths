using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class OrnamentalPlant : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;            
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
            //ModTranslation name = CreateMapEntryName();
            //name.SetDefault("Ornamental Plant");
            //name.AddTranslation(GameCulture.Russian, "Декоративное растение");
            DustType = 7;
            AddMapEntry(new Color(45, 81, 55), CreateMapEntryName());
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileObjectData.addTile(Type);
            TileObjectData.newTile.DrawYOffset = 2;
        }      
    }
}