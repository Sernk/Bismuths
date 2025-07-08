using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Content.Items.Materials;

namespace Bismuth.Content.Items.Other
{
    public class KeyOfTheSun : ModItem
    {        
        public override void SetDefaults()
        {           
            Item.width = 20;
            Item.height = 20;
            Item.value = Item.sellPrice(0, 0, 15, 0);
            Item.rare = 3;
            Item.consumable = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<TheMoldofaKeyOfTheSun>());
            recipe.AddIngredient(ItemID.HallowedBar, 10);
            recipe.AddIngredient(ItemID.SoulofMight, 3);
            recipe.AddIngredient(ItemID.SoulofFright, 3);
            recipe.AddIngredient(ItemID.SoulofSight, 3);           
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}