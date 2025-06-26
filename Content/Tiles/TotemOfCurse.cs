using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Bismuth.Content.Items.Other;
using Bismuth.Content.Projectiles;
using Bismuth.Utilities;

namespace Bismuth.Content.Tiles
{
    public class TotemOfCurse : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSolidTop[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2xX);
            TileObjectData.newTile.Height = 5;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16, 16 };
            TileObjectData.addTile(Type);
            //ModTranslation name = CreateMapEntryName();
            //name.SetDefault("Totem Of Curse");
            AddMapEntry(new Color(233, 211, 123), CreateMapEntryName());
            TileObjectData.newTile.DrawYOffset = 2;
        }
        public override bool CanKillTile(int i, int j, ref bool blockDamaged) // jtrit
        {
            return false;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
        public override bool RightClick(int i, int j)
        {
            Player player = Main.player[Main.myPlayer];
            if (BismuthWorld.IsTotemActive)
            {
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (player.inventory[num66].type == ItemID.GoldCoin && player.inventory[num66].stack > 0)
                    {
                       
                        player.inventory[num66].stack--;
                        if (!BismuthWorld.FirstTotemDeactivation)
                        {
                            player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<FirstPartOfAmulet>());
                         //   BismuthWorld.FirstTotemDeactivation = true;
                        }
                        Projectile.NewProjectile(Main.LocalPlayer.GetSource_FromThis(), new Vector2(i * 16, j * 16), Vector2.Zero, ModContent.ProjectileType<WDFix1>(), 0, 0f);
                        SoundEngine.PlaySound(SoundID.CoinPickup, player.position);
                    }
                }
            }
            return true;
        }
        public override void MouseOver(int i, int j)
        {
            Player player = Main.player[Main.myPlayer];
            if (BismuthWorld.IsTotemActive)
            {
                player.cursorItemIconEnabled = true;
                player.cursorItemIconID = ItemID.GoldCoin;
            }
        }
      /*  public override void SpecialDraw(int i, int j, SpriteBatch spriteBatch)
        {
            Player player = Main.player[Main.myPlayer];
            if (player.GetModPlayer<BismuthPlayer>().IsTotemActive)
            {
                Vector2
                ulong seed = Main.TileFrameSeed ^ ((ulong)j << 32 | (ulong)i);
                Color color = new Color(100, 100, 100, 0);
                int frameX = (int)Main.tile[i, j].frameX;
                int frameY = (int)Main.tile[i, j].frameY;
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
                    Main.spriteBatch.Draw(ModContent.GetTexture("Bismuth/Tiles/FlameForTotem"), new Vector2((float)(i * 16 - (int)Main.screenPosition.X) - (float)(((double)width - 16.0) / 2.0) + num2 + 8, (float)(j * 16 - (int)Main.screenPosition.Y + num1) + num3 + 9) + vector2, new Rectangle?(new Rectangle(frameX * 2, frameY * 2, 23, 58)), color, 0.0f, new Vector2(), 0.4f, SpriteEffects.None, 0.0f);
                    Main.spriteBatch.Draw(ModContent.GetTexture("Bismuth/Tiles/FlameForTotem"), new Vector2((float)(i * 16 - (int)Main.screenPosition.X) - (float)(((double)width - 16.0) / 2.0) + num2 + 21, (float)(j * 16 - (int)Main.screenPosition.Y + num1) + num3 + 9) + vector2, new Rectangle?(new Rectangle(frameX * 2, frameY * 2, 23, 58)), color, 0.0f, new Vector2(), 0.4f, SpriteEffects.None, 0.0f);
                }
            }
        }*/
        public override void PostDraw(int i, int j, SpriteBatch spriteBatch) // Пусть тот, кто делал фикс PostDraw() в 0.11, горит блять в аду, мудак ебаный.
        {
            if (BismuthWorld.IsTotemActive)
            {
                int left = i;
                int right = i;
                int top = j;
                Tile tile = Main.tile[i, j];
                if (tile.TileFrameX != 0)
                {
                    left--;
                }
                if (tile.TileFrameX != 18)
                {
                    right++;
                }
                if (tile.TileFrameY != 18)
                {
                    top--;
                }
                ulong seed = Main.TileFrameSeed ^ ((ulong)j << 32); // | (ulong)i
                Color color = new Color(100, 100, 100, 0);

                Vector2 vector2 = new Vector2((float)Main.offScreenRange, (float)Main.offScreenRange);
                if (Main.drawToScreen)
                    vector2 = Vector2.Zero;
                if (i == left && j == top)
                {
                    for (int index = 0; index < 7; ++index)
                    {
                        float num2 = (float)Utils.RandomInt(ref seed, -12, 13) * 0.075f;
                        float num3 = (float)Utils.RandomInt(ref seed, -12, 13) * 0.075f;
                        spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/Tiles/FlameForTotem").Value, new Vector2((float)(i * 16 - (int)Main.screenPosition.X + 8 + num2), (float)(j * 16 - (int)Main.screenPosition.Y - 1) + num3) + vector2, new Rectangle?(new Rectangle(0, 0, 10, 10)), color, 0f, Vector2.Zero, 0.4f, SpriteEffects.None, 0f);
                    }
                }
                if (j == top)
                {
                    for (int index = 0; index < 7; ++index)
                    {
                        float num2 = (float)Utils.RandomInt(ref seed, -12, 13) * 0.075f;
                        float num3 = (float)Utils.RandomInt(ref seed, -12, 13) * 0.075f;
                        spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/Tiles/FlameForTotem").Value, new Vector2((float)(right * 16 - (int)Main.screenPosition.X + 4 + num2), (float)(top * 16 - (int)Main.screenPosition.Y - 1) + num3) + vector2, new Rectangle?(new Rectangle(0, 0, 10, 10)), color, 0f, Vector2.Zero, 0.4f, SpriteEffects.None, 0f);
                    }
                }
            }
        }
    }
}