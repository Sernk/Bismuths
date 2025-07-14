using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class PapuansLamp : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 36;
            TileObjectData.addTile(Type);
            DustType = 7;
            Main.tileLighted[Type] = true;
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            DustType = 79;
            AddMapEntry(new Color(233, 211, 123), CreateMapEntryName());
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.9f;
            g = 0.9f;
            b = 0.9f;
        }
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            ulong seed = Main.TileFrameSeed ^ ((ulong)j << 32);
            Color color = new Color(120, 120, 120, 0);
            int frameX = (int)Main.tile[i, j].TileFrameX;
            int frameY = (int)Main.tile[i, j].TileFrameY;
            int width = 20;
            int num1 = 0;
            int height = 20;
            if (WorldGen.SolidTile(i, j - 1))
            {
                num1 = 2;
                if (WorldGen.SolidTile(i - 1, j + 1) || WorldGen.SolidTile(i + 1, j + 1)) num1 = 4;   
            }
            Vector2 vector2 = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
            if (Main.drawToScreen) vector2 = Vector2.Zero;
            for (int index5 = 0; index5 < 3; ++index5)
            {
                float num12 = (float)Utils.RandomInt(ref seed, -10, 11) * 0.15f;
                float num13 = (float)Utils.RandomInt(ref seed, -10, 11) * 0.15f;
                Main.spriteBatch.Draw(TextureAssets.Flames[4].Value, new Vector2((float)(i * 16 - (int)Main.screenPosition.X) - (float)(((double)width - 16.0) / 2.0) + num12 + 1, (float)(j * 16 - (int)Main.screenPosition.Y + num1) + num13 - 1) + vector2, new Microsoft.Xna.Framework.Rectangle?(new Rectangle(frameX, frameY, width, height)), color, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            }
        }
    }
}