using Bismuth.Content.Projectiles;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Items.Other
{
    public class MeuRansHook : ModItem
    {
        public override void SetDefaults()
        {            
            Item.CloneDefaults(ItemID.AmethystHook);
            Item.shootSpeed = 18f; 
            Item.shoot = ModContent.ProjectileType<MeuRansHookP>();
        }       
    }
}
