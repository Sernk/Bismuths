using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class PapuansTable : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 48;
            Item.height = 32;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 0, 60);
            Item.createTile = ModContent.TileType<Tiles.PapuansTable>();
        }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Papuan's Table");
            //DisplayName.AddTranslation(GameCulture.Russian, "Стол папуасов");
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(2504, 8);         
            recipe.AddTile(106);
            recipe.Register();
        }
    }
}
