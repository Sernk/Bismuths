using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class ProminenceP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(595);
            Projectile.width = 100;
            Projectile.height = 50;
            AIType = 595;
            Main.projFrames[Projectile.type] = 28;
        }
        public override void AI()
        {
            Vector2 vector18 = Projectile.Center + Projectile.velocity * 3f;
            Lighting.AddLight(vector18, 0.7f, 0.35f, 0f);
            if (Main.rand.Next(3) == 0)
            {
                int num30 = Dust.NewDust(vector18 - Projectile.Size / 2f, Projectile.width, Projectile.height, DustID.Torch, Projectile.velocity.X, Projectile.velocity.Y, 0, default(Color), 2f);
                Main.dust[num30].noGravity = true;
                Dust obj2 = Main.dust[num30];
                obj2.position -= Projectile.velocity;
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(BuffID.OnFire, 300);
        }
    }
}