using Bismuth.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Melee
{
    public class ToadGun : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 40;
            Item.DamageType = DamageClass.Melee;
            Item.damage = 13;
            Item.useTime = 26;
            Item.useAnimation = 26;
            Item.knockBack = 4f;
            Item.useStyle = 5;
            Item.noMelee = true;
            Item.value = Item.sellPrice(0, 0, 30, 0);
            Item.rare = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<ToadGunP>();
            Item.shootSpeed = 15f;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2?(new Vector2(-6f, 0f));
        }
        public override bool CanUseItem(Player player)
        {
            for (int index = 0; index < 1000; ++index)
            {
                if (player.ownedProjectileCounts[ModContent.ProjectileType<ToadGunP>()] < 1)
                    return true;
            }
            return false;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Vector2 vector2 = Vector2.Normalize(new Vector2(velocity.X, velocity.Y)) * 25f;
            if (Collision.CanHit(position, 0, 0, position + vector2, 0, 0))
                position += vector2;
            velocity.X *= 1.25f;
            velocity.Y *= 1.25f;
            return true;
        }
    }
}
