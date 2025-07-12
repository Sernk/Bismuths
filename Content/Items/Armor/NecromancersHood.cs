using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class NecromancersHood : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 7, 0, 0);
            Item.rare = 3;
            Item.defense = 2;
        }
        public override void UpdateEquip(Player player)
        {
            player.maxMinions++;
            player.GetDamage(DamageClass.Summon) += 0.1f;
            player.GetModPlayer<BismuthPlayer>().Charm -= 5;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<NecromancersRobe>();
        }
    }
}