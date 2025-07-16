using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Throwing
{
    public class JaguarsDagger : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 45;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 8;
            Item.useAnimation = 8;
            Item.knockBack = 2;
            Item.value = Item.sellPrice(0, 0, 3, 0);
            Item.rare = 3;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.JaguarsDaggerP>();
            Item.shootSpeed = 12f;
            Item.useTurn = true;
            Item.useStyle = 1;
            Item.noUseGraphic = true;
            Item.maxStack = 9999;
            Item.consumable = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
            return false;
        }
    }
}