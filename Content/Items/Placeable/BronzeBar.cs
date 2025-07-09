using Terraria.ModLoader;
using Terraria;
using Terraria.ID;

namespace Bismuth.Content.Items.Placeable
{
    public class BronzeBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ExtractinatorMode[Item.type] = Item.type;
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 0, 2, 50);
            Item.rare = 0;
            Item.maxStack = 999;
            Item.createTile = ModContent.TileType<Tiles.BronzeBar>();
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(12, 2);
            recipe.AddIngredient(699, 2);
            recipe.AddTile(17);
            recipe.Register();
        }
    }
}
