using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class TitaniumHat : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("TitaniumHatSetBonus").Value;
        }
        public override void SetDefaults()
        {         
            Item.width = 18;
            Item.height = 18;         
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = 4;
            Item.defense = 16;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Throwing) += 0.2f;
            player.ThrownVelocity += 0.2f;
            player.GetCritChance(DamageClass.Throwing) += 15;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ItemID.TitaniumBreastplate && legs.type == ItemID.TitaniumLeggings;
        }
        public override void UpdateArmorSet(Player player)
        {
            player.ThrownCost33 = true;
            player.setBonus = this.GetLocalization("TitaniumHatSetBonus").Value;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.TitaniumBar, 13);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}