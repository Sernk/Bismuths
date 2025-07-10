using Bismuth.Content.Items.Other;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class GreenDoorLocked : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileBlockLight[Type] = true;
            Main.tileSolid[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.Width = 1;
            TileObjectData.newTile.Height = 3;
            TileObjectData.newTile.Origin = new Point16(0, 0);
            TileObjectData.newTile.AnchorTop = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile, TileObjectData.newTile.Width, 0);
            TileObjectData.newTile.UsesCustomCanPlace = true;
            TileObjectData.newTile.LavaDeath = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Origin = new Point16(0, 1);
            TileObjectData.addAlternate(0);
            TileObjectData.newAlternate.CopyFrom(TileObjectData.newTile);
            TileObjectData.newAlternate.Origin = new Point16(0, 2);
            TileObjectData.addAlternate(0);
            TileObjectData.addTile(Type);
            AddMapEntry(Color.Green, CreateMapEntryName());
            TileID.Sets.DisableSmartCursor[Type] = true;
            DustType = 46;                  
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = 1;
        }
        public override bool CanKillTile(int i, int j, ref bool blockDamaged)
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
            for (int num66 = 0; num66 < 58; num66++)
            {
                if (player.inventory[num66].type == ModContent.ItemType<GreenKey>() && player.inventory[num66].stack > 0)
                {

                    for (int l = 0; l < 5; l++)
                    {
                        if (Main.tile[i, j + l].TileType == ModContent.TileType<MazeBrick>())
                        {
                            WorldGen.KillTile(i, j);
                            WorldGen.PlaceTile(i, j + l - 1, (ushort)ModContent.TileType<MazeDoorClosed>());
                            TileID.Sets.OpenDoorID[Type] = ModContent.TileType<MazeDoorClosed>();
                            break;
                        }
                    }
                    SoundEngine.PlaySound(SoundID.Unlock, new Vector2(i, j));
                    break;
                }
            }
            return false;
        }
        public override void MouseOver(int i, int j)
        {
            Player player = Main.player[Main.myPlayer];
            player.cursorItemIconID = ModContent.ItemType<GreenKey>();
            player.cursorItemIconEnabled = true;
        }
    }
}