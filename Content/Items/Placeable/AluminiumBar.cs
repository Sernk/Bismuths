using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class AluminiumBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ExtractinatorMode[Item.type] = Item.type;
        }
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;
            Item.value = Item.sellPrice(0, 0, 2, 0);
            Item.rare = 0;
            Item.maxStack = 999;
            Item.createTile = ModContent.TileType<Tiles.AluminiumBar>();
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
            recipe.AddIngredient(ModContent.ItemType<AluminiumOre>(), 3);       
            recipe.AddTile(17);
            recipe.Register();
        }
    }
}
