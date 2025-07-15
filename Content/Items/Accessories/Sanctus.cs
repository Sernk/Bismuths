using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
    public class Sanctus : ModItem
    {        
        public override void SetDefaults()
        {           
            Item.value = Item.buyPrice(0, 6, 30, 0);
            Item.defense = 2;
            Item.rare = 3;           
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<BismuthPlayer>().IsEquippedSanctus = true;
            player.endurance += (player.GetModPlayer<BismuthPlayer>().sanctusdamagecounter / 1250) * 0.01f;
            player.statDefense += player.GetModPlayer<BismuthPlayer>().sanctusdamagecounter / 2000;
        }
    }
}