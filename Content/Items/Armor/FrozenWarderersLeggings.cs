using Bismuth.Content.Items.Materials;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class FrozenWarderersLeggings : ModItem
    {
        public override void SetDefaults()
        {         
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 0, 15, 0);
            Item.rare = 1;
            Item.defense = 1;                 
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.1f;           
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