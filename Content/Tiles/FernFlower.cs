using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Terraria.Enums;
using System.Collections.Generic;
using Terraria.DataStructures;

namespace Bismuth.Content.Tiles
{
    public class FernFlower : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileCut[Type] = true;
          
            Main.tileNoFail[Type] = true;
       
            TileObjectData.newTile.CopyFrom(TileObjectData.StyleAlch);
            TileObjectData.newTile.AnchorValidTiles = new int[]
            {
               
            };
            TileObjectData.newTile.AnchorAlternateTiles = new int[]
            {
                78, 
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
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            int stage = Main.tile[i, j].TileFrameX / 18;
            if (stage == 2)
            {
                new Item(ModContent.ItemType<Items.Materials.FernFlower>(), i * 16, j * 16);
                new Item(ModContent.ItemType<Items.Placeable.FernSpore>(), i * 16, j * 16);
            }
        }
        public override void RandomUpdate(int i, int j)
        {
            if (Main.tile[i, j].TileFrameX == 0)
            {
                Main.tile[i, j].TileFrameX += 18;
            }
            else if (Main.tile[i, j].TileFrameX == 18)
            {
                Main.tile[i, j].TileFrameX += 18;
            }
        }      
    }
}