using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace Bismuth.Content.Projectiles
{
    public class MinosBlastCallP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.penetrate = 1;
            Projectile.extraUpdates = 1;
            AIType = ProjectileID.Bullet;
            Projectile.tileCollide = true;
            Projectile.alpha = 255;
        }
        public override void AI()
        {
            Projectile.ai[0]++;
            if (Projectile.ai[0] % 15 == 10)
            {
                int proj = Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, Vector2.Zero, 695, 10, 4f);
                Main.projectile[proj].friendly = false;
                Main.projectile[proj].hostile = true;
                SoundEngine.PlaySound(SoundID.Item14, Projectile.position);
            }
        }
    }
}