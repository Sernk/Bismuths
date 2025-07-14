using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class OrcishBed : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileID.Sets.HasOutlines[Type] = true;
            TileID.Sets.CanBeSleptIn[Type] = true; 
            TileID.Sets.InteractibleByNPCs[Type] = true; 
            TileID.Sets.IsValidSpawnPoint[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            AdjTiles = new int[] { TileID.Beds };
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style5x4); 
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 16, 16 };
            TileObjectData.addTile(Type);
            AddMapEntry(new Color(131, 86, 190), CreateMapEntryName());           
            AddToArray(ref TileID.Sets.RoomNeeds.CountsAsChair);
            TileObjectData.newTile.DrawYOffset = 2;
        }
        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[i, j];
            int spawnX = (i - (tile.TileFrameX / 18)) + (tile.TileFrameX >= 72 ? 5 : 2);
            int spawnY = j + 2;

            if (tile.TileFrameY % 38 != 0)
            {
                spawnY--;
            }
            player.FindSpawn();

            if (player.SpawnX == spawnX && player.SpawnY == spawnY)
            {
                player.RemoveSpawn();
                Main.NewText(Language.GetTextValue("Game.SpawnPointRemoved"), byte.MaxValue, 240, 20);
            }
            else if (Player.CheckSpawn(spawnX, spawnY))
            {
                player.ChangeSpawn(spawnX, spawnY);
                Main.NewText(Language.GetTextValue("Game.SpawnPointSet"), byte.MaxValue, 240, 20);
            }
            return true;
        }
        public override void MouseOver(int i, int j)
        {
            Player player = Main.player[Main.myPlayer];
            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ModContent.ItemType<Items.Placeable.OrcishBed>();
        }
    }
}