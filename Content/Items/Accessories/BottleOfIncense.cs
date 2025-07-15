using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    public class BottleOfIncense : ModItem
    {
        public override void SetDefaults()
        {
            Item.value = Item.buyPrice(0, 10, 0, 0);
            Item.rare = 4;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<BismuthPlayer>().Charm += 15;
        }
    }
}