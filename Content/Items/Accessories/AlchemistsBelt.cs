using Terraria;
using Terraria.ModLoader;
using Bismuth.Utilities;
using Terraria.ID;

namespace Bismuth.Content.Items.Accessories
{
    public class AlchemistsBelt : ModItem
    {
        public override void SetDefaults()
        {
            Item.value = Item.buyPrice(0, 15, 0, 0);
            Item.rare = ItemRarityID.LightRed;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<BismuthPlayer>().IsEquippedBelt = true;
        }
    }
}