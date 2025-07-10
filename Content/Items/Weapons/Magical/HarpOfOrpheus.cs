using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Magical
{
    public class HarpOfOrpheus : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 24;
            Item.DamageType = DamageClass.Magic;
            Item.mana = 8;
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 25;
            Item.useAnimation = 25;
            Item.knockBack = 12;
            Item.value = Item.sellPrice(0, 1, 50, 0);
            Item.rare = 8;
            Item.UseSound = SoundID.Item26;
            Item.autoReuse = true;
            Item.shoot = ProjectileID.EighthNote;
            Item.shootSpeed = 8f;
            Item.useTurn = true;
            Item.useStyle = 5;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            float numberProjectiles = 1 + Main.rand.Next(1, 3);
            for (int i = 0; i < numberProjectiles; i++)
            {
                Vector2 perturbedSpeed = new Vector2(velocity.X, velocity.Y).RotatedByRandom(MathHelper.ToRadians(30));
                Projectile.NewProjectile(source, position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockback, player.whoAmI);
            }
            return true;
        }
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(-6, 0);
        }
    }
}