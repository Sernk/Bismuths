﻿using Bismuth.Content.Items.Other;
using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.DataStructures;
using Terraria.Enums;
using Terraria.GameContent.ObjectInteractions;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Bismuth.Content.NPCs;

namespace Bismuth.Content.Tiles
{
    public class RedMazeChest : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileSpelunker[Type] = true;
            Main.tileContainer[Type] = true;
            Main.tileShine2[Type] = true;
            Main.tileShine[Type] = 1200;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileOreFinderPriority[Type] = 500;
            TileID.Sets.HasOutlines[Type] = true;
            TileID.Sets.BasicChest[Type] = true;
            TileID.Sets.DisableSmartCursor[Type] = true;
            TileID.Sets.AvoidedByNPCs[Type] = true;
            TileID.Sets.InteractibleByNPCs[Type] = true;
            TileID.Sets.IsAContainer[Type] = true;
            TileID.Sets.FriendlyFairyCanLureTo[Type] = true;
            TileID.Sets.GeneralPlacementTiles[Type] = false;
            AdjTiles = new int[] { TileID.Containers };
            AddMapEntry(Color.Red, this.GetLocalization("MapEntry1"), MapChestName);
            DustType = 79;
            RegisterItemDrop(ItemID.Chest);
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Origin = new Point16(0, 1);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
            TileObjectData.newTile.HookCheckIfCanPlace = new PlacementHook(Chest.FindEmptyChest, -1, 0, true);
            TileObjectData.newTile.HookPostPlaceMyPlayer = new PlacementHook(Chest.AfterPlacement_Hook, -1, 0, false);
            TileObjectData.newTile.AnchorInvalidTiles = new int[] { TileID.MagicalIceBlock, TileID.Boulder, TileID.BouncyBoulder, TileID.LifeCrystalBoulder, TileID.RollingCactus };
            TileObjectData.newTile.StyleHorizontal = true;
            TileObjectData.newTile.LavaDeath = false;
            TileObjectData.newTile.AnchorBottom = new AnchorData(AnchorType.SolidTile | AnchorType.SolidWithTop | AnchorType.SolidSide, TileObjectData.newTile.Width, 0);
            TileObjectData.addTile(Type);
        }
        public override ushort GetMapOption(int i, int j)
        {
            return (ushort)(Main.tile[i, j].TileFrameX / 36);
        }
        public override void Load()
        {
            _ = this.GetLocalization("MazeChest").Value;
        }
        public override LocalizedText DefaultContainerName(int frameX, int frameY)
        {
            int option = frameX / 36;
            return this.GetLocalization("MazeChest");
        }
        public override bool HasSmartInteract(int i, int j, SmartInteractScanSettings settings)
        {
            return true;
        }
        public override bool IsLockedChest(int i, int j)
        {
            return Main.tile[i, j].TileFrameX / 36 == 1;
        }
        public override bool UnlockChest(int i, int j, ref short frameXAdjustment, ref int dustType, ref bool manual)
        {
            if (Main.dayTime)
            {
                Main.NewText("The chest stubbornly refuses to open in the light of the day. Try again at night.", Color.Orange);
                return false;
            }

            DustType = dustType;
            return true;
        }
        public override bool LockChest(int i, int j, ref short frameXAdjustment, ref bool manual)
        {
            int style = TileObjectData.GetTileStyle(Main.tile[i, j]);
            if (style == 0)
            {
                return true;
            }
            return false;
        }
        public static string MapChestName(string name, int i, int j)
        {
            int left = i;
            int top = j;
            Tile tile = Main.tile[i, j];
            if (tile.TileFrameX % 36 != 0)
            {
                left--;
            }

            if (tile.TileFrameY != 0)
            {
                top--;
            }

            int chest = Chest.FindChest(left, top);
            if (chest < 0)
            {
                return Language.GetTextValue("LegacyChestType.0");
            }

            if (Main.chest[chest].name == "")
            {
                return name;
            }

            return name + ": " + Main.chest[chest].name;
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = 1;
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Chest.DestroyChest(i, j);
        }
        public override bool RightClick(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[i, j];

            Main.mouseRightRelease = false;

            int keySlot = -1;
            for (int k = 0; k < 58; k++)
            {
                if (player.inventory[k].type == ModContent.ItemType<RedKey>() && player.inventory[k].stack > 0)
                {
                    keySlot = k;
                    break;
                }
            }

            if (keySlot == -1 && !SavingOpenChests.RChest) return false;

            SavingOpenChests.RChest = true;

            int left = i;
            int top = j;

            if (tile.TileFrameX % 36 != 0) left--;
            if (tile.TileFrameY != 0) top--;

            player.CloseSign();
            player.SetTalkNPC(-1);
            Main.npcChatCornerItem = 0;
            Main.npcChatText = string.Empty;
            if (Main.editChest)
            {
                SoundEngine.PlaySound(SoundID.MenuTick);
                Main.editChest = false;
                Main.npcChatText = string.Empty;
            }
            if (player.editedChestName)
            {
                NetMessage.SendData(MessageID.SyncPlayerChest, -1, -1, NetworkText.FromLiteral(Main.chest[player.chest].name), player.chest, 1f);
                player.editedChestName = false;
            }

            bool isLocked = Chest.IsLocked(left, top);

            if (Main.netMode == NetmodeID.MultiplayerClient && !isLocked)
            {
                if (left == player.chestX && top == player.chestY && player.chest != -1)
                {
                    player.chest = -1;
                    Recipe.FindRecipes();
                    SoundEngine.PlaySound(SoundID.MenuClose);
                }
                else
                {
                    NetMessage.SendData(MessageID.RequestChestOpen, -1, -1, null, left, top);
                    Main.stackSplit = 600;
                }
            }
            else
            {
                if (isLocked)
                {
                    int key = ModContent.ItemType<Key>();
                    if (player.HasItemInInventoryOrOpenVoidBag(key) && Chest.Unlock(left, top) && player.ConsumeItem(key, includeVoidBag: true))
                    {
                        if (Main.netMode == NetmodeID.MultiplayerClient)
                        {
                            NetMessage.SendData(MessageID.LockAndUnlock, -1, -1, null, player.whoAmI, 1f, left, top);
                        }
                    }
                }
                else
                {
                    int chestID = Chest.FindChest(left, top);
                    if (chestID != -1)
                    {
                        Main.stackSplit = 600;
                        if (chestID == player.chest)
                        {
                            player.chest = -1;
                            SoundEngine.PlaySound(SoundID.MenuClose);
                        }
                        else
                        {
                            SoundEngine.PlaySound(player.chest < 0 ? SoundID.MenuOpen : SoundID.MenuTick);
                            player.OpenChest(left, top, chestID);
                        }

                        Recipe.FindRecipes();
                    }
                }
            }
            if (SavingOpenChests.MChest)
            {
            }
            else
            {
                SoundEngine.PlaySound(player.chest < 0 ? SoundID.MenuOpen : SoundID.MenuTick);
                BismuthWorld.DestroyedMaze = true;
                if (Main.netMode == 2)
                {
                    NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
                }
                BismuthWorld.OpenedRedChest = true;
                if (Main.netMode == 2)
                {
                    NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
                }
                Bismuth.ShakeScreen(50f, 120);
                if (Main.netMode == 0)
                {
                    for (int k = 1; k <= 57; k++)
                    {
                        for (int l = 1; l <= 56; l++)
                        {
                            if (!(k == 52 && l == 56) && !(k == 53 && l == 56) && !(k == 52 && l == 55) && !(k == 53 && l == 55))
                                WorldMethods.RavageChest(BismuthWorld.MazeStartX + k, BismuthWorld.MazeStartY + l);
                        }
                    }
                }
                for (int k = 1; k <= 57; k++)
                {
                    for (int l = 1; l <= 56; l++)
                    {
                        if (!(k < 6 && l < 5))
                        {
                            if (!(k == 52 && l == 56) && !(k == 53 && l == 56) && !(k == 52 && l == 55) && !(k == 53 && l == 55))
                            {
                                WorldGen.KillTile(BismuthWorld.MazeStartX + k, BismuthWorld.MazeStartY + l);
                                if (!Main.tile[BismuthWorld.MazeStartX + k, BismuthWorld.MazeStartY + l].HasTile && Main.netMode != 0)
                                    NetMessage.SendData(17, -1, -1, null, 0, (float)k, (float)l, 0f, 0, 0, 0);
                            }
                            if (k % 10 == 0 && l % 10 == 0)
                            {
                                WorldGen.PlaceTile(BismuthWorld.MazeStartX + k, BismuthWorld.MazeStartY + l, TileID.Torches, false, false, -1, 2);
                                if (Main.netMode == 1)
                                    NetMessage.SendTileSquare(-1, BismuthWorld.MazeStartX + k, BismuthWorld.MazeStartY + l, 1, TileChangeType.None);
                            }
                        }
                    }
                }
                if (!NPC.AnyNPCs(ModContent.NPCType<Minotaur>()))
                {
                    NPC.NewNPC(Main.LocalPlayer.GetSource_FromThis(), (BismuthWorld.MazeStartX + 6) * 16, (BismuthWorld.MazeStartY + 50) * 16, ModContent.NPCType<Minotaur>());
                    SavingOpenChests.MChest = true;
                }
            }
            return true;
        }
        public override void MouseOver(int i, int j)
        {
            Player player = Main.LocalPlayer;
            Tile tile = Main.tile[i, j];
            int left = i;
            int top = j;
            if (tile.TileFrameX % 36 != 0)
            {
                left--;
            }

            if (tile.TileFrameY != 0)
            {
                top--;
            }

            int chest = Chest.FindChest(left, top);
            player.cursorItemIconID = -1;
            if (chest < 0)
            {
                player.cursorItemIconText = Language.GetTextValue("LegacyChestType.0");
            }
            else
            {
                string defaultName = TileLoader.DefaultContainerName(tile.TileType, tile.TileFrameX, tile.TileFrameY);
                player.cursorItemIconText = Main.chest[chest].name.Length > 0 ? Main.chest[chest].name : defaultName;
                if (player.cursorItemIconText == defaultName)
                {
                    if (SavingOpenChests.RChest)
                    {
                        player.cursorItemIconID = ModContent.ItemType<Items.Placeable.RedMazeChest>();
                    }
                    else
                    {
                        player.cursorItemIconID = ModContent.ItemType<RedKey>();
                    }
                    if (Main.tile[left, top].TileFrameX / 36 == 1)
                    {
                        player.cursorItemIconID = ModContent.ItemType<Key>();
                    }

                    player.cursorItemIconText = "";
                }
            }

            player.noThrow = 2;
            player.cursorItemIconEnabled = true;
        }
        public override void MouseOverFar(int i, int j)
        {
            MouseOver(i, j);
            Player player = Main.LocalPlayer;
            int style = Main.tile[i, j].TileFrameX;
            if (style == 72 || style == 90)
            {
                player.cursorItemIconID = ModContent.ItemType<RedKey>();
                player.cursorItemIconText = "";
            }
            else
            {
                player.cursorItemIconID = ModContent.ItemType<Items.Placeable.RedMazeChest>();
            }
        }
    }
}