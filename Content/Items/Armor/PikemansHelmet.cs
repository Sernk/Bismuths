using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class PikemansHelmet : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("PikemanSetBonus").Value;
        }
        public override void SetDefaults()
        {         
            Item.width = 18;
            Item.height = 18;        
            Item.value = Item.sellPrice(0, 0, 35, 0);
            Item.rare = 1;
            Item.defense = 2;
        }
        public override void UpdateEquip(Player player)
        {           
            player.ThrownVelocity += 0.12f;
            player.GetCritChance(DamageClass.Throwing) += 5;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<PikemansBreastplate>() && legs.type == ModContent.ItemType<PikemansLeggings>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.ThrownCost33 = true;
            player.setBonus = this.GetLocalization("PikemanSetBonus").Value;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(225, 5);
            recipe.AddIngredient(22, 12);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}