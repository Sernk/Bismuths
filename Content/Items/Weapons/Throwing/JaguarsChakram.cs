using Bismuth.Content.Projectiles;
using Microsoft.Xna.Framework;
using System.Linq;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Throwing
{
    public class JaguarsChakram : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 34;         
            Item.DamageType = DamageClass.Throwing;          
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 15;       
            Item.useAnimation = 15;   
            Item.knockBack = 6;
            Item.value = Item.sellPrice(0, 2, 80, 0);
            Item.rare = 5;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;    
            Item.shoot = ModContent.ProjectileType<JaguarsChakramP>(); 
            Item.shootSpeed = 10f;    
            Item.useTurn = true;
            Item.useStyle = 1;  
            Item.noUseGraphic = true;       
        }
        const int max_count = 5;
        public override bool CanUseItem(Player player)
        {
            if (Main.projectile.Where(p => p.type == ModContent.ProjectileType<JaguarsChakramP>() && p.owner == Item.playerIndexTheItemIsReservedFor && p.active == true).Count() < max_count)
                return base.CanUseItem(player);
            return false;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
            return false;
        }
    }
}
