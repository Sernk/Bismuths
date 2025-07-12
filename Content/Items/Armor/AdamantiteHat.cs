using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class AdamantiteHat : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("AdamantiteHatSetBonus").Value;
        }
        public override void SetDefaults()
        {           
            Item.width = 18;
            Item.height = 18;          
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = 4;
            Item.defense = 15;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Throwing) += 0.19f;
            player.ThrownVelocity += 0.19f;
            player.GetCritChance(DamageClass.Throwing) += 15;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == 403 && legs.type == 404;  
        }
        public override void UpdateArmorSet(Player player)
        {
            player.ThrownCost33 = true;
            player.setBonus = this.GetLocalization("AdamantiteHatSetBonus").Value;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.AdamantiteBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}