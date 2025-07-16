using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class FaithTreatise : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 1, 50, 0);
            Item.rare = 3;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
            Item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            if (!player.GetModPlayer<BismuthPlayer>().IsFTRead)
                return true;
            else
                return false;
        }
        public override bool? UseItem(Player player)
        {
            player.GetModPlayer<BismuthPlayer>().IsFTRead = true;
            player.GetModPlayer<BismuthPlayer>().FTDaily = true;
            return true;
        }
    }
}
