using Bismuth.Content.Items.Accessories;
using Bismuth.Content.Items.Materials;
using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class OpenedBeggarsCasket : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 30;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 1;
        }
        public override bool CanRightClick()
        {
            return true;
        }
        public override void RightClick(Player player)
        {
            var source = player.GetSource_FromThis();
            player.GetModPlayer<BismuthPlayer>().CasketCount++;
            player.QuickSpawnItem(source, ModContent.ItemType<DwarvenCoin>(), Main.rand.Next(1, 3));
            player.QuickSpawnItem(source, ModContent.ItemType<PieceOfTabula>());
            if (player.GetModPlayer<BismuthPlayer>().CasketCount == 7)
            {
                player.QuickSpawnItem(source, ModContent.ItemType<RingOfOmnipotence>());
            }
        }
    }
}
