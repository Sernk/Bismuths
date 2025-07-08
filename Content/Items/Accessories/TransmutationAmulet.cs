using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    public class TransmutationAmulet : ModItem
    {
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 4;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.potionDelay -= 300;
            player.potionDelayTime -= 300;
        }
    }
}