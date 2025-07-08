using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class FireElementalFireball : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 16;
            Projectile.height = 16;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.light = 0.5f;
            Projectile.damage = 50;
            AIType = ProjectileID.Bullet;
            Projectile.aiStyle = 1;
            Projectile.tileCollide = false;
           
        }
        public override void AI()
        {

            for (int i = 0; i < 25; i++)
            {
                Dust.NewDust(new Microsoft.Xna.Framework.Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 6);
            }
            Lighting.AddLight(Projectile.Center, new Vector3(2.221f, 0.11f, 0.27f));
        }
        public override void OnKill(int timeLeft)
        {
            Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, Vector2.Zero, ModContent.ProjectileType<SolarBlast>(), 60, 4f);
            SoundEngine.PlaySound(SoundID.Item14);
        }
    }
}