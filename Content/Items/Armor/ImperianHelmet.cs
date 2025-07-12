using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ImperianHelmet : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("ImperianSetBonus").Value;
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.buyPrice(0, 0, 35, 0);
            Item.rare = 0;
            Item.defense = 1;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Melee) += 3;
            player.GetCritChance(DamageClass.Ranged) += 3;
            player.GetCritChance(DamageClass.Magic) += 3;
            player.GetCritChance(DamageClass.Throwing) += 3;
            player.GetModPlayer<ModP>().assassinCrit += 3;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<Lorica>() && legs.type == ModContent.ItemType<Ocrea>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.GetDamage(DamageClass.Melee) += 0.05f;
            player.GetDamage(DamageClass.Ranged) += 0.05f;
            player.GetDamage(DamageClass.Magic) += 0.05f;
            player.GetDamage(DamageClass.Summon) += 0.05f;
            player.GetDamage(DamageClass.Throwing) += 0.05f;
            player.setBonus = this.GetLocalization("ImperianSetBonus").Value;
        }        
    }
}