using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    public class DiceCup : ModItem
    {
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 2;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<BismuthPlayer>().IsEquippedDiceCup = true;
        }
    }
}