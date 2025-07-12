using Bismuth.Content.Items.Materials;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ScalyHelmet : ModItem
    {
        public override void Load()
        {
            _ = this.GetLocalization("ScalySetBonus").Value;
        }
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
            player.GetCritChance(DamageClass.Throwing) += 11;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<ScalyBreastplate>() && legs.type == ModContent.ItemType<ScalyLeggings>();
        }
        public override void UpdateArmorSet(Player player)
        {
            player.thorns += 0.2f;
            player.setBonus = this.GetLocalization("ScalySetBonus").Value;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SerpentsScale>(), 10);
            recipe.AddTile(18);
            recipe.Register();
        }
    }
}