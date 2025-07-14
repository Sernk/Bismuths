using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Tiles
{
    public class AluminiumOre : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileSpelunker[Type] = true;
            Main.tileBlockLight[Type] = true;
            AddMapEntry(new Color(214, 216, 218), CreateMapEntryName());
            DustType = 11;
            HitSound = SoundID.Tink;
        }       
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 3 : 9;
        }
        public override bool CanDrop(int i, int j)
        {
            return true;
        }
        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            yield return new Item(ModContent.ItemType<Items.Placeable.AluminiumOre>());
        }
    }
}
