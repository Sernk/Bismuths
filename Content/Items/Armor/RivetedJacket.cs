using Bismuth.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class RivetedJacket : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 0, 20, 0);
            Item.rare = 0;
            Item.defense = 1;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetModPlayer<ModP>().assassinDamage += 0.8f;
            player.GetCritChance(DamageClass.Melee) += 6;
            player.GetCritChance(DamageClass.Ranged) += 6;
            player.GetCritChance(DamageClass.Magic) += 6;
            player.GetCritChance(DamageClass.Throwing) += 6;
            player.GetModPlayer<ModP>().assassinCrit += 6;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(MIID.ID(4), 12);
            recipe.AddIngredient(MIID.ID(3), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
