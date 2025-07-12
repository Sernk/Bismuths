using Bismuth.Content.Items.Materials;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class FrozenWarderersBreastplate : ModItem
    {
        public override void SetDefaults()
        {            
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 0, 20, 0);
            Item.rare = 1;
            Item.defense = 3;          
        }
        public override void UpdateEquip(Player player)
        {
            player.statManaMax2 += 40;
            player.manaCost -= 0.15f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(225, 10);
            recipe.AddIngredient(ModContent.ItemType<IceCrystal>(), 15);
            recipe.AddTile(86);
            recipe.Register();
        }
    }
}