using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
    public class OrcishShield : ModItem
    {   
        public override void SetDefaults()
        {         
            Item.value = 3000000;
            Item.defense = 3;
            Item.rare = 4;         
            Item.accessory = true;            
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetCritChance(DamageClass.Throwing) += (player.statLifeMax - player.statLife) / 7;
            player.GetDamage(DamageClass.Throwing) += 0.11f;
            if (player.statLife < 300)
                player.GetDamage(DamageClass.Throwing) += 0.07f;
            if (player.statLife < 200)
                player.GetDamage(DamageClass.Throwing) += 0.11f;
            if (player.statLife < 100)
                player.GetDamage(DamageClass.Throwing) += 0.18f;
            if (player.statLife < 50)
                player.GetDamage(DamageClass.Throwing) += 0.22f;
        }
    }
}