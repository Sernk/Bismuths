using Bismuth.Content.Items.Accessories;
using Bismuth.Content.Items.Other;
using Bismuth.Content.Items.Weapons.Assassin;
using Bismuth.Content.Items.Weapons.Magical;
using Bismuth.Content.Items.Weapons.Melee;
using Bismuth.Content.NPCs;
using Bismuth.Content.Tiles;
using Bismuth.Content.Walls;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameContent.Generation;
using Terraria.ID;
using Terraria.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.WorldBuilding;
using static StructureHelper.API.Generator;

namespace Bismuth.Utilities
{
    public class BismuthWorld : ModSystem
    {
        #region Special varuables
        public static bool IsSwampSuccess = true; // Сгенерировалось ли болото? 
        public static bool IsDesertSuccess = true;
        public static bool GeneratedCaslte = true; // Сгенерировался ли замок?
        public static bool DownedNecromancer = false;
        public static bool DownedPapuanWizard = false;
        public static bool DownedRhino = false;
        public static int WitchSpawnX = 0;
        public static int WitchSpawnY = 0;
        public static int KilledBossesInWorld = 0;
        public static bool SwampBiome = false; // Находится ли игрок в болоте?
        public static int SwampTiles = 0; // Количество болотных блоков вокруг игрока.
        public static int TombstoneCounts = 0; // Количество могил вокруг игрока.

        public static int TombstoneX = 0; // x-координата могилы
        public static int TombstoneY = 0; // y-координата могилы
        #region WaterTempleVars
        public static int WaterTempleX = 0; // x-координата водяного храма
        public static int WaterTempleY = 0; // y-координата водяного храма
        public static bool downedBanshee = false;

        #endregion
        public static int OrcishInvasionStage = 0; // 0 - не призывалось/было провалено, 1 - в процессе, 2 - убито
        public static int DefeatedPortals = 0; // кол-во уничтоженных порталов
        public static bool SpawnedRhino = false;
        public override void TileCountsAvailable(ReadOnlySpan<int> tileCounts)
        {
            SwampTiles = tileCounts[ModContent.TileType<SwampMud>()];
            TombstoneCounts = tileCounts[TileID.Tombstones] / 4;
        }
        #region downedBosses
        public static bool downedEoC = false; // Убит ли глаз Ктулху? (Генерация лабиринта)
        public static bool downedWoF = false;
        public static bool downedAnyMechBoss = false;
        public static bool downedPlantera = false;
        public static bool downedGolem = false; // Убит ли Голем? (Генерация висмутовой руды)
        public static bool downedSkeletron = false; // Убит ли Скелетрон? (Генерация святилища Гелиоса)

        #endregion

        public static bool OpenedRedChest = false;
        public static bool DestroyedMaze = false;
        public static bool FirstTotemDeactivation = false;
        public static int WorldSize;
        public static int[] VampShop = new int[3];

        public static List<Vector2> CasketCoords = new List<Vector2>();
        public static bool CryptIsSpawned = false;
        public static bool SunriseIsPlaced = false;
        public static int RemovePriest = 0;
        #endregion
        #region StructuresCoords
        #region SwampCoords
        public static int SwampStartX = 0; // x-координата левого края болота
        public static int SwampStartY = 0; // y-координата левого края болота
        public static int SwampCenterX = 0; // x-координата центра болота 
        public static int SwampCacheX = 0; // x-координата тайника болота
        public static int SwampCacheY = 0; // y-координата тайника болота
        public static int castleside = 0;
        #endregion
        #region DesertVillageCoords
        public static int StartDesertVillageX = 0; // x-координата начальной точки генерации пустынной деревни
        public static int StartDesertVillageY = (int)GenVars.worldSurfaceLow; // y-координата начальной точки генерации пустынной деревни
        public static int DesertVillageLeftBorderX = 0; // x-координата левой границы пустынной деревни
        public static int DesertVillageLeftBorderY = 0; // y-координата левой границы пустынной деревни
        public static int DesertVillageRightBorderX = Main.maxTilesX; // x-координата правой границы пустынной деревни
        public static int DesertVillageRightBorderY = 0; // y-координата правой границы пустынной деревни
        public static int TotemX = 0; // x-координата тотема проклятия
        public static int TotemY = 0; // y-координата тотема проклятия
        public static List<Vector2> TownTiles = new List<Vector2>();
        public static List<Vector2> TownWalls = new List<Vector2>();
        public static List<Vector2> DoorsLeft = new List<Vector2>();
        public static List<Vector2> DoorsRight = new List<Vector2>();
        #region BridgeCoords
        public static int StartBridgeX = 0;
        public static int BridgeY = 0;
        public static int EndBridgeX = 0;
        public static int TempY = 0;
        #endregion
        #endregion
        public static int TotemCooldown = 0; // Время до активации тотема племени (0 - активен, 1 - 86400 - неактивен)
        public static bool IsTotemActive = true;
        #region MazeVars
        public static int MazeStartX = 0; // x-координата лабиринта
        public static int MazeStartY = 0; // y-координата лабиринта
        #endregion
        #region OrcishCastleCoords
        public static int CastleSpawnX = 0; // x-координата начальной точки генерации орочьего замка
        public static int CastleSpawnY = 0; // y-координата начальной точки генерации орочьего замка
        #endregion
        public static int SunriseX = 0; // x-координата левого края болота
        public static int SunriseY = 0; // y-координата левого края болота
        #endregion
        public static int BeachEndLeft = 0; // Конец левого пляжа (по иксам)
        public static int BeachEndRight = Main.maxTilesX;  // Конец правого пляжа (по иксам)

        //Remnants Settings
        int DesertPitSetting = 60;

