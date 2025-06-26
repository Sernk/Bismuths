using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Bismuth.Content.Projectiles
{
    public class BabaYagaPreBlast : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("");
        }
        public override void SetDefaults()
        {
            Projectile.width = 20;       //projectile width
            Projectile.height = 28;  //projectile height
            Projectile.friendly = true;      //make that the projectile will not damage you           
            Projectile.tileCollide = false;   //make that the projectile will be destroed if it hits the terrain    
            Projectile.alpha = 255;
            Projectile.timeLeft = 60;
        }
        public override void AI()
        {
            for (int i = 0; i < 5; i++)
            {
                Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, 173);
            }
            Projectile.scale *= 1.02f;
        }
        public override void OnKill(int timeLeft)
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), new Vector2(Projectile.Center.X, Projectile.Center.Y - 20), Vector2.Zero, ModContent.ProjectileType<BabaYagaBlast>(), 20, 4f);
            SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
        }
    }
}
