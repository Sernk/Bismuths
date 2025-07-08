using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Utilities;
using Bismuth.Content.Items.Materials;
using Bismuth.Content.Items.Accessories;

namespace Bismuth.Content.Items.Other
{
    public class OpenedBeggarsCasket : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Opened Beggar's Casket");
            // Tooltip.SetDefault("There are useful items inside");
           // DisplayName.AddTranslation(GameCulture.Russian, "Открытая шкатулка бедняка");
           // Tooltip.AddTranslation(GameCulture.Russian, "Содержит полезные предметы");
        }
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
