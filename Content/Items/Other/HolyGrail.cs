using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class HolyGrail : ModItem
    {
        public override void SetDefaults()
        {
            Item.CloneDefaults(ItemID.GreaterHealingPotion);
            Item.consumable = false;
            Item.value = Item.buyPrice(1, 0, 0, 0);
        }        
    }
}