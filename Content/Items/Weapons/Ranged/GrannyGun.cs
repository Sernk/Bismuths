using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Ranged
{
    public class GrannyGun : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 55500;
            Item.DamageType = DamageClass.Ranged;
            Item.width = 40;
            Item.height = 20;
            Item.useTime = 4;
            Item.useAnimation = 4;
            Item.useStyle = 5;
            Item.noMelee = true; 
            Item.knockBack = 4;
            Item.value = 10000;
            Item.rare = 11;
            Item.UseSound = SoundID.Item10;
            Item.autoReuse = true;
            Item.shoot = 10; 
            Item.shootSpeed = 10f;
            Item.useAmmo = AmmoID.Bullet;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 speed, int type, int damage, float knockback)
        {
            Vector2 perturbedSpeed = new Vector2(speed.X, speed.Y).RotatedByRandom(MathHelper.ToRadians(10));
            speed.X = perturbedSpeed.X;
            speed.Y = perturbedSpeed.Y;
            return true;
        }
    }
}