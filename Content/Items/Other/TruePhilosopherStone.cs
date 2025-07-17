using Bismuth.Content.Items.Materials;
using Bismuth.Content.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class TruePhilosopherStone : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(1, 0, 0, 0);
            Item.rare = 10;
        }
        public override void AddRecipes() // алхимик плохо работает
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<UnchargedTruePhilosopherStone>());
            recipe.AddIngredient(ModContent.ItemType<Aether>(), 10);
            recipe.AddIngredient(ItemID.SilverOre, 30);
            recipe.AddIngredient(ModContent.ItemType<Quicksilver>(), 30);
            recipe.AddIngredient(ItemID.CopperOre, 30);
            recipe.AddIngredient(ItemID.GoldOre, 30);
            recipe.AddIngredient(ItemID.IronOre, 30);
            recipe.AddIngredient(ItemID.TinOre, 30);
            recipe.AddIngredient(ItemID.LeadOre, 30);
            recipe.AddCondition(AetherRecipe.PhilosopherStone);
            recipe.AddTile(ModContent.TileType<AlchemicalShelf>());
            recipe.Register();
        }
    }
}