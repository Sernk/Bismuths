using Bismuth.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Tools
{
    public class GalvornWarhammer : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 7;
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
            Item.height = 12;
            Item.useTime = 18;
            Item.useAnimation = 18;
            Item.hammer = 60;
            Item.useStyle = 1;
            Item.knockBack = 6;
            Item.value = Item.buyPrice(0, 0, 30, 0);
            Item.rare = 0;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<GalvornBar>(), 12);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}