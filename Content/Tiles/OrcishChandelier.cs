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
    public class OrcishChandelier : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style1x2Top);
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.StyleWrapLimit = 111;
            TileObjectData.addTile(Type);
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsTorch);
            Main.tileLighted[Type] = true;
            //ModTranslation name = CreateMapEntryName();
            //name.SetDefault("Chandelier");
            //name.AddTranslation(GameCulture.Russian, "Люстра");
            DustType = 118;
            AddMapEntry(new Color(131, 86, 190), CreateMapEntryName());
        }

        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0.72f;
            g = 0.6f;
            b = 0.9f;
        }

        public override void PostDraw(int i, int j, SpriteBatch spriteBatch)
        {
            ulong seed = Main.TileFrameSeed ^ ((ulong)j << 32);
            Color color = new Color(103, 75, 197, 0);
            int frameX = (int)Main.tile[i, j].TileFrameX;
            int frameY = (int)Main.tile[i, j].TileFrameY + 54 * 19;
            int width = 20;
            int num1 = 0;
            int height = 20;
            if (WorldGen.SolidTile(i, j - 1))
            {
                num1 = 2;
                if (WorldGen.SolidTile(i - 1, j + 1) || WorldGen.SolidTile(i + 1, j + 1))
                    num1 = 4;
            }
            Vector2 vector2 = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
            if (Main.drawToScreen)
                vector2 = Vector2.Zero;
            for (int index = 0; index < 7; ++index)
            {
                float num2 = (float)Utils.RandomInt(ref seed, -12, 13) * 0.075f;
                float num3 = (float)Utils.RandomInt(ref seed, -12, 13) * 0.075f;
                Main.spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/Tiles/Flame3ForOrcish").Value, new Vector2((float)(i * 16 - (int)Main.screenPosition.X) - (float)(((double)width - 16.0) / 2.0) + num2 + 2, (float)(j * 16 - (int)Main.screenPosition.Y + num1) + num3) + vector2, new Rectangle?(new Rectangle(frameX, frameY, width, height)), color, 0.0f, new Vector2(), 1f, SpriteEffects.None, 0.0f);
            }
        }
    }
}