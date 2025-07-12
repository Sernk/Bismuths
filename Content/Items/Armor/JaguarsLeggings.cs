using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class JaguarsLeggings : ModItem
    {
        public override void SetDefaults()
        {           
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 1, 59, 0);
            Item.rare = 4;
            Item.defense = 4;        
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.2f;
        }      
    }
}