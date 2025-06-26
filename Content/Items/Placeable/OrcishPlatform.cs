using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Terraria.Localization;

namespace Bismuth.Content.Items.Placeable
{
    public class OrcishPlatform : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Orcish Platform");
            //DisplayName.AddTranslation(GameCulture.Russian, "Орочья платформа");
        }
        public override void SetDefaults()
        {
            Item.width = 8;
            Item.height = 10;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.OrcishPlatform>();
        }

        public override void AddRecipes()  //How to craft this item
        {
            Recipe recipe = CreateRecipe(50);
            recipe.AddIngredient(129, 1);        
            recipe.AddIngredient(ModContent.ItemType<Materials.OrcishFragment>(), 1);
            recipe.AddTile(TileID.WorkBenches);   //at work bench
            recipe.Register();
        }
    }
}
