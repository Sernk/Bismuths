using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class SolarBlast : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 52;
            Projectile.height = 52;
            Projectile.aiStyle = 0;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.alpha = 50;
            Projectile.light = 0.3f;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 21;
            Projectile.tileCollide = false;
            AIType = 117;
            Main.projFrames[this.Projectile.type] = 5;


            Projectile.ignoreWater = true;
            Projectile.timeLeft = 60;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.usesLocalNPCImmunity = true;
        }       
        int counter = 0;
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            target.AddBuff(189, 300, false);
        }
        public override void AI()
        {
            Projectile.scale *= 1.02f;
            counter++;
            if(counter % 3 == 0)
            Projectile.frame++;
            if (Projectile.frame >= 5)
            {
                Projectile.Kill();

            }
        }      
    }
}