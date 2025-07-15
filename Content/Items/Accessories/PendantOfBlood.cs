using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    public class PendantOfBlood : ModItem
    {
        public override void SetDefaults()
        {
            Item.value = Item.buyPrice(0, 7, 50, 0);
            Item.rare = 2;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<BismuthPlayer>().IsEquippedPendant = true;
        }
    }
}