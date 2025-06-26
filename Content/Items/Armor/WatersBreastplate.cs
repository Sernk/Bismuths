using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Bismuth.Content.Items.Materials;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Body)]
    public class WatersBreastplate : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Water's Breastplate");
            // Tooltip.SetDefault("More wetness - more damage and health regeneration");
            //DisplayName.AddTranslation(GameCulture.Russian, "Нагрудник вод");
            //Tooltip.AddTranslation(GameCulture.Russian, "Больше влажности - выше урон и восстановление здоровья.");
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 0, 50, 0);
            Item.rare = 3;
            Item.defense = 5;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ScalyBreastplate>());
            recipe.AddIngredient(ItemID.Coral, 15);
            recipe.AddIngredient(ItemID.Seashell, 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
