using Terraria.ModLoader;
using Terraria;
using Bismuth.Utilities;
using Bismuth.Content.Items.Materials;

namespace Bismuth.Content.Items.Accessories
{
    public class SignOfUndead : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Sign Of Undead");
            //Tooltip.SetDefault("10% increased assassin damage \n20% increased critical strike chance.");
            //DisplayName.AddTranslation(GameCulture.Russian, "Знак нежити");
            //Tooltip.AddTranslation(GameCulture.Russian, "Увеличение урона головореза на 10% и критического урона на 20%\nВы похищаете здоровье у врагов ночью, однако ваше \nмаксимальное здоровье снижается на 10% после каждой смерти");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 0, 2, 50);
            Item.rare = 4;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<ModP>().assassinDamage += 0.08f;
            player.GetModPlayer<BismuthPlayer>().critDmgMult += 0.2f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<DarkEssence>(), 10);
            recipe.AddIngredient(ModContent.ItemType<DarkEngraving>());
            recipe.Register();
        }
    }
}