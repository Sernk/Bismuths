using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Bismuth.Content.Projectiles;

namespace Bismuth.Content.Items.Weapons.Magical        
{
    public class WaveOfForce : ModItem
    {
        public override void SetDefaults()
        {

            Item.damage = 31;            
            Item.DamageType = DamageClass.Magic;   
            Item.width = 24;     
            Item.height = 28;     
            Item.useTime = 19;
            Item.useAnimation = 19;    
            Item.useStyle = 5;         
            Item.noMelee = true;    
            Item.knockBack = 8; 
            Item.value = Item.sellPrice(0, 1, 20, 0); 
            Item.rare = 4;   
            Item.mana = 12;
            Item.UseSound = SoundID.Item15; 
            Item.autoReuse = true; 
            Item.shoot = ModContent.ProjectileType<WaveOfForceP>();  
            Item.shootSpeed = 28f;    
        }

        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Wave of Force");
            //DisplayName.AddTranslation(GameCulture.Russian, "Силовая волна");
        }      
    }
}
