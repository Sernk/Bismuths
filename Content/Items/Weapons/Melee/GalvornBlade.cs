using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Melee
{
    public class GalvornBlade : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 22;
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 28;
            Item.useAnimation = 28;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 0, 15, 0);
            Item.rare = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = false;
            Item.useStyle = 1;
            Item.useTurn = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Materials.GalvornBar>(), 15);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}