        public static void CallOrcishInvasion()
        {
            var source = Main.LocalPlayer.GetSource_FromThis();
            Bismuth.ShakeScreen(50f, 180);
            Mod mod = ModLoader.GetMod("Bismuth");
            OrcishInvasionStage = 1;
            NPC.NewNPC(source, CastleSpawnX * 16 + 482, CastleSpawnY * 16 + 438, ModContent.NPCType<OrcishPortal>());
            NPC.NewNPC(source, CastleSpawnX * 16 + 120, CastleSpawnY * 16 + 438, ModContent.NPCType<OrcishPortal>());
            NPC.NewNPC(source, CastleSpawnX * 16 + 280, CastleSpawnY * 16 + 170, ModContent.NPCType<OrcishPortal>());
            NPC.NewNPC(source, CastleSpawnX * 16 + 650, CastleSpawnY * 16 + 60, ModContent.NPCType<OrcishPortal>());
        }
        public static void RevealAroundPoint(int x, int y)
        {
            for (int i = x - 5; i < x + 5; i++)
            {
                for (int j = y - 5; j < y + 5; j++)
                {
                    if (WorldGen.InWorld(i, j))
                        Main.Map.Update(i, j, 255);
                }
            }
            Main.refreshMap = true;
        }
        public static bool WizardDay = false;
        public override void PostUpdateWorld()
        {
            var source = Main.LocalPlayer.GetSource_FromThis();
            if (!NPC.AnyNPCs(ModContent.NPCType<ImperianConsul>()))
            {
                NPC.NewNPC(source, (Main.spawnTileX + 6) * 16 + 4, (Main.spawnTileY + 3) * 16, ModContent.NPCType<ImperianConsul>());
            }
            if (!NPC.AnyNPCs(ModContent.NPCType<DwarfBlacksmith>()))
            {
                NPC.NewNPC(source, (Main.spawnTileX - 24) * 16, (Main.spawnTileY + 3) * 16, ModContent.NPCType<DwarfBlacksmith>());
            }
            if (!NPC.AnyNPCs(ModContent.NPCType<Beggar>()))
            {
                NPC.NewNPC(source, (Main.spawnTileX - 43) * 16, (Main.spawnTileY + 3) * 16, ModContent.NPCType<Beggar>());
            }
            if (!NPC.AnyNPCs(ModContent.NPCType<Alchemist>()) && Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest != 200)
            {
                NPC.NewNPC(source, (Main.spawnTileX - 61) * 16, (Main.spawnTileY + 4) * 16, ModContent.NPCType<Alchemist>());
            }
            if (!NPC.AnyNPCs(ModContent.NPCType<ImperianCommander>()))
            {
                NPC.NewNPC(source, (Main.spawnTileX + 59) * 16, (Main.spawnTileY + 4) * 16, ModContent.NPCType<ImperianCommander>());
            }
            if (!NPC.AnyNPCs(ModContent.NPCType<StrangeOldman>()) && Main.LocalPlayer.GetModPlayer<Quests>().LuceatQuest >= 40 && Main.LocalPlayer.GetModPlayer<Quests>().NewPriestQuest != 100)
            {
                NPC.NewNPC(source, (Main.spawnTileX + 45) * 16, (Main.spawnTileY - 10) * 16, ModContent.NPCType<StrangeOldman>());
            }
            if (!NPC.AnyNPCs(ModContent.NPCType<OldmanPriest>()) && Main.LocalPlayer.GetModPlayer<Quests>().NewPriestQuest == 100)
            {
                NPC.NewNPC(source, (Main.spawnTileX + 29) * 16, (Main.spawnTileY + 2) * 16 - 2, ModContent.NPCType<OldmanPriest>());
            }
            if (castleside == 0)
            {
                castleside = CastleSpawnX > Main.maxTilesX / 2 ? 1 : -1;
            }
            if (!NPC.AnyNPCs(ModContent.NPCType<TravelingVampire>()))
            {
                if (Main.bloodMoon && !Main.dayTime)
                {
                    int[] rand = new int[6] { ModContent.ItemType<DraculasCover>(), ModContent.ItemType<PendantOfBlood>(), ModContent.ItemType<MarbleMask>(), ModContent.ItemType<ManGosh>(), ModContent.ItemType<Misericorde>(), ModContent.ItemType<Baselard>() };
                    for (int i = rand.Length - 1; i >= 1; i--)
                    {

                        int j = Main.rand.Next(i + 1);
                        int temp = rand[j];
                        rand[j] = rand[i];
                        rand[i] = temp;
                    }
                    VampShop[0] = rand[0];
                    VampShop[1] = rand[1];
                    VampShop[2] = rand[2];
                    NPC.NewNPC(source, (Main.spawnTileX - 82) * 16, (Main.spawnTileY - 2) * 16, ModContent.NPCType<TravelingVampire>());
                }
            }
            if (Main.bloodMoon && !Main.dayTime && !NPC.AnyNPCs(ModContent.NPCType<TravelingVampire>()))
            {
                NPC.NewNPC(source, (Main.spawnTileX - 82) * 16, (Main.spawnTileY - 2) * 16, ModContent.NPCType<TravelingVampire>());
            }
            if (NPC.CountNPCS(ModContent.NPCType<OrcishPortal>()) == 0 && OrcishInvasionStage == 1)
            {
                OrcishInvasionStage = 0;
                DefeatedPortals = 0;
            }
            #region Statue Buff Update
            if (!IsTotemActive)
            {
                if (TotemCooldown < 300)
                    TotemCooldown++;
                if (TotemCooldown >= 300)
                {
                    TotemCooldown = 0;
                    IsTotemActive = true;
                }
            }
            if (!Main.dayTime)
                WizardDay = false;
            #endregion
            #region Crypt
            if (Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 200 && !CryptIsSpawned)
            {
                int CryptX = TombstoneX - 9;
                int CryptY = Main.maxTilesY / 3;
                for (int i = 0; i < 15; i++)
                {
                    WorldMethods.BresenhamLineTunnel(CryptX - 5 + Main.rand.Next(-5 + i, 5 + i), CryptY + 12 - i, CryptX + 15 + Main.rand.Next(-5 + i, 5 + i), CryptY + 12 - i, 4);
                }
                for (int i = 0; i < 50; i++)
                {
                    for (int j = 0; j < 50; j++)
                    {
                        Main.tile[CryptX - 15 + j, CryptY + 15 - i].LiquidAmount = 0;
                    }
                }
                int[,] Crypt = new int[,]
                {
                       {0, 0, 0, 0, 0, 3, 1, 1, 1, 1, 1, 1, 1, 2, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 1, 6, 4, 4, 4, 4, 4, 5, 1, 0, 0, 0, 0, 0},
                       {0, 3, 1, 1, 1, 1, 4, 7, 0, 0, 0, 8, 4, 1, 1, 1, 1, 2, 0},
                       {0, 1, 6, 4, 4, 4, 4, 0, 0, 0, 0, 0, 4, 4, 4, 4, 5, 1, 0},
                       {0, 1, 4, 7, 0, 8, 4, 0, 0, 0, 0, 0, 4, 7, 0, 8, 4, 1, 0},
                       {3, 1, 4, 0, 0, 0, 4, 0, 0, 0, 0, 0, 4, 0, 0, 0, 4, 1, 2},
                       {1, 6, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 5, 1},
                       {1, 7, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 8, 1},
                       {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                       {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                       {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                };
                for (int j = 0; j < Crypt.GetLength(0); j++)
                {
                    for (int i = 0; i < Crypt.GetLength(1); i++)
                    {
                        switch (Crypt[j, i])
                        {
                            case 0:
                                WorldGen.KillTile(CryptX + i, CryptY + j);
                                break;
                            case 1:
                                WorldGen.KillTile(CryptX + i, CryptY + j);
                                WorldGen.PlaceTile(CryptX + i, CryptY + j, TileID.IridescentBrick);
                                break;
                            case 2:
                                WorldGen.KillTile(CryptX + i, CryptY + j);
                                WorldGen.PlaceTile(CryptX + i, CryptY + j, TileID.IridescentBrick);
                                WorldGen.SlopeTile(CryptX + i, CryptY + j, 1);
                                break;
                            case 3:
                                WorldGen.KillTile(CryptX + i, CryptY + j);
                                WorldGen.PlaceTile(CryptX + i, CryptY + j, TileID.IridescentBrick);
                                WorldGen.SlopeTile(CryptX + i, CryptY + j, 2);
                                break;
                            case 4:
                                WorldGen.KillTile(CryptX + i, CryptY + j);
                                WorldGen.PlaceTile(CryptX + i, CryptY + j, TileID.GrayBrick);
                                break;
                            case 5:
                                WorldGen.KillTile(CryptX + i, CryptY + j);
                                WorldGen.PlaceTile(CryptX + i, CryptY + j, TileID.GrayBrick);
                                WorldGen.SlopeTile(CryptX + i, CryptY + j, 1);
                                break;
                            case 6:
                                WorldGen.KillTile(CryptX + i, CryptY + j);
                                WorldGen.PlaceTile(CryptX + i, CryptY + j, TileID.GrayBrick);
                                WorldGen.SlopeTile(CryptX + i, CryptY + j, 2);
                                break;
                            case 7:
                                WorldGen.KillTile(CryptX + i, CryptY + j);
                                WorldGen.PlaceTile(CryptX + i, CryptY + j, TileID.GrayBrick);
                                WorldGen.SlopeTile(CryptX + i, CryptY + j, 3);
                                break;
                            case 8:
                                WorldGen.KillTile(CryptX + i, CryptY + j);
                                WorldGen.PlaceTile(CryptX + i, CryptY + j, TileID.GrayBrick);
                                WorldGen.SlopeTile(CryptX + i, CryptY + j, 4);
                                break;
                        }
                    }
                }
                int[,] CryptWall = new int[,]
                {
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 3, 1, 1, 1, 2, 2, 3, 0, 0, 0, 0, 0, 0},
                       {0, 0, 1, 0, 0, 0, 3, 1, 1, 1, 2, 2, 3, 0, 0, 0, 1, 0, 0},
                       {0, 0, 3, 2, 2, 1, 3, 1, 2, 1, 1, 2, 3, 2, 2, 1, 3, 0, 0},
                       {0, 0, 3, 2, 2, 1, 3, 2, 2, 1, 1, 1, 3, 2, 2, 1, 3, 0, 0},
                       {0, 1, 3, 2, 2, 1, 3, 2, 2, 1, 1, 1, 3, 2, 1, 1, 3, 1, 0},
                       {0, 1, 3, 2, 1, 1, 3, 2, 1, 1, 1, 1, 3, 2, 1, 1, 3, 1, 0},
                       {0, 1, 3, 1, 1, 1, 3, 1, 1, 1, 1, 1, 3, 1, 1, 1, 3, 1, 0},
                       {0, 1, 3, 1, 1, 1, 3, 1, 1, 1, 1, 1, 3, 1, 1, 1, 3, 1, 0},
                       {0, 1, 3, 1, 1, 1, 3, 1, 1, 1, 1, 1, 3, 1, 1, 2, 3, 1, 0},
                       {0, 1, 3, 1, 1, 1, 3, 1, 1, 1, 1, 1, 3, 1, 2, 2, 3, 1, 0},
                       {0, 2, 3, 1, 1, 1, 3, 1, 1, 1, 1, 1, 3, 1, 2, 1, 3, 1, 0},
                       {0, 2, 3, 1, 1, 1, 3, 1, 1, 1, 1, 1, 3, 1, 1, 1, 3, 1, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                };
                for (int j = 0; j < CryptWall.GetLength(0); j++)
                {
                    for (int i = 0; i < CryptWall.GetLength(1); i++)
                    {
                        switch (CryptWall[j, i])
                        {
                            case 0:
                                break;
                            case 1:
                                WorldGen.KillWall(CryptX + i, CryptY + j);
                                WorldGen.PlaceWall(CryptX + i, CryptY + j, WallID.Ebonwood);
                                break;
                            case 2:
                                WorldGen.KillWall(CryptX + i, CryptY + j);
                                WorldGen.PlaceWall(CryptX + i, CryptY + j, WallID.Bone);
                                WorldGen.paintWall(CryptX + i, CryptY + j, 27);
                                break;
                            case 3:
                                WorldGen.KillWall(CryptX + i, CryptY + j);
                                WorldGen.PlaceWall(CryptX + i, CryptY + j, WallID.PearlstoneBrick);
                                break;
                        }
                    }
                }
                WorldGen.PlaceTile(CryptX + 1, CryptY + 10, TileID.Platforms, false, false, -1, 16);
                WorldGen.PlaceTile(CryptX + 1, CryptY + 9, TileID.Books);
                WorldGen.PlaceTile(CryptX + 17, CryptY + 10, TileID.Platforms, false, false, -1, 16);
                WorldGen.PlaceTile(CryptX + 17, CryptY + 9, TileID.Books);
                WorldGen.PlaceTile(CryptX + 1, CryptY + 13, ModContent.TileType<Bone1>());
                WorldGen.PlaceTile(CryptX + 17, CryptY + 13, ModContent.TileType<Bone1>());
                WorldGen.Place3x1(CryptX + 10, CryptY + 13, (ushort)ModContent.TileType<Bone4>());
                WorldGen.Place3x2(CryptX + 3, CryptY + 13, TileID.Campfire, 2);
                WorldGen.Place3x2(CryptX + 15, CryptY + 13, TileID.Campfire, 2);
                WorldGen.Place2x2(CryptX + 13, CryptY + 13, TileID.CookingPots, 0);
                WorldGen.PlaceTile(CryptX + 9, CryptY + 2, TileID.Chandeliers, false, false, -1, 32);
                NPC.NewNPC(source, (CryptX + 11) * 16, (CryptY + 10) * 16, ModContent.NPCType<Necromant>());
                CryptIsSpawned = true;
            }
            #endregion
            if (!DownedNecromancer && CryptIsSpawned && !NPC.AnyNPCs(ModContent.NPCType<Necromant>()) && !NPC.AnyNPCs(ModContent.NPCType<EvilNecromancer>()))
                NPC.NewNPC(source, (TombstoneX + 2) * 16, (Main.maxTilesY / 3 + 10) * 16, ModContent.NPCType<Necromant>());
            if (MazeStartX != 0 && MazeStartY != 0 && !NPC.AnyNPCs(ModContent.NPCType<Minotaur>()) && !Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().downedMinotaur && DestroyedMaze && Main.player[Main.myPlayer].Center.ToTileCoordinates().X > MazeStartX && Main.player[Main.myPlayer].Center.ToTileCoordinates().X < MazeStartX + 58 && Main.player[Main.myPlayer].Center.ToTileCoordinates().Y > MazeStartY && Main.player[Main.myPlayer].Center.ToTileCoordinates().Y < MazeStartY + 57)
            {
                NPC.NewNPC(source, (MazeStartX + 6) * 16, (MazeStartY + 50) * 16, ModContent.NPCType<Minotaur>());
            }
            if (!NPC.AnyNPCs(ModContent.NPCType<BabaYaga>()) && !NPC.AnyNPCs(ModContent.NPCType<EvilBabaYaga>()) && Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest == 200 && !Main.LocalPlayer.GetModPlayer<BismuthPlayer>().downedWitch)
            {
                if (!Main.LocalPlayer.GetModPlayer<BismuthPlayer>().witchsecondatt)
                    Main.LocalPlayer.GetModPlayer<BismuthPlayer>().witchsecondatt = true;
                NPC.NewNPC(source, WitchSpawnX, WitchSpawnY, ModContent.NPCType<BabaYaga>());
            }
            if (Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest != 200 && !NPC.AnyNPCs(ModContent.NPCType<BabaYaga>()))
                NPC.NewNPC(source, WitchSpawnX, WitchSpawnY, ModContent.NPCType<BabaYaga>());
            #region Sunrise
            if (Main.LocalPlayer.GetModPlayer<Quests>().SunriseQuest == 100 && !SunriseIsPlaced)
            {
                WorldGen.PlaceTile(SunriseX, SunriseY, ModContent.TileType<SunrisePicture>());
                SunriseIsPlaced = true;
            }
            #endregion
            if (Main.LocalPlayer.GetModPlayer<Quests>().NewPriestQuest == 100 && !NPC.AnyNPCs(ModContent.NPCType<OldmanPriest>()))
                NPC.NewNPC(source,(Main.spawnTileX + 29) * 16, (Main.spawnTileY + 2) * 16 - 2, ModContent.NPCType<OldmanPriest>());
            if (!downedBanshee)
            {
                Main.tile[WaterTempleX + 9, WaterTempleY + 17].TileFrameX = 72;
                Main.tile[WaterTempleX + 40, WaterTempleY + 17].TileFrameX = 72;
                Main.tile[WaterTempleX + 19, WaterTempleY + 14].TileFrameX = 54;
                Main.tile[WaterTempleX + 19, WaterTempleY + 13].TileFrameX = 54;
                Main.tile[WaterTempleX + 18, WaterTempleY + 14].TileFrameX = 36;
                Main.tile[WaterTempleX + 18, WaterTempleY + 13].TileFrameX = 36;
                Main.tile[WaterTempleX + 32, WaterTempleY + 14].TileFrameX = 54;
                Main.tile[WaterTempleX + 32, WaterTempleY + 13].TileFrameX = 54;
                Main.tile[WaterTempleX + 31, WaterTempleY + 14].TileFrameX = 36;
                Main.tile[WaterTempleX + 31, WaterTempleY + 13].TileFrameX = 36;
            }
            else
            {
                Main.tile[WaterTempleX + 9, WaterTempleY + 17].TileFrameX = 0;
                Main.tile[WaterTempleX + 40, WaterTempleY + 17].TileFrameX = 0;
                Main.tile[WaterTempleX + 19, WaterTempleY + 14].TileFrameX = 18;
                Main.tile[WaterTempleX + 19, WaterTempleY + 13].TileFrameX = 18;
                Main.tile[WaterTempleX + 18, WaterTempleY + 14].TileFrameX = 0;
                Main.tile[WaterTempleX + 18, WaterTempleY + 13].TileFrameX = 0;
                Main.tile[WaterTempleX + 32, WaterTempleY + 14].TileFrameX = 18;
                Main.tile[WaterTempleX + 32, WaterTempleY + 13].TileFrameX = 18;
                Main.tile[WaterTempleX + 31, WaterTempleY + 14].TileFrameX = 0;
                Main.tile[WaterTempleX + 31, WaterTempleY + 13].TileFrameX = 0;
            }
        }
        public override void OnWorldLoad()
        {
            IsTotemActive = true;
            FirstTotemDeactivation = false;
            WitchSpawnX = 0;
            WitchSpawnY = 0;
            KilledBossesInWorld = 0;
            downedGolem = false;
            downedSkeletron = false;
            downedEoC = false;
            downedWoF = false;
            downedAnyMechBoss = false;
            downedPlantera = false;
            downedBanshee = false;
            WaterTempleX = 0;
            WaterTempleY = 0;
            MazeStartX = 0;
            MazeStartY = 0;
            CastleSpawnX = 0;
            CastleSpawnY = 0;
            TownTiles = new List<Vector2>();
            TownWalls = new List<Vector2>();
            DoorsRight = new List<Vector2>();
            DoorsLeft = new List<Vector2>();
            CasketCoords = new List<Vector2>();
            IsSwampSuccess = true;
            IsDesertSuccess = true;
            GeneratedCaslte = true;
            TombstoneX = 0;
            TombstoneY = 0;
            CryptIsSpawned = false;
            TotemX = 0;
            TotemY = 0;
            SunriseIsPlaced = false;
            OpenedRedChest = false;
            DestroyedMaze = false;
            OrcishInvasionStage = 0;
            FirstTotemDeactivation = false;
            DownedNecromancer = false;
            DownedPapuanWizard = false;
            DownedRhino = false;
            VampShop = new int[3] { 0, 0, 0 };
            SunriseX = 0;
            SunriseY = 0;
        }
        public override void ModifyWorldGenTasks(List<GenPass> tasks, ref double totalWeight)
        {
            int MicroBiomesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Micro Biomes"));
            int ShiniesIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Shinies"));
            if (ShiniesIndex == -1)
            {
                return;
            }
            tasks.Insert(ShiniesIndex + 1, new PassLegacy("Generating more vanilla ores", delegate (GenerationProgress progress, GameConfiguration configuration)
            {
                progress.Message = "Generating more vanilla ores";
                #region Mod Ores
                int aluminium = ModContent.TileType<AluminiumOre>();
                int cinnabar = ModContent.TileType<Content.Tiles.Cinnabar>();
                for (int n = 0; n < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 3E-05); n++)
                {
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceLow, (int)GenVars.worldSurfaceHigh), (double)WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(2, 5), aluminium, false, 0f, 0f, false, true);
                }
                for (int num = 0; num < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 8E-05); num++)
                {
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceHigh, (int)GenVars.rockLayerHigh), (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), aluminium, false, 0f, 0f, false, true);
                }
                for (int num2 = 0; num2 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0002); num2++)
                {
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY), (double)WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), aluminium, false, 0f, 0f, false, true);
                }
                for (int num = 0; num < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 8E-05 / 2); num++)
                {
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceHigh, (int)GenVars.rockLayerHigh), (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), cinnabar, false, 0f, 0f, false, true);
                }
                for (int num2 = 0; num2 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0002); num2++)
                {
                    WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY), (double)WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), cinnabar, false, 0f, 0f, false, true);
                }
                #endregion
                #region More Vanilla Ores
                bool CopperInWorld, TinInWorld, IronInWorld, LeadInWorld, SilverInWorld, TungstenInWorld, GoldInWorld, PlatinumInWorld = CopperInWorld = TinInWorld = IronInWorld = LeadInWorld = SilverInWorld = TungstenInWorld = GoldInWorld = false;
                for (int x = 0; x < Main.maxTilesX; x++)
                {
                    for (int y = 0; y < Main.maxTilesY; y++)
                    {
                        if (Main.tile[x, y].TileType == TileID.Copper)
                        {
                            CopperInWorld = true;
                        }
                        else
                            TinInWorld = true;
                        if (Main.tile[x, y].TileType == TileID.Iron)
                        {
                            IronInWorld = true;
                        }
                        else
                            LeadInWorld = true;

                        if (Main.tile[x, y].TileType == TileID.Silver)
                        {
                            SilverInWorld = true;
                        }
                        else
                            TungstenInWorld = true;

                        if (Main.tile[x, y].TileType == TileID.Gold)
                        {
                            GoldInWorld = true;
                        }
                        else
                            PlatinumInWorld = true;
                        if (x == Main.maxTilesX && y == Main.maxTilesY) break;
                    }
                }
                if (CopperInWorld)
                {
                    for (int n = 0; n < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); n++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceLow, (int)GenVars.worldSurfaceHigh), (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), TileID.Tin, false, 0f, 0f, false, true);
                    }
                    for (int l = 0; l < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 8E-05); l++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceHigh, (int)GenVars.rockLayerHigh), (double)WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(3, 7), TileID.Tin, false, 0f, 0f, false, true);
                    }
                    for (int m = 0; m < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0002); m++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY), (double)WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), TileID.Tin, false, 0f, 0f, false, true);
                    }
                }
                if (TinInWorld)
                {
                    for (int n = 0; n < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 6E-05); n++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceLow, (int)GenVars.worldSurfaceHigh), (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(2, 6), TileID.Copper, false, 0f, 0f, false, true);
                    }
                    for (int l = 0; l < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 8E-05); l++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceHigh, (int)GenVars.rockLayerHigh), (double)WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(3, 7), TileID.Copper, false, 0f, 0f, false, true);
                    }
                    for (int m = 0; m < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0002); m++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY), (double)WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), TileID.Copper, false, 0f, 0f, false, true);
                    }
                }
                if (IronInWorld)
                {
                    for (int n = 0; n < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 3E-05); n++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceLow, (int)GenVars.worldSurfaceHigh), (double)WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(2, 5), TileID.Lead, false, 0f, 0f, false, true);
                    }
                    for (int num = 0; num < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 8E-05); num++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceHigh, (int)GenVars.rockLayerHigh), (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), TileID.Lead, false, 0f, 0f, false, true);
                    }
                    for (int num2 = 0; num2 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0002); num2++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY), (double)WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), TileID.Lead, false, 0f, 0f, false, true);
                    }
                }
                if (LeadInWorld)
                {
                    for (int n = 0; n < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 3E-05); n++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceLow, (int)GenVars.worldSurfaceHigh), (double)WorldGen.genRand.Next(3, 7), WorldGen.genRand.Next(2, 5), TileID.Iron, false, 0f, 0f, false, true);
                    }
                    for (int num = 0; num < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 8E-05); num++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceHigh, (int)GenVars.rockLayerHigh), (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), TileID.Iron, false, 0f, 0f, false, true);
                    }
                    for (int num2 = 0; num2 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.0002); num2++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY), (double)WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), TileID.Iron, false, 0f, 0f, false, true);
                    }
                }
                if (SilverInWorld)
                {
                    for (int num3 = 0; num3 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 2.6E-05); num3++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceHigh, (int)GenVars.rockLayerHigh), (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), TileID.Tungsten, false, 0f, 0f, false, true);
                    }
                    for (int num4 = 0; num4 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00015); num4++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY), (double)WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), TileID.Tungsten, false, 0f, 0f, false, true);
                    }
                    for (int num5 = 0; num5 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00017); num5++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, (int)GenVars.worldSurfaceLow), (double)WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), TileID.Tungsten, false, 0f, 0f, false, true);
                    }
                }
                if (TungstenInWorld)
                {
                    for (int num3 = 0; num3 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 2.6E-05); num3++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.worldSurfaceHigh, (int)GenVars.rockLayerHigh), (double)WorldGen.genRand.Next(3, 6), WorldGen.genRand.Next(3, 6), TileID.Silver, false, 0f, 0f, false, true);
                    }
                    for (int num4 = 0; num4 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00015); num4++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY), (double)WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), TileID.Silver, false, 0f, 0f, false, true);
                    }
                    for (int num5 = 0; num5 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00017); num5++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, (int)GenVars.worldSurfaceLow), (double)WorldGen.genRand.Next(4, 9), WorldGen.genRand.Next(4, 8), TileID.Silver, false, 0f, 0f, false, true);
                    }
                }
                if (GoldInWorld)
                {
                    for (int num6 = 0; num6 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00012); num6++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY), (double)WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), TileID.Platinum, false, 0f, 0f, false, true);
                    }
                    for (int num7 = 0; num7 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00012); num7++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, (int)GenVars.worldSurfaceLow - 20), (double)WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), TileID.Platinum, false, 0f, 0f, false, true);
                    }
                }
                if (PlatinumInWorld)
                {
                    for (int num6 = 0; num6 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00012); num6++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next((int)GenVars.rockLayerLow, Main.maxTilesY), (double)WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), TileID.Gold, false, 0f, 0f, false, true);
                    }
                    for (int num7 = 0; num7 < (int)((double)(Main.maxTilesX * Main.maxTilesY) * 0.00012); num7++)
                    {
                        WorldGen.TileRunner(WorldGen.genRand.Next(0, Main.maxTilesX), WorldGen.genRand.Next(0, (int)GenVars.worldSurfaceLow - 20), (double)WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), TileID.Gold, false, 0f, 0f, false, true);
                    }
                }
                #endregion

            }));
            int WaterTempleCleanX = 0;
            int WaterTempleCleanY = 0;
            int GravitatingSand = tasks.FindIndex(genpass => genpass.Name.Equals("Gravitating Sand"));
            if (ModLoader.TryGetMod("Remnants", out Mod Remnants))
            {
                DesertPitSetting = 75;
            }
            else
            {
                tasks.Insert(GravitatingSand + 1, new PassLegacy("Initializing", delegate (GenerationProgress progress, GameConfiguration configuration)
                {
                    int x = 0;
                    int y = 0;
                    while (!WorldMethods.CheckLiquid(x, y, 255))
                        y++;
                    while (!WorldGen.SolidTile(x, y))
                        x++;
                    BeachEndLeft = x;
                    x = Main.maxTilesX - 1;
                    y = 0;
                    while (!WorldMethods.CheckLiquid(x, y, 255))
                        y++;
                    while (!WorldGen.SolidTile(x, y))
                        x--;
                    BeachEndRight = x;
                }));
            }
            int WaterTempleIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Surface Chests"));
            tasks.Insert(WaterTempleIndex + 1, new PassLegacy("Generating Water Temple", delegate (GenerationProgress progress, GameConfiguration configuration)
            {
                int TempleSide = Main.rand.Next(0, 2);

                WaterTempleX = TempleSide == 0 ? 80 : Main.maxTilesX - 100;
                WaterTempleY = 0;
                while (!WorldGen.SolidTile(WaterTempleX, WaterTempleY))
                    WaterTempleY++;
                WaterTempleY -= 21;
                WaterTempleCleanX = WaterTempleX;
                WaterTempleCleanY = WaterTempleY;
                int[,] WaterTempleTile = new int[,]
                {  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 4, 4, 0, 0, 4, 4, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 6, 6, 3, 3, 6, 6, 6, 6, 3, 3, 6, 6, 6, 6, 3, 3, 6, 6, 6, 6, 3, 3, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 6, 6, 0, 0, 6, 0, 6, 6, 0, 0, 6, 6, 0, 6, 0, 0, 6, 6, 0, 6, 0, 0, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 6, 6, 4, 4, 6, 0, 0, 0, 4, 4, 6, 0, 0, 6, 4, 4, 6, 0, 0, 0, 4, 4, 6, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 6, 6, 6, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 6, 0, 0, 0, 0, 0, 7, 7, 7, 0, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 7, 6, 7, 0, 0, 7, 6, 7, 0, 0, 0, 7, 6, 0, 0, 0, 0, 6, 6, 0, 0, 6, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 7, 0, 0, 7, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 7, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 7, 7, 0, 0, 0, 0, 0, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 7, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 4, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 4, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 4, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 1, 1, 4, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 4, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 4, 0, 0, 0, 0, 0, 0},
                   {1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 4, 8, 0, 0, 8, 0, 0, 8, 0, 0, 8, 0, 0, 8, 0, 0, 8, 0, 0, 8, 0, 0, 8, 0, 0, 8, 0, 0, 8, 4, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 0, 0, 0},
                   {9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9},
                   {9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9},
                   {9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9},
                   {9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9},
                   {9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9},
                   {9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9},
                   {9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9},
                };
                for (int j = 0; j < WaterTempleTile.GetLength(0); j++)
                {
                    for (int i = 0; i < WaterTempleTile.GetLength(1); i++)
                    {
                        switch (WaterTempleTile[j, i])
                        {
                            case 0:
                                WorldGen.KillTile(WaterTempleX + i, WaterTempleY + j);
                                Main.tile[WaterTempleX + i, WaterTempleY + j].LiquidAmount = 0;
                                break;
                            case 1:
                                WorldGen.KillTile(WaterTempleX + i, WaterTempleY + j);
                                WorldGen.PlaceTile(WaterTempleX + i, WaterTempleY + j, TileID.PearlstoneBrick);
                                Main.tile[WaterTempleX + i, WaterTempleY + j].LiquidAmount = 0;
                                break;
                            case 2:
                                WorldGen.KillTile(WaterTempleX + i, WaterTempleY + j);
                                WorldGen.PlaceTile(WaterTempleX + i, WaterTempleY + j, TileID.GrayBrick);
                                Main.tile[WaterTempleX + i, WaterTempleY + j].LiquidAmount = 0;
                                break;
                            case 3:
                                WorldGen.KillTile(WaterTempleX + i, WaterTempleY + j);
                                WorldGen.PlaceTile(WaterTempleX + i, WaterTempleY + j, TileID.PlatinumBrick);
                                Main.tile[WaterTempleX + i, WaterTempleY + j].LiquidAmount = 0;
                                break;
                            case 4:
                                WorldGen.KillTile(WaterTempleX + i, WaterTempleY + j);
                                WorldGen.PlaceTile(WaterTempleX + i, WaterTempleY + j, TileID.TeamBlockWhitePlatform);
                                Main.tile[WaterTempleX + i, WaterTempleY + j].LiquidAmount = 0;
                                break;
                            case 5:
                                WorldGen.KillTile(WaterTempleX + i, WaterTempleY + j);
                                WorldGen.PlaceTile(WaterTempleX + i, WaterTempleY + j, TileID.Platforms, false, false, -1, 1);
                                Main.tile[WaterTempleX + i, WaterTempleY + j].LiquidAmount = 0;
                                break;
                            case 6:
                                WorldGen.KillTile(WaterTempleX + i, WaterTempleY + j);
                                WorldGen.PlaceTile(WaterTempleX + i, WaterTempleY + j, TileID.LeafBlock);
                                WorldGen.paintTile(WaterTempleX + i, WaterTempleY + j, 4);
                                Main.tile[WaterTempleX + i, WaterTempleY + j].LiquidAmount = 0;
                                break;
                            case 7:
                                WorldGen.KillTile(WaterTempleX + i, WaterTempleY + j);
                                WorldGen.PlaceTile(WaterTempleX + i, WaterTempleY + j, TileID.LeafBlock);
                                Main.tile[WaterTempleX + i, WaterTempleY + j].LiquidAmount = 0;
                                Tile WaterTemple = Main.tile[WaterTempleX + i, WaterTempleY + j];
                                WaterTemple.IsActuated = true;
                                WorldGen.paintTile(WaterTempleX + i, WaterTempleY + j, 4);
                                break;
                            case 8:
                                WorldGen.KillTile(WaterTempleX + i, WaterTempleY + j);
                                WorldGen.PlaceTile(WaterTempleX + i, WaterTempleY + j, TileID.Chain);
                                Main.tile[WaterTempleX + i, WaterTempleY + j].LiquidAmount = 0;
                                break;
                            case 9:
                                WorldGen.KillTile(WaterTempleX + i, WaterTempleY + j);
                                WorldGen.PlaceTile(WaterTempleX + i, WaterTempleY + j, TileID.Sand);
                                break;
                        }
                    }
                }
                int[,] WaterTempleWall = new int[,]
                {  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 9, 9, 9, 9, 9, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 4, 5, 5, 4, 8, 8, 4, 5, 5, 4, 8, 8, 4, 5, 5, 4, 8, 8, 4, 5, 5, 4, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 8, 6, 6, 1, 8, 8, 8, 6, 6, 8, 8, 8, 8, 6, 6, 7, 7, 8, 8, 6, 6, 8, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 1, 6, 6, 8, 8, 7, 7, 6, 6, 7, 7, 8, 1, 6, 6, 1, 7, 1, 8, 6, 6, 8, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 7, 6, 6, 8, 1, 7, 1, 6, 6, 7, 1, 1, 1, 6, 6, 1, 1, 1, 8, 6, 6, 1, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 1, 6, 6, 1, 1, 1, 1, 6, 6, 1, 1, 1, 1, 6, 6, 1, 1, 1, 1, 6, 6, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 6, 6, 1, 1, 1, 1, 6, 6, 1, 1, 1, 1, 6, 6, 1, 1, 1, 1, 6, 6, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 6, 6, 1, 1, 1, 1, 6, 6, 1, 1, 1, 1, 6, 6, 1, 1, 1, 1, 6, 6, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 6, 6, 1, 1, 1, 1, 6, 6, 1, 1, 1, 1, 6, 6, 1, 1, 1, 1, 6, 6, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 6, 6, 1, 1, 1, 1, 6, 6, 1, 1, 1, 1, 6, 6, 1, 1, 1, 1, 6, 6, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 6, 6, 1, 1, 1, 1, 6, 6, 1, 1, 1, 1, 6, 6, 1, 1, 1, 1, 6, 6, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 6, 6, 1, 1, 1, 1, 6, 6, 1, 1, 1, 1, 6, 6, 1, 1, 1, 1, 6, 6, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 3, 4, 5, 5, 4, 3, 3, 4, 5, 5, 4, 3, 3, 4, 5, 5, 4, 3, 3, 4, 5, 5, 4, 3, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                };
                for (int j = 0; j < WaterTempleWall.GetLength(0); j++)
                {
                    for (int i = 0; i < WaterTempleWall.GetLength(1); i++)
                    {
                        switch (WaterTempleWall[j, i])
                        {
                            case 0:
                                WorldGen.KillWall(WaterTempleX + i, WaterTempleY + j);
                                break;
                            case 1:
                                WorldGen.KillWall(WaterTempleX + i, WaterTempleY + j);
                                WorldGen.PlaceWall(WaterTempleX + i, WaterTempleY + j, WallID.PearlstoneBrick);
                                Main.tile[WaterTempleX + i, WaterTempleY + j].LiquidAmount = 0;
                                break;
                            case 2:
                                WorldGen.KillWall(WaterTempleX + i, WaterTempleY + j);
                                WorldGen.PlaceWall(WaterTempleX + i, WaterTempleY + j, WallID.Ebonwood);
                                Main.tile[WaterTempleX + i, WaterTempleY + j].LiquidAmount = 0;
                                break;
                            case 3:
                                WorldGen.KillWall(WaterTempleX + i, WaterTempleY + j);
                                WorldGen.PlaceWall(WaterTempleX + i, WaterTempleY + j, WallID.GrayBrick);
                                Main.tile[WaterTempleX + i, WaterTempleY + j].LiquidAmount = 0;
                                break;
                            case 4:
                                WorldGen.KillWall(WaterTempleX + i, WaterTempleY + j);
                                WorldGen.PlaceWall(WaterTempleX + i, WaterTempleY + j, WallID.PlatinumBrick);
                                Main.tile[WaterTempleX + i, WaterTempleY + j].LiquidAmount = 0;
                                break;
                            case 5:
                                WorldGen.KillWall(WaterTempleX + i, WaterTempleY + j);
                                WorldGen.PlaceWall(WaterTempleX + i, WaterTempleY + j, WallID.PlatinumBrick);
                                WorldGen.paintWall(WaterTempleX + i, WaterTempleY + j, 26);
                                Main.tile[WaterTempleX + i, WaterTempleY + j].LiquidAmount = 0;
                                break;
                            case 6:
                                WorldGen.KillWall(WaterTempleX + i, WaterTempleY + j);
                                WorldGen.PlaceWall(WaterTempleX + i, WaterTempleY + j, WallID.Ebonwood);
                                WorldGen.paintWall(WaterTempleX + i, WaterTempleY + j, 27);
                                Main.tile[WaterTempleX + i, WaterTempleY + j].LiquidAmount = 0;
                                break;
                            case 7:
                                WorldGen.KillWall(WaterTempleX + i, WaterTempleY + j);
                                WorldGen.PlaceWall(WaterTempleX + i, WaterTempleY + j, WallID.Stone);
                                Main.tile[WaterTempleX + i, WaterTempleY + j].LiquidAmount = 0;
                                break;
                            case 8:
                                WorldGen.KillWall(WaterTempleX + i, WaterTempleY + j);
                                WorldGen.PlaceWall(WaterTempleX + i, WaterTempleY + j, WallID.Jungle);
                                Main.tile[WaterTempleX + i, WaterTempleY + j].LiquidAmount = 0;
                                break;
                            case 9:
                                WorldGen.KillWall(WaterTempleX + i, WaterTempleY + j);
                                WorldGen.PlaceWall(WaterTempleX + i, WaterTempleY + j, WallID.MarbleBlock);
                                Main.tile[WaterTempleX + i, WaterTempleY + j].LiquidAmount = 0;
                                break;
                        }
                    }

                }
                int[,] WaterTempleSlope = new int[,]
                {  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 2, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 2, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 2, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 2, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                };
                for (int j = 0; j < WaterTempleSlope.GetLength(0); j++)
                {
                    for (int i = 0; i < WaterTempleSlope.GetLength(1); i++)
                    {
                        switch (WaterTempleSlope[j, i])
                        {
                            case 0:
                                break;
                            case 1:
                                WorldGen.SlopeTile(WaterTempleX + i, WaterTempleY + j, 1);
                                break;
                            case 2:
                                WorldGen.SlopeTile(WaterTempleX + i, WaterTempleY + j, 2);
                                break;
                            case 3:
                                WorldGen.SlopeTile(WaterTempleX + i, WaterTempleY + j, 3);
                                break;
                            case 4:
                                WorldGen.SlopeTile(WaterTempleX + i, WaterTempleY + j, 4);
                                break;
                            case 5:
                                Tile WaterTemple = Main.tile[WaterTempleX + i, WaterTempleY + j];
                                WaterTemple.IsHalfBlock = true;
                                break;
                        }
                    }
                }
                WorldGen.PlaceObject(WaterTempleX + 23, WaterTempleY + 17, ModContent.TileType<AltarOfWaters>());
                WorldGen.Place1xX(WaterTempleX + 4, WaterTempleY + 20, TileID.ClosedDoor, 35);
                WorldGen.Place1xX(WaterTempleX + 12, WaterTempleY + 17, TileID.ClosedDoor, 35);
                WorldGen.Place1xX(WaterTempleX + 37, WaterTempleY + 17, TileID.ClosedDoor, 35);
                WorldGen.Place1xX(WaterTempleX + 45, WaterTempleY + 20, TileID.ClosedDoor, 35);
                WorldGen.Place2x1(WaterTempleX + 15, WaterTempleY + 20, TileID.WorkBenches, 30);
                WorldGen.Place2x1(WaterTempleX + 21, WaterTempleY + 20, TileID.WorkBenches, 30);
                WorldGen.Place2x1(WaterTempleX + 27, WaterTempleY + 20, TileID.WorkBenches, 30);
                WorldGen.Place2x1(WaterTempleX + 33, WaterTempleY + 20, TileID.WorkBenches, 30);
                WorldGen.Place2x1(WaterTempleX + 15, WaterTempleY + 6, TileID.WorkBenches, 30);
                WorldGen.Place2x1(WaterTempleX + 21, WaterTempleY + 6, TileID.WorkBenches, 30);
                WorldGen.Place2x1(WaterTempleX + 27, WaterTempleY + 6, TileID.WorkBenches, 30);
                WorldGen.Place2x1(WaterTempleX + 33, WaterTempleY + 6, TileID.WorkBenches, 30);
                WorldGen.Place2x2(WaterTempleX + 19, WaterTempleY + 14, TileID.Candelabras, 6);
                WorldGen.Place2x2(WaterTempleX + 32, WaterTempleY + 14, TileID.Candelabras, 6);
                WorldGen.PlaceTile(WaterTempleX + 9, WaterTempleY + 17, TileID.Torches, false, false, -1, 5);
                WorldGen.PlaceTile(WaterTempleX + 40, WaterTempleY + 17, TileID.Torches, false, false, -1, 5);
                WorldGen.PlaceTile(WaterTempleX + 15, WaterTempleY + 17, TileID.Statues, false, false, -1, 36);
                WorldGen.PlaceTile(WaterTempleX + 33, WaterTempleY + 17, TileID.Statues, false, false, -1, 36);
            }));
            tasks.Insert(MicroBiomesIndex + 1, new PassLegacy("Cleaning Water Temple", delegate (GenerationProgress progress, GameConfiguration configuration)
            {
                int[,] WaterTempleClean = new int[,]
                {  {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0},
                   {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, };
                for (int j = 0; j < WaterTempleClean.GetLength(0); j++)
                {
                    for (int i = 0; i < WaterTempleClean.GetLength(1); i++)
                    {
                        switch (WaterTempleClean[j, i])
                        {
                            case 0:
                                break;
                            case 1:
                                WorldGen.KillTile(WaterTempleCleanX + i, WaterTempleCleanY + j);
                                break;
                        }
                    }
                }
            }));
            int IceIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Jungle Chests"));
            tasks.Insert(IceIndex + 1, new PassLegacy("Generating swamp", delegate (GenerationProgress progress, GameConfiguration configuration)
            {
                progress.Message = "Generating swamp";
                if (Main.maxTilesX == 4200)
                    WorldSize = 1;
                else if (Main.maxTilesX == 6300)
                    WorldSize = 2;
                else if (Main.maxTilesX == 8400)
                    WorldSize = 3;

                int failcount = 0;
            #region Searching
            IL_19:
                if (failcount > 50000)
                {
                    IsSwampSuccess = false;
                    goto IL_20;
                }
                SwampStartX = WorldGen.genRand.Next(BeachEndLeft, BeachEndRight - (Main.maxTilesX / 20));
                SwampStartY = (int)GenVars.worldSurfaceLow;
                while (!WorldGen.SolidTile(SwampStartX, SwampStartY))
                {
                    SwampStartY++;
                    if (SwampStartY == Main.maxTilesY)
                        break;
                }
                int EndX = SwampStartX + (Main.maxTilesX / 20);
                if (EndX > Main.spawnTileX - 120)
                {
                    if (SwampStartX < Main.spawnTileX + 120)
                    {
                        failcount++;
                        goto IL_19;
                    }

                }
                SwampCenterX = SwampStartX + ((Main.maxTilesX / 20) / 2);
                int CenterY = (int)GenVars.worldSurfaceLow;
                int EndY = (int)GenVars.worldSurfaceLow;
                while (!WorldGen.SolidTile(SwampCenterX, CenterY))
                {
                    CenterY++;
                    if (CenterY == Main.maxTilesY)
                        break;
                }
                while (!WorldGen.SolidTile(EndX, EndY))
                {
                    EndY++;
                    if (EndY == Main.maxTilesY)
                        break;
                }
                for (int i = 0; i < (Main.maxTilesX / 20); i++)
                {
                    for (int j = 0; j < (Main.maxTilesX / 20) / 2; j++)
                    {
                        if (Main.tile[SwampStartX + i, SwampStartY - 30 + j].TileType == TileID.IceBlock || Main.tile[SwampStartX + i, SwampStartY - 30 + j].TileType == TileID.SnowBlock || Main.tile[SwampStartX + i, SwampStartY - 30 + j].TileType == TileID.BlueDungeonBrick || Main.tile[SwampStartX + i, SwampStartY - 30 + j].TileType == TileID.GreenDungeonBrick || Main.tile[SwampStartX + i, SwampStartY - 30 + j].TileType == TileID.PinkDungeonBrick || Main.tile[SwampStartX + i, SwampStartY - 30 + j].TileType == TileID.Cloud || Main.tile[SwampStartX + i, SwampStartY - 30 + j].TileType == TileID.RainCloud || Main.tile[SwampStartX + i, SwampStartY - 30 + j].TileType == TileID.Ebonstone || Main.tile[SwampStartX + i, SwampStartY - 30 + j].TileType == TileID.Crimstone || Main.tile[SwampStartX + i, SwampStartY - 30 + j].TileType == TileID.SandstoneBrick || Main.tile[SwampStartX + i, SwampStartY - 30 + j].TileType == TileID.HardenedSand || Main.tile[SwampStartX + i, SwampStartY - 30 + j].TileType == TileID.Mud || Main.tile[SwampStartX + i, SwampStartY - 30 + j].TileType == TileID.LivingWood || Main.tile[SwampStartX + i, SwampStartY - 30 + j].TileType == TileID.LeafBlock)
                        {
                            failcount++;
                            goto IL_19;
                        }
                    }
                }
                #endregion
                #region SwampBase
                int LowestPointX = SwampCenterX;
                int LowestPointY = CenterY + (Main.maxTilesX / 20) / 2 + 30;
                int RightBetweenPointX = EndX - ((Main.maxTilesX / 20) / 6);
                int RightBetweenPointY = LowestPointY - 30 * WorldSize + 15;
                int LeftBetweenPointX = SwampStartX + ((Main.maxTilesX / 20) / 6);
                int LeftBetweenPointY = RightBetweenPointY;
                ushort swamptile = (ushort)ModContent.TileType<SwampMud>();
                ushort swampwall = (ushort)ModContent.WallType<SwampWall>();
                for (int i = 0; i < (Main.maxTilesX / 20) / 2; i++)
                {
                    WorldMethods.BresenhamLineSandOverride(LeftBetweenPointX, LeftBetweenPointY - i, RightBetweenPointX, RightBetweenPointY - i, swamptile);
                    WorldMethods.BresenhamLineTile(LeftBetweenPointX, LeftBetweenPointY - i, RightBetweenPointX, RightBetweenPointY - i, 5, swamptile, 5);
                }
                for (int i = 0; i < (Main.maxTilesX / 20) / 2; i++)
                {
                    WorldMethods.BresenhamLineSandOverride(LeftBetweenPointX, LeftBetweenPointY - i, LowestPointX, LowestPointY - i, swamptile);
                    WorldMethods.BresenhamLineTile(LeftBetweenPointX, LeftBetweenPointY - i, LowestPointX, LowestPointY - i, 5, swamptile, 5);
                }
                for (int i = 0; i < (Main.maxTilesX / 20) / 2; i++)
                {
                    WorldMethods.BresenhamLineSandOverride(RightBetweenPointX, RightBetweenPointY - i, LowestPointX, LowestPointY - i, swamptile);
                    WorldMethods.BresenhamLineTile(RightBetweenPointX, RightBetweenPointY - i, LowestPointX, LowestPointY - i, 5, swamptile, 5);
                }
                for (int i = 0; i < (Main.maxTilesX / 20) / 2; i++)
                {
                    WorldMethods.BresenhamLineSandOverride(SwampStartX + i, SwampStartY, LeftBetweenPointX + i, LeftBetweenPointY, swamptile);
                    WorldMethods.BresenhamLineTile(SwampStartX + i, SwampStartY, LeftBetweenPointX + i, LeftBetweenPointY, 5, swamptile, 5);
                }
                for (int i = 0; i < (Main.maxTilesX / 20) / 2; i++)
                {
                    WorldMethods.BresenhamLineSandOverride(EndX - i, EndY, RightBetweenPointX - i, RightBetweenPointY, swamptile);
                    WorldMethods.BresenhamLineTile(EndX - i, EndY, RightBetweenPointX - i, RightBetweenPointY, 5, swamptile, 5);
                }
                for (int i = 0; i < (Main.maxTilesX / 20) / 2; i++)
                {
                    WorldMethods.BresenhamLineSandOverride(SwampStartX + i, EndY, LeftBetweenPointX + i, LeftBetweenPointY, swamptile);
                    WorldMethods.BresenhamLineTile(SwampStartX + i, EndY, LeftBetweenPointX + i, LeftBetweenPointY, 5, swamptile, 5);
                }
                for (int i = 0; i < (Main.maxTilesX / 20) / 2; i++)
                {
                    WorldMethods.BresenhamLineSandOverride(EndX - i, SwampStartY, RightBetweenPointX - i, RightBetweenPointY, swamptile);
                    WorldMethods.BresenhamLineTile(EndX - i, SwampStartY, RightBetweenPointX - i, RightBetweenPointY, 5, swamptile, 5);
                }
                #endregion
                #region Walls
                for (int i = 0; i < Main.maxTilesX; i++)
                {
                    for (int j = 0; j < Main.maxTilesY; j++)
                    {
                        if (WorldMethods.CheckTile(i, j, swamptile))
                        {
                            WorldGen.KillWall(i, j);
                            WorldGen.PlaceWall(i, j, swampwall);
                        }
                    }
                }
                WorldMethods.BresenhamLineKillWall(SwampStartX, SwampStartY, EndX, EndY);
                for (int i = 0; i < 100; i++)
                {
                    WorldMethods.BresenhamLineTunnel(SwampStartX, SwampStartY - i, EndX, EndY - i, 1);
                    if (SwampStartY - i - 5 < 0 || EndY - i - 5 < 0)
                        break;
                }
                for (int i = 0; i < 100; i++)
                {
                    WorldMethods.BresenhamLineKillWall(SwampStartX, SwampStartY + 6 - i, EndX, EndY + 6 - i);
                    if (SwampStartY - i - 5 < 0 || EndY - i - 5 < 0)
                        break;
                }
                if (EndY >= SwampStartY)
                {
                    for (int i = SwampStartX; i < EndX; i++)
                    {
                        for (int j = SwampStartY; j > 0; j--)
                        {
                            if (Main.tile[i, j].HasTile && Main.tile[i, j].TileType == swamptile)
                                WorldGen.KillTile(i, j);
                            if (Main.tile[i, j].WallType == ModContent.WallType<SwampWall>())
                                WorldGen.KillWall(i, j);
                        }
                    }

                }
                else
                {
                    for (int i = SwampStartX; i < EndX; i++)
                    {
                        for (int j = EndY; j > 0; j--)
                        {
                            if (Main.tile[i, j].HasTile && Main.tile[i, j].TileType == swamptile)
                                WorldGen.KillTile(i, j);
                            if (Main.tile[i, j].WallType == ModContent.WallType<SwampWall>())
                                WorldGen.KillWall(i, j);
                        }
                    }
                }
                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        if (Main.tile[EndX + 1 + i, EndY - 50 + j].HasTile && Main.tile[EndX + 1 + i, EndY - 50 + j].TileType == swamptile)
                            WorldGen.KillTile(EndX + 1 + i, EndY - 50 + j);
                        if (Main.tile[EndX + 1 + i, EndY - 50 + j].WallType == ModContent.WallType<SwampWall>())
                            WorldGen.KillWall(EndX + 1 + i, EndY - 50 + j);
                    }
                }
                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        if (Main.tile[SwampStartX - 1 - i, EndY - 50 + j].HasTile && Main.tile[SwampStartX - 1 - i, EndY - 50 + j].TileType == swamptile)
                            WorldGen.KillTile(SwampStartX - 1 - i, EndY - 50 + j);
                        if (Main.tile[SwampStartX - 1 - i, EndY - 50 + j].WallType == ModContent.WallType<SwampWall>())
                            WorldGen.KillWall(SwampStartX - 1 - i, EndY - 50 + j);
                    }
                }
                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        if (WorldMethods.CheckTile(SwampStartX - 6 - i, j, swamptile))
                            WorldGen.KillTile(SwampStartX - 6 - i, j);
                        if (WorldMethods.CheckWall(SwampStartX - 6 - i, j, swampwall))
                            WorldGen.KillWall(SwampStartX - 6 - i, j);
                    }
                }
                for (int i = 0; i < 12; i++)
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        if (WorldMethods.CheckTile(EndX + 6 + i, j, swamptile))
                            WorldGen.KillTile(EndX + 6 + i, j);
                        if (WorldMethods.CheckWall(EndX + 6 + i, j, swampwall))
                            WorldGen.KillWall(EndX + 6 + i, j);
                    }
                }
                for (int i = 0; i < 100; i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        if (Main.tile[SwampStartX - 1 - i, EndY - 50 + j].HasTile && Main.tile[SwampStartX - 1 - i, EndY - 50 + j].TileType == swamptile)
                            WorldGen.KillTile(SwampStartX - 1 - i, EndY - 50 + j);
                        if (Main.tile[SwampStartX - 1 - i, EndY - 50 + j].WallType == ModContent.WallType<SwampWall>())
                            WorldGen.KillWall(SwampStartX - 1 - i, EndY - 50 + j);
                    }
                }
                #endregion
                #region PeatGeneration
                for (int k = 0; k < 175; k++)
                {
                    int Xo = SwampStartX + Main.rand.Next(0, (Main.maxTilesX / 20));
                    int Yo = SwampStartY + Main.rand.Next(0, (Main.maxTilesX / 20));
                    if (Main.tile[Xo, Yo].TileType == ModContent.TileType<SwampMud>())
                    {
                        {
                            WorldGen.TileRunner(Xo, Yo, (double)WorldGen.genRand.Next(4, 8), WorldGen.genRand.Next(4, 8), ModContent.TileType<PeatBlock>(), false, 0f, 0f, false, true);
                        }
                    }
                }
                #endregion
                #region SwampCaves
                int CavesStartX = SwampCenterX;
                int CavesStartY = (int)GenVars.worldSurfaceLow; ;
                while (!WorldGen.SolidTile(CavesStartX, CavesStartY))
                    CavesStartY++;
                int FirstPointX = CavesStartX + Main.rand.Next(-10, 10);
                int FirstPointY = CavesStartY + Main.rand.Next(20, 30);
                WorldMethods.BresenhamLineTunnel(CavesStartX, CavesStartY, FirstPointX, FirstPointY, Main.rand.Next(3, 5));
                int SecondPointX = Main.rand.Next(0, 2) == 0 ? FirstPointX + Main.rand.Next(20, 30) : FirstPointX - Main.rand.Next(20, 30);
                int SecondPointY = FirstPointY + Main.rand.Next(10, 15);
                WorldMethods.BresenhamLineTunnel(FirstPointX, FirstPointY, SecondPointX, SecondPointY, Main.rand.Next(2, 4));
                int ThirdPointX = SecondPointX > CavesStartX ? SecondPointX - Main.rand.Next(6, 12) : SecondPointX + Main.rand.Next(6, 12);
                int ThirdPointY = SecondPointY + Main.rand.Next(10, 20);
                WorldMethods.BresenhamLineTunnel(SecondPointX, SecondPointY, ThirdPointX, ThirdPointY, Main.rand.Next(2, 3));
                int FourthPointX = ThirdPointX + Main.rand.Next(15, 20);
                int FourthPointY = ThirdPointY + Main.rand.Next(10, 15);
                int FifthPointX = ThirdPointX - (FourthPointX - ThirdPointX);
                int FifthPointY = ThirdPointY + Main.rand.Next(10, 15);
                WorldMethods.BresenhamLineTunnel(ThirdPointX, ThirdPointY, FourthPointX, FourthPointY, Main.rand.Next(2, 3));
                WorldMethods.BresenhamLineTunnel(ThirdPointX, ThirdPointY, FifthPointX, FifthPointY, Main.rand.Next(2, 3));
                SwampCacheX = FifthPointX;
                if (SwampCacheX == FourthPointX - 5)
                    SwampCacheY = FourthPointY;
                else
                    SwampCacheY = FifthPointY;
                int SixthPointX = ThirdPointX + Main.rand.Next(-6, 6);
                int SixthPointY = ThirdPointY + Main.rand.Next(15, 20);
                WorldMethods.BresenhamLineTunnel(ThirdPointX, ThirdPointY, SixthPointX, SixthPointY, Main.rand.Next(3, 5));
                int SeventhPointX = SecondPointX > FirstPointX ? FirstPointX - Main.rand.Next(20, 30) : FirstPointX + Main.rand.Next(20, 30);
                int SeventhPointY = FirstPointY + Main.rand.Next(20, 25);
                WorldMethods.BresenhamLineTunnel(FirstPointX, FirstPointY, SeventhPointX, SeventhPointY, Main.rand.Next(2, 4));
                int EighthPointX = SeventhPointX + Main.rand.Next(10, 15);
                int EighthPointY = SeventhPointY + Main.rand.Next(40, 45);
                int NinethPointX = SeventhPointX - (EighthPointX - SeventhPointX) + Main.rand.Next(5, 15);
                int NinethPointY = EighthPointY - Main.rand.Next(15, 20);
                WorldMethods.BresenhamLineTunnel(SeventhPointX, SeventhPointY, EighthPointX, EighthPointY, Main.rand.Next(2, 3));
                WorldMethods.BresenhamLineTunnel(SeventhPointX, SeventhPointY, NinethPointX, NinethPointY, Main.rand.Next(2, 3));
                WorldGen.TileRunner(SixthPointX, SixthPointY, 8, 1, TileID.Spikes, true, 0f, 0f, false, false);
                int TenthPointX = FirstPointX + Main.rand.Next(-3, 3);
                int TenthPointY = FirstPointY + Main.rand.Next(8, 12);
                WorldMethods.BresenhamLineTunnel(FirstPointX, FirstPointY, TenthPointX, TenthPointY, Main.rand.Next(3, 5));
                WorldGen.TileRunner(TenthPointX, TenthPointY, 8, 1, TileID.Spikes, true, 0f, 0f, false, false);
                #endregion
                #region Lakes
                for (int i = 0; i < 6 + WorldSize * 2; i++)
                {
                    int k = WorldGen.genRand.Next(SwampStartX, EndX);
                    if (SwampCenterX - 60 < k && k < SwampCenterX - 22)
                    {
                        continue;
                    }
                    int l = (int)GenVars.worldSurfaceLow;
                    while (!WorldGen.SolidTile(k, l))
                        l++;
                    WorldMethods.BresenhamLineTunnel(k, l, k, l, 4);
                    for (int n = 0; n < 6; n++)
                    {
                        Main.tile[k - 3 + n, l - 3 + n].LiquidAmount = 255;
                    }
                }
                #endregion
                #region Ambient
                for (int i = 0; i < (Main.maxTilesX / 20); i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        if (Main.rand.Next(8) == 0)
                        {
                            switch (Main.rand.Next(2))
                            {
                                case 0:
                                    WorldGen.Place3x2(SwampStartX + i, SwampStartY - 50 + j, (ushort)ModContent.TileType<Fern>());
                                    break;
                                case 1:
                                    WorldGen.Place3x2(SwampStartX + i, SwampStartY - 50 + j, (ushort)ModContent.TileType<Fern2>());
                                    break;
                            }
                        }
                    }
                }
                for (int i = 0; i < (Main.maxTilesX / 20); i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        if (Main.rand.Next(9) == 0)
                        {
                            switch (Main.rand.Next(2))
                            {
                                case 0:
                                    WorldGen.PlaceTile(SwampStartX + i, SwampStartY - 50 + j, (ushort)ModContent.TileType<Reed>());
                                    break;
                                case 1:
                                    WorldGen.PlaceTile(SwampStartX + i, SwampStartY - 50 + j, (ushort)ModContent.TileType<Reed2>());
                                    break;
                            }
                        }
                    }
                }
                for (int i = 0; i < (Main.maxTilesX / 20); i++)
                {
                    for (int j = 0; j < 100; j++)
                    {
                        if (Main.rand.Next(10) == 0)
                        {
                            switch (Main.rand.Next(3))
                            {
                                case 0:
                                    WorldGen.Place2x1(SwampStartX + i, SwampStartY - 50 + j, (ushort)ModContent.TileType<SwampAmbientB1>());
                                    break;
                                case 1:
                                    WorldGen.Place2x1(SwampStartX + i, SwampStartY - 50 + j, (ushort)ModContent.TileType<SwampAmbientB2>());
                                    break;
                                case 2:
                                    WorldGen.Place2x1(SwampStartX + i, SwampStartY - 50 + j, (ushort)ModContent.TileType<SwampAmbientB3>());
                                    break;
                            }
                        }
                    }
                }
                for (int i = 0; i < Main.maxTilesX; i++)
                {
                    for (int j = 1; j < Main.maxTilesY; j++)
                    {
                        if (Main.tile[i, j].TileType == ModContent.TileType<SwampMud>() && Main.tile[i, j].HasUnactuatedTile)
                        {
                            if (!Main.tile[i, j - 1].HasTile)
                            {
                                if (Main.rand.Next(18) == 0)
                                {
                                    switch (Main.rand.Next(4))
                                    {
                                        case 0:
                                            WorldGen.PlaceTile(i, j - 1, ModContent.TileType<SwampAmbientA1>(), true, false, -1, 0);
                                            break;
                                        case 1:
                                            WorldGen.PlaceTile(i, j - 1, ModContent.TileType<SwampAmbientA2>(), true, false, -1, 0);
                                            break;
                                        case 2:
                                            WorldGen.PlaceTile(i, j - 1, ModContent.TileType<SwampAmbientA3>(), true, false, -1, 0);
                                            break;
                                        case 3:
                                            WorldGen.PlaceTile(i, j - 1, ModContent.TileType<SwampAmbientA4>(), true, false, -1, 0);
                                            break;

                                    }
                                }
                            }
                        }
                    }
                }
            #endregion
            IL_20:
                ;
            }));
            #region caskets
            int CasketIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Buried Chests"));
            tasks.Insert(CasketIndex + 1, new PassLegacy("Casket Placing", delegate (GenerationProgress progress, GameConfiguration configuration)
            {
                int success = 0;
                while (success != 7)
                {
                    int X = Main.rand.Next(100, Main.maxTilesX - 100);
                    int Y = Main.rand.Next((int)GenVars.worldSurfaceHigh, (int)GenVars.rockLayerHigh);
                    if (!Main.tile[X, Y].HasTile && WorldGen.SolidTile(X, Y + 1))
                    {
                        WorldGen.PlaceTile(X, Y, ModContent.TileType<Content.Tiles.BeggarsCasket>());
                        CasketCoords.Add(new Vector2(X, Y));
                        success++;
                    }
                }
            }));
            #endregion
            int WeedsIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Weeds"));
            int SpawnCleanIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Jungle Chests"));
            int SpawnPointIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Spawn Point"));
            tasks.Insert(SpawnPointIndex + 1, new PassLegacy("Spawn Update", delegate (GenerationProgress progress, GameConfiguration configuration)
            {
                Main.spawnTileX = Main.maxTilesX / 2;
                Main.spawnTileY -= 2;
            }));

            tasks.Insert(SpawnCleanIndex + 1, new PassLegacy("Spawn Cleaning", delegate (GenerationProgress progress, GameConfiguration configuration)
            {
                #region Spawn Base
                Main.spawnTileX = Main.maxTilesX / 2;
                int FlagTile1X = Main.spawnTileX - 30;
                int FlagTile1Y = (int)GenVars.worldSurfaceLow;
                while (WorldGen.TileEmpty(FlagTile1X, FlagTile1Y))
                {
                    FlagTile1Y++;
                }

                int FlagTile2X = Main.spawnTileX - 20;
                int FlagTile2Y = (int)GenVars.worldSurfaceLow;
                while (WorldGen.TileEmpty(FlagTile2X, FlagTile2Y))
                {
                    FlagTile2Y++;
                }
                int FlagTile3X = Main.spawnTileX - 10;
                int FlagTile3Y = (int)GenVars.worldSurfaceLow;
                while (WorldGen.TileEmpty(FlagTile3X, FlagTile3Y))
                {
                    FlagTile3Y++;
                }
                int FlagTile4X = Main.spawnTileX + 10;
                int FlagTile4Y = (int)GenVars.worldSurfaceLow;
                while (WorldGen.TileEmpty(FlagTile4X, FlagTile4Y))
                {
                    FlagTile4Y++;
                }
                int FlagTile5X = Main.spawnTileX + 20;
                int FlagTile5Y = (int)GenVars.worldSurfaceLow;
                while (WorldGen.TileEmpty(FlagTile5X, FlagTile5Y))
                {
                    FlagTile5Y++;
                }
                int FlagTile6X = Main.spawnTileX + 30;
                int FlagTile6Y = (int)GenVars.worldSurfaceLow;
                while (WorldGen.TileEmpty(FlagTile6X, FlagTile6Y))
                {
                    FlagTile6Y++;
                }
                int HighestYPoint = FlagTile6Y;
                if (FlagTile5Y < HighestYPoint)
                    HighestYPoint = FlagTile5Y;
                if (FlagTile4Y < HighestYPoint)
                    HighestYPoint = FlagTile4Y;
                if (FlagTile3Y < HighestYPoint)
                    HighestYPoint = FlagTile3Y;
                if (FlagTile2Y < HighestYPoint)
                    HighestYPoint = FlagTile2Y;
                if (FlagTile1Y < HighestYPoint)
                    HighestYPoint = FlagTile1Y;
                for (int i = 0; i < 200; i++)
                {
                    int type;
                    int k = 0;
                    Tile tile3 = Framing.GetTileSafely(Main.spawnTileX - 100 + i, HighestYPoint + k);
                    while (tile3.TileType != TileID.Dirt && tile3.TileType != TileID.SnowBlock && tile3.TileType != TileID.Mud)
                    {
                        k++;
                        tile3 = Framing.GetTileSafely(Main.spawnTileX - 100 + i, HighestYPoint + k);
                    }
                    type = tile3.TileType;
                    for (int j = 0; j < 50; j++)
                    {
                        WorldGen.PlaceTile(Main.spawnTileX - 100 + i, HighestYPoint - 2 + j, type);
                    }
                    for (int l = 0; l < 50; l++)
                    {
                        WorldGen.KillTile(Main.spawnTileX - 100 + i, HighestYPoint - 3 - l);
                        WorldGen.KillWall(Main.spawnTileX - 100 + i, HighestYPoint - 4 - l);
                    }
                }
                int CheckLeftHillX = Main.spawnTileX - 101;
                int CheckLeftHillY = (int)GenVars.worldSurfaceLow;
                while (WorldGen.TileEmpty(CheckLeftHillX, CheckLeftHillY))
                {
                    CheckLeftHillY++;
                }
                if (CheckLeftHillY - HighestYPoint > 4)
                    for (int i = 0; i < 100; i++)
                    {
                        WorldMethods.BresenhamLineTunnel(CheckLeftHillX, CheckLeftHillY - 4 - i, CheckLeftHillX - 70, CheckLeftHillY - 10 - i, 3);
                    }
                int CheckRightHillX = Main.spawnTileX + 101;
                int CheckRightHillY = (int)GenVars.worldSurfaceLow;
                while (WorldGen.TileEmpty(CheckRightHillX, CheckRightHillY))
                {
                    CheckRightHillY++;
                }
                if (CheckRightHillY - HighestYPoint > 4)
                    for (int i = 0; i < 100; i++)
                    {
                        WorldMethods.BresenhamLineTunnel(CheckRightHillX, CheckRightHillY - 4 - i, CheckRightHillX + 70, CheckRightHillY - 10 - i, 3);
                    }
                #endregion           
            }));
            tasks.Insert(WeedsIndex + 1, new PassLegacy("Some more swamp", delegate (GenerationProgress progress, GameConfiguration configuration)
            {
                #region Grass
                progress.Message = "Generating swamp";
                for (int i = 0; i < Main.maxTilesX; i++)
                {
                    for (int j = 1; j < Main.maxTilesY; j++)
                    {
                        if (Main.tile[i, j].TileType == ModContent.TileType<SwampMud>() && Main.tile[i, j].HasUnactuatedTile)
                        {
                            if (!Main.tile[i, j - 1].HasTile)
                            {
                                switch (Main.rand.Next(5))
                                {
                                    case 0:
                                        WorldGen.PlaceTile(i, j - 1, ModContent.TileType<SwampGrass1>(), true, false, -1, 0);
                                        break;
                                    case 1:
                                        WorldGen.PlaceTile(i, j - 1, ModContent.TileType<SwampGrass2>(), true, false, -1, 0);
                                        break;
                                    case 2:
                                        WorldGen.PlaceTile(i, j - 1, ModContent.TileType<SwampGrass3>(), true, false, -1, 0);
                                        break;
                                    case 3:
                                        WorldGen.PlaceTile(i, j - 1, ModContent.TileType<SwampGrass4>(), true, false, -1, 0);
                                        break;
                                    case 4:
                                        WorldGen.PlaceTile(i, j - 1, ModContent.TileType<SwampGrass5>(), true, false, -1, 0);
                                        break;
                                }
                            }
                        }
                    }
                }
                #endregion
            }));
            tasks.Insert(MicroBiomesIndex + 1, new PassLegacy("Some more swamp", delegate (GenerationProgress progress, GameConfiguration configuration)
            {
                #region Cache
                SwampCacheX -= 8;
                int[,] Cache = new int[,]
                 {  { 1, 0, 1, 1, 0, 0, 1, 1 },
                     { 1, 3, 2, 2, 2, 2, 3, 1 },
                     { 1, 2, 2, 2, 2, 2, 2, 1 },
                     { 0, 2, 2, 2, 2, 2, 2, 0 },
                     { 0, 2, 2, 2, 2, 2, 2, 0 },
                     { 0, 2, 2, 2, 2, 2, 2, 0 },
                     { 1, 1, 0, 1, 1, 1, 0, 1 } };
                for (int j = 0; j < Cache.GetLength(0); j++)
                {
                    for (int i = 0; i < Cache.GetLength(1); i++)
                    {
                        switch (Cache[j, i])
                        {
                            case 0:
                                WorldGen.KillTile(SwampCacheX + i, SwampCacheY + j);
                                break;
                            case 1:
                                WorldGen.KillTile(SwampCacheX + i, SwampCacheY + j);
                                WorldGen.PlaceTile(SwampCacheX + i, SwampCacheY + j, ModContent.TileType<SwampWood>());
                                break;
                            case 2:
                                WorldGen.KillTile(SwampCacheX + i, SwampCacheY + j);
                                WorldGen.KillWall(SwampCacheX + i, SwampCacheY + j);
                                WorldGen.PlaceWall(SwampCacheX + i, SwampCacheY + j, ModContent.WallType<SwampWoodWall>());
                                break;
                            case 3:
                                WorldGen.KillTile(SwampCacheX + i, SwampCacheY + j);
                                WorldGen.KillWall(SwampCacheX + i, SwampCacheY + j);
                                WorldGen.PlaceWall(SwampCacheX + i, SwampCacheY + j, ModContent.WallType<SwampWoodWall>());
                                WorldGen.PlaceTile(SwampCacheX + i, SwampCacheY + j, TileID.Torches, false, false, -1, 8);
                                break;
                        }
                    }
                }
                int swampchest = WorldGen.PlaceChest(SwampCacheX + 3, SwampCacheY + 5, (ushort)ModContent.TileType<SwampChest>(), false, 0);
                int swampchestIndex = Chest.FindChest(SwampCacheX + 3, SwampCacheY + 4);
                if (swampchestIndex != -1)
                {

                    GenerateBiomeSwampChestLoot(Main.chest[swampchestIndex].item);
                }
                #endregion
                #region Hut
                progress.Message = "Generating swamp";
                if (!IsSwampSuccess)
                    goto IL_37;

                int StartHutX = SwampCenterX - 50;
                int StartHutY = (int)GenVars.worldSurfaceLow;
                while (!WorldGen.SolidTile(StartHutX, StartHutY))
                {
                    StartHutY++;
                }
                StartHutY -= 15;
                int[,] HutBlocks = new int[,]
                    {  { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0, 0 },
                        { 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 0, 0, 0, 0 },
                        { 0, 0, 1, 1, 1, 1, 2, 2, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0 },
                        { 0, 0, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0 },
                        { 0, 0, 1, 1, 1, 1, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0 },
                        { 0, 0, 1, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                        { 0, 0, 1, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                        { 0, 0, 1, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                        { 0, 0, 1, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 1, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 1, 0, 0, 0, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
                        { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
                        { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 },
                        { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 },
                        { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 },
                        { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 },
                        { 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3 },};

                for (int j = 0; j < HutBlocks.GetLength(0); j++)
                {
                    for (int i = 0; i < HutBlocks.GetLength(1); i++)
                    {
                        switch (HutBlocks[j, i])
                        {
                            case 0:
                                WorldGen.KillTile(StartHutX + i, StartHutY + j);
                                break;
                            case 1:
                                WorldGen.KillTile(StartHutX + i, StartHutY + j);
                                WorldGen.PlaceTile(StartHutX + i, StartHutY + j, TileID.Shadewood);
                                break;
                            case 2:
                                WorldGen.KillTile(StartHutX + i, StartHutY + j);
                                WorldGen.PlaceTile(StartHutX + i, StartHutY + j, TileID.Rope);
                                break;
                            case 3:
                                if (!WorldGen.SolidTile(StartHutX + i, StartHutY + j))
                                    WorldGen.KillTile(StartHutX + i, StartHutY + j);
                                WorldGen.PlaceTile(StartHutX + i, StartHutY + j, ModContent.TileType<SwampMud>());
                                Tile StartHut = Main.tile[StartHutX + i, StartHutY + j];
                                StartHut.IsHalfBlock = false;
                                WorldGen.SlopeTile(StartHutX + i, StartHutY + j, 0);
                                break;
                        }
                    }
                }

                WorldGen.Place4x2(StartHutX + 11, StartHutY + 6, (ushort)ModContent.TileType<ShadewoodBedNoSettle>(), -1);
                WorldGen.PlaceObject(StartHutX + 3, StartHutY + 3, TileID.Chimney);
                WorldGen.Place3x2(StartHutX + 4, StartHutY + 14, TileID.Fireplace);
                WorldGen.PlaceTile(StartHutX + 10, StartHutY + 9, TileID.Chandeliers, false, false, -1, 19);
                WorldGen.Place3x2(StartHutX + 12, StartHutY + 14, TileID.Tables, 1);
                WorldGen.PlaceOnTable1x1(StartHutX + 12, StartHutY + 12, TileID.ClayPot);
                WorldGen.PlaceObject(StartHutX + 12, StartHutY + 11, ModContent.TileType<Content.Tiles.FernFlower>());
                WorldGen.Place2x2(StartHutX + 9, StartHutY + 14, (ushort)ModContent.TileType<MagicPot>(), 0);
                WorldGen.PlaceOnTable1x1(StartHutX + 3, StartHutY + 12, TileID.CopperCoinPile);
                WorldGen.PlaceOnTable1x1(StartHutX + 4, StartHutY + 12, TileID.CopperCoinPile);
                WorldGen.Place1xX(StartHutX + 17, StartHutY + 14, TileID.ClosedDoor, 10);
                int[,] StructWall = new int[,]
                    {  { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 0, 1, 1, 3, 3, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 2, 2, 0, 1, 1, 1, 3, 3, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
                        { 0, 0, 0, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
                        { 0, 0, 0, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
                        { 0, 0, 0, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
                        { 0, 0, 0, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
                        { 0, 0, 0, 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, };
                for (int j = 0; j < StructWall.GetLength(0); j++)
                {
                    for (int i = 0; i < StructWall.GetLength(1); i++)
                    {
                        switch (StructWall[j, i])
                        {
                            case 0:
                                WorldGen.KillWall(StartHutX + i, StartHutY + j);
                                break;
                            case 1:
                                WorldGen.KillWall(StartHutX + i, StartHutY + j);
                                WorldGen.PlaceWall(StartHutX + i, StartHutY + j, WallID.Shadewood);
                                break;
                            case 2:
                                WorldGen.KillWall(StartHutX + i, StartHutY + j);
                                WorldGen.PlaceWall(StartHutX + i, StartHutY + j, WallID.Stone);
                                break;
                            case 3:
                                WorldGen.KillWall(StartHutX + i, StartHutY + j);
                                WorldGen.PlaceWall(StartHutX + i, StartHutY + j, WallID.Glass);
                                break;
                        }
                    }
                }
                WorldGen.SlopeTile(StartHutX + 8, StartHutY, 2);
                WorldGen.SlopeTile(StartHutX + 11, StartHutY, 1);
                WorldGen.SlopeTile(StartHutX + 7, StartHutY + 1, 2);
                WorldGen.SlopeTile(StartHutX + 12, StartHutY + 1, 1);
                WorldGen.SlopeTile(StartHutX + 6, StartHutY + 2, 2);
                WorldGen.SlopeTile(StartHutX + 8, StartHutY + 2, 3);
                WorldGen.SlopeTile(StartHutX + 11, StartHutY + 2, 4);
                WorldGen.SlopeTile(StartHutX + 13, StartHutY + 2, 1);
                WorldGen.SlopeTile(StartHutX + 5, StartHutY + 3, 2);
                WorldGen.SlopeTile(StartHutX + 7, StartHutY + 3, 3);
                WorldGen.SlopeTile(StartHutX + 12, StartHutY + 3, 4);
                WorldGen.SlopeTile(StartHutX + 14, StartHutY + 3, 1);
                WorldGen.SlopeTile(StartHutX + 6, StartHutY + 4, 3);
                WorldGen.SlopeTile(StartHutX + 13, StartHutY + 4, 4);
                WorldGen.SlopeTile(StartHutX + 15, StartHutY + 4, 1);
                WorldGen.SlopeTile(StartHutX + 16, StartHutY + 5, 1);
                NPC.NewNPC(Main.LocalPlayer.GetSource_FromThis(), (StartHutX + 8) * 16 - 4, (StartHutY + 12) * 16, ModContent.NPCType<BabaYaga>());
                WitchSpawnX = (StartHutX + 8) * 16 - 4;
                WitchSpawnY = (StartHutY + 12) * 16;
            #endregion
            IL_37:
                ;
            }));
            int DesertIndex = tasks.FindIndex(genpass => genpass.Name.Equals("Full Desert"));
            tasks.Insert(DesertIndex + 1, new PassLegacy("Desert Village Setting", delegate (GenerationProgress progress, GameConfiguration configuration)
            {
                var desert = GenVars.UndergroundDesertLocation;
                int desertLeft = desert.Left;
                int desertRight = desert.Right;

                int offset = -60; // смещение влево
                int CenterX = desertLeft + ((desertRight - desertLeft) / 2) + offset;

                int top = Math.Max((int)GenVars.worldSurfaceLow, desert.Top - 20);
                int bottom = Math.Min(Main.maxTilesY - 1, desert.Bottom + 50);
                int centerY = top;

                for (int j = top; j <= bottom; j++)
                {
                    if (WorldMethods.CheckWall(CenterX, j, WallID.HardenedSand) || WorldMethods.CheckWall(CenterX, j, WallID.Sandstone))
                    {
                        centerY = j - DesertPitSetting;
                        break;
                    }
                }

                StartBridgeX = CenterX;
                BridgeY = centerY;
                EndBridgeX = StartBridgeX + 2;
            }));

            tasks.Insert(MicroBiomesIndex + 2, new PassLegacy("Desert Village", delegate (GenerationProgress progress, GameConfiguration configuration)
            {
                Point16 ruin3Pos = new Point16(StartBridgeX, BridgeY);
                GenerateStructure("Structures/Desert", ruin3Pos, Bismuth.instance);
            }));     
            tasks.Insert(MicroBiomesIndex + 3, new PassLegacy("Imperian Town", delegate (GenerationProgress progress, GameConfiguration configuration)
            {
                Main.spawnTileX = Main.maxTilesX / 2;
                Main.spawnTileY -= 2;
                #region LeaderHouse
                int LeaderHouseX = Main.spawnTileX - 8;
                int LeaderHouseY = (int)GenVars.worldSurfaceLow;
                while (!WorldGen.SolidTile(LeaderHouseX, LeaderHouseY) || WorldMethods.CheckTile(LeaderHouseX, LeaderHouseY, TileID.Trees) || WorldMethods.CheckTile(LeaderHouseX, LeaderHouseY, TileID.Sunflower) || WorldMethods.CheckTile(LeaderHouseX, LeaderHouseY, TileID.Pumpkins))
                    LeaderHouseY++;
                LeaderHouseY -= 17;

                int[,] LeaderHouse = new int[,]
                 {
                { 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 2, 2, 2, 0, 2, 2, 2, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 2, 2, 2, 2, 0, 0, 0, 0, 0, 2, 2, 2, 2, 0, 0, 0 },
                { 0, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 0 },
                { 2, 2, 1, 1, 1, 1, 5, 5, 5, 5, 5, 5, 5, 1, 1, 1, 1, 2, 2 },
                { 0, 0, 1, 7, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 9, 1, 0, 0 },
                { 0, 0, 1, 6, 0, 0, 0, 11, 0, 0, 0, 0, 0, 0, 0, 8, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 5, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 5, 0 },
                { 0, 0, 1, 1, 1, 1, 5, 5, 5, 5, 5, 5, 5, 1, 1, 1, 1, 0, 0 },
                { 0, 0, 1, 7, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 9, 1, 0, 0 },
                { 0, 0, 1, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 10, 4, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 10, 0 },
                { 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4 },
                 };
                for (int j = 0; j < LeaderHouse.GetLength(0); j++)
                {
                    for (int i = 0; i < LeaderHouse.GetLength(1); i++)
                    {
                        switch (LeaderHouse[j, i])
                        {
                            case 0:
                                WorldGen.KillTile(LeaderHouseX + i, LeaderHouseY + j);
                                break;
                            case 1:
                                WorldGen.KillTile(LeaderHouseX + i, LeaderHouseY + j);
                                WorldGen.PlaceTile(LeaderHouseX + i, LeaderHouseY + j, TileID.GrayBrick);
                                break;
                            case 2:
                                WorldGen.KillTile(LeaderHouseX + i, LeaderHouseY + j);
                                WorldGen.PlaceTile(LeaderHouseX + i, LeaderHouseY + j, 312);
                                break;
                            case 3:
                                WorldGen.KillTile(LeaderHouseX + i, LeaderHouseY + j);
                                WorldGen.PlaceTile(LeaderHouseX + i, LeaderHouseY + j, 253);
                                WorldGen.paintTile(LeaderHouseX + i, LeaderHouseY + j, 28);
                                break;
                            case 4:
                                WorldGen.KillTile(LeaderHouseX + i, LeaderHouseY + j);
                                WorldGen.PlaceTile(LeaderHouseX + i, LeaderHouseY + j, TileID.EbonstoneBrick);
                                WorldGen.paintTile(LeaderHouseX + i, LeaderHouseY + j, 27);
                                break;
                            case 5:
                                WorldGen.KillTile(LeaderHouseX + i, LeaderHouseY + j);
                                WorldGen.PlaceTile(LeaderHouseX + i, LeaderHouseY + j, TileID.Platforms, false, false, -1, 19);
                                break;
                            case 6:
                                WorldGen.KillTile(LeaderHouseX + i, LeaderHouseY + j);
                                WorldGen.PlaceTile(LeaderHouseX + i, LeaderHouseY + j, 253);
                                WorldGen.SlopeTile(LeaderHouseX + i, LeaderHouseY + j, 3);
                                WorldGen.paintTile(LeaderHouseX + i, LeaderHouseY + j, 28);
                                break;
                            case 7:
                                WorldGen.KillTile(LeaderHouseX + i, LeaderHouseY + j);
                                WorldGen.PlaceTile(LeaderHouseX + i, LeaderHouseY + j, 253);
                                WorldGen.SlopeTile(LeaderHouseX + i, LeaderHouseY + j, 2);
                                WorldGen.paintTile(LeaderHouseX + i, LeaderHouseY + j, 28);
                                break;
                            case 8:
                                WorldGen.KillTile(LeaderHouseX + i, LeaderHouseY + j);
                                WorldGen.PlaceTile(LeaderHouseX + i, LeaderHouseY + j, 253);
                                WorldGen.SlopeTile(LeaderHouseX + i, LeaderHouseY + j, 4);
                                WorldGen.paintTile(LeaderHouseX + i, LeaderHouseY + j, 28);
                                break;
                            case 9:
                                WorldGen.KillTile(LeaderHouseX + i, LeaderHouseY + j);
                                WorldGen.PlaceTile(LeaderHouseX + i, LeaderHouseY + j, 253);
                                WorldGen.SlopeTile(LeaderHouseX + i, LeaderHouseY + j, 1);
                                WorldGen.paintTile(LeaderHouseX + i, LeaderHouseY + j, 28);
                                break;
                            case 10:
                                WorldGen.KillTile(LeaderHouseX + i, LeaderHouseY + j);
                                WorldGen.PlaceTile(LeaderHouseX + i, LeaderHouseY + j, TileID.EbonstoneBrick);
                                WorldGen.paintTile(LeaderHouseX + i, LeaderHouseY + j, 27);
                                Tile LeaderHouses = Main.tile[LeaderHouseX + i, LeaderHouseY + j];
                                LeaderHouses.IsHalfBlock = true;
                                break;


                        }
                    }
                }

                WorldGen.Place3x2(LeaderHouseX + 5, LeaderHouseY + 15, TileID.Fireplace);
                WorldGen.PlaceOnTable1x1(LeaderHouseX + 5, LeaderHouseY + 13, TileID.Bottles, 8);
                WorldGen.PlaceObject(LeaderHouseX + 7, LeaderHouseY + 15, TileID.GrandfatherClocks, false, 6);
                WorldGen.Place1x2(LeaderHouseX + 9, LeaderHouseY + 15, (ushort)ModContent.TileType<BorealChairNoSettle>(), 0);
                Tile tile1 = Framing.GetTileSafely(LeaderHouseX + 9, LeaderHouseY + 15);
                Tile tile1under = Framing.GetTileSafely(LeaderHouseX + 9, LeaderHouseY + 14);
                tile1.TileFrameX += 18;
                tile1under.TileFrameX += 18;
                WorldGen.Place3x2(LeaderHouseX + 11, LeaderHouseY + 15, (ushort)ModContent.TileType<BorealTableNoSettle>());
                WorldGen.Place1x2(LeaderHouseX + 13, LeaderHouseY + 15, (ushort)ModContent.TileType<BorealChairNoSettle>(), 0);
                WorldGen.Place1xX(LeaderHouseX + 2, LeaderHouseY + 15, TileID.ClosedDoor, 30);
                WorldGen.Place1xX(LeaderHouseX + 16, LeaderHouseY + 15, TileID.ClosedDoor, 30);
                WorldGen.Place4x2(LeaderHouseX + 13, LeaderHouseY + 9, TileID.Beds, 0);
                WorldGen.Place3x2(LeaderHouseX + 4, LeaderHouseY + 9, TileID.Dressers, 4);
                WorldGen.paintTile(LeaderHouseX + 4, LeaderHouseY + 9, 28);
                WorldGen.paintTile(LeaderHouseX + 3, LeaderHouseY + 9, 28);
                WorldGen.paintTile(LeaderHouseX + 5, LeaderHouseY + 9, 28);
                WorldGen.paintTile(LeaderHouseX + 4, LeaderHouseY + 8, 28);
                WorldGen.paintTile(LeaderHouseX + 3, LeaderHouseY + 8, 28);
                WorldGen.paintTile(LeaderHouseX + 5, LeaderHouseY + 8, 28);
                WorldGen.PlaceTile(LeaderHouseX + 3, LeaderHouseY + 7, TileID.Books);
                WorldGen.Place1x2(LeaderHouseX + 6, LeaderHouseY + 9, (ushort)ModContent.TileType<BorealChairNoSettle>(), 0);
                WorldGen.Place1x2Top(LeaderHouseX + 5, LeaderHouseY + 5, TileID.HangingLanterns, 2);
                WorldGen.Place1x2Top(LeaderHouseX + 13, LeaderHouseY + 5, TileID.HangingLanterns, 2);
                WorldGen.Place1x2Top(LeaderHouseX + 9, LeaderHouseY + 1, TileID.HangingLanterns, 3);
                WorldGen.PlaceOnTable1x1(LeaderHouseX + 12, LeaderHouseY + 13, TileID.Candles);
                WorldGen.Place2x1(LeaderHouseX + 10, LeaderHouseY + 13, TileID.Bowls);
                int[,] LeaderHouseWall = new int[,]
                {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 4, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 4, 0, 0, 3, 2, 2, 2, 3, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 4, 3, 2, 3, 2, 2, 2, 3, 2, 3, 2, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 4, 3, 2, 3, 2, 2, 2, 3, 2, 3, 2, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 5, 3, 1, 1, 1, 1, 1, 1, 1, 3, 1, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 4, 2, 1, 1, 1, 1, 1, 1, 1, 3, 1, 1, 0, 0, 0 },
                { 0, 0, 6, 1, 5, 2, 1, 1, 1, 1, 1, 1, 1, 3, 1, 1, 6, 0, 0 },
                { 0, 0, 6, 2, 4, 2, 3, 3, 2, 2, 3, 2, 2, 3, 2, 3, 6, 0, 0 },
                { 0, 0, 0, 1, 5, 2, 1, 1, 1, 1, 1, 1, 1, 3, 1, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 5, 3, 2, 2, 2, 3, 3, 2, 3, 3, 3, 3, 0, 0, 0 },
                { 0, 0, 0, 1, 5, 4, 1, 1, 1, 1, 1, 1, 1, 3, 1, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 1, 4, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 1, 4, 1, 1, 1, 1, 1, 1, 1, 2, 1, 1, 0, 0, 0 },
                { 0, 0, 0, 3, 3, 2, 2, 2, 2, 2, 2, 3, 3, 2, 2, 3, 0, 0, 0 },
                { 0, 0, 0, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 7, 0, 0, 0 },
                };
                for (int j = 0; j < LeaderHouseWall.GetLength(0); j++)
                {
                    for (int i = 0; i < LeaderHouseWall.GetLength(1); i++)
                    {
                        switch (LeaderHouseWall[j, i])
                        {
                            case 0:
                                WorldGen.KillWall(LeaderHouseX + i, LeaderHouseY + j);
                                break;
                            case 1:
                                WorldGen.KillWall(LeaderHouseX + i, LeaderHouseY + j);
                                WorldGen.PlaceWall(LeaderHouseX + i, LeaderHouseY + j, 5);
                                break;
                            case 2:
                                WorldGen.KillWall(LeaderHouseX + i, LeaderHouseY + j);
                                WorldGen.PlaceWall(LeaderHouseX + i, LeaderHouseY + j, 115);
                                WorldGen.paintWall(LeaderHouseX + i, LeaderHouseY + j, 28);
                                break;
                            case 3:
                                WorldGen.KillWall(LeaderHouseX + i, LeaderHouseY + j);
                                WorldGen.PlaceWall(LeaderHouseX + i, LeaderHouseY + j, 78);
                                break;
                            case 4:
                                WorldGen.KillWall(LeaderHouseX + i, LeaderHouseY + j);
                                WorldGen.PlaceWall(LeaderHouseX + i, LeaderHouseY + j, 22);
                                break;
                            case 5:
                                WorldGen.KillWall(LeaderHouseX + i, LeaderHouseY + j);
                                WorldGen.PlaceWall(LeaderHouseX + i, LeaderHouseY + j, 5);
                                WorldGen.paintWall(LeaderHouseX + i, LeaderHouseY + j, 26);
                                break;
                            case 6:
                                WorldGen.KillWall(LeaderHouseX + i, LeaderHouseY + j);
                                WorldGen.PlaceWall(LeaderHouseX + i, LeaderHouseY + j, 145);
                                break;
                            case 7:
                                WorldGen.KillWall(LeaderHouseX + i, LeaderHouseY + j);
                                WorldGen.PlaceWall(LeaderHouseX + i, LeaderHouseY + j, 24);
                                WorldGen.paintWall(LeaderHouseX + i, LeaderHouseY + j, 27);
                                break;
                        }
                    }
                }
                WorldGen.Place2x3Wall(LeaderHouseX + 11, LeaderHouseY + 6, TileID.Painting2X3, 1);
                WorldGen.PlaceObject(LeaderHouseX + 4, LeaderHouseY + 1, TileID.Chimney);
                // WorldGen.PlaceObject(LeaderHouseX + 11, LeaderHouseY + 6, )//FIX IT!
                NPC.NewNPC(Main.LocalPlayer.GetSource_FromThis(), (LeaderHouseX + 14) * 16 + 4, (LeaderHouseY + 16) * 16, ModContent.NPCType<ImperianConsul>());
                //WorldGen.Place3x2(LeaderHouseX + 4, LeaderHouseY + 9, TileID.)
                SunriseX = LeaderHouseX + 7;
                SunriseY = LeaderHouseY + 6;
                #endregion
                #region Forge
                int ForgeX = Main.spawnTileX - 38;
                int ForgeY = (int)GenVars.worldSurfaceLow;
                while (!WorldGen.SolidTile(ForgeX, ForgeY) || WorldMethods.CheckTile(ForgeX, ForgeY, TileID.Trees) || WorldMethods.CheckTile(ForgeX, ForgeY, TileID.Sunflower) || WorldMethods.CheckTile(ForgeX, ForgeY, TileID.Pumpkins))
                    ForgeY++;
                ForgeY -= 13;
                int[,] Forge = new int[,]
                {
                { 0, 0, 0, 0, 0, 0, 0, 0, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 3, 3, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 1, 3, 3, 0, 0 },
                { 0, 3, 3, 3, 3, 3, 3, 3, 3, 1, 4, 4, 6, 6, 0, 6, 0, 4, 4, 1, 0, 0, 0, 0 },
                { 3, 3, 1, 2, 2, 2, 2, 2, 2, 1, 4, 0, 0, 6, 0, 6, 0, 0, 4, 1, 0, 0, 0, 0 },
                { 0, 0, 1, 4, 0, 6, 6, 4, 4, 1, 8, 0, 0, 0, 0, 0, 0, 8, 8, 1, 5, 5, 5, 5 },
                { 0, 0, 1, 0, 0, 6, 6, 0, 4, 1, 2, 5, 5, 5, 5, 5, 5, 5, 2, 1, 0, 9, 9, 0 },
                { 0, 0, 1, 0, 0, 6, 0, 0, 0, 1, 4, 0, 0, 0, 0, 0, 0, 0, 4, 1, 0, 4, 9, 9 },
                { 0, 0, 1, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 4, 4, 9, 9 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 2, 2, 2, 1, 0, 0, 1, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0 },
                { 11, 11, 11, 11, 1, 7, 7, 1, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 },
                { 11, 11, 11, 11, 1, 1, 1, 1, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 },
                { 11, 11, 11, 11, 1, 10, 10, 1, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 },
                { 11, 11, 11, 11, 1, 1, 1, 1, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11, 11 },
                };
                for (int j = 0; j < Forge.GetLength(0); j++)
                {
                    for (int i = 0; i < Forge.GetLength(1); i++)
                    {
                        switch (Forge[j, i])
                        {
                            case 0:
                                WorldGen.KillTile(ForgeX + i, ForgeY + j);
                                break;
                            case 1:
                                WorldGen.KillTile(ForgeX + i, ForgeY + j);
                                WorldGen.PlaceTile(ForgeX + i, ForgeY + j, 38);
                                break;
                            case 2:
                                WorldGen.KillTile(ForgeX + i, ForgeY + j);
                                WorldGen.PlaceTile(ForgeX + i, ForgeY + j, 151);
                                WorldGen.paintTile(ForgeX + i, ForgeY + j, 27);
                                break;
                            case 3:
                                WorldGen.KillTile(ForgeX + i, ForgeY + j);
                                WorldGen.PlaceTile(ForgeX + i, ForgeY + j, 312);
                                break;
                            case 4:
                                WorldGen.KillTile(ForgeX + i, ForgeY + j);
                                WorldGen.PlaceTile(ForgeX + i, ForgeY + j, 253);
                                WorldGen.paintTile(ForgeX + i, ForgeY + j, 28);
                                break;
                            case 5:
                                WorldGen.KillTile(ForgeX + i, ForgeY + j);
                                WorldGen.PlaceTile(ForgeX + i, ForgeY + j, TileID.Platforms, false, false, -1, 19);
                                break;
                            case 6:
                                WorldGen.KillTile(ForgeX + i, ForgeY + j);
                                WorldGen.PlaceTile(ForgeX + i, ForgeY + j, 214);
                                break;
                            case 7:
                                WorldGen.KillTile(ForgeX + i, ForgeY + j);
                                WorldGen.PlaceTile(ForgeX + i, ForgeY + j, 415);
                                Tile Forge1 = Main.tile[ForgeX + i, ForgeY + j];
                                Forge1.IsHalfBlock = true;
                                break;
                            case 8:
                                WorldGen.KillTile(ForgeX + i, ForgeY + j);
                                WorldGen.PlaceTile(ForgeX + i, ForgeY + j, 250);
                                break;
                            case 9:
                                WorldGen.KillTile(ForgeX + i, ForgeY + j);
                                WorldGen.PlaceTile(ForgeX + i, ForgeY + j, 250);
                                WorldGen.paintTile(ForgeX + i, ForgeY + j, 26);
                                break;
                            case 10:
                                WorldGen.KillTile(ForgeX + i, ForgeY + j);
                                WorldGen.PlaceTile(ForgeX + i, ForgeY + j, 336);
                                break;
                        }
                    }
                }
                WorldGen.Place1xX(ForgeX + 2, ForgeY + 11, TileID.ClosedDoor, 13);
                WorldGen.Place1xX(ForgeX + 19, ForgeY + 11, TileID.ClosedDoor, 13);
                WorldGen.PlaceObject(ForgeX + 11, ForgeY - 1, TileID.Chimney);
                WorldGen.PlaceWall(ForgeX + 11, ForgeY - 1, WallID.PearlstoneBrick);
                WorldGen.Place1x2Top(ForgeX + 4, ForgeY + 4, TileID.HangingLanterns, 34);
                WorldGen.Place1x2Top(ForgeX + 9, ForgeY + 7, TileID.HangingLanterns, 34);
                WorldGen.Place1x2Top(ForgeX + 16, ForgeY + 2, TileID.HangingLanterns, 34);
                WorldGen.Place3x3(ForgeX + 8, ForgeY + 11, TileID.HeavyWorkBench);
                WorldGen.Place3x2(ForgeX + 11, ForgeY + 11, (ushort)ModContent.TileType<BlastFurnace>());
                WorldGen.PlaceChest(ForgeX + 16, ForgeY + 11, TileID.Containers, false, 5);

                int[,] ForgeWall = new int[,]
                {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 4, 1, 1, 1, 3, 1, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 7, 3, 1, 1, 2, 4, 1, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 3, 1, 1, 3, 1, 1, 5, 5, 4, 1, 1, 1, 4, 2, 2, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 3, 1, 1, 3, 1, 1, 4, 5, 3, 4, 4, 3, 4, 3, 3, 0, 9, 9, 9, 0 },
                { 0, 0, 0, 2, 3, 1, 1, 3, 1, 1, 5, 5, 3, 1, 1, 1, 3, 1, 1, 8, 9, 9, 9, 0 },
                { 0, 0, 0, 1, 3, 2, 2, 3, 1, 1, 5, 7, 3, 1, 1, 1, 4, 1, 1, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 3, 1, 2, 3, 1, 2, 7, 5, 3, 1, 1, 1, 4, 1, 2, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 4, 1, 1, 3, 2, 2, 5, 7, 4, 1, 1, 1, 3, 2, 2, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 3, 4, 3, 3, 3, 3, 3, 5, 5, 4, 4, 4, 4, 3, 3, 3, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 6, 4, 6, 6, 3, 6, 6, 5, 5, 6, 6, 6, 6, 3, 6, 6, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                };
                for (int j = 0; j < ForgeWall.GetLength(0); j++)
                {
                    for (int i = 0; i < ForgeWall.GetLength(1); i++)
                    {
                        switch (ForgeWall[j, i])
                        {
                            case 0:
                                WorldGen.KillWall(ForgeX + i, ForgeY + j);
                                break;
                            case 1:
                                WorldGen.KillWall(ForgeX + i, ForgeY + j);
                                WorldGen.PlaceWall(ForgeX + i, ForgeY + j, 5);
                                break;
                            case 2:
                                WorldGen.KillWall(ForgeX + i, ForgeY + j);
                                WorldGen.PlaceWall(ForgeX + i, ForgeY + j, 34);
                                WorldGen.paintWall(ForgeX + i, ForgeY + j, 27);
                                break;
                            case 3:
                                WorldGen.KillWall(ForgeX + i, ForgeY + j);
                                WorldGen.PlaceWall(ForgeX + i, ForgeY + j, 115);
                                WorldGen.paintWall(ForgeX + i, ForgeY + j, 28);
                                break;
                            case 4:
                                WorldGen.KillWall(ForgeX + i, ForgeY + j);
                                WorldGen.PlaceWall(ForgeX + i, ForgeY + j, 78);
                                break;
                            case 5:
                                WorldGen.KillWall(ForgeX + i, ForgeY + j);
                                WorldGen.PlaceWall(ForgeX + i, ForgeY + j, 22);
                                break;
                            case 6:
                                WorldGen.KillWall(ForgeX + i, ForgeY + j);
                                WorldGen.PlaceWall(ForgeX + i, ForgeY + j, 111);
                                break;
                            case 7:
                                WorldGen.KillWall(ForgeX + i, ForgeY + j);
                                WorldGen.PlaceWall(ForgeX + i, ForgeY + j, 5);
                                WorldGen.paintWall(ForgeX + i, ForgeY + j, 26);
                                break;
                            case 8:
                                WorldGen.KillWall(ForgeX + i, ForgeY + j);
                                WorldGen.PlaceWall(ForgeX + i, ForgeY + j, 4);
                                break;
                            case 9:
                                WorldGen.KillWall(ForgeX + i, ForgeY + j);
                                WorldGen.PlaceWall(ForgeX + i, ForgeY + j, 41);
                                break;
                        }
                    }
                }
                int[,] ForgeSlope = new int[,]
                {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 0, 0, 0, 0, 0, 4, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 3, 0, 0, 0, 4, 1, 0, 5, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 2, 0, 1, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 3, 4, 3, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 5, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                };
                for (int j = 0; j < ForgeSlope.GetLength(0); j++)
                {
                    for (int i = 0; i < ForgeSlope.GetLength(1); i++)
                    {
                        switch (ForgeSlope[j, i])
                        {
                            case 0:
                                break;
                            case 1:
                                WorldGen.SlopeTile(ForgeX + i, ForgeY + j, 1);
                                break;
                            case 2:
                                WorldGen.SlopeTile(ForgeX + i, ForgeY + j, 2);
                                break;
                            case 3:
                                WorldGen.SlopeTile(ForgeX + i, ForgeY + j, 3);
                                break;
                            case 4:
                                WorldGen.SlopeTile(ForgeX + i, ForgeY + j, 4);
                                break;
                            case 5:
                                Tile Forge2 = Main.tile[ForgeX + i, ForgeY + j];
                                Forge2.IsHalfBlock = true;
                                break;
                        }
                    }
                }
                WorldGen.PlaceObject(ForgeX + 5, ForgeY + 12, TileID.TrapdoorClosed);
                WorldGen.PlaceObject(ForgeX + 13, ForgeY + 7, TileID.Painting3X3, false, 42);
                WorldGen.PlaceObject(ForgeX + 16, ForgeY + 7, TileID.Painting3X3, false, 41);
                NPC.NewNPC(Main.LocalPlayer.GetSource_FromThis(), (ForgeX + 14) * 16, (ForgeY + 11) * 16, ModContent.NPCType<DwarfBlacksmith>());
                #endregion
                #region Temple
                int TempleX = Main.spawnTileX + 18;
                int TempleY = Main.spawnTileY - 14;
                while (!WorldGen.SolidTile(TempleX, TempleY) || WorldMethods.CheckTile(TempleX, TempleY, TileID.Trees) || WorldMethods.CheckTile(TempleX, TempleY, TileID.Sunflower) || WorldMethods.CheckTile(TempleX, TempleY, TileID.Pumpkins))
                    TempleY++;
                TempleY -= 17;
                int[,] Temple = new int[,]
                {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 7, 7, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 8, 7, 7, 7, 11, 11, 7, 7, 7, 8, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 8, 7, 7, 7, 11, 9, 9, 9, 9, 9, 9, 11, 7, 7, 7, 8, 0, 0, 0 },
                { 8, 7, 7, 7, 11, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 9, 11, 7, 7, 7, 8 },
                { 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0 },
                { 0, 0, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 6, 0, 0 },
                { 0, 0, 5, 10, 5, 5, 10, 5, 5, 10, 5, 5, 10, 5, 5, 10, 5, 5, 10, 5, 0, 0 },
                { 0, 0, 0, 3, 0, 0, 3, 0, 0, 3, 0, 0, 3, 0, 0, 3, 0, 0, 3, 0, 0, 0 },
                { 0, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 0 },
                { 0, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 0 },
                { 0, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 0 },
                { 0, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 0 },
                { 0, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 0 },
                { 0, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 4, 0, 0, 0 },
                { 0, 0, 0, 3, 0, 0, 3, 0, 0, 3, 0, 0, 3, 0, 0, 3, 0, 0, 3, 0, 0, 0 },
                { 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0 },
                { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0 },
                { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                };
                for (int j = 0; j < Temple.GetLength(0); j++)
                {
                    for (int i = 0; i < Temple.GetLength(1); i++)
                    {
                        switch (Temple[j, i])
                        {
                            case 0:
                                WorldGen.KillTile(TempleX + i, TempleY + j);
                                WorldGen.KillWall(TempleX + i, TempleY + j);
                                break;
                            case 1:
                                WorldGen.KillTile(TempleX + i, TempleY + j);
                                WorldGen.PlaceTile(TempleX + i, TempleY + j, 118);
                                WorldGen.paintTile(TempleX + i, TempleY + j, 3);
                                WorldGen.KillWall(TempleX + i, TempleY + j);
                                break;
                            case 2:
                                WorldGen.KillTile(TempleX + i, TempleY + j);
                                WorldGen.PlaceTile(TempleX + i, TempleY + j, 357);
                                WorldGen.paintTile(TempleX + i, TempleY + j, 3);
                                WorldGen.KillWall(TempleX + i, TempleY + j);
                                break;
                            case 3:
                                WorldGen.KillTile(TempleX + i, TempleY + j);
                                WorldGen.KillWall(TempleX + i, TempleY + j);
                                WorldGen.PlaceWall(TempleX + i, TempleY + j, 179);
                                WorldGen.paintWall(TempleX + i, TempleY + j, 3);
                                break;
                            case 4:
                                WorldGen.KillTile(TempleX + i, TempleY + j);
                                WorldGen.KillWall(TempleX + i, TempleY + j);
                                WorldGen.PlaceWall(TempleX + i, TempleY + j, 41);
                                WorldGen.paintWall(TempleX + i, TempleY + j, 26);
                                break;
                            case 5:
                                WorldGen.KillTile(TempleX + i, TempleY + j);
                                WorldGen.KillWall(TempleX + i, TempleY + j);
                                WorldGen.PlaceTile(TempleX + i, TempleY + j, TileID.Platforms, false, false, -1, 9);
                                break;
                            case 6:
                                WorldGen.KillTile(TempleX + i, TempleY + j);
                                WorldGen.PlaceTile(TempleX + i, TempleY + j, 177);
                                WorldGen.paintTile(TempleX + i, TempleY + j, 3);
                                WorldGen.KillWall(TempleX + i, TempleY + j);
                                break;
                            case 7:
                                WorldGen.KillTile(TempleX + i, TempleY + j);
                                WorldGen.PlaceTile(TempleX + i, TempleY + j, 175);
                                WorldGen.KillWall(TempleX + i, TempleY + j);
                                break;
                            case 8:
                                WorldGen.KillTile(TempleX + i, TempleY + j);
                                WorldGen.PlaceTile(TempleX + i, TempleY + j, 175);
                                WorldGen.KillWall(TempleX + i, TempleY + j);
                                Tile Temples = Main.tile[TempleX + i, TempleY + j];
                                Temples.IsHalfBlock = true;
                                break;
                            case 9:
                                WorldGen.KillTile(TempleX + i, TempleY + j);
                                WorldGen.KillWall(TempleX + i, TempleY + j);
                                WorldGen.PlaceWall(TempleX + i, TempleY + j, 123);
                                break;
                            case 10:
                                WorldGen.KillTile(TempleX + i, TempleY + j);
                                WorldGen.KillWall(TempleX + i, TempleY + j);
                                WorldGen.PlaceTile(TempleX + i, TempleY + j, TileID.Pearlwood);
                                break;
                            case 11:
                                WorldGen.KillTile(TempleX + i, TempleY + j);
                                WorldGen.KillWall(TempleX + i, TempleY + j);
                                WorldGen.PlaceTile(TempleX + i, TempleY + j, TileID.Platforms, false, false, -1, 9);
                                WorldGen.PlaceWall(TempleX + i, TempleY + j, 123);
                                break;
                        }
                    }
                }
                WorldGen.PlaceTile(TempleX + 3, TempleY + 8, TileID.Torches, false, false, -1, 12);
                WorldGen.PlaceTile(TempleX + 6, TempleY + 8, TileID.Torches, false, false, -1, 12);
                WorldGen.PlaceTile(TempleX + 9, TempleY + 8, TileID.Torches, false, false, -1, 12);
                WorldGen.PlaceTile(TempleX + 12, TempleY + 8, TileID.Torches, false, false, -1, 12);
                WorldGen.PlaceTile(TempleX + 15, TempleY + 8, TileID.Torches, false, false, -1, 12);
                WorldGen.PlaceTile(TempleX + 18, TempleY + 8, TileID.Torches, false, false, -1, 12);
                NPC.NewNPC(Main.LocalPlayer.GetSource_FromThis(), (TempleX + 11) * 16, (TempleY + 12) * 16, ModContent.NPCType<Priest>());
                #endregion               
                #region Alchemist House
                int AlchemistHouseX = Main.spawnTileX - 70;
                int AlchemistHouseY = (int)GenVars.worldSurfaceLow;
                while (!WorldGen.SolidTile(AlchemistHouseX, AlchemistHouseY) || WorldMethods.CheckTile(AlchemistHouseX, AlchemistHouseY, TileID.Trees) || WorldMethods.CheckTile(AlchemistHouseX, AlchemistHouseY, TileID.Sunflower) || WorldMethods.CheckTile(AlchemistHouseX, AlchemistHouseY, TileID.Pumpkins))
                    AlchemistHouseY++;
                AlchemistHouseY -= 13;
                int[,] AlchemistHouse = new int[,]
                {
                { 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0 },
                { 2, 2, 1, 1, 1, 3, 3, 3, 3, 3, 1, 1, 1, 3, 5, 5, 5, 3, 3 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 8, 0 },
                { 0, 0, 1, 5, 5, 0, 0, 0, 0, 0, 5, 5, 1, 5, 5, 5, 5, 8, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 5, 5, 8, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0 },
                { 0, 0, 1, 1, 1, 5, 5, 5, 5, 5, 1, 1, 1, 3, 5, 5, 5, 3, 3 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 8, 0 },
                { 0, 0, 1, 5, 5, 0, 0, 0, 0, 0, 5, 5, 1, 0, 0, 0, 0, 8, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 8, 0 },
                { 9, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 9, 9, 9, 9, 9 },
                };
                for (int j = 0; j < AlchemistHouse.GetLength(0); j++)
                {
                    for (int i = 0; i < AlchemistHouse.GetLength(1); i++)
                    {
                        switch (AlchemistHouse[j, i])
                        {
                            case 0:
                                WorldGen.KillTile(AlchemistHouseX + i, AlchemistHouseY + j);
                                break;
                            case 1:
                                WorldGen.KillTile(AlchemistHouseX + i, AlchemistHouseY + j);
                                WorldGen.PlaceTile(AlchemistHouseX + i, AlchemistHouseY + j, TileID.GrayBrick);
                                break;
                            case 2:
                                WorldGen.KillTile(AlchemistHouseX + i, AlchemistHouseY + j);
                                WorldGen.PlaceTile(AlchemistHouseX + i, AlchemistHouseY + j, 312);
                                break;
                            case 3:
                                WorldGen.KillTile(AlchemistHouseX + i, AlchemistHouseY + j);
                                WorldGen.PlaceTile(AlchemistHouseX + i, AlchemistHouseY + j, 253);
                                WorldGen.paintTile(AlchemistHouseX + i, AlchemistHouseY + j, 28);
                                break;
                            case 4:
                                WorldGen.KillTile(AlchemistHouseX + i, AlchemistHouseY + j);
                                WorldGen.PlaceTile(AlchemistHouseX + i, AlchemistHouseY + j, 30);
                                //  WorldGen.SlopeTile(AlchemistHouseX + i, AlchemistHouseY + j, 3);
                                break;
                            case 5:
                                WorldGen.KillTile(AlchemistHouseX + i, AlchemistHouseY + j);
                                WorldGen.PlaceTile(AlchemistHouseX + i, AlchemistHouseY + j, TileID.Platforms, false, false, -1, 19);
                                break;
                            case 6:
                                WorldGen.KillTile(AlchemistHouseX + i, AlchemistHouseY + j);
                                WorldGen.PlaceObject(AlchemistHouseX + i, AlchemistHouseY + j, TileID.ClayPot);
                                break;
                            case 7:
                                WorldGen.KillTile(AlchemistHouseX + i, AlchemistHouseY + j);
                                WorldGen.PlaceTile(AlchemistHouseX + i, AlchemistHouseY + j, 30);
                                //   WorldGen.SlopeTile(AlchemistHouseX + i, AlchemistHouseY + j, 4);
                                break;
                            case 8:
                                WorldGen.KillTile(AlchemistHouseX + i, AlchemistHouseY + j);
                                WorldGen.PlaceTile(AlchemistHouseX + i, AlchemistHouseY + j, TileID.WoodenBeam);
                                break;
                        }
                    }
                }
                int[,] AlchemistHouseWall = new int[,]
                {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 3, 1, 2, 1, 1, 1, 2, 1, 3, 0, 8, 7, 7, 8, 0, 0 },
                { 0, 0, 0, 4, 3, 2, 1, 1, 1, 2, 3, 3, 0, 2, 2, 2, 2, 0, 0 },
                { 0, 0, 0, 3, 1, 2, 1, 1, 1, 2, 1, 3, 6, 7, 8, 8, 7, 0, 0 },
                { 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 6, 2, 2, 2, 2, 6, 0 },
                { 0, 0, 0, 3, 1, 2, 1, 1, 1, 2, 1, 3, 6, 8, 8, 7, 7, 7, 0 },
                { 0, 0, 0, 3, 1, 2, 2, 2, 2, 2, 1, 3, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 3, 1, 2, 1, 1, 1, 2, 1, 3, 0, 7, 8, 0, 7, 0, 0 },
                { 0, 0, 0, 3, 3, 2, 1, 1, 1, 2, 3, 3, 0, 7, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 3, 1, 2, 1, 1, 1, 2, 1, 3, 6, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 6, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 5, 5, 2, 5, 5, 5, 2, 5, 5, 6, 6, 6, 6, 6, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                };
                for (int j = 0; j < AlchemistHouseWall.GetLength(0); j++)
                {
                    for (int i = 0; i < AlchemistHouseWall.GetLength(1); i++)
                    {
                        switch (AlchemistHouseWall[j, i])
                        {
                            case 0:
                                WorldGen.KillWall(AlchemistHouseX + i, AlchemistHouseY + j);
                                break;
                            case 1:
                                WorldGen.KillWall(AlchemistHouseX + i, AlchemistHouseY + j);
                                WorldGen.PlaceWall(AlchemistHouseX + i, AlchemistHouseY + j, 5);
                                break;
                            case 2:
                                WorldGen.KillWall(AlchemistHouseX + i, AlchemistHouseY + j);
                                WorldGen.PlaceWall(AlchemistHouseX + i, AlchemistHouseY + j, 41);
                                WorldGen.paintWall(AlchemistHouseX + i, AlchemistHouseY + j, 28);
                                break;
                            case 3:
                                WorldGen.KillWall(AlchemistHouseX + i, AlchemistHouseY + j);
                                WorldGen.PlaceWall(AlchemistHouseX + i, AlchemistHouseY + j, 22);
                                break;
                            case 4:
                                WorldGen.KillWall(AlchemistHouseX + i, AlchemistHouseY + j);
                                WorldGen.PlaceWall(AlchemistHouseX + i, AlchemistHouseY + j, 5);
                                WorldGen.paintWall(AlchemistHouseX + i, AlchemistHouseY + j, 26);
                                break;
                            case 5:
                                WorldGen.KillWall(AlchemistHouseX + i, AlchemistHouseY + j);
                                WorldGen.PlaceWall(AlchemistHouseX + i, AlchemistHouseY + j, 147);
                                break;
                            case 6:
                                WorldGen.KillWall(AlchemistHouseX + i, AlchemistHouseY + j);
                                WorldGen.PlaceWall(AlchemistHouseX + i, AlchemistHouseY + j, 138);
                                WorldGen.paintWall(AlchemistHouseX + i, AlchemistHouseY + j, 28);
                                break;
                            case 7:
                                WorldGen.KillWall(AlchemistHouseX + i, AlchemistHouseY + j);
                                WorldGen.PlaceWall(AlchemistHouseX + i, AlchemistHouseY + j, 67);
                                break;
                            case 8:
                                WorldGen.KillWall(AlchemistHouseX + i, AlchemistHouseY + j);
                                WorldGen.PlaceWall(AlchemistHouseX + i, AlchemistHouseY + j, 66);
                                break;
                        }
                    }
                }
                WorldGen.SlopeTile(AlchemistHouseX + 3, AlchemistHouseY + 2, 3);
                WorldGen.SlopeTile(AlchemistHouseX + 11, AlchemistHouseY + 2, 4);
                WorldGen.SlopeTile(AlchemistHouseX + 3, AlchemistHouseY + 8, 3);
                WorldGen.SlopeTile(AlchemistHouseX + 11, AlchemistHouseY + 8, 4);
                WorldGen.PlaceObject(AlchemistHouseX + 13, AlchemistHouseY + 4, TileID.ClayPot);
                WorldGen.PlaceObject(AlchemistHouseX + 15, AlchemistHouseY + 4, TileID.ClayPot);
                WorldGen.PlaceObject(AlchemistHouseX + 16, AlchemistHouseY + 4, TileID.ClayPot);
                WorldGen.PlaceObject(AlchemistHouseX + 13, AlchemistHouseY + 6, TileID.ClayPot);
                WorldGen.PlaceObject(AlchemistHouseX + 14, AlchemistHouseY + 6, TileID.ClayPot);
                WorldGen.Place3x2(AlchemistHouseX + 4, AlchemistHouseY + 6, TileID.Dressers, 4);
                WorldGen.paintTile(AlchemistHouseX + 4, AlchemistHouseY + 6, 28);
                WorldGen.paintTile(AlchemistHouseX + 3, AlchemistHouseY + 6, 28);
                WorldGen.paintTile(AlchemistHouseX + 5, AlchemistHouseY + 6, 28);
                WorldGen.paintTile(AlchemistHouseX + 4, AlchemistHouseY + 5, 28);
                WorldGen.paintTile(AlchemistHouseX + 3, AlchemistHouseY + 5, 28);
                WorldGen.paintTile(AlchemistHouseX + 5, AlchemistHouseY + 5, 28);
                WorldGen.PlaceOnTable1x1(AlchemistHouseX + 4, AlchemistHouseY + 2, TileID.Bottles);
                WorldGen.PlaceOnTable1x1(AlchemistHouseX + 4, AlchemistHouseY + 4, TileID.Bottles, 2);
                WorldGen.PlaceOnTable1x1(AlchemistHouseX + 3, AlchemistHouseY + 4, TileID.Candles, 19);
                WorldGen.PlaceOnTable1x1(AlchemistHouseX + 10, AlchemistHouseY + 2, TileID.Books);
                WorldGen.PlaceOnTable1x1(AlchemistHouseX + 11, AlchemistHouseY + 2, TileID.Books);
                WorldGen.Place2x2(AlchemistHouseX + 9, AlchemistHouseY + 6, (ushort)ModContent.TileType<AlchemicalShelf>(), 0);
                WorldGen.Place2x2(AlchemistHouseX + 11, AlchemistHouseY + 6, TileID.CookingPots, 0);
                WorldGen.PlaceOnTable1x1(AlchemistHouseX + 4, AlchemistHouseY + 8, TileID.Books);
                WorldGen.PlaceOnTable1x1(AlchemistHouseX + 10, AlchemistHouseY + 8, TileID.Books);
                WorldGen.PlaceOnTable1x1(AlchemistHouseX + 3, AlchemistHouseY + 8, TileID.Books);
                WorldGen.PlaceOnTable1x1(AlchemistHouseX + 11, AlchemistHouseY + 8, TileID.Books);
                WorldGen.Place1x2(AlchemistHouseX + 5, AlchemistHouseY + 12, (ushort)ModContent.TileType<BorealChairNoSettle>(), 0);
                Tile tile2 = Framing.GetTileSafely(AlchemistHouseX + 5, AlchemistHouseY + 12);
                Tile tile2under = Framing.GetTileSafely(AlchemistHouseX + 5, AlchemistHouseY + 11);
                tile2.TileFrameX += 18;
                tile2under.TileFrameX += 18;
                WorldGen.Place3x2(AlchemistHouseX + 7, AlchemistHouseY + 12, (ushort)ModContent.TileType<BorealTableNoSettle>());
                WorldGen.PlaceOnTable1x1(AlchemistHouseX + 6, AlchemistHouseY + 10, TileID.Bottles, 0);
                WorldGen.PlaceOnTable1x1(AlchemistHouseX + 7, AlchemistHouseY + 10, TileID.Candles, 0);
                WorldGen.Place1xX(AlchemistHouseX + 2, AlchemistHouseY + 12, TileID.ClosedDoor, 13);
                WorldGen.Place1xX(AlchemistHouseX + 12, AlchemistHouseY + 12, TileID.ClosedDoor, 13);
                WorldGen.Place1x2Top(AlchemistHouseX + 18, AlchemistHouseY + 8, TileID.HangingLanterns, 27);
                NPC.NewNPC(Main.LocalPlayer.GetSource_FromThis(), (AlchemistHouseX + 9) * 16, (AlchemistHouseY + 12) * 16, ModContent.NPCType<Alchemist>());
                #endregion
                #region Fountain
                int FountainX = Main.spawnTileX + 42;
                int FountainY = (int)GenVars.worldSurfaceLow;
                while (!WorldGen.SolidTile(FountainX, FountainY) || WorldMethods.CheckTile(FountainX, FountainY, TileID.Trees) || WorldMethods.CheckTile(FountainX, FountainY, TileID.Sunflower) || WorldMethods.CheckTile(FountainX, FountainY, TileID.Pumpkins))
                    FountainY++;

                for (int i = 0; i < 6; i++)
                {
                    WorldGen.KillTile(FountainX - 1 + i, FountainY - 3);
                    WorldGen.KillTile(FountainX - 1 + i, FountainY - 2);
                    WorldGen.KillTile(FountainX - 1 + i, FountainY - 1);
                    WorldGen.KillTile(FountainX - 1 + i, FountainY);
                    WorldGen.PlaceTile(FountainX - 1 + i, FountainY, TileID.PearlstoneBrick);
                }
                WorldGen.PlaceObject(FountainX, FountainY - 4, ModContent.TileType<Fountain>());
                /*   WorldGen.PlaceTile(FountainX, FountainY, TileID.PearlstoneBrick);
                   WorldGen.PlaceTile(FountainX + 1, FountainY, TileID.PearlstoneBrick);
                   WorldGen.PlaceTile(FountainX + 2, FountainY, TileID.PearlstoneBrick);
                   WorldGen.PlaceTile(FountainX + 3, FountainY, TileID.PearlstoneBrick);
                   WorldGen.PlaceTile(FountainX + 4, FountainY, TileID.PearlstoneBrick);
                   WorldGen.PlaceTile(FountainX + 5, FountainY, TileID.PearlstoneBrick);
                   WorldGen.PlaceObject(FountainX + 1, FountainY - 4, mod.TileType("Fountain"));*/
                #endregion
                #region Casern
                int CasernX = Main.spawnTileX + 49;
                int CasernY = (int)GenVars.worldSurfaceLow;
                while (!WorldGen.SolidTile(CasernX, CasernY) || WorldMethods.CheckTile(CasernX, CasernY, TileID.Trees) || WorldMethods.CheckTile(CasernX, CasernY, TileID.Sunflower) || WorldMethods.CheckTile(CasernX, CasernY, TileID.Pumpkins))
                    CasernY++;
                CasernY -= 13;
                int[,] Casern = new int[,]

                {
                { 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 2, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 4, 0, 0, 0, 4, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 4, 0, 0, 0, 4, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 3, 3, 3, 3, 4, 0, 0, 0, 4, 3, 3, 3, 3, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 4, 0, 0, 0, 4, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 4, 0, 0, 0, 4, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 1, 1, 1, 1, 1, 4, 4, 4, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 5, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                };

                for (int j = 0; j < Casern.GetLength(0); j++)
                {
                    for (int i = 0; i < Casern.GetLength(1); i++)
                    {
                        switch (Casern[j, i])
                        {
                            case 0:
                                WorldGen.KillTile(CasernX + i, CasernY + j);
                                break;
                            case 1:
                                WorldGen.KillTile(CasernX + i, CasernY + j);
                                WorldGen.PlaceTile(CasernX + i, CasernY + j, 38);
                                break;
                            case 2:
                                WorldGen.KillTile(CasernX + i, CasernY + j);
                                WorldGen.PlaceTile(CasernX + i, CasernY + j, 312);
                                break;
                            case 3:
                                WorldGen.KillTile(CasernX + i, CasernY + j);
                                WorldGen.PlaceTile(CasernX + i, CasernY + j, 253);
                                WorldGen.paintTile(CasernX + i, CasernY + j, 28);
                                break;
                            case 4:
                                WorldGen.KillTile(CasernX + i, CasernY + j);
                                WorldGen.PlaceTile(CasernX + i, CasernY + j, TileID.Platforms, false, false, -1, 19);
                                break;
                        }
                    }
                }
                WorldGen.Place4x2(CasernX + 4, CasernY + 3, TileID.Beds, 1);
                WorldGen.Place4x2(CasernX + 4, CasernY + 6, TileID.Beds, 1);
                WorldGen.Place4x2(CasernX + 13, CasernY + 3, TileID.Beds);
                WorldGen.Place4x2(CasernX + 13, CasernY + 6, TileID.Beds);
                WorldGen.Place1xX(CasernX + 2, CasernY + 12, TileID.ClosedDoor, 14);
                WorldGen.Place1xX(CasernX + 16, CasernY + 12, TileID.ClosedDoor, 14);
                WorldGen.PlaceObject(CasernX + 7, CasernY + 12, TileID.Statues);
                WorldGen.PlaceObject(CasernX + 12, CasernY + 12, TileID.Statues, false, 11);
                WorldGen.Place3x2(CasernX + 4, CasernY + 12, (ushort)ModContent.TileType<BorealTableNoSettle>());
                WorldGen.Place3x2(CasernX + 14, CasernY + 12, (ushort)ModContent.TileType<BorealTableNoSettle>());
                WorldGen.PlaceObject(CasernX + 20, CasernY + 11, ModContent.TileType<Target>());
                WorldGen.PlaceObject(CasernX + 23, CasernY + 11, ModContent.TileType<Target>());
                WorldGen.PlaceObject(CasernX + 26, CasernY + 11, ModContent.TileType<Target>());
                WorldGen.Place1x2Top(CasernX + 9, CasernY + 2, TileID.HangingLanterns, 3);
                NPC.NewNPC(Main.LocalPlayer.GetSource_FromThis(), (CasernX + 10) * 16 - 8, (CasernY + 12) * 16, ModContent.NPCType<ImperianCommander>());
                int[,] CasernWall = new int[,]

                {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 1, 2, 1, 1, 2, 1, 1, 1, 2, 1, 1, 2, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 2, 1, 1, 2, 1, 1, 1, 2, 1, 1, 2, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 2, 1, 1, 2, 1, 1, 1, 2, 1, 1, 2, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 2, 1, 1, 2, 1, 1, 1, 2, 1, 1, 2, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 2, 1, 1, 2, 1, 1, 1, 2, 1, 1, 2, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 2, 1, 1, 2, 2, 2, 2, 2, 1, 1, 2, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 2, 1, 1, 2, 1, 1, 1, 2, 1, 1, 2, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 2, 1, 1, 2, 1, 1, 1, 2, 1, 1, 2, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 2, 1, 1, 2, 1, 1, 1, 2, 1, 1, 2, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 2, 1, 1, 2, 1, 1, 1, 2, 1, 1, 2, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 2, 1, 1, 2, 1, 1, 1, 2, 1, 1, 2, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                };

                for (int j = 0; j < CasernWall.GetLength(0); j++)
                {
                    for (int i = 0; i < CasernWall.GetLength(1); i++)
                    {
                        switch (CasernWall[j, i])
                        {
                            case 0:
                                WorldGen.KillWall(CasernX + i, CasernY + j);
                                break;
                            case 1:
                                WorldGen.KillWall(CasernX + i, CasernY + j);
                                WorldGen.PlaceWall(CasernX + i, CasernY + j, 5);
                                break;
                            case 2:
                                WorldGen.KillWall(CasernX + i, CasernY + j);
                                WorldGen.PlaceWall(CasernX + i, CasernY + j, 115);
                                WorldGen.paintWall(CasernX + i, CasernY + j, 28);
                                break;
                        }
                    }
                }
                WorldGen.PlaceTile(CasernX + 7, CasernY + 8, TileID.Torches);
                WorldGen.PlaceTile(CasernX + 11, CasernY + 8, TileID.Torches);
                WorldGen.Place3x3Wall(CasernX + 4, CasernY + 9, TileID.Painting3X3, 45);
                WorldGen.Place3x3Wall(CasernX + 9, CasernY + 9, TileID.Painting3X3, 43);
                WorldGen.Place3x3Wall(CasernX + 14, CasernY + 9, TileID.Painting3X3, 45);
                #endregion
                #region Beggar Region
                int TreeX = Main.spawnTileX - 48;
                int TreeY = (int)GenVars.worldSurfaceLow;
                while (!WorldGen.SolidTile(TreeX, TreeY) || WorldMethods.CheckTile(TreeX, TreeY, TileID.Trees) || WorldMethods.CheckTile(TreeX, TreeY, TileID.Sunflower) || WorldMethods.CheckTile(TreeX, TreeY, TileID.Pumpkins))
                    TreeY++;
                TreeY -= 14;
                int[,] Tree = new int[,]

                {
                    { 0, 0, 0, 0, 7, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 6, 0, 0, 7, 0 },
                    { 0, 7, 0, 7, 0, 5, 0, 0, 8, 0 },
                    { 0, 7, 7, 7, 7, 4, 1, 0, 2, 3 },
                    { 0, 0, 7, 0, 7, 7, 5, 5, 3, 0 },
                    { 0, 7, 4, 1, 0, 0, 5, 8, 8, 0 },
                    { 0, 0, 0, 4, 5, 5, 3, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 5, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 4, 5, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 5, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 5, 5, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 4, 5, 5, 0 },
                    { 0, 0, 0, 0, 0, 0, 2, 5, 5, 0 },
                    { 0, 0, 0, 0, 0, 0, 5, 5, 5, 1 },
                };
                for (int j = 0; j < Tree.GetLength(0); j++)
                {
                    for (int i = 0; i < Tree.GetLength(1); i++)
                    {
                        switch (Tree[j, i])
                        {
                            case 0:
                                WorldGen.KillTile(TreeX + i, TreeY + j);
                                break;
                            case 1:
                                WorldGen.KillTile(TreeX + i, TreeY + j);
                                WorldGen.PlaceTile(TreeX + i, TreeY + j, TileID.LivingMahogany);
                                Tile Trees = Main.tile[TreeX + i, TreeY + j];
                                Trees.IsActuated = true;
                                WorldGen.SlopeTile(TreeX + i, TreeY + j, 1);
                                break;
                            case 2:
                                WorldGen.KillTile(TreeX + i, TreeY + j);
                                WorldGen.PlaceTile(TreeX + i, TreeY + j, TileID.LivingMahogany);
                                Tile Trees1 = Main.tile[TreeX + i, TreeY + j];
                                Trees1.IsActuated = true;
                                WorldGen.SlopeTile(TreeX + i, TreeY + j, 2);
                                break;
                            case 3:
                                WorldGen.KillTile(TreeX + i, TreeY + j);
                                WorldGen.PlaceTile(TreeX + i, TreeY + j, TileID.LivingMahogany);
                                Tile Trees2 = Main.tile[TreeX + i, TreeY + j];
                                Trees2.IsActuated = true;
                                WorldGen.SlopeTile(TreeX + i, TreeY + j, 3);
                                break;
                            case 4:
                                WorldGen.KillTile(TreeX + i, TreeY + j);
                                WorldGen.PlaceTile(TreeX + i, TreeY + j, TileID.LivingMahogany);
                                Tile Trees3 = Main.tile[TreeX + i, TreeY + j];
                                Trees3.IsActuated = true;
                                WorldGen.SlopeTile(TreeX + i, TreeY + j, 4);
                                break;
                            case 5:
                                WorldGen.KillTile(TreeX + i, TreeY + j);
                                WorldGen.PlaceTile(TreeX + i, TreeY + j, TileID.LivingMahogany);
                                Tile Trees4 = Main.tile[TreeX + i, TreeY + j];
                                Trees4.IsActuated = true;
                                break;
                            case 6:
                                WorldGen.KillTile(TreeX + i, TreeY + j);
                                WorldGen.PlaceTile(TreeX + i, TreeY + j, TileID.LivingMahogany);
                                Tile Trees5 = Main.tile[TreeX + i, TreeY + j];
                                Trees5.IsActuated = true;
                                Tile Trees6 = Main.tile[TreeX + i, TreeY + j];
                                Trees6.IsHalfBlock = true;
                                break;
                            case 7:
                                WorldGen.KillTile(TreeX + i, TreeY + j);
                                WorldGen.PlaceTile(TreeX + i, TreeY + j, TileID.LeafBlock);
                                WorldGen.paintTile(TreeX + i, TreeY + j, 16);
                                Tile Trees7 = Main.tile[TreeX + i, TreeY + j];
                                Trees7.IsActuated = true;
                                break;
                            case 8:
                                WorldGen.KillTile(TreeX + i, TreeY + j);
                                WorldGen.PlaceTile(TreeX + i, TreeY + j, TileID.LeafBlock);
                                Tile Trees8 = Main.tile[TreeX + i, TreeY + j];
                                Trees8.IsActuated = true;
                                break;
                        }
                    }
                }
                int[,] TreeWall = new int[,]

              {
                    { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 1, 0, 0, 1, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 1, 1 },
                    { 0, 1, 1, 0, 2, 1, 0, 1, 1, 1 },
                    { 0, 0, 0, 0, 0, 1, 1, 0, 0, 0 },
                    { 2, 0, 2, 2, 2, 2, 2, 2, 0, 0 },
                    { 0, 2, 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 2, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
              };
                for (int j = 0; j < TreeWall.GetLength(0); j++)
                {
                    for (int i = 0; i < TreeWall.GetLength(1); i++)
                    {
                        switch (TreeWall[j, i])
                        {
                            case 0:
                                WorldGen.KillWall(TreeX + i, TreeY + j);
                                break;
                            case 1:
                                WorldGen.KillWall(TreeX + i, TreeY + j);
                                WorldGen.PlaceWall(TreeX + i, TreeY + j, WallID.Grass);
                                WorldGen.paintWall(TreeX + i, TreeY + j, 16);
                                break;
                            case 2:
                                WorldGen.KillWall(TreeX + i, TreeY + j);
                                WorldGen.PlaceWall(TreeX + i, TreeY + j, WallID.Grass);
                                break;
                        }
                    }
                }
                for (int i = 0; i < 6; i++)
                {
                    WorldGen.KillTile(TreeX - 1 + i, TreeY + 14);
                    WorldGen.KillTile(TreeX - 1 + i, TreeY + 13);
                    WorldGen.KillTile(TreeX - 1 + i, TreeY + 12);
                    WorldGen.KillTile(TreeX - 1 + i, TreeY + 11);
                    WorldGen.PlaceTile(TreeX - 1 + i, TreeY + 14, TileID.Mud);
                }
                WorldGen.PlaceObject(TreeX, TreeY + 12, ModContent.TileType<BeggarTent>());
                NPC.NewNPC(Main.LocalPlayer.GetSource_FromThis(), (TreeX + 5) * 16, (TreeY + 11) * 16, ModContent.NPCType<Beggar>());
                #endregion
                #region Left Tower
                int TowerLeftX = Main.spawnTileX - 89;
                int TowerLeftY = (int)GenVars.worldSurfaceLow;
                while (!WorldGen.SolidTile(TowerLeftX, TowerLeftY) || WorldMethods.CheckTile(TowerLeftX, TowerLeftY, TileID.Trees) || WorldMethods.CheckTile(TowerLeftX, TowerLeftY, TileID.Sunflower) || WorldMethods.CheckTile(TowerLeftX, TowerLeftY, TileID.Pumpkins))
                    TowerLeftY++;
                TowerLeftY -= 23;
                int[,] TowerLeft = new int[,]
                {
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                { 2, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2 },
                { 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 1, 1, 1, 1, 1, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 5, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 5, 0, 0 },
                { 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 1, 1, 1, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 5, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 5, 0, 0 },
                { 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 1, 1, 1, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 4, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 0, 0 },
                };
                for (int j = 0; j < TowerLeft.GetLength(0); j++)
                {
                    for (int i = 0; i < TowerLeft.GetLength(1); i++)
                    {
                        switch (TowerLeft[j, i])
                        {
                            case 0:
                                WorldGen.KillTile(TowerLeftX + i, TowerLeftY + j);
                                break;
                            case 1:
                                WorldGen.KillTile(TowerLeftX + i, TowerLeftY + j);
                                WorldGen.PlaceTile(TowerLeftX + i, TowerLeftY + j, 273);
                                break;
                            case 2:
                                WorldGen.KillTile(TowerLeftX + i, TowerLeftY + j);
                                WorldGen.PlaceTile(TowerLeftX + i, TowerLeftY + j, TileID.Platforms, false, false, -1, 19);
                                break;
                            case 3:
                                WorldGen.KillTile(TowerLeftX + i, TowerLeftY + j);
                                WorldGen.PlaceTile(TowerLeftX + i, TowerLeftY + j, 152);
                                WorldGen.paintTile(TowerLeftX + i, TowerLeftY + j, 27);
                                break;
                            case 4:
                                WorldGen.KillTile(TowerLeftX + i, TowerLeftY + j);
                                WorldGen.PlaceTile(TowerLeftX + i, TowerLeftY + j, 152);
                                WorldGen.paintTile(TowerLeftX + i, TowerLeftY + j, 26);
                                Tile TowerLef = Main.tile[TowerLeftX + i, TowerLeftY + j];
                                TowerLef.IsHalfBlock = true;
                                break;
                            case 5:
                                WorldGen.KillTile(TowerLeftX + i, TowerLeftY + j);
                                WorldGen.PlaceTile(TowerLeftX + i, TowerLeftY + j, TileID.Platforms, false, false, -1, 19); //FIX IT!
                                break;
                        }
                    }
                }
                int[,] TowerLeftWall = new int[,]
            {
{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{ 0, 0, 0, 1, 0, 0, 2, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0 },
{ 0, 0, 0, 1, 1, 2, 2, 1, 1, 2, 2, 2, 1, 2, 0, 0, 0 },
{ 7, 7, 0, 2, 2, 2, 1, 1, 2, 2, 2, 1, 1, 2, 0, 7, 7 },
{ 7, 7, 0, 0, 2, 2, 2, 3, 3, 3, 2, 2, 2, 0, 0, 7, 7 },
{ 8, 8, 0, 0, 4, 3, 4, 2, 2, 2, 2, 3, 4, 0, 0, 8, 8 },
{ 8, 8, 0, 0, 4, 3, 2, 1, 2, 2, 4, 3, 4, 0, 0, 8, 8 },
{ 0, 0, 0, 6, 2, 3, 4, 4, 4, 2, 2, 5, 4, 6, 0, 0, 0 },
{ 0, 0, 0, 6, 2, 3, 4, 2, 2, 2, 2, 3, 4, 6, 0, 0, 0 },
{ 0, 0, 0, 0, 2, 3, 2, 2, 2, 2, 1, 3, 2, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 4, 3, 3, 3, 3, 3, 3, 1, 2, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 4, 5, 2, 2, 2, 2, 2, 5, 4, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 2, 5, 2, 2, 1, 1, 2, 5, 4, 0, 0, 0, 0 },
{ 0, 0, 0, 6, 2, 3, 4, 2, 2, 2, 2, 3, 4, 6, 0, 0, 0 },
{ 0, 0, 0, 6, 4, 3, 2, 2, 4, 4, 2, 3, 4, 6, 0, 0, 0 },
{ 0, 0, 0, 0, 4, 5, 2, 2, 2, 2, 2, 5, 4, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 4, 5, 3, 3, 3, 3, 3, 2, 4, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 4, 5, 2, 2, 2, 2, 2, 3, 4, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 4, 5, 2, 4, 4, 2, 2, 3, 4, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 4, 3, 2, 2, 2, 2, 2, 5, 4, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 1, 3, 1, 1, 1, 1, 1, 3, 1, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 1, 3, 1, 1, 1, 1, 1, 5, 1, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            };
                for (int j = 0; j < TowerLeftWall.GetLength(0); j++)
                {
                    for (int i = 0; i < TowerLeftWall.GetLength(1); i++)
                    {
                        switch (TowerLeftWall[j, i])
                        {
                            case 0:
                                WorldGen.KillWall(TowerLeftX + i, TowerLeftY + j);
                                break;
                            case 1:
                                WorldGen.KillWall(TowerLeftX + i, TowerLeftY + j);
                                WorldGen.PlaceWall(TowerLeftX + i, TowerLeftY + j, 147);
                                break;
                            case 2:
                                WorldGen.KillWall(TowerLeftX + i, TowerLeftY + j);
                                WorldGen.PlaceWall(TowerLeftX + i, TowerLeftY + j, 35);
                                WorldGen.paintWall(TowerLeftX + i, TowerLeftY + j, 27);
                                break;
                            case 3:
                                WorldGen.KillWall(TowerLeftX + i, TowerLeftY + j);
                                WorldGen.PlaceWall(TowerLeftX + i, TowerLeftY + j, 115);
                                WorldGen.paintWall(TowerLeftX + i, TowerLeftY + j, 28);
                                break;
                            case 4:
                                WorldGen.KillWall(TowerLeftX + i, TowerLeftY + j);
                                WorldGen.PlaceWall(TowerLeftX + i, TowerLeftY + j, 5);
                                break;
                            case 5:
                                WorldGen.KillWall(TowerLeftX + i, TowerLeftY + j);
                                WorldGen.PlaceWall(TowerLeftX + i, TowerLeftY + j, 78);
                                break;
                            case 6:
                                WorldGen.KillWall(TowerLeftX + i, TowerLeftY + j);
                                WorldGen.PlaceWall(TowerLeftX + i, TowerLeftY + j, 107);
                                break;
                            case 7:
                                WorldGen.KillWall(TowerLeftX + i, TowerLeftY + j);
                                WorldGen.PlaceWall(TowerLeftX + i, TowerLeftY + j, 179);
                                break;
                            case 8:
                                WorldGen.KillWall(TowerLeftX + i, TowerLeftY + j);
                                WorldGen.PlaceWall(TowerLeftX + i, TowerLeftY + j, 179);
                                WorldGen.paintWall(TowerLeftX + i, TowerLeftY + j, 21);
                                break;
                        }
                    }
                }
                WorldGen.Place3x2(TowerLeftX + 5, TowerLeftY + 3, TileID.Campfire);
                WorldGen.Place3x2(TowerLeftX + 11, TowerLeftY + 3, TileID.Campfire);
                WorldGen.PlaceObject(TowerLeftX + 8, TowerLeftY + 6, TileID.Painting3X3, false, 43);
                WorldGen.PlaceObject(TowerLeftX + 8, TowerLeftY + 13, TileID.Painting3X3, false, 45);
                WorldGen.PlaceObject(TowerLeftX + 8, TowerLeftY + 18, TileID.Painting3X3, false, 44);
                WorldGen.PlaceObject(TowerLeftX + 6, TowerLeftY + 21, TileID.Statues);
                WorldGen.PlaceObject(TowerLeftX + 11, TowerLeftY + 21, TileID.Statues);
                WorldGen.Place1xX(TowerLeftX + 3, TowerLeftY + 21, TileID.ClosedDoor, 14);
                WorldGen.Place1xX(TowerLeftX + 13, TowerLeftY + 21, TileID.ClosedDoor, 14);
                WorldGen.PlaceTile(TowerLeftX + 4, TowerLeftY + 5, TileID.Torches);
                WorldGen.PlaceTile(TowerLeftX + 4, TowerLeftY + 11, TileID.Torches);
                WorldGen.PlaceTile(TowerLeftX + 4, TowerLeftY + 17, TileID.Torches);
                WorldGen.PlaceTile(TowerLeftX + 12, TowerLeftY + 5, TileID.Torches);
                WorldGen.PlaceTile(TowerLeftX + 12, TowerLeftY + 11, TileID.Torches);
                WorldGen.PlaceTile(TowerLeftX + 12, TowerLeftY + 17, TileID.Torches);
                #endregion
                #region Right Tower
                int TowerRightX = Main.spawnTileX + 82;
                int TowerRightY = (int)GenVars.worldSurfaceLow;
                while (!WorldGen.SolidTile(TowerRightX, TowerRightY) || WorldMethods.CheckTile(TowerRightX, TowerRightY, TileID.Trees) || WorldMethods.CheckTile(TowerRightX, TowerRightY, TileID.Sunflower) || WorldMethods.CheckTile(TowerRightX, TowerRightY, TileID.Pumpkins))
                    TowerRightY++;
                TowerRightY -= 23;
                int[,] TowerRight = new int[,]
                {
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                { 2, 2, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 2 },
                { 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 1, 1, 1, 1, 1, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 5, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 5, 0, 0 },
                { 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 1, 1, 1, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 5, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 5, 0, 0 },
                { 0, 0, 0, 1, 1, 1, 1, 2, 2, 2, 1, 1, 1, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 4, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 3, 4, 0, 0 },
                };
                for (int j = 0; j < TowerRight.GetLength(0); j++)
                {
                    for (int i = 0; i < TowerRight.GetLength(1); i++)
                    {
                        switch (TowerRight[j, i])
                        {
                            case 0:
                                WorldGen.KillTile(TowerRightX + i, TowerRightY + j);
                                break;
                            case 1:
                                WorldGen.KillTile(TowerRightX + i, TowerRightY + j);
                                WorldGen.PlaceTile(TowerRightX + i, TowerRightY + j, 273);
                                break;
                            case 2:
                                WorldGen.KillTile(TowerRightX + i, TowerRightY + j);
                                WorldGen.PlaceTile(TowerRightX + i, TowerRightY + j, TileID.Platforms, false, false, -1, 19);
                                break;
                            case 3:
                                WorldGen.KillTile(TowerRightX + i, TowerRightY + j);
                                WorldGen.PlaceTile(TowerRightX + i, TowerRightY + j, 152);
                                WorldGen.paintTile(TowerRightX + i, TowerRightY + j, 27);
                                break;
                            case 4:
                                WorldGen.KillTile(TowerRightX + i, TowerRightY + j);
                                WorldGen.PlaceTile(TowerRightX + i, TowerRightY + j, 152);
                                WorldGen.paintTile(TowerRightX + i, TowerRightY + j, 26);
                                Tile TowerRigh = Main.tile[TowerRightX + i, TowerRightY + j];
                                TowerRigh.IsHalfBlock = true;
                                break;
                            case 5:
                                WorldGen.KillTile(TowerRightX + i, TowerRightY + j);
                                WorldGen.PlaceTile(TowerRightX + i, TowerRightY + j, TileID.Platforms, false, false, -1, 19); //FIX IT!
                                break;
                        }
                    }
                }
                int[,] TowerRightWall = new int[,]
            {
{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
{ 0, 0, 0, 1, 0, 0, 2, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0 },
{ 0, 0, 0, 1, 1, 2, 2, 1, 1, 2, 2, 2, 1, 2, 0, 0, 0 },
{ 7, 7, 0, 2, 2, 2, 1, 1, 2, 2, 2, 1, 1, 2, 0, 7, 7 },
{ 7, 7, 0, 0, 2, 2, 2, 3, 3, 3, 2, 2, 2, 0, 0, 7, 7 },
{ 8, 8, 0, 0, 4, 3, 4, 2, 2, 2, 2, 3, 4, 0, 0, 8, 8 },
{ 8, 8, 0, 0, 4, 3, 2, 1, 2, 2, 4, 3, 4, 0, 0, 8, 8 },
{ 0, 0, 0, 6, 2, 3, 4, 4, 4, 2, 2, 5, 4, 6, 0, 0, 0 },
{ 0, 0, 0, 6, 2, 3, 4, 2, 2, 2, 2, 3, 4, 6, 0, 0, 0 },
{ 0, 0, 0, 0, 2, 3, 2, 2, 2, 2, 1, 3, 2, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 4, 3, 3, 3, 3, 3, 3, 1, 2, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 4, 5, 2, 2, 2, 2, 2, 5, 4, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 2, 5, 2, 2, 1, 1, 2, 5, 4, 0, 0, 0, 0 },
{ 0, 0, 0, 6, 2, 3, 4, 2, 2, 2, 2, 3, 4, 6, 0, 0, 0 },
{ 0, 0, 0, 6, 4, 3, 2, 2, 4, 4, 2, 3, 4, 6, 0, 0, 0 },
{ 0, 0, 0, 0, 4, 5, 2, 2, 2, 2, 2, 5, 4, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 4, 5, 3, 3, 3, 3, 3, 2, 4, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 4, 5, 2, 2, 2, 2, 2, 3, 4, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 4, 5, 2, 4, 4, 2, 2, 3, 4, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 4, 3, 2, 2, 2, 2, 2, 5, 4, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 1, 3, 1, 1, 1, 1, 1, 3, 1, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 1, 3, 1, 1, 1, 1, 1, 5, 1, 0, 0, 0, 0 },
{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            };
                for (int j = 0; j < TowerRightWall.GetLength(0); j++)
                {
                    for (int i = 0; i < TowerRightWall.GetLength(1); i++)
                    {
                        switch (TowerRightWall[j, i])
                        {
                            case 0:
                                WorldGen.KillWall(TowerRightX + i, TowerRightY + j);
                                break;
                            case 1:
                                WorldGen.KillWall(TowerRightX + i, TowerRightY + j);
                                WorldGen.PlaceWall(TowerRightX + i, TowerRightY + j, 147);
                                break;
                            case 2:
                                WorldGen.KillWall(TowerRightX + i, TowerRightY + j);
                                WorldGen.PlaceWall(TowerRightX + i, TowerRightY + j, 35);
                                WorldGen.paintWall(TowerRightX + i, TowerRightY + j, 27);
                                break;
                            case 3:
                                WorldGen.KillWall(TowerRightX + i, TowerRightY + j);
                                WorldGen.PlaceWall(TowerRightX + i, TowerRightY + j, 115);
                                WorldGen.paintWall(TowerRightX + i, TowerRightY + j, 28);
                                break;
                            case 4:
                                WorldGen.KillWall(TowerRightX + i, TowerRightY + j);
                                WorldGen.PlaceWall(TowerRightX + i, TowerRightY + j, 5);
                                break;
                            case 5:
                                WorldGen.KillWall(TowerRightX + i, TowerRightY + j);
                                WorldGen.PlaceWall(TowerRightX + i, TowerRightY + j, 78);
                                break;
                            case 6:
                                WorldGen.KillWall(TowerRightX + i, TowerRightY + j);
                                WorldGen.PlaceWall(TowerRightX + i, TowerRightY + j, 107);
                                break;
                            case 7:
                                WorldGen.KillWall(TowerRightX + i, TowerRightY + j);
                                WorldGen.PlaceWall(TowerRightX + i, TowerRightY + j, 179);
                                break;
                            case 8:
                                WorldGen.KillWall(TowerRightX + i, TowerRightY + j);
                                WorldGen.PlaceWall(TowerRightX + i, TowerRightY + j, 179);
                                WorldGen.paintWall(TowerRightX + i, TowerRightY + j, 21);
                                break;
                        }
                    }
                }
                WorldGen.Place3x2(TowerRightX + 5, TowerRightY + 3, TileID.Campfire);
                WorldGen.Place3x2(TowerRightX + 11, TowerRightY + 3, TileID.Campfire);
                WorldGen.PlaceObject(TowerRightX + 8, TowerRightY + 6, TileID.Painting3X3, false, 43);
                WorldGen.PlaceObject(TowerRightX + 8, TowerRightY + 13, TileID.Painting3X3, false, 45);
                WorldGen.PlaceObject(TowerRightX + 8, TowerRightY + 18, TileID.Painting3X3, false, 44);
                WorldGen.PlaceObject(TowerRightX + 6, TowerRightY + 21, TileID.Statues);
                WorldGen.PlaceObject(TowerRightX + 11, TowerRightY + 21, TileID.Statues);
                WorldGen.Place1xX(TowerRightX + 3, TowerRightY + 21, TileID.ClosedDoor, 14);
                WorldGen.Place1xX(TowerRightX + 13, TowerRightY + 21, TileID.ClosedDoor, 14);
                WorldGen.PlaceTile(TowerRightX + 4, TowerRightY + 5, TileID.Torches);
                WorldGen.PlaceTile(TowerRightX + 4, TowerRightY + 11, TileID.Torches);
                WorldGen.PlaceTile(TowerRightX + 4, TowerRightY + 17, TileID.Torches);
                WorldGen.PlaceTile(TowerRightX + 12, TowerRightY + 5, TileID.Torches);
                WorldGen.PlaceTile(TowerRightX + 12, TowerRightY + 11, TileID.Torches);
                WorldGen.PlaceTile(TowerRightX + 12, TowerRightY + 17, TileID.Torches);
                #endregion
                #region Fences
                for (int i = 0; i < 5; i++)
                {
                    WorldGen.PlaceWall(Main.spawnTileX - 74 + i, TowerLeftY + 22, WallID.MetalFence);

                }
                WorldGen.KillTile(Main.spawnTileX - 72, TowerLeftY + 22);
                WorldGen.PlaceObject(Main.spawnTileX - 72, TowerLeftY + 22, TileID.Lampposts);
                WorldGen.PlaceWall(TreeX - 3, TreeY + 13, WallID.EbonwoodFence);
                WorldGen.paintWall(TreeX - 3, TreeY + 13, 28);
                WorldGen.PlaceWall(TreeX - 3, TreeY + 12, WallID.EbonwoodFence);
                WorldGen.paintWall(TreeX - 3, TreeY + 12, 28);
                WorldGen.PlaceWall(TreeX - 2, TreeY + 13, WallID.EbonwoodFence);
                WorldGen.paintWall(TreeX - 2, TreeY + 13, 28);
                WorldGen.PlaceWall(TreeX - 1, TreeY + 13, WallID.EbonwoodFence);
                WorldGen.paintWall(TreeX - 1, TreeY + 13, 28);
                WorldGen.PlaceWall(TreeX - 1, TreeY + 12, WallID.EbonwoodFence);
                WorldGen.paintWall(TreeX - 1, TreeY + 12, 28);
                WorldGen.PlaceWall(TreeX - 4, TreeY + 13, WallID.EbonwoodFence);
                WorldGen.paintWall(TreeX - 4, TreeY + 13, 28);
                WorldGen.PlaceWall(TreeX - 5, TreeY + 12, WallID.EbonwoodFence);
                WorldGen.paintWall(TreeX - 5, TreeY + 12, 28);
                for (int i = 0; i < 9; i++)
                {
                    WorldGen.PlaceWall(ForgeX + 21 + i, ForgeY + 12, WallID.EbonwoodFence);
                    WorldGen.paintWall(ForgeX + 21 + i, ForgeY + 12, 28);
                }
                WorldGen.KillTile(ForgeX + 26, ForgeY + 12);
                WorldGen.PlaceObject(ForgeX + 26, ForgeY + 12, TileID.Lampposts);
                for (int i = 0; i < 7; i++)
                {
                    WorldGen.PlaceWall(CasernX + 28 + i, CasernY + 12, WallID.MetalFence);
                }
                WorldGen.KillTile(CasernX + 31, CasernY + 12);
                WorldGen.PlaceObject(CasernX + 31, CasernY + 12, TileID.Lampposts);
                #endregion
                #region Tombstone
                TombstoneX = Main.dungeonX > Main.spawnTileX ? WorldGen.genRand.Next(BeachEndLeft, BeachEndLeft + 600) : WorldGen.genRand.Next(BeachEndRight - 600, BeachEndRight);
                TombstoneY = (int)GenVars.worldSurfaceLow;
                while (!WorldGen.SolidTile(TombstoneX, TombstoneY))
                    TombstoneY++;
                int type = 0;
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (WorldGen.SolidTile(TombstoneX - 1 + i, TombstoneY + j))
                        {
                            if (Main.tile[TombstoneX - 1 + i, TombstoneY + j].TileType == 0 || Main.tile[TombstoneX - 1 + i, TombstoneY + j].TileType == TileID.ClayBlock || Main.tile[TombstoneX - 1 + i, TombstoneY + j].TileType == 1)
                            {
                                type = 0;
                                break;
                            }
                            if (Main.tile[TombstoneX - 1 + i, TombstoneY + j].TileType == TileID.Ebonstone || Main.tile[TombstoneX - 1 + i, TombstoneY + j].TileType == TileID.Ebonsand)
                            {
                                type = 112;
                                break;
                            }
                            if (Main.tile[TombstoneX - 1 + i, TombstoneY + j].TileType == TileID.Crimsand || Main.tile[TombstoneX - 1 + i, TombstoneY + j].TileType == TileID.CrimsonHardenedSand || Main.tile[TombstoneX - 1 + i, TombstoneY + j].TileType == TileID.CrimsonSandstone || Main.tile[TombstoneX - 1 + i, TombstoneY + j].TileType == TileID.Crimstone)
                            {
                                type = 234;
                                break;
                            }
                            if (Main.tile[TombstoneX - 1 + i, TombstoneY + j].TileType == ModContent.TileType<SwampMud>())
                            {
                                type = ModContent.TileType<SwampMud>();
                                break;
                            }
                            if (Main.tile[TombstoneX - 1 + i, TombstoneY + j].TileType == TileID.SnowBlock || Main.tile[TombstoneX - 1 + i, TombstoneY + j].TileType == TileID.IceBlock)
                            {
                                type = 147;
                                break;
                            }
                            if (Main.tile[TombstoneX - 1 + i, TombstoneY + j].TileType == TileID.Sand || Main.tile[TombstoneX - 1 + i, TombstoneY + j].TileType == TileID.Sandstone || Main.tile[TombstoneX - 1 + i, TombstoneY + j].TileType == TileID.HardenedSand)
                            {
                                type = 53;
                                break;
                            }
                        }
                    }
                }
                for (int i = 0; i < 8; i++)
                {
                    WorldGen.KillTile(TombstoneX - 1, TombstoneY - i);
                    WorldGen.KillTile(TombstoneX, TombstoneY - i);
                    WorldGen.KillTile(TombstoneX + 1, TombstoneY - i);
                }
                int offsetY = 0;
                for (int i = 0; i < 3; i++)
                {
                    while (!WorldGen.SolidTile(TombstoneX - 1 + i, TombstoneY + offsetY))
                    {
                        WorldGen.PlaceTile(TombstoneX - 1 + i, TombstoneY + offsetY, type);
                    }
                }
                for (int i = 0; i < 8; i++)
                {
                    WorldGen.SlopeTile(TombstoneX - 1, TombstoneY + i, 0);
                    WorldGen.SlopeTile(TombstoneX, TombstoneY + i, 0);
                    WorldGen.SlopeTile(TombstoneX + 1, TombstoneY + i, 0);
                }
                WorldGen.PlaceObject(TombstoneX, TombstoneY - 1, (ushort)ModContent.TileType<WarriorsTombstone>());
                /* for (int i = 0; i < 40; i++)
                 {
                     WorldGen.PlaceTile(TombstoneX, TombstoneY - 5 - i, TileID.AdamantiteBeam);
                 }*/
                #endregion
                #region TilesList
                for (int i = Main.spawnTileX - 89; i < Main.spawnTileX + 99; i++)
                {
                    for (int j = Main.spawnTileY - 30; j < Main.spawnTileY + 10; j++)
                    {
                        if (Main.tile[i, j] != null && /*Main.tile[i, j].nactive() && */Main.tile[i, j].HasTile && Main.tile[i, j].TileType != TileID.Sunflower && Main.tile[i, j].TileType != TileID.Trees && Main.tile[i, j].TileType != TileID.Pumpkins && Main.tile[i, j].TileType != 3)
                            TownTiles.Add(new Vector2(i, j));
                    }
                }
                for (int i = Main.spawnTileX - 89; i < Main.spawnTileX + 99; i++)
                {
                    for (int j = Main.spawnTileY - 30; j < Main.spawnTileY + 10; j++)
                    {
                        if (Main.tile[i, j] != null && /*Main.tile[i, j].nactive() && */Main.tile[i, j].HasTile && Main.tile[i, j].TileType == TileID.ClosedDoor)
                        {
                            DoorsLeft.Add(new Vector2(i - 1, j));
                            DoorsRight.Add(new Vector2(i + 1, j));

                        }
                    }
                }
                #endregion
                #region WallsList
                for (int i = Main.spawnTileX - 89; i < Main.spawnTileX + 99; i++)
                {
                    for (int j = Main.spawnTileY - 30; j < Main.spawnTileY + 10; j++)
                    {
                        if (Main.tile[i, j] != null && Main.tile[i, j].WallType > 0)
                            TownWalls.Add(new Vector2(i, j));
                    }
                }
                #endregion
            }));
            int CastleIndex2 = tasks.FindIndex(genpass => genpass.Name.Equals("Final Cleanup"));
            tasks.Insert(CastleIndex2 + 1, new PassLegacy("Castle", delegate (GenerationProgress progress, GameConfiguration configuration)
            {
                #region Castle
                int failcount2 = 0;
            IL_23:
                if (failcount2 > 20000)
                {
                    GeneratedCaslte = false;
                    goto IL_38;
                }
                CastleSpawnX = WorldGen.genRand.Next(BeachEndLeft, BeachEndRight - 50);
                CastleSpawnY = (int)GenVars.worldSurfaceLow;
                while (!WorldGen.SolidTile(CastleSpawnX, CastleSpawnY))
                {
                    CastleSpawnY++;
                    if (CastleSpawnY == Main.maxTilesY)
                        break;
                }

                int EndX = CastleSpawnX + 50;
                int EndY = (int)GenVars.worldSurfaceLow;
                while (!WorldGen.SolidTile(EndX, EndY))
                {
                    EndY++;
                    if (EndY == Main.maxTilesY)
                        break;
                }
                if (EndX > Main.spawnTileX - 120)
                {
                    if (CastleSpawnX < Main.spawnTileX + 120)
                    {
                        failcount2++;
                        goto IL_23;
                    }

                }
                if (Math.Abs(CastleSpawnY - EndY) > 10)
                {
                    failcount2++;
                    goto IL_23;
                }
                CastleSpawnY -= 28;
                for (int i = 0; i < 50; i++)
                {
                    for (int j = 0; j < 60; j++)
                    {
                        if (Main.tile[CastleSpawnX + i, CastleSpawnY + j].TileType == TileID.IceBlock || Main.tile[CastleSpawnX + i, CastleSpawnY + j].TileType == TileID.SnowBlock || Main.tile[CastleSpawnX + i, CastleSpawnY + j].TileType == TileID.BlueDungeonBrick || Main.tile[CastleSpawnX + i, CastleSpawnY + j].TileType == TileID.GreenDungeonBrick || Main.tile[CastleSpawnX + i, CastleSpawnY + j].TileType == TileID.PinkDungeonBrick || Main.tile[CastleSpawnX + i, CastleSpawnY + j].TileType == TileID.Cloud || Main.tile[CastleSpawnX + i, CastleSpawnY + j].TileType == TileID.RainCloud || Main.tile[CastleSpawnX + i, CastleSpawnY + j].TileType == TileID.Ebonstone || Main.tile[CastleSpawnX + i, CastleSpawnY + j].TileType == TileID.Crimstone || Main.tile[CastleSpawnX + i, CastleSpawnY + j].TileType == TileID.SandstoneBrick || Main.tile[CastleSpawnX + i, CastleSpawnY + j].TileType == TileID.HardenedSand || Main.tile[CastleSpawnX + i, CastleSpawnY + j].TileType == TileID.Mud || Main.tile[CastleSpawnX + i, CastleSpawnY + j].TileType == TileID.LivingWood || Main.tile[CastleSpawnX + i, CastleSpawnY + j].TileType == TileID.LeafBlock || Main.tile[CastleSpawnX + i, CastleSpawnY + j].TileType == Mod.Find<ModTile>("SwampMud").Type)
                        {
                            failcount2++;
                            goto IL_23;
                        }
                    }
                }
                for (int i = 0; i < 49; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (WorldGen.SolidTile(CastleSpawnX + i, CastleSpawnX + j))
                        {
                            if (WorldMethods.CheckTile(CastleSpawnX + i, CastleSpawnY + j, TileID.Sand))
                            {
                                for (int k = 0; k < 10; k++)
                                {
                                    WorldGen.PlaceTile(CastleSpawnX + i, CastleSpawnY + k, TileID.Sand);
                                }
                                break;
                            }
                            else
                            {
                                for (int k = 0; k < 10; k++)
                                {
                                    WorldGen.PlaceTile(CastleSpawnX + i, CastleSpawnY + k, TileID.Dirt);
                                }
                                break;
                            }
                        }
                    }
                }
                int[,] Castle = new int[,]
                {
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 9, 0, 0, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 7, 0, 0, 0, 0, 0, 7, 2, 1, 1, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 9, 0, 0, 0, 0, 0, 0, 0, 7, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 9, 0, 0, 0, 0, 0, 0, 0, 9, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 4, 4, 4, 4, 4, 1, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 6, 6, 1, 1, 1, 1, 1, 1, 1, 5, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 4, 4, 0, 0, 0, 2, 1, 1, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 2, 0, 6, 6, 0, 0, 7, 7, 0, 7, 2, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 4, 4, 0, 0, 0, 1, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 6, 6, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 4, 4, 0, 0, 1, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 6, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 4, 4, 0, 1, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 4, 4, 4, 4, 4, 1, 1, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 2, 0, 0, 0, 4, 4, 2, 1, 0, 0, 0, 0 },
                    { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 4, 4, 4, 4, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 0, 0, 0, 4, 4, 0, 0, 0, 0, 2, 1, 2, 0, 7, 0, 10, 7, 7, 10, 0, 7, 7, 2, 1, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 1, 0 },
                    { 0, 1, 0, 0, 9, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 10, 0, 7, 10, 0, 0, 0, 7, 1, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 1, 0 },
                    { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 2, 0, 0, 2, 0, 0, 0, 0, 1, 1, 4, 4, 4, 4, 4, 1, 1, 1, 1, 1, 0 },
                    { 0, 1, 1, 2, 0, 0, 0, 0, 0, 0, 0, 2, 1, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 4, 4, 0, 0, 0, 1, 1, 0, 10, 0, 0 },
                    { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 4, 4, 4, 4, 4, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 4, 4, 0, 0, 1, 0, 0, 10, 0, 0 },
                    { 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 1, 0, 0, 4, 4, 0, 3, 0, 0, 10, 0, 0 },
                    { 0, 0, 1, 4, 4, 0, 0, 0, 0, 0, 4, 4, 1, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 1, 0, 0, 10, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 4, 4, 4, 4, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
                    { 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 3, 2, 0, 0, 0, 9, 9, 3, 0, 0, 7, 0, 0, 7, 7, 0, 0, 3, 0, 7, 7, 0, 7, 7, 2, 5, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8 },
                    { 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 3, 0, 0, 0, 9, 9, 0, 3, 9, 0, 0, 0, 0, 0, 0, 0, 9, 3, 9, 7, 0, 0, 7, 0, 0, 3, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8 },
                    { 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 5, 0, 0, 9, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8 },
                    { 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 5, 0, 9, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8 },
                    { 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 3, 9, 9, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8 },
                    { 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 3, 3, 3, 3, 3, 3, 5, 3, 5, 5, 3, 3, 3, 3, 5, 5, 3, 3, 3, 3, 5, 3, 3, 3, 3, 3, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8, 8 },

                };
                for (int j = 0; j < Castle.GetLength(0); j++)
                {
                    for (int i = 0; i < Castle.GetLength(1); i++)
                    {
                        switch (Castle[j, i])

                        {
                            case 0:
                                WorldGen.KillTile(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.KillWall(CastleSpawnX + i, CastleSpawnY + j);
                                break;
                            case 1:
                                WorldGen.KillTile(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.KillWall(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.PlaceTile(CastleSpawnX + i, CastleSpawnY + j, TileID.GrayBrick);
                                break;
                            case 2:
                                WorldGen.KillTile(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.KillWall(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.PlaceTile(CastleSpawnX + i, CastleSpawnY + j, TileID.BorealWood);

                                break;
                            case 3:
                                WorldGen.KillTile(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.KillWall(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.PlaceTile(CastleSpawnX + i, CastleSpawnY + j, TileID.Mudstone, false, false, 0, 4);
                                WorldGen.paintTile(CastleSpawnX + i, CastleSpawnY + j, 27);
                                break;
                            case 4:
                                WorldGen.KillTile(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.KillWall(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.PlaceTile(CastleSpawnX + i, CastleSpawnY + j, ModContent.TileType<OrcishPlatform>());
                                break;
                            case 5:
                                WorldGen.KillTile(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.KillWall(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.PlaceTile(CastleSpawnX + i, CastleSpawnY + j, TileID.Stone);
                                break;
                            case 6:
                                WorldGen.KillTile(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.KillWall(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.PlaceTile(CastleSpawnX + i, CastleSpawnY + j, TileID.Rope);
                                break;
                            case 7:
                                WorldGen.KillTile(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.KillWall(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.PlaceTile(CastleSpawnX + i, CastleSpawnY + j, TileID.Cobweb);
                                break;
                            case 8:
                                if (!WorldGen.SolidTile(CastleSpawnX + i, CastleSpawnY + j))
                                    WorldGen.KillTile(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.SlopeTile(CastleSpawnX + i, CastleSpawnY + j, 0);
                                WorldGen.PlaceTile(CastleSpawnX + i, CastleSpawnY + j, TileID.Dirt, false, false, -1, 19);
                                break;
                            case 9:
                                WorldGen.KillTile(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.KillWall(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.PlaceTile(CastleSpawnX + i, CastleSpawnY + j, TileID.Platforms, false, false, -1, 19);
                                break;
                            case 10:
                                WorldGen.KillTile(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.KillWall(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.PlaceTile(CastleSpawnX + i, CastleSpawnY + j, TileID.Chain);
                                break;
                        }
                    }
                }

                WorldGen.PlaceTile(CastleSpawnX + 13, CastleSpawnY + 10, TileID.Torches, false, false, -1, 4);
                WorldGen.PlaceTile(CastleSpawnX + 21, CastleSpawnY + 10, TileID.Torches, false, false, -1, 4);
                WorldGen.PlaceTile(CastleSpawnX + 43, CastleSpawnY + 3, TileID.Torches, false, false, -1, 4);
                WorldGen.PlaceTile(CastleSpawnX + 36, CastleSpawnY + 6, TileID.Torches, false, false, -1, 4);
                WorldGen.PlaceTile(CastleSpawnX + 25, CastleSpawnY + 16, TileID.Torches, false, false, -1, 4);
                WorldGen.PlaceTile(CastleSpawnX + 4, CastleSpawnY + 19, TileID.Torches, false, false, -1, 4);
                WorldGen.PlaceTile(CastleSpawnX + 37, CastleSpawnY + 18, TileID.Torches, false, false, -1, 4);
                WorldGen.PlaceTile(CastleSpawnX + 13, CastleSpawnY + 30, TileID.Torches, false, false, -1, 4);
                WorldGen.PlaceTile(CastleSpawnX + 37, CastleSpawnY + 19, TileID.BoneBlock);
                WorldGen.PlaceTile(CastleSpawnX + 3, CastleSpawnY + 23, TileID.Books, false, false, -1, 1);
                WorldGen.PlaceTile(CastleSpawnX + 4, CastleSpawnY + 23, TileID.Books, false, false, -1, 0);
                WorldGen.PlaceTile(CastleSpawnX + 5, CastleSpawnY + 21, TileID.Banners);
                WorldGen.PlaceTile(CastleSpawnX + 9, CastleSpawnY + 21, TileID.Banners);
                WorldGen.Place3x3(CastleSpawnX + 7, CastleSpawnY + 21, (ushort)ModContent.TileType<OrcishChandelier>(), 0);
                WorldGen.Place2x2(CastleSpawnX + 11, CastleSpawnY + 23, (ushort)ModContent.TileType<OrcishCandelabra>(), 0);
                WorldGen.Place1xX(CastleSpawnX + 12, CastleSpawnY + 27, (ushort)ModContent.TileType<OrcishDoorClosed>());
                WorldGen.PlaceChest(CastleSpawnX + 16, CastleSpawnY + 33, 21, false, 5);
                WorldGen.Place1xX(CastleSpawnX + 19, CastleSpawnY + 33, TileID.ClosedDoor, 30);
                WorldGen.Place2x1(CastleSpawnX + 21, CastleSpawnY + 33, TileID.WorkBenches, 23);
                WorldGen.PlaceOnTable1x1(CastleSpawnX + 22, CastleSpawnY + 32, TileID.Bottles, 4);
                WorldGen.Place3x3(CastleSpawnX + 24, CastleSpawnY + 33, TileID.Sawmill);
                WorldGen.Place2x1(CastleSpawnX + 26, CastleSpawnY + 33, TileID.Anvils, 1);
                WorldGen.Place1xX(CastleSpawnX + 29, CastleSpawnY + 33, TileID.ClosedDoor, 30);
                WorldGen.PlaceTile(CastleSpawnX + 20, CastleSpawnY + 29, ModContent.TileType<OrcishCandle>());
                WorldGen.PlaceTile(CastleSpawnX + 21, CastleSpawnY + 29, TileID.Banners);
                WorldGen.PlaceTile(CastleSpawnX + 27, CastleSpawnY + 29, TileID.Banners);
                WorldGen.PlaceTile(CastleSpawnX + 28, CastleSpawnY + 29, ModContent.TileType<OrcishCandle>());
                WorldGen.PlaceTile(CastleSpawnX + 30, CastleSpawnY + 29, ModContent.TileType<OrcishCandle>());
                WorldGen.Place2x2(CastleSpawnX + 33, CastleSpawnY + 33, TileID.CookingPots, 0);
                WorldGen.Place3x2(CastleSpawnX + 35, CastleSpawnY + 33, TileID.Furnaces);
                WorldGen.PlaceTile(CastleSpawnX + 19, CastleSpawnY + 26, (ushort)ModContent.TileType<OrcishLamp>());
                int orcishchest = WorldGen.PlaceChest(CastleSpawnX + 20, CastleSpawnY + 27, (ushort)ModContent.TileType<OrcishChest>(), false, 0);
                int orcishchestIndex = Chest.FindChest(CastleSpawnX + 20, CastleSpawnY + 26);
                if (orcishchestIndex != -1)
                {
                    GenerateBiomeOrcishChestLoot(Main.chest[orcishchestIndex].item);
                }
                WorldGen.Place1x2(CastleSpawnX + 25, CastleSpawnY + 27, (ushort)ModContent.TileType<OrcishChair>(), 0);
                Tile tile1 = Framing.GetTileSafely(CastleSpawnX + 25, CastleSpawnY + 27);
                Tile tile1under = Framing.GetTileSafely(CastleSpawnX + 25, CastleSpawnY + 26);
                tile1.TileFrameX += 18;
                tile1under.TileFrameX += 18;
                WorldGen.Place3x2(CastleSpawnX + 27, CastleSpawnY + 27, (ushort)ModContent.TileType<OrcishTable>(), 0);
                WorldGen.PlaceOnTable1x1(CastleSpawnX + 28, CastleSpawnY + 25, TileID.Bottles, 4);
                WorldGen.Place1x2(CastleSpawnX + 29, CastleSpawnY + 27, (ushort)ModContent.TileType<OrcishChair>(), 0);
                WorldGen.PlaceTile(CastleSpawnX + 31, CastleSpawnY + 27, (ushort)ModContent.TileType<OrcishCandle>());
                WorldGen.PlaceChest(CastleSpawnX + 32, CastleSpawnY + 27, 21, false, 5);
                WorldGen.Place1x2Top(CastleSpawnX + 28, CastleSpawnY + 21, (ushort)ModContent.TileType<OrcishLantern>(), 0);
                WorldGen.Place1x2Top(CastleSpawnX + 31, CastleSpawnY + 21, (ushort)ModContent.TileType<OrcishLantern>(), 0);
                WorldGen.PlaceTile(CastleSpawnX + 36, CastleSpawnY + 22, TileID.Books);
                WorldGen.PlaceTile(CastleSpawnX + 40, CastleSpawnY + 27, (ushort)ModContent.TileType<OrcishCandle>());
                WorldGen.PlaceChest(CastleSpawnX + 41, CastleSpawnY + 27, 21, false, 5);
                WorldGen.Place3x2(CastleSpawnX + 20, CastleSpawnY + 21, (ushort)ModContent.TileType<OrcishTable>());
                WorldGen.PlaceTile(CastleSpawnX + 22, CastleSpawnY + 20, (ushort)ModContent.TileType<OrcishLamp>());
                WorldGen.Place1x2(CastleSpawnX + 18, CastleSpawnY + 21, (ushort)ModContent.TileType<OrcishChair>(), 0);
                Tile tile2 = Framing.GetTileSafely(CastleSpawnX + 18, CastleSpawnY + 21);
                Tile tile2under = Framing.GetTileSafely(CastleSpawnX + 18, CastleSpawnY + 20);
                tile2.TileFrameX += 18;
                tile2under.TileFrameX += 18;
                WorldGen.PlaceOnTable1x1(CastleSpawnX + 19, CastleSpawnY + 19, TileID.Bottles);
                WorldGen.Place2x1(CastleSpawnX + 20, CastleSpawnY + 19, TileID.Bowls, 3);
                WorldGen.Place1x2Top(CastleSpawnX + 20, CastleSpawnY + 12, (ushort)ModContent.TileType<OrcishLantern>(), 0);
                WorldGen.PlaceTile(CastleSpawnX + 12, CastleSpawnY + 15, (ushort)ModContent.TileType<OrcishLamp>());
                WorldGen.PlaceChest(CastleSpawnX + 21, CastleSpawnY + 16, 21, false, 5);
                WorldGen.Place1xX(CastleSpawnX + 23, CastleSpawnY + 16, (ushort)ModContent.TileType<OrcishDoorClosed>());
                WorldGen.PlaceTile(CastleSpawnX + 37, CastleSpawnY + 13, (ushort)ModContent.TileType<OrcishLamp>());
                WorldGen.Place3x2(CastleSpawnX + 37, CastleSpawnY + 9, (ushort)ModContent.TileType<OrcishTable>());
                WorldGen.Place1x2(CastleSpawnX + 39, CastleSpawnY + 9, (ushort)ModContent.TileType<OrcishChair>(), 0);
                WorldGen.PlaceOnTable1x1(CastleSpawnX + 36, CastleSpawnY + 7, TileID.Books, 0);
                WorldGen.PlaceOnTable1x1(CastleSpawnX + 37, CastleSpawnY + 7, TileID.Bottles);
                WorldGen.Place3x3(CastleSpawnX + 40, CastleSpawnY + 5, (ushort)ModContent.TileType<OrcishChandelier>());
                WorldGen.PlaceObject(CastleSpawnX + 7, CastleSpawnY + 27, (ushort)ModContent.TileType<DeadCourier>());

                int[,] CastleWall = new int[,]
                {
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 6, 0, 0, 5, 0, 0, 0, 1, 0, 0, 1, 0, 6, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 0, 0, 1, 1, 5, 1, 1, 1, 1, 1, 1, 0, 6, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 1, 4, 1, 1, 1, 1, 1, 4, 5, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 1, 4, 1, 7, 1, 7, 1, 4, 1, 0, 5, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 1, 4, 1, 7, 1, 7, 1, 4, 5, 0, 5, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 4, 1, 7, 1, 8, 1, 4, 1, 5, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 4, 1, 1, 1, 1, 1, 4, 1, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1, 0, 0, 2, 0, 0, 1, 0, 0, 6, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 3, 1, 2, 1, 1, 1, 0, 5, 0, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 4, 1, 1, 1, 1, 1, 4, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 1, 7, 1, 7, 1, 4, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 8, 1, 7, 1, 7, 1, 7, 1, 7, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 4, 1, 8, 1, 7, 1, 4, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 7, 1, 7, 1, 7, 1, 8, 1, 8, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 6, 0, 4, 1, 1, 1, 1, 1, 4, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 7, 1, 7, 1, 7, 1, 7, 1, 8, 1, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 0, 5, 6, 0, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 4, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 5, 6, 5, 1, 5, 6, 5, 0, 4, 1, 1, 1, 1, 1, 4, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 0, 0, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 1, 7, 1, 8, 1, 4, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 6, 0, 6, 5, 0, 1, 4, 3, 1, 1, 1, 1, 4, 1, 1, 0, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 0, 4, 1, 7, 1, 7, 1, 4, 0, 0, 5, 0, 0 },
                    { 0, 0, 1, 0, 0, 1, 0, 0, 1, 6, 5, 5, 0, 3, 4, 7, 1, 8, 1, 7, 7, 1, 1, 0, 1, 1, 3, 1, 1, 1, 1, 1, 1, 1, 4, 1, 0, 0, 1, 1, 1, 1, 1, 2, 1, 1, 1, 5, 0 },
                    { 0, 0, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 1, 4, 8, 1, 7, 1, 8, 4, 1, 1, 0, 4, 3, 1, 1, 1, 1, 3, 1, 1, 1, 4, 1, 0, 0, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 5, 5, 1, 3, 1, 1, 1, 4, 1, 0, 1, 4, 7, 1, 7, 1, 7, 4, 1, 1, 0, 4, 1, 1, 1, 1, 3, 1, 1, 1, 1, 4, 1, 1, 0, 1, 1, 1, 3, 2, 0, 5, 5, 5, 0, 0 },
                    { 0, 0, 0, 5, 4, 1, 1, 1, 3, 3, 4, 1, 0, 1, 4, 1, 1, 1, 0, 0, 0, 0, 0, 0, 4, 1, 1, 1, 2, 2, 2, 1, 1, 1, 4, 1, 1, 0, 1, 1, 1, 1, 3, 0, 5, 0, 0, 0, 0 },
                    { 0, 0, 0, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 1, 1, 1, 1, 1, 1, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 4, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 3, 4, 3, 3, 3, 1, 1, 4, 1, 0, 2, 4, 1, 1, 3, 1, 3, 4, 1, 1, 1, 4, 1, 1, 3, 1, 3, 3, 1, 3, 1, 4, 1, 1, 4, 2, 3, 2, 1, 1, 0, 0, 0, 0, 0, 0 },
                    { 0, 8, 7, 3, 4, 3, 1, 1, 1, 1, 4, 1, 1, 2, 4, 1, 3, 1, 1, 1, 4, 1, 1, 1, 4, 1, 3, 1, 1, 1, 3, 2, 1, 1, 4, 1, 1, 4, 1, 2, 1, 1, 1, 8, 7, 0, 0, 0, 0 },
                    { 0, 7, 7, 2, 4, 1, 1, 1, 2, 1, 4, 1, 2, 1, 4, 1, 2, 1, 2, 1, 4, 1, 1, 2, 4, 1, 1, 1, 1, 1, 2, 2, 1, 1, 4, 1, 1, 4, 1, 1, 1, 2, 2, 7, 8, 0, 0, 0, 0 },
                    { 0, 7, 8, 2, 4, 2, 2, 2, 2, 2, 4, 2, 2, 2, 4, 2, 2, 2, 2, 2, 4, 2, 2, 2, 4, 1, 2, 2, 2, 2, 2, 2, 2, 2, 4, 1, 1, 4, 2, 2, 2, 2, 2, 8, 8, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 3, 3, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 4, 2, 2, 2, 2, 2, 4, 2, 2, 2, 2, 2, 2, 4, 2, 2, 2, 4, 2, 2, 4, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 4, 2, 2, 2, 2, 2, 4, 2, 2, 3, 2, 2, 2, 4, 2, 2, 2, 4, 2, 3, 4, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 4, 2, 2, 2, 2, 2, 4, 2, 2, 3, 3, 2, 2, 4, 2, 2, 2, 4, 3, 3, 4, 1, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 4, 2, 3, 2, 2, 2, 4, 2, 3, 2, 2, 2, 2, 4, 2, 2, 2, 4, 2, 2, 4, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 4, 3, 2, 2, 2, 2, 4, 2, 2, 2, 2, 2, 2, 4, 2, 2, 2, 4, 2, 3, 4, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                };
                for (int j = 0; j < CastleWall.GetLength(0); j++)
                {
                    for (int i = 0; i < CastleWall.GetLength(1); i++)
                    {
                        switch (CastleWall[j, i])
                        {
                            case 0:
                                WorldGen.KillWall(CastleSpawnX + i, CastleSpawnY + j);
                                break;
                            case 1:
                                WorldGen.KillWall(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.PlaceWall(CastleSpawnX + i, CastleSpawnY + j, WallID.GrayBrick);
                                break;
                            case 2:
                                WorldGen.KillWall(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.PlaceWall(CastleSpawnX + i, CastleSpawnY + j, WallID.MudstoneBrick);
                                WorldGen.paintWall(CastleSpawnX + i, CastleSpawnY + j, 27);
                                break;
                            case 3:
                                WorldGen.KillWall(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.PlaceWall(CastleSpawnX + i, CastleSpawnY + j, WallID.Stone);
                                break;
                            case 4:
                                WorldGen.KillWall(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.PlaceWall(CastleSpawnX + i, CastleSpawnY + j, WallID.Wood);
                                break;
                            case 5:
                                WorldGen.KillWall(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.PlaceWall(CastleSpawnX + i, CastleSpawnY + j, WallID.LivingLeaf);
                                WorldGen.paintWall(CastleSpawnX + i, CastleSpawnY + j, 4);
                                break;
                            case 6:
                                WorldGen.KillWall(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.PlaceWall(CastleSpawnX + i, CastleSpawnY + j, WallID.Flower);
                                WorldGen.paintWall(CastleSpawnX + i, CastleSpawnY + j, 4);
                                break;
                            case 7:
                                WorldGen.KillWall(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.PlaceWall(CastleSpawnX + i, CastleSpawnY + j, WallID.IronFence);
                                break;
                            case 8:
                                WorldGen.KillWall(CastleSpawnX + i, CastleSpawnY + j);
                                WorldGen.PlaceWall(CastleSpawnX + i, CastleSpawnY + j, WallID.MetalFence);
                                break;
                        }
                    }
                }
                int[,] CastleSlope = new int[,]
            {
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 3, 0, 0, 0, 0, 0, 0, 0, 4, 0, 3, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 3, 0, 1, 0, 0, 0, 4, 0, 3, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 2, 0, 4, 0, 0, 0, 0, 0 },
                    { 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 4, 0, 3, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 2, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0 },
                    { 0, 4, 0, 3, 0, 0, 0, 0, 0, 0, 0, 4, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 1, 0, 0, 0, 0, 3, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },

            };
                for (int j = 0; j < CastleSlope.GetLength(0); j++)
                {
                    for (int i = 0; i < CastleSlope.GetLength(1); i++)
                    {
                        switch (CastleSlope[j, i])
                        {
                            case 0:
                                break;
                            case 1:
                                WorldGen.SlopeTile(CastleSpawnX + i, CastleSpawnY + j, 1);
                                break;
                            case 2:
                                WorldGen.SlopeTile(CastleSpawnX + i, CastleSpawnY + j, 2);
                                break;
                            case 3:
                                WorldGen.SlopeTile(CastleSpawnX + i, CastleSpawnY + j, 3);
                                break;
                            case 4:
                                WorldGen.SlopeTile(CastleSpawnX + i, CastleSpawnY + j, 4);
                                break;
                        }
                    }
                }
                WorldGen.PlaceObject(CastleSpawnX + 25, CastleSpawnY + 22, (ushort)ModContent.TileType<OrcishCoatOfArms>());
                WorldGen.PlaceObject(CastleSpawnX + 33, CastleSpawnY + 22, (ushort)ModContent.TileType<OrcishCoatOfArms>());
                for (int i = 0; i < 50; i++)
                {
                    int n = 0;
                    while (!WorldGen.SolidTile(CastleSpawnX + i, CastleSpawnY + 35 + n))
                    {
                        WorldGen.KillTile(CastleSpawnX + i, CastleSpawnY + 35 + n);
                        WorldGen.PlaceTile(CastleSpawnX + i, CastleSpawnY + 35 + n, TileID.Dirt);
                        n++;
                    }
                }

            #endregion
            IL_38:
                ;
            }));
        }
        #region Chests Loot
        void GenerateBiomeTailorChestLoot(Item[] chestInventory)
        {
            int TailorcurrentIndex = 0;
            chestInventory[TailorcurrentIndex].SetDefaults(ModContent.ItemType<SecondPartOfAmulet>()); TailorcurrentIndex++;
        }
        void GenerateBiomeMainChestLoot(Item[] chestInventory)
        {
            int MaincurrentIndex = 0;
            chestInventory[MaincurrentIndex].SetDefaults(ModContent.ItemType<ThirdPartOfAmulet>()); MaincurrentIndex++;
        }
        void GenerateBiomeUnderChestLoot(Item[] chestInventory)
        {
            int UndercurrentIndex = 0;
            chestInventory[UndercurrentIndex].SetDefaults(ModContent.ItemType<FourthPartOfAmulet>()); UndercurrentIndex++;
        }
        void GenerateBiomeForgeChestLoot(Item[] chestInventory)
        {
            int ForgecurrentIndex = 0;
            chestInventory[ForgecurrentIndex].SetDefaults(ModContent.ItemType<FifthPartOfAmulet>()); ForgecurrentIndex++;

        }
        void GenerateBiomeSwampChestLoot(Item[] chestInventory)
        {
            int SwampcurrentIndex = 0;
            chestInventory[SwampcurrentIndex].SetDefaults(ModContent.ItemType<UnchargedElessar>()); SwampcurrentIndex++;
        }
        void GenerateBiomeOrcishChestLoot(Item[] chestInventory)
        {
            int OrcishcurrentIndex = 0;
            chestInventory[OrcishcurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ModContent.ItemType<Doomhammer>(), ModContent.ItemType<OrcishBanner>(), ModContent.ItemType<MagnesiumOxide>(), ModContent.ItemType<WaveOfForce>())); OrcishcurrentIndex++;
            chestInventory[OrcishcurrentIndex].SetDefaults(ModContent.ItemType<Content.Items.Materials.OrcishBar>()); chestInventory[OrcishcurrentIndex].stack = Main.rand.Next(7, 20); OrcishcurrentIndex++;
            chestInventory[OrcishcurrentIndex].SetDefaults(Utils.SelectRandom(WorldGen.genRand, ItemID.TitanPotion, ItemID.RagePotion)); chestInventory[OrcishcurrentIndex].stack = Main.rand.Next(2, 4); OrcishcurrentIndex++;
            chestInventory[OrcishcurrentIndex].SetDefaults(ItemID.GoldCoin); chestInventory[OrcishcurrentIndex].stack = Main.rand.Next(4, 7); OrcishcurrentIndex++;
            chestInventory[OrcishcurrentIndex].SetDefaults(ItemID.SilverCoin); chestInventory[OrcishcurrentIndex].stack = Main.rand.Next(1, 100); OrcishcurrentIndex++;
        }
        #endregion
        public override void SaveWorldData(TagCompound tag)
        {
            tag["TotemX"] = TotemX;
            tag["TotemY"] = TotemY;
            tag["TotemCooldown"] = TotemCooldown;
            tag["IsTotemActive"] = IsTotemActive;
            tag["WitchSpawnX"] = WitchSpawnX;
            tag["WitchSpawnY"] = WitchSpawnY;
            tag["downedEoC"] = downedEoC;
            tag["downedGolem"] = downedGolem;
            tag["downedSkeletron"] = downedSkeletron;
            tag["OpenedRedChest"] = OpenedRedChest;
            tag["DestroyedMaze"] = DestroyedMaze;
            tag["WaterTempleX"] = WaterTempleX;
            tag["WaterTempleY"] = WaterTempleY;
            tag["downedBanshee"] = downedBanshee;
            tag["MazeStartX"] = MazeStartX;
            tag["MazeStartY"] = MazeStartY;
            tag["CastleSpawnX"] = CastleSpawnX;
            tag["CastleSpawnY"] = CastleSpawnY;
            tag["TombstoneX"] = TombstoneX;
            tag["TombstoneY"] = TombstoneY;
            tag["IsSwampSuccess"] = IsSwampSuccess;
            tag["IsDesertSuccess"] = IsDesertSuccess;
            tag["GeneratedCaslte"] = GeneratedCaslte;
            tag["CryptIsSpawned"] = CryptIsSpawned;
            tag["SunriseIsPlaced"] = SunriseIsPlaced;
            tag["OrcishInvasionStage"] = OrcishInvasionStage;
            tag["FirstTotemDeactivation"] = FirstTotemDeactivation;
            tag["TownTiles"] = TownTiles;
            tag["DoorsLeft"] = DoorsLeft;
            tag["DoorsRight"] = DoorsRight;
            tag["TownWalls"] = TownWalls;
            tag["DownedNecromancer"] = DownedNecromancer;
            tag["DownedRhino"] = DownedRhino;
            tag["DownedPapuanWizard"] = DownedPapuanWizard;
            tag["VampireShop"] = VampShop;
            tag["WizardDay"] = WizardDay;
            tag["downedWoF"] = downedWoF;
            tag["downedPlantera"] = downedPlantera;
            tag["downedAnyMechBoss"] = downedAnyMechBoss;
            tag["SunriseX"] = SunriseX;
            tag["SunriseY"] = SunriseY;
            tag["RemovePriest"] = RemovePriest;
            tag["DownedNecromancer"] = DownedNecromancer;
        }
        public override void LoadWorldData(TagCompound tag)
        {
            TotemX = tag.GetInt("TotemX");
            TotemY = tag.GetInt("TotemY");
            TotemCooldown = tag.GetInt("TotemCooldown");
            IsTotemActive = tag.GetBool("IsTotemActive");
            SunriseX = tag.GetInt("SunriseX");
            SunriseY = tag.GetInt("SunriseY");
            WitchSpawnX = tag.GetInt("WitchSpawnX");
            WitchSpawnY = tag.GetInt("WitchSpawnY");
            downedEoC = tag.GetBool("downedEoC");
            downedGolem = tag.GetBool("downedGolem");
            downedWoF = tag.GetBool("downedWoF");
            downedPlantera = tag.GetBool("downedPlantera");
            downedAnyMechBoss = tag.GetBool("downedAnyMechBoss");
            downedSkeletron = tag.GetBool("downedSkeletron");
            OpenedRedChest = tag.GetBool("OpenedRedChest");
            DestroyedMaze = tag.GetBool("DestroyedMaze");
            MazeStartX = tag.GetInt("MazeStartX");
            MazeStartY = tag.GetInt("MazeStartY");
            WaterTempleX = tag.GetInt("WaterTempleX");
            WaterTempleY = tag.GetInt("WaterTempleY");
            CastleSpawnX = tag.GetInt("CastleSpawnX");
            CastleSpawnY = tag.GetInt("CastleSpawnY");
            TombstoneX = tag.GetInt("TombstoneX");
            TombstoneY = tag.GetInt("TombstoneY");
            KilledBossesInWorld = tag.GetInt("KilledBossesInWorld");
            CasketCoords = tag.Get<List<Vector2>>("CasketCoords");
            IsDesertSuccess = tag.GetBool("IsDesertSuccess");
            IsSwampSuccess = tag.GetBool("IsSwampSuccess");
            CryptIsSpawned = tag.GetBool("CryptIsSpawned");
            GeneratedCaslte = tag.GetBool("GeneratedCaslte");
            SunriseIsPlaced = tag.GetBool("SunriseIsPlaced");
            downedBanshee = tag.GetBool("downedBanshee");
            DoorsLeft = tag.Get<List<Vector2>>("DoorsLeft");
            DoorsRight = tag.Get<List<Vector2>>("DoorsRight");
            DownedNecromancer = tag.GetBool("DownedNecromancer");
            DownedRhino = tag.GetBool("DownedRhino");
            DownedPapuanWizard = tag.GetBool("DownedPapuanWizard");
            OrcishInvasionStage = tag.GetInt("OrcishInvasionStage");
            FirstTotemDeactivation = tag.GetBool("FirstTotemDeactivation");
            TownTiles = tag.Get<List<Vector2>>("TownTiles");
            TownWalls = tag.Get<List<Vector2>>("TownWalls");
            VampShop = tag.GetIntArray("VampireShop");
            WizardDay = tag.GetBool("WizardDay");
            RemovePriest = tag.GetInt("RemovePriest");
        }
        public override void NetSend(BinaryWriter writer)
        {
            writer.Write(TownTiles.Count);
            foreach (var v in TownTiles)
            {
                writer.WriteVector2(v);
            }
            writer.Write(TownWalls.Count);
            foreach (var v in TownWalls)
            {
                writer.WriteVector2(v);
            }
            writer.Write(DoorsLeft.Count);
            foreach (var v in DoorsLeft)
            {
                writer.WriteVector2(v);
            }
            writer.Write(DoorsRight.Count);
            foreach (var v in DoorsRight)
            {
                writer.WriteVector2(v);
            }
            writer.Write(CasketCoords.Count);
            foreach (var v in CasketCoords)
            {
                writer.WriteVector2(v);
            }
            writer.Write(IsTotemActive);
            writer.Write(downedEoC);
            writer.Write(downedBanshee);
            writer.Write(downedSkeletron);
            writer.Write(DownedNecromancer);
            writer.Write(DownedRhino);
            writer.Write(downedWoF);
            writer.Write(DownedPapuanWizard);
            writer.Write(downedAnyMechBoss);
            writer.Write(downedPlantera);
            writer.Write(downedGolem);
            writer.Write(TotemX);
            writer.Write(TotemY);
            writer.Write(SunriseX);
            writer.Write(SunriseY);
            writer.Write(WitchSpawnX);
            writer.Write(WitchSpawnY);
            writer.Write(MazeStartX);
            writer.Write(MazeStartY);
            writer.Write(WaterTempleX);
            writer.Write(WaterTempleY);
            writer.Write(TombstoneX);
            writer.Write(TombstoneY);
            writer.Write(CastleSpawnX);
            writer.Write(CastleSpawnY);
            writer.Write(IsDesertSuccess);
            writer.Write(IsSwampSuccess);
            writer.Write(CryptIsSpawned);
            writer.Write(GeneratedCaslte);
            writer.Write(SunriseIsPlaced);
            //writer.Write(OpenedRedChest);
            writer.Write(DestroyedMaze);
            writer.Write(WizardDay);
            writer.Write(FirstTotemDeactivation);

            writer.Write(TotemCooldown);
            writer.Write(KilledBossesInWorld);
            writer.Write(OrcishInvasionStage);
            writer.Write(RemovePriest);
            for (int i = 0; i < 3; i++)
            {
                writer.Write(VampShop[i]);
            }
        }
        public override void NetReceive(BinaryReader reader)
        {
            int count = reader.ReadInt32();
            TownTiles = new List<Vector2>();
            for (int i = 0; i < count; i++)
            {
                TownTiles.Add(reader.ReadVector2());
            }
            int count2 = reader.ReadInt32();
            TownWalls = new List<Vector2>();
            for (int i = 0; i < count2; i++)
            {
                TownWalls.Add(reader.ReadVector2());
            }
            int count3 = reader.ReadInt32();
            DoorsLeft = new List<Vector2>();
            for (int i = 0; i < count3; i++)
            {
                DoorsLeft.Add(reader.ReadVector2());
            }
            int count4 = reader.ReadInt32();
            DoorsRight = new List<Vector2>();
            for (int i = 0; i < count4; i++)
            {
                DoorsRight.Add(reader.ReadVector2());
            }
            int count5 = reader.ReadInt32();
            CasketCoords = new List<Vector2>();
            for (int i = 0; i < count5; i++)
            {
                CasketCoords.Add(reader.ReadVector2());
            }
            IsTotemActive = reader.ReadBoolean();
            downedEoC = reader.ReadBoolean();
            downedBanshee = reader.ReadBoolean();
            downedSkeletron = reader.ReadBoolean();
            DownedNecromancer = reader.ReadBoolean();
            DownedRhino = reader.ReadBoolean();
            downedWoF = reader.ReadBoolean();
            DownedPapuanWizard = reader.ReadBoolean();
            downedAnyMechBoss = reader.ReadBoolean();
            downedPlantera = reader.ReadBoolean();
            downedGolem = reader.ReadBoolean();
            TotemX = reader.ReadInt32();
            TotemY = reader.ReadInt32();
            SunriseX = reader.ReadInt32();
            SunriseY = reader.ReadInt32();
            WitchSpawnX = reader.ReadInt32();
            WitchSpawnY = reader.ReadInt32();
            MazeStartX = reader.ReadInt32();
            MazeStartY = reader.ReadInt32();
            WaterTempleX = reader.ReadInt32();
            WaterTempleY = reader.ReadInt32();
            TombstoneX = reader.ReadInt32();
            TombstoneY = reader.ReadInt32();
            CastleSpawnX = reader.ReadInt32();
            CastleSpawnY = reader.ReadInt32();
            IsDesertSuccess = reader.ReadBoolean();
            IsSwampSuccess = reader.ReadBoolean();
            CryptIsSpawned = reader.ReadBoolean();
            GeneratedCaslte = reader.ReadBoolean();
            SunriseIsPlaced = reader.ReadBoolean();
            OpenedRedChest = reader.ReadBoolean();
            DestroyedMaze = reader.ReadBoolean();
            WizardDay = reader.ReadBoolean();
            FirstTotemDeactivation = reader.ReadBoolean();
            //    
            TotemCooldown = reader.ReadInt32();
            KilledBossesInWorld = reader.ReadInt32();
            OrcishInvasionStage = reader.ReadInt32();
            RemovePriest = reader.ReadInt32();
            for (int i = 0; i < 3; i++)
                VampShop[i] = reader.ReadInt32();
        }
    }
}


