using Bismuth.Content.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class BismuthumLeggings : ModItem
    {
        public override void SetDefaults()
        {           
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 4, 0, 0);
            Item.rare = 8;
            Item.defense = 14;     
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.35f;
            player.GetCritChance(DamageClass.Melee) += 14;
            player.GetCritChance(DamageClass.Ranged) += 14;
            player.GetCritChance(DamageClass.Magic) += 14;
            player.GetCritChance(DamageClass.Throwing) += 14;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BismuthumBar>(), 18); 
            recipe.AddTile(TileID.MythrilAnvil); 
            recipe.Register();
        }
    }
}