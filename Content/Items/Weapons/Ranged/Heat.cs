using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Ranged
{
    public class Heat : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 58;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 22;
            Item.useAnimation = 22;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 3, 50, 0);
            Item.rare = 5;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = AmmoID.Arrow;
            Item.shootSpeed = 35f;
            Item.useStyle = 5;
            Item.useAmmo = AmmoID.Arrow;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-2, 3);
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 speed, int type, int damage, float knockback)
        {
            if (type == ProjectileID.WoodenArrowFriendly)
            {
                float numberProjectiles = 5;
                float rotation = MathHelper.ToRadians(8);
                for (int i = 0; i < numberProjectiles; i++)
                {
                    Vector2 perturbedSpeed = new Vector2(speed.X, speed.Y).RotatedBy(MathHelper.Lerp(-rotation, rotation, i / (numberProjectiles - 1))) * 35f;
                    Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<Projectiles.HeatArrow>(), damage, knockback, player.whoAmI);
                }
                return false;
            }
            else
                return true;
        }
    }
}