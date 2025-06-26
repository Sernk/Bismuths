using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Bismuth.Utilities;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Head)]
    public class WatersHelmet : ModItem
    {

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Water's Helmet");
            // Tooltip.SetDefault("More wetness - higher critical strike chance");
            //DisplayName.AddTranslation(GameCulture.Russian, "Шлем вод");
            //Tooltip.AddTranslation(GameCulture.Russian, "Больше влажности - выше шанс критического удара.");
        }
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = Item.sellPrice(0, 0, 40, 0);
            Item.rare = 3;
            Item.defense = 4;
        }
        public override bool IsArmorSet(Item head, Item body, Item legs)
        {
            return body.type == ModContent.ItemType<WatersBreastplate>() && legs.type == ModContent.ItemType<WatersLeggings>();
        }
        public override void UpdateArmorSet(Player player)
        {
            string WaterSetBonus = Language.GetTextValue("Mods.Bismuth.WaterSetBonus");
            player.setBonus = "WaterSetBonus";
            player.GetModPlayer<BismuthPlayer>().watersetbonus = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ScalyHelmet>());
            recipe.AddIngredient(ItemID.Coral, 10);
            recipe.AddIngredient(ItemID.Seashell, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}