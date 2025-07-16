using Bismuth.Content.Items.Materials;
using Bismuth.Content.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Melee
{
    public class RunicBlade : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 44;
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 2, 50, 0);
            Item.rare = 6;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useStyle = 1;
            Item.shoot = ModContent.ProjectileType<Projectiles.RunicBladeP>();
            Item.shootSpeed = 21f;
            Item.useTurn = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RuneEssence>(), 10);
            recipe.AddIngredient(381, 8);
            recipe.AddTile(ModContent.TileType<RuneTable>());
            recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ModContent.ItemType<RuneEssence>(), 10);
            recipe1.AddIngredient(1184, 8);
            recipe1.AddTile(TileID.Anvils);
            recipe1.Register();
        }
    }
}