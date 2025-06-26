using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class PapuansBed : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Papuan's Bed");
            //DisplayName.AddTranslation(GameCulture.Russian, "Кровать папуасов");
        }
        public override void SetDefaults()
        {
            Item.width = 64;
            Item.height = 26;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 4, 0);
            Item.createTile = ModContent.TileType<Tiles.PapuansBed>();
        }      
        public override void AddRecipes()  //How to craft this item
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(2504, 15);
            recipe.AddIngredient(225, 5);            
            recipe.AddTile(86);   
            recipe.Register();
        }
    }
}
