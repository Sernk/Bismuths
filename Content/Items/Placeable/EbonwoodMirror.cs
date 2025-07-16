using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class EbonwoodMirror : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 10;
            Item.height = 24;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 2, 0);
            Item.createTile = ModContent.TileType<Tiles.EbonwoodMirror>();
            Item.placeStyle = 0;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Glass, 5);
            recipe.AddIngredient(ItemID.Ebonwood, 10);
            recipe.AddTile(TileID.Sawmill);
            recipe.Register();
        }
    }
}