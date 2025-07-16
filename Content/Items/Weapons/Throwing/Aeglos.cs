using Bismuth.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Throwing
{
    public class Aeglos : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 33;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 28;
            Item.useAnimation = 28;
            Item.knockBack = 5.5f;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 4;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<AeglosP>();
            Item.shootSpeed = 11.5f;
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