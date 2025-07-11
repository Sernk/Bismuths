using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Utilities.Global
{
    public class GlobalWalls : GlobalWall
    {
        public override void KillWall(int i, int j, int type, ref bool fail)
        {
            if (BismuthWorld.TownWalls.Contains(new Vector2(i, j)))
            {
                fail = true;                
                Main.tile[i, j].WallType = (ushort)type;
            }
        }
        public override bool Drop(int i, int j, int type, ref int dropType)
        {
            if (BismuthWorld.TownWalls.Contains(new Vector2(i, j)))
            {
                return false;
            }
            return base.Drop(i, j, type, ref dropType);
        }
        public override bool CanExplode(int i, int j, int type)
        {                  
            if (BismuthWorld.TownWalls.Contains(new Vector2(i, j)))
                return false;
            return true;
        }
    }
}