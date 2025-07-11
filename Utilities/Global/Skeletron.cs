using Bismuth.Content.Items.Accessories;
using Bismuth.Content.Items.Weapons.Assassin;
using Bismuth.Content.Items.Weapons.Melee;
using Bismuth.Content.Items.Weapons.Ranged;
using Bismuth.Content.Items.Weapons.Throwing;
using Bismuth.Content.Tiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Chat;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Utilities.Global
{
    public class Skeletron : GlobalNPC, ILocalizedModType
    {
        public string LocalizationCategory => "DeadSkeletron";

        public override void Load()
        {
            _ = this.GetLocalization("HeliosText").Value;
        }
        public override void OnKill(NPC npc)
        {
            string HeliosText = this.GetLocalization("HeliosText").Value;
            if (npc.type == NPCID.SkeletronHead)
            {
                if (BismuthWorld.downedSkeletron == false)
                {
                    BismuthWorld.downedSkeletron = true;
                    if (Main.netMode == 2)
                    {
                        NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
                    }
                    if (Main.netMode == 0)
                    {
                        Main.NewText(HeliosText, Color.LightGray);
                    }
                    else if (Main.netMode == 2)
                    {
                        ChatHelper.BroadcastChatMessage(NetworkText.FromKey(HeliosText, new object[0]), Color.LightGoldenrodYellow, -1);
                    }
                    int StartHeliosX = Main.spawnTileX;
                    int StartHeliosY = 100;
                    int[,] HeliosTemple = new int[,] {   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                         { 0, 0, 0, 0, 0, 0, 0, 5, 5, 2, 2, 2, 2, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                         { 0, 0, 0, 0, 0, 5, 5, 2, 2, 2, 2, 2, 2, 2, 2, 5, 5, 0, 0, 0, 0, 0, 0 },
                                                         { 0, 0, 0, 0, 5, 5, 2, 2, 2, 0, 0, 0, 0, 2, 2, 2, 5, 5, 0, 0, 0, 0, 0 },
                                                         { 0, 0, 0, 5, 3, 2, 2, 2, 0, 0, 0, 0, 0, 0, 2, 2, 2, 3, 5, 0, 0, 0, 0 },
                                                         { 0, 0, 0, 3, 2, 2, 2, 0, 6, 0, 0, 0, 0, 6, 0, 2, 2, 2, 3, 0, 0, 0, 0 },
                                                         { 0, 0, 5, 3, 3, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 3, 5, 0, 0, 0 },
                                                         { 0, 0, 3, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 0, 0, 0 },
                                                         { 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0 },
                                                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                         { 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                         { 0, 0, 0, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 0, 0, 0, 0 },
                                                         { 0, 0, 4, 2, 2, 2, 2, 2, 3, 3, 0, 0, 3, 3, 2, 2, 2, 2, 2, 4, 0, 0, 0 },
                                                         { 4, 4, 4, 1, 1, 1, 1, 1, 2, 3, 3, 3, 3, 2, 1, 1, 1, 1, 1, 4, 4, 4, 4 },
                                                         { 4, 4, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 4, 4, 4 },
                                                         { 0, 4, 4, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 4, 0, 0 },
                                                         { 0, 0, 0, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 4, 4, 0, 0, 0 },
                                                         { 0, 0, 0, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 0, 0, 0, 0, 0 },
                                                         { 0, 0, 0, 4, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 4, 0, 0, 0, 0, 0 },
                                                         { 0, 0, 0, 0, 4, 4, 1, 1, 1, 1, 1, 1, 1, 1, 4, 4, 4, 0, 0, 0, 0, 0, 0 },
                                                         { 0, 0, 0, 0, 0, 4, 1, 1, 1, 1, 1, 1, 1, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                         { 0, 0, 0, 0, 0, 4, 4, 4, 4, 1, 1, 1, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                         { 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }  };

                    for (int j = 0; j < HeliosTemple.GetLength(0); j++)
                    {
                        for (int i = 0; i < HeliosTemple.GetLength(1); i++)
                        {
                            switch (HeliosTemple[j, i])
                            {
                                case 0:
                                    WorldGen.KillTile(StartHeliosX + i, StartHeliosY + j);
                                    WorldGen.KillWall(StartHeliosX + i, StartHeliosY + j);
                                    break;
                                case 1:
                                    WorldGen.KillTile(StartHeliosX + i, StartHeliosY + j);
                                    WorldGen.KillWall(StartHeliosX + i, StartHeliosY + j);
                                    WorldGen.PlaceTile(StartHeliosX + i, StartHeliosY + j, TileID.Dirt);
                                    break;
                                case 2:
                                    WorldGen.KillTile(StartHeliosX + i, StartHeliosY + j);
                                    WorldGen.KillWall(StartHeliosX + i, StartHeliosY + j);
                                    WorldGen.PlaceTile(StartHeliosX + i, StartHeliosY + j, TileID.GoldBrick);
                                    break;
                                case 3:
                                    WorldGen.KillTile(StartHeliosX + i, StartHeliosY + j);
                                    WorldGen.KillWall(StartHeliosX + i, StartHeliosY + j);
                                    WorldGen.PlaceTile(StartHeliosX + i, StartHeliosY + j, TileID.PearlstoneBrick);
                                    break;
                                case 4:
                                    WorldGen.KillTile(StartHeliosX + i, StartHeliosY + j);
                                    WorldGen.KillWall(StartHeliosX + i, StartHeliosY + j);
                                    WorldGen.PlaceTile(StartHeliosX + i, StartHeliosY + j, TileID.Dirt);
                                    WorldGen.PlaceTile(StartHeliosX + i, StartHeliosY + j, TileID.Grass);
                                    break;
                                case 5:
                                    WorldGen.KillTile(StartHeliosX + i, StartHeliosY + j);
                                    WorldGen.KillWall(StartHeliosX + i, StartHeliosY + j);
                                    WorldGen.PlaceTile(StartHeliosX + i, StartHeliosY + j, TileID.MarbleBlock);
                                    break;
                                case 6:
                                    WorldGen.KillTile(StartHeliosX + i, StartHeliosY + j);
                                    WorldGen.KillWall(StartHeliosX + i, StartHeliosY + j);
                                    WorldGen.PlaceWall(StartHeliosX + i, StartHeliosY + j, WallID.PearlstoneBrick);
                                    WorldGen.PlaceTile(StartHeliosX + i, StartHeliosY + j, TileID.Torches, false, false, 0, 6);
                                    break;
                            }
                            ;

                            WorldGen.SlopeTile(StartHeliosX + 9, StartHeliosY, 2);
                            WorldGen.SlopeTile(StartHeliosX + 7, StartHeliosY + 1, 2);
                            WorldGen.SlopeTile(StartHeliosX + 5, StartHeliosY + 2, 2);
                            WorldGen.SlopeTile(StartHeliosX + 3, StartHeliosY + 4, 2);
                            WorldGen.SlopeTile(StartHeliosX + 12, StartHeliosY, 1);
                            WorldGen.SlopeTile(StartHeliosX + 14, StartHeliosY + 1, 1);
                            WorldGen.SlopeTile(StartHeliosX + 16, StartHeliosY + 2, 1);
                            WorldGen.SlopeTile(StartHeliosX + 18, StartHeliosY + 4, 1);
                            WorldGen.SlopeTile(StartHeliosX + 9, StartHeliosY + 13, 1);
                            WorldGen.SlopeTile(StartHeliosX + 12, StartHeliosY + 13, 2);
                            WorldGen.SlopeTile(StartHeliosX + 9, StartHeliosY + 10, 2);
                            WorldGen.SlopeTile(StartHeliosX + 12, StartHeliosY + 10, 1);
                            WorldGen.SlopeTile(StartHeliosX + 4, StartHeliosY + 7, 3);
                            WorldGen.SlopeTile(StartHeliosX + 6, StartHeliosY + 5, 3);
                            WorldGen.SlopeTile(StartHeliosX + 7, StartHeliosY + 4, 3);
                            WorldGen.SlopeTile(StartHeliosX + 14, StartHeliosY + 4, 4);
                            WorldGen.SlopeTile(StartHeliosX + 15, StartHeliosY + 5, 4);
                            WorldGen.SlopeTile(StartHeliosX + 17, StartHeliosY + 7, 4);
                            WorldGen.Place1xX(StartHeliosX + 3, StartHeliosY + 11, (ushort)ModContent.TileType<HeliosDoorClosed>());
                            WorldGen.Place1xX(StartHeliosX + 18, StartHeliosY + 11, (ushort)ModContent.TileType<HeliosDoorClosed>());
                            int helioschest = WorldGen.PlaceChest(StartHeliosX + 10, StartHeliosY + 9, (ushort)ModContent.TileType<HeliosChest>(), false, 0);
                            int chestIndex = Chest.FindChest(StartHeliosX + 10, StartHeliosY + 8);
                            if (chestIndex != -1)
                            {

                                GenerateBiomeHeliosChestLoot(Main.chest[chestIndex].item);
                            }
                        }

                    }
                    int[,] HeliosTempleWall = new int[,]  {   { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                              { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                              { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                              { 0, 0, 0, 0, 0, 0, 1, 4, 4, 4, 4, 4, 4, 4, 4, 1, 0, 0, 0, 0, 0, 0, 0 },
                                                              { 0, 0, 0, 0, 0, 1, 4, 3, 3, 3, 3, 3, 3, 3, 3, 4, 1, 0, 0, 0, 0, 0, 0 },
                                                              { 0, 0, 0, 0, 1, 4, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 1, 0, 0, 0, 0, 0 },
                                                              { 0, 0, 0, 0, 1, 4, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 1, 0, 0, 0, 0, 0 },
                                                              { 0, 0, 0, 0, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1, 0, 0, 0, 0, 0 },
                                                              { 0, 0, 0, 0, 1, 4, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 4, 1, 0, 0, 0, 0, 0 },
                                                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                                                              { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };

                    for (int j = 0; j < HeliosTempleWall.GetLength(0); j++)
                    {
                        for (int i = 0; i < HeliosTempleWall.GetLength(1); i++)
                        {
                            switch (HeliosTempleWall[j, i])
                            {
                                case 0:
                                    break;
                                case 1:
                                    WorldGen.PlaceWall(StartHeliosX + i, StartHeliosY + j, WallID.PearlstoneBrick);
                                    break;
                                case 2:
                                    WorldGen.PlaceWall(StartHeliosX + i, StartHeliosY + j, WallID.StoneSlab);
                                    break;
                                case 3:
                                    WorldGen.PlaceWall(StartHeliosX + i, StartHeliosY + j, WallID.IronFence);
                                    break;
                                case 4:
                                    WorldGen.PlaceWall(StartHeliosX + i, StartHeliosY + j, WallID.GoldBrick);
                                    break;
                            }
                        }
                    }
                    WorldGen.PlaceObject(StartHeliosX + 10, StartHeliosY + 5, ModContent.TileType<SunrisePicture>());
                }
            }
        }

        void GenerateBiomeHeliosChestLoot(Item[] chestInventory)
        {
            int HelioscurrentIndex = 0;
            chestInventory[HelioscurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ModContent.ItemType<Prominence>(), ModContent.ItemType<SolarDisk>(), ModContent.ItemType<StatuetteOfHelios>(), ModContent.ItemType<ShinyCover>(), ModContent.ItemType<SolarWind>(), ModContent.ItemType<Heat>())); HelioscurrentIndex++;
            chestInventory[HelioscurrentIndex].SetDefaults(ItemID.GreaterHealingPotion); chestInventory[HelioscurrentIndex].stack = Main.rand.Next(3, 11); HelioscurrentIndex++;
            chestInventory[HelioscurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ItemID.RegenerationPotion, ItemID.IronskinPotion, ItemID.SwiftnessPotion)); chestInventory[HelioscurrentIndex].stack = Main.rand.Next(1, 6); HelioscurrentIndex++;
            chestInventory[HelioscurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ItemID.GillsPotion, ItemID.ShinePotion, ItemID.SpelunkerPotion, ItemID.NightOwlPotion)); chestInventory[HelioscurrentIndex].stack = Main.rand.Next(1, 6); HelioscurrentIndex++;
            chestInventory[HelioscurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ItemID.RecallPotion, ItemID.InvisibilityPotion, ItemID.HunterPotion, ItemID.ThornsPotion)); chestInventory[HelioscurrentIndex].stack = Main.rand.Next(1, 6); HelioscurrentIndex++;
            chestInventory[HelioscurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ItemID.CookedFish, ItemID.CookedShrimp, ItemID.CookedMarshmallow, ItemID.BowlofSoup, ItemID.Bacon, ItemID.SugarCookie)); chestInventory[HelioscurrentIndex].stack = Main.rand.Next(6, 12); HelioscurrentIndex++;
            chestInventory[HelioscurrentIndex].SetDefaults(ItemID.GoldCoin); chestInventory[HelioscurrentIndex].stack = Main.rand.Next(2, 5); HelioscurrentIndex++;
        }
    }
}