using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class PalladiumHat : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("PalladiumHatSetBonus").Value;
        }
        public override void SetDefaults()
        {          
            Item.width = 18;
            Item.height = 18;      
            Item.value = Item.sellPrice(0, 1, 50, 0);
            Item.rare = 4;
            Item.defense = 9;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Throwing) += 0.11f;
            player.ThrownVelocity += 0.11f;
            player.GetCritChance(DamageClass.Throwing) += 10;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.PalladiumBreastplate && legs.type == ItemID.PalladiumLeggings;  
        }
        public override void UpdateArmorSet( Player player)
        {
            player.ThrownCost33 = true;
            player.setBonus = this.GetLocalization("PalladiumHatSetBonus").Value;
        }
        public override void AddRecipes()  
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.PalladiumBar, 12);   
            recipe.AddTile(16);   
            recipe.Register();
        }
    }
}