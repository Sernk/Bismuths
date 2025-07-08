using Bismuth.Content.Items.Materials;
using Bismuth.Content.Tiles;
using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Waist)]
    public class RuneOfAssasin : ModItem
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
            player.GetCritChance(DamageClass.Throwing) += 5;
            player.GetCritChance(DamageClass.Magic) += 5;
            player.GetCritChance(DamageClass.Ranged) += 5;
            player.GetCritChance(DamageClass.Melee) += 5;  
            ModContent.GetInstance<ModP>().assassinCrit += 5;
        }
    }
}