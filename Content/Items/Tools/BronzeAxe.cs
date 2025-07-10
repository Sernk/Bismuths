using Bismuth.Content.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Tools
{

    public class BronzeAxe : ModItem
    {
        public override void SetDefaults()
        {

            Item.damage = 8;
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
            Item.height = 12;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.axe = 14;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 0, 16, 0);
            Item.rare = 0;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}
