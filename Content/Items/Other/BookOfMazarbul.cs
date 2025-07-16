using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class BookOfMazarbul : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 3;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 4;
            Item.consumable = true;
        }
        public override bool? UseItem(Player player)
        {
            if (!player.GetModPlayer<BismuthPlayer>().NoRPGGameplay)
            {
                player.GetModPlayer<BismuthPlayer>().SkillPoints++;
                player.GetModPlayer<BismuthPlayer>().IsReadMazarbul = true;
            }
            return true;
        }
    }
}