using Bismuth.Utilities;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Armor
{
    [AutoloadEquip(EquipType.Legs)]
    public class RivetedBoots : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 18;
            Item.height = 18;
            Item.rare = 0;
            Item.value = Item.sellPrice(0, 0, 20, 0);
        }       
        public override void UpdateEquip(Player player)
        {
            player.moveSpeed += 0.08f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(MIID.ID(4), 8);
            recipe.AddIngredient(MIID.ID(3), 8);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}