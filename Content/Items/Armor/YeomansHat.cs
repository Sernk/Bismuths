using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class YeomansHat : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("YeomanSetBonus").Value;
        }
        public override void SetDefaults()
        {          
            Item.width = 18;
            Item.height = 18;         
            Item.value = Item.buyPrice(0, 0, 40, 0);
            Item.rare = 1;
            Item.defense = 2;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Ranged) += 0.09f;
            player.arrowDamage += 0.12f; 
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<YeomansShirt>() && legs.type == ModContent.ItemType<YeomansLeggings>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.statDefense += 1;
            player.setBonus = this.GetLocalization("YeomanSetBonus").Value; ;
        }      
    }
}