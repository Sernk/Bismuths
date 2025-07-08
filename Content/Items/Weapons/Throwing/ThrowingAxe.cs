using Bismuth.Content.Projectiles;
using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Throwing
{
    public class ThrowingAxe : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 12;
            Item.DamageType = DamageClass.Throwing;
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 10;
            Item.useAnimation = 10;
            Item.knockBack = 4;
            Item.value = Item.sellPrice(0, 0, 50, 0);
            Item.rare = 2;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.shoot = ModContent.ProjectileType<ThrowingAxeP>();
            Item.shootSpeed = 15f;
            Item.useTurn = true;
            Item.useStyle = 1;
            Item.noUseGraphic = true;
        }

        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Throwing Axe");
            //DisplayName.AddTranslation(GameCulture.Russian, "Метательный топорик");
        }

        const int max_count = 1;

        public override bool CanUseItem(Player player)
        {
            if (Main.projectile.Where(p => p.type == ModContent.ProjectileType<ThrowingAxeP>() && p.owner == Item.playerIndexTheItemIsReservedFor && p.active == true).Count() < max_count)
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
