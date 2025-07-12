using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class JaguarsMask : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("JaguarSetBonus").Value;
        }
        public override void SetDefaults()
        {          
            Item.width = 18;
            Item.height = 18;          
            Item.value = Item.sellPrice(0, 1, 72, 0);
            Item.rare = 4;
            Item.defense = 5;
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.18f;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<JaguarsBreastplate>() && legs.type == ModContent.ItemType<JaguarsLeggings>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.moveSpeed += 0.3f;
            string JaguarSetBonus = this.GetLocalization("JaguarSetBonus").Value;
            player.setBonus = JaguarSetBonus;
        }
    }
}