using Bismuth.Content.Items.Materials;
using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class GalvornBreastplate : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 0, 30, 0);
            Item.rare = 2;
            Item.defense = 7;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Melee) += 0.07f;
            player.GetDamage(DamageClass.Ranged) += 0.07f;
            player.GetDamage(DamageClass.Magic) += 0.07f;
            player.GetDamage(DamageClass.Throwing) += 0.07f;
            player.GetModPlayer<ModP>().assassinDamage += 0.07f;
            player.GetAttackSpeed(DamageClass.Melee) += 0.3f;
            player.moveSpeed -= 0.05f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<GalvornBar>(), 30);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}