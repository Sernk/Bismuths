using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class RekstrisBoots : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.rare = 9;
            Item.vanity = true;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<BismuthPlayer>().IsEquippedRekstrisBoots = true;
        }
        public override void UpdateVanity(Player player)
        {
            player.GetModPlayer<BismuthPlayer>().IsEquippedRekstrisBoots = true;
        }
    }
}