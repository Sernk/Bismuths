using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Utilities.Global
{
    public class Golem : GlobalNPC, ILocalizedModType
    {
        public string LocalizationCategory => "DeadGolems";

        public override void Load()
        {
            _ = this.GetLocalization("BismuthumText").Value;
        }

        public override void OnKill(NPC npc)
        {
            string BismuthumText = this.GetLocalization("BismuthumText").Value;

            if (npc.type == NPCID.Golem)
            {          
                if (!BismuthWorld.downedGolem)
                {
                    BismuthWorld.downedGolem = true;
                    if (Main.netMode == 2)
                    {
                        NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
                    }
                    if (Main.netMode == 0)
                    {
                        Main.NewText(BismuthumText, Color.LightGray);
                    }
                    else if (Main.netMode == 2)
                    {
                        ChatHelper.BroadcastChatMessage(NetworkText.FromKey(BismuthumText, new object[0]), Color.LightGray, -1);
                    }
                    for (int k = 0; k < 800; k++)                                                                                                                                  
                    {                                                                                                                                                                                                                   
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(600, Main.maxTilesY), (double)WorldGen.genRand.Next(5, 10), WorldGen.genRand.Next(5, 10), ModContent.TileType<Content.Tiles.BismuthumOre>(), false, 0f, 0f, false, true);
                    }                  
                }               
            }
        }
    }  
}
