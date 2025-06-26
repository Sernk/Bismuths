using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class WatersLeggings : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Water's Leggings");
            // Tooltip.SetDefault("More wetness - higher movement speed");
            //DisplayName.AddTranslation(GameCulture.Russian, "Поножи вод");
            //Tooltip.AddTranslation(GameCulture.Russian, "Больше влажности - выше скорость передвижения.");
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 0, 35, 0);
            Item.rare = 3;
            Item.defense = 3;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ScalyLeggings>());
            recipe.AddIngredient(ItemID.Coral, 10);
            recipe.AddIngredient(ItemID.Seashell, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
