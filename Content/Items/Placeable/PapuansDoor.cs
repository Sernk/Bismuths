using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class PapuansDoor : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 14;
            Item.height = 28;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 0, 40);
            Item.createTile = ModContent.TileType<Tiles.PapuansDoorClosed>();
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Papuan's Door");
            //DisplayName.AddTranslation(GameCulture.Russian, "Дверь папуасов");
        }

        public override void AddRecipes()
        { 
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(2504, 6);          
            recipe.AddTile(106);  
            recipe.Register();
        }
    }
}
