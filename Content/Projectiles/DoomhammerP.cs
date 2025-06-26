using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace Bismuth.Content.Projectiles
{
    public class DoomhammerP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Lightning Blast");
            //DisplayName.AddTranslation(GameCulture.Russian, "Взрыв молнии");
        }
        public override void SetDefaults()
        {
            Projectile.width = 52;
            Projectile.height = 52;
            Projectile.aiStyle = 0;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.alpha = 80;
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
        public override void AI()
        {
            Projectile.scale *= 1.04f;
            counter++;
            if (counter % 1 == 0)
                Projectile.frame++;
            if (Projectile.frame >= 5)
            {
                Projectile.Kill();

            }
            for (int i = 0; i < 10; i++)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 135);
                Main.dust[dust].noGravity = true;
            }
        }
    }
}