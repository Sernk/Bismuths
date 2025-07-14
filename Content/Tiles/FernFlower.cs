using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class FernFlower : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileCut[Type] = true; 
            Main.tileNoAttach[Type] = true;
            TileID.Sets.CanBeClearedDuringGeneration[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
            TileObjectData.newTile.AnchorAlternateTiles = new int[]
            {
                78, 380
            };
            TileObjectData.newTile.AnchorValidTiles = new int[]
            {

            };
            TileObjectData.addTile(Type);
        }
        public override void SetSpriteEffects(int i, int j, ref SpriteEffects spriteEffects)
        {
            if (i % 2 == 1)
            {
                spriteEffects = SpriteEffects.FlipHorizontally;
            }
        }
        public override bool RightClick(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            if (tile.TileFrameX == 36)
            {
                Player player = Main.LocalPlayer;
                Item.NewItem(new EntitySource_TileInteraction(player, i, j), i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Placeable.FernSpore>());
                Item.NewItem(new EntitySource_TileInteraction(player, i, j), i * 16, j * 16, 16, 16, ModContent.ItemType<Items.Materials.FernFlower>());

                tile.TileFrameX = 18;
                NetMessage.SendTileSquare(-1, i, j, 1);
                return true;
            }
            return false;
        }
        public override void MouseOver(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            Player player = Main.LocalPlayer;

            if (tile.TileFrameX == 36)
            {
                player.cursorItemIconID = ModContent.ItemType<Items.Materials.FernFlower>();
                player.cursorItemIconEnabled = true;
            }
        }
        public override bool CanDrop(int i, int j)
        {
            return true;
        }
        public override IEnumerable<Item> GetItemDrops(int i, int j)
        {
            Tile tile = Framing.GetTileSafely(i, j);
            if (tile.TileFrameX == 36)
            {
                yield return new Item(ModContent.ItemType<Items.Materials.FernFlower>());
                yield return new Item(ModContent.ItemType<Items.Placeable.FernSpore>());
            }
            else
            {
                yield return new Item(ModContent.ItemType<Items.Placeable.FernSpore>());
            }
        }
    }
}