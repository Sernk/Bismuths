using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class PapuansLantern : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            Main.tileLighted[Type] = true;
            //ModTranslation name = CreateMapEntryName();
            //name.SetDefault("Lantern");
            //name.AddTranslation(GameCulture.Russian, "Фонарь");
            DustType = 79;
            AddMapEntry(new Color(233, 211, 123), CreateMapEntryName());
            TileObjectData.newTile.DrawYOffset = 2;
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.9f;
            g = 0.9f;
            b = 0.9f;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            ulong seed = Main.TileFrameSeed ^ ((ulong)j << 32);//| (ulong)i
            Color color = new Color(100, 100, 100, 0);
            int left = i;
            int top = j;
            Tile tile = Main.tile[i, j];
            if (tile.TileFrameX != 0)
            {
                left--;
            }
            if (tile.TileFrameY != 18)
            {
                top--;
            }
            Vector2 vector2 = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
            if (Main.drawToScreen)
                vector2 = Vector2.Zero;
            if (i == left && j == top)
            {
                for (int index = 0; index < 7; ++index)
                {
                    float num2 = (float)Utils.RandomInt(ref seed, -12, 13) * 0.075f;
                    float num3 = (float)Utils.RandomInt(ref seed, -12, 13) * 0.075f;
                    spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/Tiles/Flame_1").Value, new Vector2((float)(i * 16 - (int)Main.screenPosition.X) + num2 + 4, (float)(j * 16 - (int)Main.screenPosition.Y + num3) + 1) + vector2, new Rectangle?(new Rectangle(0, 0, 8, 10)), color, 0.0f, new Vector2(), 0.9f, SpriteEffects.None, 0.0f);
                }
            }
        }
    }
}