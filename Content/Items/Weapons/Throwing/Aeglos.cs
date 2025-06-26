using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Content.Projectiles;

namespace Bismuth.Content.Items.Weapons.Throwing
{
    public class Aeglos : ModItem
    {
        public override void SetDefaults()
        {

            Item.damage = 33;           //this is the item damage
            Item.DamageType = DamageClass.Throwing;             //this make the item do throwing damage
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 28;       //this is how fast you use the item
            Item.useAnimation = 28;   //this is how fast the animation when the item is used
            Item.knockBack = 5.5f;
            Item.value = Item.sellPrice(0, 1, 0, 0);
            Item.rare = 4;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;       //this make the item auto reuse
            Item.shoot = ModContent.ProjectileType<AeglosP>();  //javelin projectile (поставь продж обратно)
            Item.shootSpeed = 11.5f;     //projectile speed
            Item.useTurn = true;
            Item.useStyle = 1;  // Анимация использования на персонаже
            Item.noUseGraphic = true; // Скрывает ли графику "взмаха"           
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Aeglos");
            //DisplayName.AddTranslation(GameCulture.Russian, "Аэглос");
        }

        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
            return false;
        }
    }
}
