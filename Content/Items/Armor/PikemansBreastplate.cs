using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class PikemansBreastplate : ModItem
    {  
        public override void SetDefaults()
        {           
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 0, 30, 0);
            Item.rare = 1;
            Item.defense = 3;             
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Throwing) += 0.12f;           
        }
        public override void AddRecipes()  
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(225, 5);
            recipe.AddIngredient(22, 15);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar);
            recipe.AddTile(16);  
            recipe.Register();
        }
    }
}