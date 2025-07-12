using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class NomadsHood : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("NomadSetBonus").Value;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 1, 20, 0);
            Item.rare = 8;
            Item.defense = 4;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<ModP>().assassinDamage += 0.05f;
            player.GetCritChance(DamageClass.Melee) += 13;
            player.GetCritChance(DamageClass.Ranged) += 13;
            player.GetCritChance(DamageClass.Magic) += 13;
            player.GetCritChance(DamageClass.Throwing) += 13;
            player.GetModPlayer<ModP>().assassinCrit += 13;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<NomadsJacket>() && legs.type == ModContent.ItemType<NomadsBoots>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = this.GetLocalization("NomadSetBonus").Value;
            player.GetModPlayer<BismuthPlayer>().nomadsetbonus = true;
        }
    }
}