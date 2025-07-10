using Bismuth.Content.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Ranged
{
    public class GalvornBow : ModItem
    {
        public override void SetDefaults()
        { 
            Item.damage = 17;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 0, 35, 0);
            Item.rare = 2;
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
            recipe.AddIngredient(ModContent.ItemType<GalvornBar>(), 15);
            recipe.AddTile(16);
            recipe.Register();
        }
    }
}