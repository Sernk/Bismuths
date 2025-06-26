using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Bismuth.Content.Items.Materials;
using Bismuth.Content.Items.Other;
namespace Bismuth.Content.Tiles
{
    public class AltarOfWaters : ModTile
    {
        public override void SetStaticDefaults()
        {
            TileObjectData.newTile.DrawYOffset = 2;
            Main.tileNoAttach[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x2);
            TileObjectData.newTile.Height = 2;
            TileObjectData.newTile.Width = 6;
            Main.tileLighted[Type] = true;
            Main.tileFrameImportant[Type] = true;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16, 16 };
            TileObjectData.addTile(Type);
            //ModTranslation name = CreateMapEntryName();
            //name.SetDefault("Altar of Waters");
            //name.AddTranslation(GameCulture.Russian, "Алтарь вод");
            AddMapEntry(new Color(152, 171, 198), CreateMapEntryName());
            TileObjectData.newTile.DrawYOffset = 2;
        }
        public override bool CanKillTile(int i, int j, ref bool blockDamaged) // jtrit
        {
            return false;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
        public override void ModifyLight(int i, int j, ref float r, ref float g, ref float b)
        {
            r = 0f;
            g = 0.1f;
            b = 0.2f;
        }
        public override bool RightClick(int i, int j)
        {
            Player player = Main.player[Main.myPlayer];
            for (int num66 = 0; num66 < 58; num66++)
            {
                if (player.inventory[num66].type == ModContent.ItemType<UnchargedElessar>() && player.inventory[num66].stack > 0 && Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest == 200)
                {
                    player.inventory[num66].stack--;
                    player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<Elessar>());
                }
            }
            return true;
        }

        public override void MouseOver(int i, int j)
        {
            Player player = Main.player[Main.myPlayer];
            for (int num66 = 0; num66 < 58; num66++)
            {
                if (player.inventory[num66].type == ModContent.ItemType<UnchargedElessar>() && player.inventory[num66].stack > 0 && Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest == 200)
                {
                    player.cursorItemIconEnabled = true;
                    player.cursorItemIconID = ModContent.ItemType<UnchargedElessar>();
                }
            }
        }
    }
}