using Terraria;
using Terraria.ModLoader;
using Bismuth.Content.Items.Materials;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class ScalyBreastplate : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Scaly Breastplate");
            // Tooltip.SetDefault("Thrown damage is increased by 10%.");
            //DisplayName.AddTranslation(GameCulture.Russian, "Нагрудник из чешуи");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает метательный урон на 10%.");
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 0, 35, 0);
            Item.rare = 1;
            Item.defense = 4;
        }
        public override void UpdateEquip(Player player)
        {
            player.GetDamage(DamageClass.Throwing) += 0.1f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<SerpentsScale>(), 12);
            recipe.AddTile(18);
            recipe.Register();
        }
    }
}