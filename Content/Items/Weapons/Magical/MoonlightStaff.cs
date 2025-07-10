using Bismuth.Content.Items.Materials;
using Bismuth.Content.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Magical
{
    public class MoonlightStaff : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 42;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 12;
            Item.width = 40;
            Item.height = 40;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.useStyle = 5;
            Item.staff[Item.type] = true; 
            Item.noMelee = true; 
            Item.knockBack = 8;
            Item.value = 10000;
            Item.rare = 6;
            Item.UseSound = SoundID.Item20;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.MoonlightStaffP>();
            Item.shootSpeed = 28f;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<RuneEssence>(), 12);
            recipe.AddIngredient(ItemID.CobaltBar, 8);
            recipe.AddTile(ModContent.TileType<RuneTable>());
            recipe.Register();

            Recipe recipe1 = CreateRecipe();
            recipe1.AddIngredient(ModContent.ItemType<RuneEssence>(), 12);
            recipe1.AddIngredient(ItemID.PalladiumBar, 8);
            recipe1.AddTile(ModContent.TileType<RuneTable>());
            recipe1.Register();
        }
    }
}