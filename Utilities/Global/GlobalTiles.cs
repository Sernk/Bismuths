using Bismuth.Content.Items.Other;
using Bismuth.Content.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Utilities.Global
{
    public class GlobalTiles : GlobalTile
    {
        public override bool CanKillTile(int i, int j, int type, ref bool blockDamaged)
        {
            Tile chest = Main.tile[i, j - 1];
            if ((i == BismuthWorld.TotemX - 1 && j == BismuthWorld.TotemY + 3) || (i == BismuthWorld.TotemX && j == BismuthWorld.TotemY + 3)) return false;      
            if (BismuthWorld.TownTiles.Contains(new Vector2(i, j)) && !Main.LocalPlayer.HasItem(ModContent.ItemType<MasterToolBox>())) return false;
            if (BismuthWorld.DoorsLeft.Contains(new Vector2(i, j)) && Main.tile[i, j].TileType == TileID.OpenDoor && !Main.LocalPlayer.HasItem(ModContent.ItemType<MasterToolBox>())) return false;
            if (BismuthWorld.DoorsRight.Contains(new Vector2(i, j)) && Main.tile[i, j].TileType == TileID.OpenDoor && !Main.LocalPlayer.HasItem(ModContent.ItemType<MasterToolBox>())) return false;  
            if ((chest.TileFrameX == 72 || chest.TileFrameX == 90) && chest.TileType == (ushort)ModContent.TileType<OrcishChest>() && !Chest.CanDestroyChest(i, j - 1)) return false;
            if (Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 0 && Main.tile[i, j - 1].TileType == (ushort)ModContent.TileType<WarriorsTombstone>()) return false;
            if (Main.tile[i, j - 1].TileType == (ushort)ModContent.TileType<AltarOfWaters>()) return false;
            if (Main.LocalPlayer.GetModPlayer<Quests>().ReportQuest <= 20 && (Main.tile[i, j].TileType == (ushort)ModContent.TileType<DeadCourier>() || Main.tile[i, j - 1].TileType == (ushort)ModContent.TileType<DeadCourier>())) return false;
            return CanKillTile(i, j, type, ref blockDamaged);
        }
        public override bool Slope(int i, int j, int type)
        {
            if (BismuthWorld.TownTiles.Contains(new Vector2(i, j)) && !Main.LocalPlayer.HasItem(ModContent.ItemType<MasterToolBox>())) return false;  
            return true;
        }
        public override bool CanPlace(int i, int j, int type)
        {
            if (BismuthWorld.MazeStartX != 0 && BismuthWorld.MazeStartY != 0)
            {
                if (i >= BismuthWorld.MazeStartX && i <= BismuthWorld.MazeStartX + 58 && j >= BismuthWorld.MazeStartY && j <= BismuthWorld.MazeStartY + 57 && BismuthWorld.DestroyedMaze && !Main.LocalPlayer.HasItem(ModContent.ItemType<MasterToolBox>())) return false;   
            }
            return true;
        }
        public override bool CanExplode(int i, int j, int type)
        {
            if ((i == BismuthWorld.TotemX - 1 && j == BismuthWorld.TotemY + 3) || (i == BismuthWorld.TotemX && j == BismuthWorld.TotemY + 3)) return false;           
            if (BismuthWorld.TownTiles.Contains(new Vector2(i, j)) && !Main.LocalPlayer.HasItem(ModContent.ItemType<MasterToolBox>())) return false;   
            return true;
        }
    }
}