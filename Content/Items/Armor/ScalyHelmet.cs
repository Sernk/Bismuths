using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Bismuth.Content.Items.Materials;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class ScalyHelmet : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Scaly Helmet");
            // Tooltip.SetDefault("Increases throwing critical strike chance by 11%. \nYou use any items 5% faster.");
            //DisplayName.AddTranslation(GameCulture.Russian, "Шлем из чешуи");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличивает шанс критического удара метательным оружием на 11% \nВы используете все предметы на 5% быстрее.");
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
            string ScalySetBonus = Language.GetTextValue("Mods.Bismuth.ScalySetBonus");
            player.thorns += 0.2f;
            player.setBonus = "Attackers also take damage";
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