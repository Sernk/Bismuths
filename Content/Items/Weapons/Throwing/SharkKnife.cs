using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Weapons.Throwing
{
    public class SharkKnife : ModItem
    {
        public override void SetDefaults()
        {
            Item.damage = 37;           
            Item.DamageType = DamageClass.Throwing;            
            Item.noMelee = true;
            Item.width = 20;
            Item.height = 20;
            Item.useTime = 7;       
            Item.useAnimation = 7;  
            Item.knockBack = 2;
            Item.value = Item.buyPrice(0, 0, 6, 0);
            Item.rare = 3;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;      
            Item.shoot = ModContent.ProjectileType<Projectiles.SharkKnifeP>();  
            Item.shootSpeed = 9f;    
            Item.useTurn = true;
            Item.useStyle = 1;  
            Item.noUseGraphic = true;  
            Item.maxStack = 999;
            Item.consumable = true;
        }
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            Projectile.NewProjectile(source, position.X, position.Y, velocity.X, velocity.Y, type, damage, knockback, player.whoAmI);
            return false;
        }
    }
}