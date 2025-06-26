using Terraria;
using Terraria.ModLoader;
using Bismuth.Content.Items.Materials;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class ScalyLeggings : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Scaly Leggings");
            // Tooltip.SetDefault("Movement speed is increased by 9%.");
            //DisplayName.AddTranslation(GameCulture.Russian, "Поножи из чешуи");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает скорость передвижения на 9%.");
        }
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
            player.moveSpeed += 0.09f;
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