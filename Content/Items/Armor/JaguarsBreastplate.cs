using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class JaguarsBreastplate : ModItem
    { 
        public override void SetDefaults()
        {           
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 2, 34, 0);
            Item.rare = 4;
            Item.defense = 6;         
        }
        public override void UpdateEquip(Player player)
        {
            player.wingTimeMax += 40;
            player.jumpBoost = true;
        }
    }
}