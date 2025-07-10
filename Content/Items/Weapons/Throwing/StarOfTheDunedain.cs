using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Content.Projectiles;

namespace Bismuth.Content.Items.Weapons.Throwing
{
    public class StarOfTheDunedain : ModItem
    {
        public override void SetDefaults()
        {

            Item.damage = 52;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 22;
            Item.useAnimation = 22; 
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 2, 76, 0);
            Item.rare = 4;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<StarOfTheDunedainBase>();
            Item.shootSpeed = 7.5f;
            Item.useTurn = true;
            Item.useStyle = 1;
            Item.noUseGraphic = true;
        }
        const int max_count = 1;
        public override bool CanUseItem(Player player)
        {
            if (Main.projectile.Where(p => p.type == ModContent.ProjectileType<StarOfTheDunedainBase>() && p.owner == Item.playerIndexTheItemIsReservedFor && p.active == true).Count() < max_count)
                return base.CanUseItem(player);
            return false;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 speed, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position.X, position.Y, speed.X, speed.Y, type, damage, knockback, player.whoAmI);
            return false;
        }
    }
}
