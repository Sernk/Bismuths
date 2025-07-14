using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Tiles
{
    public class Cinnabar : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileBlockLight[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileMergeDirt[Type] = true;
            Main.tileLighted[Type] = true;
            Main.tileSpelunker[Type] = true;
            AddMapEntry(new Color(113, 0, 17), CreateMapEntryName());
            DustType = 11;
            HitSound = SoundID.Tink;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        public override bool CanDrop(int i, int j) 
        {
            return true;
        }
        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            yield return new Item(ModContent.ItemType<Items.Materials.Cinnabar>());
        }
    }
}
