using Bismuth.Content.Items.Materials;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class FrozenWarderersHood : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("FrozenWardererSetBonus").Value;
        }
        public override void SetDefaults()
        {         
            Item.width = 18;
            Item.height = 18;        
            Item.value = Item.sellPrice(0, 0, 35, 0);
            Item.rare = 1;
            Item.defense = 1;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Magic) += 0.06f;          
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<FrozenWarderersBreastplate>() && legs.type == ModContent.ItemType<FrozenWarderersLeggings>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.GetDamage(DamageClass.Magic) += 0.08f;
            player.setBonus = this.GetLocalization("FrozenWardererSetBonus").Value; ;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(225, 8);
            recipe.AddIngredient(ModContent.ItemType<IceCrystal>(), 10);
            recipe.AddTile(86);
            recipe.Register();
        }
    }
}