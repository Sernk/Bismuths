using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Content.Items.Materials;

namespace Bismuth.Content.Items.Placeable
{
    public class TannedSkin : ModItem
    {
        public override void SetDefaults()
        {

            Item.width = 64;
            Item.height = 26;
            Item.maxStack = 999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = 3500;
            Item.createTile = ModContent.TileType<Tiles.TannedSkin>();
        }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Tanned Skin");
            //DisplayName.AddTranslation(GameCulture.Russian, "Дубленая кожа");
        }

        public override void AddRecipes()  
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(9, 10);
            recipe.AddIngredient(ModContent.ItemType<AnimalSkin>(), 3);
            recipe.AddTile(18);  
            recipe.Register();
        }
    }
}
