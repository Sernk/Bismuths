using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class CobaltHeadgear : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("CobaltHeadgearSetBonus").Value;
        }
        public override void SetDefaults()
        {          
            Item.width = 18;         
            Item.height = 18;
            Item.value = Item.sellPrice(0, 1, 50, 0);
            Item.rare = 4;
            Item.defense = 8;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Throwing) += 0.1f;
            player.ThrownVelocity += 0.1f;
            player.GetCritChance(DamageClass.Throwing) += 10;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == 374 && legs.type == 375;  
        }
        public override void UpdateArmorSet(Player player)
        {
            player.ThrownCost33 = true;
            player.setBonus = this.GetLocalization("CobaltHeadgearSetBonus").Value; ;
        }
        public override void AddRecipes()  
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CobaltBar, 10);   
            recipe.AddTile(TileID.Anvils);   
            recipe.Register();
        }
    }
}