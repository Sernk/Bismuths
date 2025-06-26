using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Walls
{
    public class SwampWall : ModWall
    {
        public override void SetStaticDefaults()
        {
            DustType = DustID.Marble;
            AddMapEntry(new Color(150, 150, 150));
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }       
    }
}