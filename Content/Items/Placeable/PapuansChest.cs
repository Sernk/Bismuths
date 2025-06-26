using Terraria.Localization;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class PapuansChest : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 26;
            Item.height = 22;
            Item.maxStack = 99;        
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.createTile = ModContent.TileType<Tiles.PapuansChest>();
        }


        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Papuan's Chest");
            //DisplayName.AddTranslation(GameCulture.Russian, "Сундук папуасов");
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(2504, 8);
            recipe.AddIngredient(22, 2);
            recipe.AddRecipeGroup("IronBar", 2);
            recipe.AddTile(106);
            recipe.Register();
        }
    }
}
