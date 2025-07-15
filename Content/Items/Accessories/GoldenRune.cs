using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(new EquipType[] { EquipType.Back, EquipType.Front })]
    public class GoldenRune : ModItem
    {
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 1, 50, 0);
            Item.rare = 5;
            Item.accessory = true;
            Item.width = 40;
            Item.height = 40;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.lifeRegen += 4;
            player.GetModPlayer<BismuthPlayer>().IsEquippedGoldenRune = true;
        }
    }
}