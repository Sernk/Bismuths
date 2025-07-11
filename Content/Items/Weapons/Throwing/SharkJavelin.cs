using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Throwing
{
    public class SharkJavelin : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 39;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 18; 
            Item.useAnimation = 18;
            Item.knockBack = 7;
            Item.value = Item.buyPrice(0, 5, 20, 0);
            Item.rare = 3;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.SharkJavelinP>();
            Item.shootSpeed = 8.5f;
            Item.useTurn = true;
            Item.useStyle = 1;
            Item.noUseGraphic = true; 
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
            return false;
        }
    }
}
