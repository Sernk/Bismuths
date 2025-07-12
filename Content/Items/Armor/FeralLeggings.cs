using Bismuth.Content.Items.Materials;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class FeralLeggings : ModItem
    {
        public override void SetDefaults()
        {        
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 0, 15, 0);
            Item.rare = 1;
            Item.defense = 2;           
        }
        public override void UpdateEquip(Player player)
        {
            player.GetCritChance(DamageClass.Melee) += 6;
            player.moveSpeed -= 0.14f;    
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