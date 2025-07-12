using Bismuth.Content.Items.Materials;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class FeralBreastplate : ModItem
    {
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
            player.GetDamage(DamageClass.Melee) += 0.07f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AnimalSkin>(), 10);
            recipe.AddTile(18);
            recipe.Register();
        }
    }
}