using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class PikemansLeggings : ModItem
    {
        public override void SetDefaults()
        {           
            Item.width = 18;
            Item.height = 18;
            Item.value = 10;
            Item.rare = 1;
            Item.defense = 2;        
            Item.value = Item.sellPrice(0, 1, 50, 0);
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.08f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(225, 5);
            recipe.AddIngredient(22, 10);
            recipe.AddRecipeGroup(RecipeGroupID.IronBar);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}