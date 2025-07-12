using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class YeomansShirt : ModItem
    {
        public override void SetDefaults()
        { 
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.buyPrice(0, 0, 50, 0);
            Item.rare = 1;
            Item.defense = 1;                   
        }
        public override void UpdateEquip(Player player)
        {  
            player.GetCritChance(DamageClass.Ranged) += 7;     
        }       
    }
}
