using Bismuth.Content.Items.Placeable;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Tools
{
    public class BismuthumDrill : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 27;
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
            Item.height = 12;
            Item.useTime = 8;
            Item.useAnimation = 25;
            Item.channel = true;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.pick = 220;
            Item.useStyle = 5;
            Item.knockBack = 6;
            Item.value = Item.buyPrice(0, 6, 50, 0);
            Item.rare = 8;
            Item.UseSound = SoundID.Item23;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.BismuthumDrillP>();
            Item.shootSpeed = 40f;
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