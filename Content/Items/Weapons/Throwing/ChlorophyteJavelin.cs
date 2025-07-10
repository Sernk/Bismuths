using Bismuth.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Throwing
{
    public class ChlorophyteJavelin : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 46; 
            Item.DamageType = DamageClass.Throwing;  
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 2, 7, 0);
            Item.rare = 7;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true; 
            Item.shoot = ModContent.ProjectileType<ChlorophyteJavelinP>(); 
            Item.shootSpeed = 5f; 
            Item.useTurn = true;
            Item.useStyle = 1;  
            Item.noUseGraphic = true; 
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.ChlorophyteBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 speed, int type, int damage, float knockback)
        {
            float numberProjectiles = 2; 

            float rotation = MathHelper.ToRadians(5);
            position += Vector2.Normalize(new Vector2(speed.X, speed.Y)) * 2f;
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(speed.X, speed.Y).RotatedBy(MathHelper.Lerp(0, rotation, i / (numberProjectiles - 1))) * 2f;
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
            }
            return false;
        }
    }
}