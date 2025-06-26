using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Content.Tiles;

namespace Bismuth.Content.Items.Materials
{
    public class GalvornBar : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Galvorn Bar");
            //DisplayName.AddTranslation(GameCulture.Russian, "Галворновый слиток");
        }
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 20;
            Item.value = 100;
            Item.rare = 1;
            Item.maxStack = 9999;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 15;
            Item.useStyle = 1;
           // item.consumable = true;
        }
        public override void AddRecipes()
        {

            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<PeatPowder>(), 3);
            recipe.AddIngredient(ItemID.MeteoriteBar);
            recipe.AddTile(ModContent.TileType<BlastFurnace>());
            recipe.Register();
        }
    }
}