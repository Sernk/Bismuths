using Bismuth.Content.Items.Other;
using Bismuth.Content.Items.Tools;
using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;

namespace Bismuth.Content.Tiles
{
    public class WarriorsTombstone : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x3);
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16, 18 };
            TileObjectData.addTile(Type);
            TileObjectData.newTile.DrawYOffset = 0;
            AddMapEntry(new Color(193, 138, 104), CreateMapEntryName());
        }
        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }
        public override bool RightClick(int i, int j)
        {
            Player player = Main.player[Main.myPlayer];
            if (player.inventory[player.selectedItem].type == ModContent.ItemType<DirtyShovel>() && Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 20)
            {
                Main.tile[BismuthWorld.TombstoneX, BismuthWorld.TombstoneY - 1].TileFrameX += 54;
                Main.tile[BismuthWorld.TombstoneX, BismuthWorld.TombstoneY - 2].TileFrameX += 54;
                Main.tile[BismuthWorld.TombstoneX, BismuthWorld.TombstoneY - 3].TileFrameX += 54;
                Main.tile[BismuthWorld.TombstoneX - 1, BismuthWorld.TombstoneY - 1].TileFrameX += 54;
                Main.tile[BismuthWorld.TombstoneX - 1, BismuthWorld.TombstoneY - 2].TileFrameX += 54;
                Main.tile[BismuthWorld.TombstoneX - 1, BismuthWorld.TombstoneY - 3].TileFrameX += 54;
                Main.tile[BismuthWorld.TombstoneX + 1, BismuthWorld.TombstoneY - 1].TileFrameX += 54;
                Main.tile[BismuthWorld.TombstoneX + 1, BismuthWorld.TombstoneY - 2].TileFrameX += 54;
                Main.tile[BismuthWorld.TombstoneX + 1, BismuthWorld.TombstoneY - 3].TileFrameX += 54;
                SoundEngine.PlaySound(SoundID.Dig, player.position);
                player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<WarriorsRemains>());
                Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest = 30;
            }
            return true;
        }
        public override void MouseOver(int i, int j)
        {
            Player player = Main.player[Main.myPlayer];
            player.cursorItemIconEnabled = true;
            player.cursorItemIconID = ModContent.ItemType<DirtyShovel>();
        }
        public override bool CanKillTile(int i, int j, ref bool blockDamaged)
        {
            if (Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 0)return false;
            return base.CanKillTile(i, j, ref blockDamaged);
        }
        public override bool CanExplode(int i, int j)
        {
            if (Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 0) return false;     
            return base.CanExplode(i, j);
        }
        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            if (Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 20)
            {
                NPC.NewNPC(Main.LocalPlayer.GetSource_FromThis(), i * 16, j * 16, NPCID.Skeleton);
                Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest = 40;
            }
        }
    }
}