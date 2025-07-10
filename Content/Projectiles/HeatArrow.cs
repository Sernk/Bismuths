using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class HeatArrow : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);         
        }   
        public override void AI()
        {
            for (int i = 0; i < 2; i++)
            {
                int dust = Dust.NewDust(new Vector2(Projectile.position.X,Projectile.position.Y), Projectile.width / 2, Projectile.height / 2, 6);
                Main.dust[dust].scale = 0.9f;
            }            
        }
        public override void OnKill(int timeLeft)
        {
            for (int i = 0; i < 5; i++)
            {
                int dust = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width / 2, Projectile.height / 2, 6);
                Main.dust[dust].scale = 1.2f;
            }
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {           
            target.AddBuff(BuffID.OnFire, 480);
        }
    }
}