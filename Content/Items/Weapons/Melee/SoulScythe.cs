using Bismuth.Content.Projectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Melee
{
    public class SoulScythe : ModItem
    {
        public override void SetDefaults()
        {
            Item.DamageType = DamageClass.Melee;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 30;
            Item.useAnimation = 30;
            Item.knockBack = 5;
            Item.rare = 0;
            Item.UseSound = SoundID.Item77;
            Item.autoReuse = false;
            Item.useStyle = 1;
            Item.noUseGraphic = true;
            Item.noMelee = true;
            Item.shoot = ModContent.ProjectileType<ScytheSlashHitboxP>();
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {      
            Projectile.NewProjectile(source, player.position, Vector2.Zero, ModContent.ProjectileType<ScytheSlashHitboxP>(), 15, 4f, Main.myPlayer);
            return false;
        }
    }
}