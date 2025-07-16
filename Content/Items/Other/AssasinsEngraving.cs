using Bismuth.Utilities;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class AssasinsEngraving : ModItem
    {
        public override void SetDefaults()
        {           
            Item.width = 40;
            Item.height = 20;
            Item.value = 100;
            Item.rare = 1;
            Item.useStyle = 1;
            Item.useTime = 15;
            Item.useAnimation = 15;
            Item.consumable = true;
        }
        public override bool CanUseItem(Player player)
        {
            if (player.GetModPlayer<BismuthPlayer>().PlayerClass != 0 || player.GetModPlayer<BismuthPlayer>().NoRPGGameplay)
                return false;
            else
                return true;
        }
        public override bool? UseItem(Player player)
        {
            if (player.GetModPlayer<BismuthPlayer>().OpenedBook)
                player.GetModPlayer<BismuthPlayer>().OpenedBook = false;
            player.GetModPlayer<BismuthPlayer>().PlayerClass = 5;
            return true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<ClassEngraving>());
            recipe.Register();
        }
    }
}