using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class AdventurersBook : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = 0;
            Item.rare = 0;
            Item.useStyle = 1;
            Item.useTime = 15;
            Item.useAnimation = 15;
        }
        public override bool? UseItem(Player player)
        {
            if (!player.GetModPlayer<BismuthPlayer>().OpenedBook)
                player.GetModPlayer<BismuthPlayer>().OpenedBook = true;
            return true;
        }
    }
}
