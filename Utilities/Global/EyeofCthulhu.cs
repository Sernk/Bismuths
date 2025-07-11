using Bismuth.Content.Items.Accessories;
using Bismuth.Content.Items.Materials;
using Bismuth.Content.Items.Other;
using Bismuth.Content.Items.Tools;
using Bismuth.Content.Items.Weapons.Ranged;
using Bismuth.Content.NPCs;
using Bismuth.Content.Tiles;
using Bismuth.Content.Walls;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Utilities.Global
{
    public class EyeofCthulhu : GlobalNPC, ILocalizedModType
    {
        public string LocalizationCategory => "DeadEoC";

        public override void Load()
        {
            _ = this.GetLocalization("MazeText").Value;
        }

        public override void OnKill(NPC npc)
        {
            string MazeText = this.GetLocalization("MazeText").Value;
            if (npc.type == 4)
            {
                if (!BismuthWorld.downedEoC)
                {
                    BismuthWorld.downedEoC = true;
                    if (Main.netMode == 2)
                    {
                        NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
                    }
                    if (Main.netMode == 0)
                    {
                        Main.NewText(MazeText, Color.LightGray);
                    }
                    else if (Main.netMode == 2)
                    {
                        ChatHelper.BroadcastChatMessage(NetworkText.FromKey(MazeText, new object[0]), Color.LightGray, -1);
                    }
                    BismuthWorld.MazeStartX = WorldGen.genRand.Next(Main.spawnTileX - 150, Main.spawnTileX + 100);
                    BismuthWorld.MazeStartY = Main.maxTilesY / 2;
                    if (Main.netMode == 2)
                    {
                        NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
                    }
                    int[,] Maze = new int[,]
                     { { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2  },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 1, 1, 1, 1, 1, 1, 1, 0, 3, 1, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 3, 1, 3, 0, 1, 1, 1, 1, 1, 1, 3, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 1, 0, 3, 0, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 1, 3, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 3, 1, 1, 0, 0, 1, 0, 3, 0, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 1, 3, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 3, 1, 1, 1, 1, 1, 1, 1, 2, },
                       { 2, 0, 3, 1, 0, 0, 0, 1, 0, 3, 1, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 0, 1, 3, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 3, 1, 0, 0, 0, 1, 0, 3, 1, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 3, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 3, 1, 0, 0, 0, 1, 0, 3, 1, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 3, 0, 1, 0, 0, 1, 0, 3, 1, 1, 1, 1, 1, 1, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 3, 1, 1, 1, 1, 1, 0, 3, 1, 1, 1, 1, 0, 3, 1, 3, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 3, 0, 1, 1, 1, 1, 0, 3, 1, 0, 0, 1, 0, 0, 1, 0, 3, 1, 1, 1, 1, 1, 1, 1, 2, },
                       { 2, 0, 3, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 3, 1, 3, 0, 1, 0, 3, 1, 0, 0, 1, 1, 1, 3, 0, 1, 3, 0, 1, 3, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 1, 0, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 3, 1, 3, 0, 0, 0, 3, 1, 0, 0, 0, 0, 1, 3, 0, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 3, 0, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 3, 0, 1, 3, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 1, 0, 0, 1, 0, 3, 1, 0, 3, 1, 1, 0, 0, 2, },
                       { 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 0, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 0, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 3, 1, 0, 3, 1, 1, 1, 1, 2, },
                       { 2, 0, 3, 1, 1, 1, 1, 1, 1, 3, 0, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 0, 0, 3, 0, 0, 0, 0, 2, },
                       { 2, 0, 3, 1, 0, 0, 0, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 3, 1, 0, 0, 0, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 3, 1, 0, 0, 0, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 1, 0, 3, 1, 0, 0, 0, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, },
                       { 2, 0, 3, 1, 1, 1, 0, 0, 1, 0, 3, 1, 1, 1, 1, 1, 1, 1, 3, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 0, 1, 0, 3, 1, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 3, 0, 0, 0, 0, 0, 1, 3, 3, 1, 3, 0, 1, 0, 0, 0, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 1, 0, 3, 1, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 0, 0, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 0, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 0, 0, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 0, 0, 3, 1, 0, 3, 1, 3, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, },
                       { 2, 1, 1, 1, 1, 1, 1, 1, 1, 0, 3, 1, 0, 3, 1, 0, 3, 1, 0, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 3, 1, 0, 0, 0, 3, 1, 0, 3, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 3, 1, 0, 3, 1, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 3, 1, 0, 3, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 0, 3, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 3, 1, 0, 3, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 0, 3, 1, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 0, 0, 0, 3, 1, 0, 3, 1, 3, 0, 1, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 3, 1, 0, 3, 1, 0, 3, 1, 1, 1, 1, 1, 1, 1, 1, 3, 0, 1, 1, 1, 1, 0, 3, 1, 1, 1, 0, 3, 1, 0, 3, 1, 3, 0, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 1, 3, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 3, 0, 1, 0, 0, 1, 0, 0, 1, 0, 3, 1, 1, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 1, 3, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 3, 0, 1, 1, 1, 1, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 1, 3, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 1, 1, 1, 3, 0, 0, 1, 0, 0, 3, 1, 1, 1, 1, 0, 3, 1, 0, 3, 1, 0, 0, 1, 1, 1, 1, 1, 3, 0, 1, 0, 0, 1, 1, 1, 1, 1, 1, 0, 3, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 1, 3, 0, 0, 1, 0, 0, 3, 1, 0, 0, 0, 0, 3, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 1, 3, 0, 0, 1, 0, 0, 3, 1, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 1, 3, 0, 0, 1, 0, 0, 3, 1, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 1, 3, 0, 0, 1, 0, 0, 3, 1, 0, 0, 1, 1, 1, 1, 0, 3, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 0, 1, 0, 3, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 0, 3, 0, 0, 1, 0, 0, 3, 1, 0, 0, 1, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 0, 3, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 3, 0, 1, 0, 0, 3, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 0, 3, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 3, 0, 1, 0, 0, 3, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 0, 3, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 1, 0, 3, 0, 1, 0, 0, 3, 1, 1, 1, 1, 0, 0, 1, 1, 1, 1, 3, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 0, 1, 3, 0, 0, 0, 3, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 1, 0, 3, 0, 1, 0, 0, 3, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 0, 0, 0, 0, 0, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 1, 0, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 0, 0, 0, 0, 0, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 1, 0, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 3, 0, 1, 1, 1, 1, 1, 1, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 1, 1, 1, 0, 3, 0, 1, 1, 1, 1, 1, 3, 3, 1, 1, 1, 1, 0, 3, 1, 3, 0, 1, 0, 3, 1, 1, 1, 1, 3, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 3, 0, 1, 0, 0, 0, 1, 3, 0, 1, 0, 0, 0, 3, 3, 1, 3, 0, 1, 0, 3, 1, 0, 0, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 1, 3, 0, 1, 0, 0, 0, 0, 3, 1, 3, 0, 1, 0, 3, 1, 0, 0, 1, 3, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 1, 3, 0, 1, 0, 0, 0, 0, 3, 1, 3, 0, 1, 0, 3, 1, 0, 0, 1, 3, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 2, },
                       { 2, 1, 1, 1, 0, 3, 0, 0, 0, 0, 0, 1, 0, 3, 1, 1, 1, 1, 0, 3, 1, 3, 0, 1, 0, 3, 1, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 3, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 3, 0, 1, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 3, 1, 3, 0, 0, 0, 3, 1, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, },
                       { 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, }, };


                    for (int j = 0; j < Maze.GetLength(0); j++)
                    {
                        for (int i = 0; i < Maze.GetLength(1); i++)
                        {
                            switch (Maze[j, i])
                            {
                                case 0:
                                    WorldGen.KillTile(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j);
                                    WorldGen.KillWall(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j);
                                    WorldGen.PlaceWall(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j, (ushort)ModContent.WallType<MazeWall>());
                                    Main.tile[BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j].LiquidAmount = 0;
                                    break;
                                case 1:
                                    WorldGen.KillTile(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j);
                                    WorldGen.KillWall(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j);
                                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j, ModContent.TileType<MazeBrick>());
                                    WorldGen.PlaceWall(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j, (ushort)ModContent.WallType<MazeWall>());
                                    Main.tile[BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j].LiquidAmount = 0;
                                    break;
                                case 2:
                                    WorldGen.KillTile(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j);
                                    WorldGen.KillWall(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j);
                                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j, ModContent.TileType<MazeBrick>());
                                    Main.tile[BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j].LiquidAmount = 0;
                                    break;
                                case 3:
                                    WorldGen.KillTile(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j);
                                    WorldGen.KillWall(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j);
                                    WorldGen.PlaceWall(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j, (ushort)ModContent.WallType<MazeWall>());
                                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j, TileID.Chain);
                                    Main.tile[BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j].LiquidAmount = 0;
                                    break;
                                case 4:
                                    WorldGen.KillTile(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j);
                                    WorldGen.KillWall(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j);
                                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j, ModContent.TileType<MazeBrick>());
                                    Main.tile[BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j].LiquidAmount = 0;
                                    // WorldGen.Place2x1(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j, (ushort)mod.TileType("Ladder"));

                                    WorldGen.PlaceWall(BismuthWorld.MazeStartX + i, BismuthWorld.MazeStartY + j, (ushort)ModContent.WallType<MazeWall>());
                                    break;
                            }
                            WorldGen.Place1xX(BismuthWorld.MazeStartX + 6, BismuthWorld.MazeStartY + 3, (ushort)ModContent.TileType<GreenDoorLocked>());
                            WorldGen.Place1xX(BismuthWorld.MazeStartX + 30, BismuthWorld.MazeStartY + 24, (ushort)ModContent.TileType<BlueDoorLocked>());
                            WorldGen.Place1xX(BismuthWorld.MazeStartX + 41, BismuthWorld.MazeStartY + 51, (ushort)ModContent.TileType<RedDoorLocked>());
                        }
                    }
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 5, BismuthWorld.MazeStartY + 3, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 26, BismuthWorld.MazeStartY + 3, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 52, BismuthWorld.MazeStartY + 3, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 42, BismuthWorld.MazeStartY + 6, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 3, BismuthWorld.MazeStartY + 7, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 24, BismuthWorld.MazeStartY + 8, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 44, BismuthWorld.MazeStartY + 10, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 11, BismuthWorld.MazeStartY + 11, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 52, BismuthWorld.MazeStartY + 11, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 25, BismuthWorld.MazeStartY + 12, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 37, BismuthWorld.MazeStartY + 19, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 6, BismuthWorld.MazeStartY + 20, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 43, BismuthWorld.MazeStartY + 23, ModContent.TileType<Bone1>());                  
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 13, BismuthWorld.MazeStartY + 24, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 52, BismuthWorld.MazeStartY + 27, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 25, BismuthWorld.MazeStartY + 28, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 6, BismuthWorld.MazeStartY + 32, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 31, BismuthWorld.MazeStartY + 32, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 36, BismuthWorld.MazeStartY + 36, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 14, BismuthWorld.MazeStartY + 40, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 17, BismuthWorld.MazeStartY + 44, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 27, BismuthWorld.MazeStartY + 44, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 36, BismuthWorld.MazeStartY + 51, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 16, BismuthWorld.MazeStartY + 52, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 2, BismuthWorld.MazeStartY + 56, ModContent.TileType<Bone1>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 35, BismuthWorld.MazeStartY + 56, ModContent.TileType<Bone1>());
                    WorldGen.Place2x1(BismuthWorld.MazeStartX + 26, BismuthWorld.MazeStartY + 8, (ushort)ModContent.TileType<Bone2>());
                    WorldGen.Place2x1(BismuthWorld.MazeStartX + 4, BismuthWorld.MazeStartY + 16, (ushort)ModContent.TileType<Bone2>());
                    WorldGen.Place2x1(BismuthWorld.MazeStartX + 18, BismuthWorld.MazeStartY + 20, (ushort)ModContent.TileType<Bone2>());
                    WorldGen.Place2x1(BismuthWorld.MazeStartX + 50, BismuthWorld.MazeStartY + 23, (ushort)ModContent.TileType<Bone2>());
                    WorldGen.Place2x1(BismuthWorld.MazeStartX + 51, BismuthWorld.MazeStartY + 31, (ushort)ModContent.TileType<Bone2>());
                    WorldGen.Place2x1(BismuthWorld.MazeStartX + 2, BismuthWorld.MazeStartY + 36, (ushort)ModContent.TileType<Bone2>());
                    WorldGen.Place2x1(BismuthWorld.MazeStartX + 2, BismuthWorld.MazeStartY + 52, (ushort)ModContent.TileType<Bone2>());
                    WorldGen.Place2x1(BismuthWorld.MazeStartX + 12, BismuthWorld.MazeStartY + 56, (ushort)ModContent.TileType<Bone2>());
                    WorldGen.Place2x1(BismuthWorld.MazeStartX + 48, BismuthWorld.MazeStartY + 56, (ushort)ModContent.TileType<Bone2>());
                    WorldGen.Place3x1(BismuthWorld.MazeStartX + 40, BismuthWorld.MazeStartY + 2, (ushort)ModContent.TileType<Bone3>());
                    WorldGen.Place3x1(BismuthWorld.MazeStartX + 11, BismuthWorld.MazeStartY + 16, (ushort)ModContent.TileType<Bone3>());
                    WorldGen.Place3x1(BismuthWorld.MazeStartX + 25, BismuthWorld.MazeStartY + 20, (ushort)ModContent.TileType<Bone3>());
                    WorldGen.Place3x1(BismuthWorld.MazeStartX + 45, BismuthWorld.MazeStartY + 23, (ushort)ModContent.TileType<Bone3>());
                    WorldGen.Place3x1(BismuthWorld.MazeStartX + 45, BismuthWorld.MazeStartY + 56, (ushort)ModContent.TileType<Bone3>());
                    WorldGen.Place3x1(BismuthWorld.MazeStartX + 55, BismuthWorld.MazeStartY + 3, (ushort)ModContent.TileType<Bone4>());
                    WorldGen.Place3x1(BismuthWorld.MazeStartX + 34, BismuthWorld.MazeStartY + 40, (ushort)ModContent.TileType<Bone4>());
                    WorldGen.Place2x2(BismuthWorld.MazeStartX + 38, BismuthWorld.MazeStartY + 11, (ushort)ModContent.TileType<amphora3>(), 0);
                    WorldGen.Place2xX(BismuthWorld.MazeStartX + 4, BismuthWorld.MazeStartY + 24, (ushort)ModContent.TileType<amphora1>());
                    WorldGen.Place2xX(BismuthWorld.MazeStartX + 56, BismuthWorld.MazeStartY + 7, (ushort)ModContent.TileType<amphora2>());
                    WorldGen.Place2xX(BismuthWorld.MazeStartX + 41, BismuthWorld.MazeStartY + 19, (ushort)ModContent.TileType<amphora2>());
                    WorldGen.Place2xX(BismuthWorld.MazeStartX + 29, BismuthWorld.MazeStartY + 44, (ushort)ModContent.TileType<amphora2>());
                    WorldGen.Place2x2(BismuthWorld.MazeStartX + 22, BismuthWorld.MazeStartY + 24, (ushort)ModContent.TileType<amphora3>(), 0);
                    WorldGen.Place2xX(BismuthWorld.MazeStartX + 22, BismuthWorld.MazeStartY + 32, (ushort)ModContent.TileType<amphora2>());
                    WorldGen.Place2xX(BismuthWorld.MazeStartX + 25, BismuthWorld.MazeStartY + 36, (ushort)ModContent.TileType<amphora1>());
                    WorldGen.Place2x2(BismuthWorld.MazeStartX + 38, BismuthWorld.MazeStartY + 32, (ushort)ModContent.TileType<amphora3>(), 0);
                    WorldGen.Place2xX(BismuthWorld.MazeStartX + 48, BismuthWorld.MazeStartY + 34, (ushort)ModContent.TileType<amphora1>());
                    WorldGen.Place2x2(BismuthWorld.MazeStartX + 2, BismuthWorld.MazeStartY + 48, (ushort)ModContent.TileType<amphora3>(), 0);
                    WorldGen.Place2x2(BismuthWorld.MazeStartX + 28, BismuthWorld.MazeStartY + 56, (ushort)ModContent.TileType<amphora3>(), 0);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 5, BismuthWorld.MazeStartY - 2);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 4, BismuthWorld.MazeStartY - 2);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 3, BismuthWorld.MazeStartY - 2);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 5, BismuthWorld.MazeStartY - 1);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 4, BismuthWorld.MazeStartY - 1);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 3, BismuthWorld.MazeStartY - 1);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 2, BismuthWorld.MazeStartY - 1);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY - 1);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 6, BismuthWorld.MazeStartY);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 5, BismuthWorld.MazeStartY);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 4, BismuthWorld.MazeStartY);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 3, BismuthWorld.MazeStartY);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 2, BismuthWorld.MazeStartY);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 7, BismuthWorld.MazeStartY + 1);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 6, BismuthWorld.MazeStartY + 1);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 5, BismuthWorld.MazeStartY + 1);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 4, BismuthWorld.MazeStartY + 1);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 3, BismuthWorld.MazeStartY + 1);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 2, BismuthWorld.MazeStartY + 1);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY + 1);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 7, BismuthWorld.MazeStartY + 2);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 6, BismuthWorld.MazeStartY + 2);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 5, BismuthWorld.MazeStartY + 2);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 4, BismuthWorld.MazeStartY + 2);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 3, BismuthWorld.MazeStartY + 2);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 2, BismuthWorld.MazeStartY + 2);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY + 2);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 7, BismuthWorld.MazeStartY + 3);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 6, BismuthWorld.MazeStartY + 3);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 5, BismuthWorld.MazeStartY + 3);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 4, BismuthWorld.MazeStartY + 3);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 3, BismuthWorld.MazeStartY + 3);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 2, BismuthWorld.MazeStartY + 3);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY + 3);
                    WorldGen.KillTile(BismuthWorld.MazeStartX - 6, BismuthWorld.MazeStartY + 4);
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 1, BismuthWorld.MazeStartY - 1, TileID.Stone);
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 1, BismuthWorld.MazeStartY + 1, TileID.Stone);
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX, BismuthWorld.MazeStartY - 1, TileID.Stone);
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX, BismuthWorld.MazeStartY + 1, TileID.Stone);
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX, BismuthWorld.MazeStartY + 2, TileID.Stone);
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX, BismuthWorld.MazeStartY + 3, TileID.Stone);
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY - 2, TileID.Stone);
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY - 1, TileID.Stone);
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY, TileID.Stone);
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY + 1, TileID.Stone);
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY + 2, TileID.Stone);
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY + 3, TileID.Stone);
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX - 1, BismuthWorld.MazeStartY + 4, TileID.Stone);
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX - 2, BismuthWorld.MazeStartY, TileID.Stone);
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX - 2, BismuthWorld.MazeStartY + 1, TileID.Stone);
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX - 2, BismuthWorld.MazeStartY + 2, TileID.Stone);
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX - 3, BismuthWorld.MazeStartY + 1, TileID.Stone);
                    NPC.NewNPC(Main.LocalPlayer.GetSource_FromThis(), (BismuthWorld.MazeStartX + 4) * 16, (BismuthWorld.MazeStartY + 3) * 16 - 4, ModContent.NPCType<StrangeOldman>());
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 2, BismuthWorld.MazeStartY + 2, TileID.Torches);
                    WorldGen.PlaceTile(BismuthWorld.MazeStartX + 43, BismuthWorld.MazeStartY + 2, ModContent.TileType<Content.Tiles.Luceat>());
                    int greenchest = WorldGen.PlaceChest(BismuthWorld.MazeStartX + 55, BismuthWorld.MazeStartY + 23, (ushort)ModContent.TileType<GreenMazeChest>(), false, 0);
                    int greenchestIndex = Chest.FindChest(BismuthWorld.MazeStartX + 55, BismuthWorld.MazeStartY + 22);
                    if (greenchestIndex != -1)
                    {

                        GenerateBiomeGreenChestLoot(Main.chest[greenchestIndex].item);
                    }

                    int bluechest = WorldGen.PlaceChest(BismuthWorld.MazeStartX + 24, BismuthWorld.MazeStartY + 16, (ushort)ModContent.TileType<BlueMazeChest>(), false, 0);
                    int bluechestIndex = Chest.FindChest(BismuthWorld.MazeStartX + 24, BismuthWorld.MazeStartY + 15);
                    if (bluechestIndex != -1)
                    {

                        GenerateBiomeBlueChestLoot(Main.chest[bluechestIndex].item);
                    }

                    int redchest = WorldGen.PlaceChest(BismuthWorld.MazeStartX + 52, BismuthWorld.MazeStartY + 56, (ushort)ModContent.TileType<RedMazeChest>(), false, 0);
                    int redchestIndex = Chest.FindChest(BismuthWorld.MazeStartX + 52, BismuthWorld.MazeStartY + 55);
                    if (redchestIndex != -1)
                    {

                        GenerateBiomeRedChestLoot(Main.chest[redchestIndex].item);
                    }
                   
                }
               
            }
            
        }
        void GenerateBiomeRedChestLoot(Item[] chestInventory)
        {
            int RedcurrentIndex = 0;
            chestInventory[RedcurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ModContent.ItemType<AriadnesTangle>(), ModContent.ItemType<PrometheusFire>())); RedcurrentIndex++;
            chestInventory[RedcurrentIndex].SetDefaults(ModContent.ItemType<AthenasShield>()); RedcurrentIndex++; 
            chestInventory[RedcurrentIndex].SetDefaults(ModContent.ItemType<TheMoldofaKeyOfTheSun>()); RedcurrentIndex++;
            chestInventory[RedcurrentIndex].SetDefaults(ItemID.HealingPotion); chestInventory[RedcurrentIndex].stack = Main.rand.Next(3, 11); RedcurrentIndex++;
            chestInventory[RedcurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ItemID.ApprenticeBait, ItemID.JourneymanBait, ItemID.MasterBait)); chestInventory[RedcurrentIndex].stack = Main.rand.Next(4, 9); RedcurrentIndex++;
            chestInventory[RedcurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ItemID.CookedFish, ItemID.CookedShrimp)); chestInventory[RedcurrentIndex].stack = Main.rand.Next(2, 5); RedcurrentIndex++;
          
        }
        void GenerateBiomeBlueChestLoot(Item[] chestInventory)
        {
            int BluecurrentIndex = 0;
            chestInventory[BluecurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ModContent.ItemType<WingsOfDaedalus>(), ModContent.ItemType<GoldenRune>())); BluecurrentIndex++;
            chestInventory[BluecurrentIndex].SetDefaults(ModContent.ItemType<RedKey>()); BluecurrentIndex++;
            chestInventory[BluecurrentIndex].SetDefaults(ItemID.HealingPotion); chestInventory[BluecurrentIndex].stack = Main.rand.Next(3, 11); BluecurrentIndex++;
            chestInventory[BluecurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ItemID.HunterPotion, ItemID.ShinePotion)); chestInventory[BluecurrentIndex].stack = Main.rand.Next(2, 4); BluecurrentIndex++;
            chestInventory[BluecurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ItemID.CookedFish, ItemID.CookedShrimp)); chestInventory[BluecurrentIndex].stack = Main.rand.Next(2, 5); BluecurrentIndex++;
        }
        void GenerateBiomeGreenChestLoot(Item[] chestInventory)
        {
            int GreencurrentIndex = 0;
            chestInventory[GreencurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ModContent.ItemType<QuiverOfOdysseus>(), ModContent.ItemType<BowOfOdysseus>())); GreencurrentIndex++;
            chestInventory[GreencurrentIndex].SetDefaults(ModContent.ItemType<BlueKey>()); GreencurrentIndex++;
            chestInventory[GreencurrentIndex].SetDefaults(ItemID.HealingPotion); chestInventory[GreencurrentIndex].stack = Main.rand.Next(3, 11); GreencurrentIndex++;
            chestInventory[GreencurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ItemID.RegenerationPotion, ItemID.IronskinPotion)); chestInventory[GreencurrentIndex].stack = Main.rand.Next(1, 3); GreencurrentIndex++;
            chestInventory[GreencurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ItemID.CookedFish, ItemID.CookedShrimp)); chestInventory[GreencurrentIndex].stack = Main.rand.Next(2, 5); GreencurrentIndex++;
        }
    }
}