using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class PaladinsMask : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("PaladinSetBonus").Value;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 0, 35, 0);
            Item.rare = 3;
            Item.defense = 6;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed -= 0.05f;
            player.GetDamage(DamageClass.Melee) += 0.1f;
            player.endurance += 0.05f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<PaladinsShell>() && legs.type == ModContent.ItemType<PaladinsLeggings>();
        }
        public override void UpdateArmorSet(Player player)
        {            
            player.GetModPlayer<BismuthPlayer>().paladinssetbonus = true;
            player.setBonus = this.GetLocalization("PaladinSetBonus").Value;
        }
    }
}