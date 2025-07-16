using Bismuth.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Magical
{
    public class ShamansStaff : ModItem
    {
        public override void SetDefaults()
        {
            Item.mana = 52;
            Item.DamageType = DamageClass.Magic;
            Item.width = 30;
            Item.height = 30;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.useStyle = 5;
            Item.channel = true;
            Item.noMelee = true;
            Item.value = Item.sellPrice(0, 3, 0, 0);
            Item.rare = 3;
            Item.shoot = ModContent.ProjectileType<ShamansStaffP>();
            Item.shootSpeed = 0f;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, player.Center.X, player.Center.Y, 0f, 0f, ModContent.ProjectileType<ShamansStaffP>(), damage, knockback, player.whoAmI, 0f, 0f);
            return true;
        }
    }
}