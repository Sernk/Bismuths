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

            Item.damage = 52;           //this is the item damage
            Item.DamageType = DamageClass.Throwing;             //this make the item do throwing damage
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 22;       //this is how fast you use the item
            Item.useAnimation = 22;   //this is how fast the animation when the item is used
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 2, 76, 0);
            Item.rare = 4;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;       //this make the item auto reuse
            Item.shoot = ModContent.ProjectileType<StarOfTheDunedainBase>();  //javelin projectile (поставь продж обратно)
            Item.shootSpeed = 7.5f;     //projectile speed
            Item.useTurn = true;
            Item.useStyle = 1;  // Анимация использования на персонаже
            Item.noUseGraphic = true; // Скрывает ли графику "взмаха"           
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Star Of The Dunedain");
            //DisplayName.AddTranslation(GameCulture.Russian, "Звезда Дунедайн");
            // Tooltip.SetDefault("Creates two spinning discs");
            //Tooltip.AddTranslation(GameCulture.Russian, "Создаёт два вращающихся диска");
        }
        const int max_count = 1;
        public override bool CanUseItem(Player player)
        {
            if (Main.projectile.Where(p => p.type == ModContent.ProjectileType<StarOfTheDunedainBase>() && p.owner == Item.playerIndexTheItemIsReservedFor && p.active == true).Count() < max_count)
                return CanUseItem(player);
            return false;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 speed, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position.X, position.Y, speed.X, speed.Y, type, damage, knockback, player.whoAmI);
            return false;
        }
    }
}
