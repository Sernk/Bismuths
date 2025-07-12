using Bismuth.Content.Items.Materials;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class FeralHelmet : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("FeralSetBonus").Value;
        }
        public override void SetDefaults()
        {          
            Item.width = 18;
            Item.height = 18;           
            Item.value = Item.sellPrice(0, 0, 20, 0);
            Item.rare = 1;
            Item.defense = 2;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Melee) += 0.05f;
            player.GetCritChance(DamageClass.Melee) += 3;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<FeralBreastplate>() && legs.type == ModContent.ItemType<FeralLeggings>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.setBonus = this.GetLocalization("FeralSetBonus").Value;
            player.GetAttackSpeed(DamageClass.Melee) += 0.15f;
        }
        public override void AddRecipes()
        {       
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AnimalSkin>(), 7);
            recipe.AddTile(18);
            recipe.Register();
        }    
    }
}