using Terraria.ModLoader;
using Terraria;

namespace Bismuth.Content.Projectiles
{
    public class IceSpikeP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ice Spike");
            //DisplayName.AddTranslation(GameCulture.Russian, "Ледяной шип");
        }
        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 32;
            Projectile.aiStyle = 0;
            Projectile.DamageType = DamageClass.Magic;
            Main.projFrames[this.Projectile.type] = 10;
            Projectile.hostile = false;
            Projectile.friendly = true;
            Projectile.damage = 30;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 600;
        }
        int counter = 0;
        int cooldown = 0;
        public override bool? CanHitNPC(NPC target)
        {             
            if (Projectile.frame < 5)
                return false;
            else
                return true;
        }
        public override void AI()
        {
            if (Projectile.ai[0] == 0f && Projectile.frame == 0)
            {
                Projectile.frame = 4;
            }
            else if (Projectile.ai[0] == 1f && Projectile.frame == 0)
            {
                Projectile.frame = 2;
            }
            if (Projectile.ai[0] > 0f)
            {
                Projectile.frameCounter = 0;
                Projectile.ai[0] -= 1f;
            }
            else
            {
                Projectile.frameCounter++;
            }
            if (Projectile.frameCounter % 6 == 0)
            {
                if (Projectile.frame == 3)
                {
                    Projectile.ai[1]++;
                    if (Projectile.ai[1] >= 4)
                    {
                        Projectile.frame++;
                        Projectile.ai[1] = 0f;
                    }
                }
                else if(Projectile.frame < 9)
                    Projectile.frame++;
                else
                    Projectile.Kill();
            }
           
        }
    }
}