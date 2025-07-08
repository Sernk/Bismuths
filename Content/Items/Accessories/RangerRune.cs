using Bismuth.Content.Items.Materials;
using Bismuth.Content.Tiles;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Waist)]
    public class RangerRune : ModItem
    {
        public override void SetDefaults()
        {           
            Item.value = Item.sellPrice(0, 2, 0, 0);
            Item.rare = 5;
            Item.accessory = true;                  
        }
        public override void AddRecipes()  
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RuneRim>(), 1);   
            recipe.AddIngredient(ModContent.ItemType<RuneEssence>(), 8);
            recipe.AddTile(ModContent.TileType<RuneTable>());   
            recipe.Register();
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetDamage(DamageClass.Ranged) += 0.12f;          
        }
    }
}