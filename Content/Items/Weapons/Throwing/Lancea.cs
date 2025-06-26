using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Content.Projectiles;

namespace Bismuth.Content.Items.Weapons.Throwing
{
    public class Lancea : ModItem
    {
        public override void SetDefaults()
        {

            Item.damage = 8;           
            Item.DamageType = DamageClass.Throwing;             
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 36;       
            Item.useAnimation = 36;  
            Item.knockBack = 4;
            Item.value = Item.buyPrice(0, 0, 50, 0);
            Item.rare = 0;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;       
            Item.shoot = ModContent.ProjectileType<LanceaP>();  
            Item.shootSpeed = 7f;     
            Item.useTurn = true;
            Item.useStyle = 1;  
            Item.noUseGraphic = true;           
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Lancea");
            //DisplayName.AddTranslation(GameCulture.Russian, "Ланцея");
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
            return false;
        }
    }
}
