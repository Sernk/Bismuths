using Bismuth.Content.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Tools
{
    public class BismuthumPickaxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 27;
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
            Item.height = 12;
            Item.useTime = 14;
            Item.useAnimation = 14;         
            Item.pick = 220;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = Item.buyPrice(0, 6, 50, 0);
            Item.rare = 8;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BismuthumBar>(), 12);
            recipe.AddTile(134);
            recipe.Register();
        }
    }
}
