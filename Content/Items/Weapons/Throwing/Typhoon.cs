using Microsoft.Xna.Framework;
using System.Drawing;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Content.Projectiles;

namespace Bismuth.Content.Items.Weapons.Throwing
{
    public class Typhoon : ModItem
    {
        public override void SetDefaults()
        {

            Item.damage = 20;           //this is the item damage
            Item.DamageType = DamageClass.Throwing;             //this make the item do throwing damage
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 22;       //this is how fast you use the item
            Item.useAnimation = 22;   //this is how fast the animation when the item is used
            Item.knockBack = 6;
            Item.value = Item.buyPrice(0, 5, 0, 0);
            Item.rare = 4;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;       //this make the item auto reuse
            Item.shoot = ModContent.ProjectileType<TyphoonP>();  //javelin projectile (поставь продж обратно)
            Item.shootSpeed = 20.5f;     //projectile speed
            Item.useTurn = true;
            Item.useStyle = 1;  // Анимация использования на персонаже
            Item.noUseGraphic = true; // Скрывает ли графику "взмаха"           
        }
        
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Typhoon");
            //DisplayName.AddTranslation(GameCulture.Russian, "Тайфун");
            // Tooltip.SetDefault("Creates water flower after dealing damage");
            //Tooltip.AddTranslation(GameCulture.Russian, "Создаёт водный цветок после нанесения урона");
        }
        const int max_count = 1;

        public override bool CanUseItem(Player player)
        {
            if (Main.projectile.Where(p => p.type == ModContent.ProjectileType<TyphoonP>() && p.owner == Item.playerIndexTheItemIsReservedFor && p.active == true).Count() < max_count)
                return CanUseItem(player);
            return false;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
            return false;
        }
    }
}
