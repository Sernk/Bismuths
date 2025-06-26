using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class PapuansWorkbench : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 16;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 0, 30);
            Item.createTile = ModContent.TileType<Tiles.PapuansWorkbench>();
        }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Papuan's Workbench");
            //DisplayName.AddTranslation(GameCulture.Russian, "Верстак папуасов");
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(2504, 10);
            recipe.AddTile(106);
            recipe.Register();
        }
    }
}
