using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class HectorsSpearP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(66);
            AIType = 66;            
        }      
    }
}