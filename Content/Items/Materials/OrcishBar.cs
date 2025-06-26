using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Materials
{
    public class OrcishBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Orcish Bar");
            //DisplayName.AddTranslation(GameCulture.Russian, "Орочий слиток");
        }
        public override void SetDefaults()
        {            
            Item.width = 40;
            Item.height = 20;
            Item.value = 100;
            Item.rare = 2;
            Item.maxStack = 999;
            Item.createTile = ModContent.TileType<Tiles.OrcishBar>();
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
            Item.consumable = true;      
        }
        public override void AddRecipes() 
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<OrcishFragment>(), 3);
            recipe.AddTile(77);
            recipe.Register();
        }
    }
}