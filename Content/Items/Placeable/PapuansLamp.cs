using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class PapuansLamp : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 16;
            Item.height = 48;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 1, 0);
            Item.createTile = ModContent.TileType<Tiles.PapuansLamp>();
        }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Papuan's Lamp");
            //DisplayName.AddTranslation(GameCulture.Russian, "Лампа папуасов");
        }
        public override void AddRecipes()  
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(2504, 3);
            recipe.AddIngredient(8, 1);          
            recipe.AddTile(106);   
            recipe.Register();
        }
    }
}
