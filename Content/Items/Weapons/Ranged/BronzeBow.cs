using Bismuth.Content.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Ranged
{
    public class BronzeBow : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 8;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 16;
            Item.useAnimation = 16;
            Item.knockBack = 4;
            Item.value = Item.buyPrice(0, 0, 10, 0);
            Item.rare = 0;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = false;
            Item.shoot = AmmoID.Arrow;
            Item.shootSpeed = 13f;
            Item.useStyle = 5;
            Item.useAmmo = AmmoID.Arrow;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<BronzeBar>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}