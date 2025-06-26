using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Enums;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ObjectData;
using Bismuth.Content.Items.Other;

namespace Bismuth.Content.Tiles
{
    public class DeadCourier : ModTile
    {
        public override void SetStaticDefaults()
        {
            Main.tileFrameImportant[Type] = true;
            Main.tileLavaDeath[Type] = true;
            TileObjectData.newTile.CopyFrom(TileObjectData.Style2x1);
            TileObjectData.newTile.Height = 1;
            TileObjectData.newTile.Width = 3;
            TileObjectData.newTile.CoordinateHeights = new int[] { 16 };
            TileObjectData.addTile(Type);
            //////ModTranslation name = CreateMapEntryName();
            TileObjectData.newTile.DrawYOffset = 2;
            //name.SetDefault("");
            AddMapEntry(new Color(48, 40, 35), CreateMapEntryName());

        }
        public override bool RightClick(int i, int j)
        {
            Player player = Main.player[Main.myPlayer];
            if (Main.LocalPlayer.GetModPlayer<Quests>().ReportQuest == 20)
            {                           
                player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<ScoutsReport>());
                Main.LocalPlayer.GetModPlayer<Quests>().ReportQuest = 30;
            }
            return true;
        }
        public override bool CanKillTile(int i, int j, ref bool blockDamaged)
        {
            return false;
        }
        public override bool CanExplode(int i, int j)
        {
            return false;
        }
    }
}