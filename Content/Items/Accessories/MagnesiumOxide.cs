using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    public class MagnesiumOxide : ModItem
    {     
        public override void SetDefaults()
        {            
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 5;
            Item.accessory = true;
        }     
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.ThrownVelocity += 0.4f;
            player.GetDamage(DamageClass.Throwing) -= 0.08f;
        }
    }
}