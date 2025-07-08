using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(new EquipType[] { EquipType.Back, EquipType.Front })]
    public class ShinyCover : ModItem
    {
        public override void SetDefaults()
        {           
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 4;
            Item.accessory = true;
        }      
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<BismuthPlayer>().OrbitalAlive = true;                          
        }
    }
}