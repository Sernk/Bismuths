using Terraria.ModLoader;
using Terraria;

namespace Bismuth.Content.Projectiles
{
    public class BabaYagaBlast : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Dark Blast");
            //DisplayName.AddTranslation(GameCulture.Russian, "Темный взрыв");
        }
        public override void SetDefaults()
        {
            Projectile.width = 112;
            Projectile.height = 112;
            Projectile.aiStyle = 0;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.alpha = 50;
            Projectile.light = 0.3f;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 21;
            Projectile.tileCollide = false;
            AIType = 117;
            Main.projFrames[this.Projectile.type] = 4;
            Projectile.hostile = true;
            Projectile.friendly = false;
            Projectile.damage = 20;
            Projectile.ignoreWater = true;
            Projectile.timeLeft = 60;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.usesLocalNPCImmunity = true;
        }
        int counter = 0;
        public override void AI()
        {
            Projectile.scale *= 1.02f;
            counter++;
            if (counter % 4 == 0)
                Projectile.frame++;
            if (Projectile.frame >= 4)
            {
                Projectile.Kill();

            }
        }
    }
}