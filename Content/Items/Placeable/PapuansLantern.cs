using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class PapuansLantern : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 16;
            Item.height = 32;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.createTile = ModContent.TileType<Tiles.PapuansLantern>();
        }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Papuan's Lantern");
            //DisplayName.AddTranslation(GameCulture.Russian, "Фонарь папуасов");
        }

        public override void AddRecipes()  
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(2504, 6);
            recipe.AddIngredient(8, 1);          
            recipe.AddTile(106);   
            recipe.Register();
        }
    }
}
