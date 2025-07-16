using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Throwing
{
    public class OrcishJavelin : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 26; 
            Item.DamageType = DamageClass.Throwing; 
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 24;
            Item.useAnimation = 24;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 3;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.OrcishJavelinP>();
            Item.shootSpeed = 10.5f;
            Item.useTurn = true;
            Item.useStyle = 1;
            Item.noUseGraphic = true;         
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Materials.OrcishBar>(), 10); 
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
            return false;
        }
    }
}