using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Ranged
{
    public class TribalBow : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.DamageType = DamageClass.Ranged;
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 20;
            Item.useAnimation = 20;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 0, 30, 0);
            Item.rare = 8;
            Item.UseSound = SoundID.Item5;
            Item.autoReuse = true;
            Item.shoot = AmmoID.Arrow;
            Item.shootSpeed = 13f;
            Item.useStyle = 5;
            Item.useAmmo = AmmoID.Arrow;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            if (Main.rand.Next(0, 5) == 0)
            {
                Projectile.NewProjectile(source, position, new Vector2(velocity.X + 1, velocity.Y - 1), type, damage, knockback, Main.myPlayer);
            }
            return true;
        }
    }
}