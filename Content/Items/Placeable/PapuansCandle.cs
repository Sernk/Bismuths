using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class PapuansCandle : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 16;
            Item.height = 16;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 0, 0);
            Item.createTile = ModContent.TileType<Tiles.PapuansCandle>();
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Papuan's Candle");
            //DisplayName.AddTranslation(GameCulture.Russian, "Свеча папуасов");
        }

        public override void AddRecipes()  //How to craft this item
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(2504, 4);
            recipe.AddIngredient(8, 1);
            recipe.AddTile(106);   //at work bench
            recipe.Register();
        }
    }
}
