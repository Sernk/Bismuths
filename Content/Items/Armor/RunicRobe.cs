using Bismuth.Content.Items.Materials;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class RunicRobe : ModItem
    {
        public override void SetDefaults()
        {         
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 4, 50, 0);
            Item.rare = 6;
            Item.defense = 7;          
        }
        public override void UpdateEquip(Player player)
        {            
            player.GetDamage(DamageClass.Magic) += 0.15f;           
            player.GetCritChance(DamageClass.Magic) += 10;          
            player.wearsRobe = true;
          
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(225, 60);
            recipe.AddIngredient(ModContent.ItemType<RuneEssence>(), 15);
            recipe.AddTile(86);
            recipe.Register();
        }
    }
}