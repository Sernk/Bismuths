using Bismuth.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Tools
{
    public class GalvornPickaxe : ModItem
    {
        public override void SetDefaults()
        {

            Item.damage = 12;
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
            Item.height = 12;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.pick = 90;
            Item.useStyle = 1;
            Item.knockBack = 4;
            Item.value = Item.buyPrice(0, 0, 30, 0);
            Item.rare = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<GalvornBar>(), 20);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}