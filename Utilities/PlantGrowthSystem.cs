using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Bismuth.Utilities
{
    public class PlantGrowthSystem : ModSystem
    {
        private const int GroundGrowthTicks = 9000;  // 2,5 минуты = 150 сек * 60 тиков
        private const int PlanterGrowthTicks = 3600; // 1 минута = 60 сек * 60 тиков

        private double lastGroundGrowth = 0;
        private double lastPlanterGrowth = 0;

        public override void PostUpdateWorld()
        {
            const int ScanPeriod = 3600;                   
            if (Main.GameUpdateCount % ScanPeriod != 0) return;

            double now = Main.GameUpdateCount;

            if (Main.dayTime)
            {
                for (int i = 0; i < Main.maxTilesX; i++)
                {
                    for (int j = 0; j < Main.maxTilesY; j++)
                    {
                        Tile tile = Framing.GetTileSafely(i, j);

                        if (!tile.HasTile || tile.TileType != ModContent.TileType<Content.Tiles.FernFlower>()) continue;

                        Tile below = Framing.GetTileSafely(i, j + 1);

                        bool onPlanter = below.HasTile && below.TileType == TileID.PlanterBox;

                        if (onPlanter)
                        {
                            if (now - lastPlanterGrowth < PlanterGrowthTicks) continue;
                            lastPlanterGrowth = now;
                        }
                        else
                        {
                            if (now - lastGroundGrowth < GroundGrowthTicks) continue;        
                            lastGroundGrowth = now;
                        }

                        // ★ рост 
                        if (tile.TileFrameX == 0) tile.TileFrameX = 18;
                        else if (tile.TileFrameX == 18) tile.TileFrameX = 36;
                            
                        WorldGen.SquareTileFrame(i, j);
                        NetMessage.SendTileSquare(-1, i, j, 1);
                    }
                } 
            }
        }
    }
}