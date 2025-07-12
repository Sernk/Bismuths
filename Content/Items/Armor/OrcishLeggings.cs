using Bismuth.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class OrcishLeggings : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.value = 10;
            Item.rare = 3;
            Item.defense = 4;
            Item.value = Item.sellPrice(0, 0, 30, 0);
        }
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.18f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(MIID.ID(2), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}