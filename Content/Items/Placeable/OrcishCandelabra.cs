using System;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Placeable
{
    public class OrcishCandelabra : ModItem
    {
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Orcish Candelabra");
            //DisplayName.AddTranslation(GameCulture.Russian, "Орочий канделябр");
        }
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 32;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
            Item.consumable = true;
            Item.value = Item.sellPrice(0, 0, 3, 0);
            Item.createTile = ModContent.TileType<Tiles.OrcishCandelabra>();
        }

   
        public override void AddRecipes()  //How to craft this item
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(129, 5);
            recipe.AddIngredient(8, 3);
            recipe.AddIngredient(ModContent.ItemType<Materials.OrcishFragment>(), 1);
            recipe.AddTile(TileID.WorkBenches);   //at work bench
            recipe.Register();
        }
    }
}
