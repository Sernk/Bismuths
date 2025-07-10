using Bismuth.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Throwing
{
    public class CobaltJavelin : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 39;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 1, 38, 0);
            Item.rare = 4;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<CobaltJavelinP>();
            Item.shootSpeed = 7.5f;
            Item.useTurn = true;
            Item.useStyle = 1;
            Item.noUseGraphic = true;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.CobaltBar, 10); 
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 speed, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position.X, position.Y, speed.X, speed.Y, type, damage, knockback, player.whoAmI);
            return false;
        }
    }
}