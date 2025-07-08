using Bismuth.Content.Items.Placeable;
using Bismuth.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Shield)]
    public class MirrorShield : ModItem
    {
        public override void SetDefaults()
        {
            Item.value = Item.sellPrice(0, 0, 15, 0);
            Item.defense = 1;
            Item.rare = 2;
            Item.accessory = true;
        }
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.GetModPlayer<BismuthPlayer>().ParryChance += 10;
            player.GetModPlayer<BismuthPlayer>().ParryChance += (int)(10 * (((float)(player.statLifeMax2 - player.statLife) / (float)player.statLifeMax2)));
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<AluminiumBar>(), 15);
            recipe.AddIngredient(ItemID.Glass, 50);
            recipe.AddIngredient(ItemID.Wood, 50);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}