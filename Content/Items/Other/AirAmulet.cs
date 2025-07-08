using Bismuth.Content.Buffs;
using Bismuth.Content.Items.Materials;
using Bismuth.Content.Tiles;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class AirAmulet : ModItem
    {
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 0, 50, 0);
            Item.rare = 7;
            Item.useStyle = 1;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.FindBuffIndex(ModContent.BuffType<AirElemental>()) != -1 || player.FindBuffIndex(ModContent.BuffType<EarthElemental>()) != -1 || player.FindBuffIndex(ModContent.BuffType<FireElemental>()) != -1 || player.FindBuffIndex(ModContent.BuffType<WaterElemental>()) != -1)
                return false;
            return true;
        }
        public override bool? UseItem(Player player)
        {
            player.AddBuff(ModContent.BuffType<AirElemental>(), 1800 * 60);
            return true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<EmptyAmulet>());
            recipe.AddIngredient(ModContent.ItemType<AirEssence>(), 10);
            recipe.AddTile(ModContent.TileType<RuneTable>());
            recipe.Register();
        }
    }
}