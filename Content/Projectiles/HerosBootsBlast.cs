using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace Bismuth.Content.Projectiles
{
    public class HerosBootsBlast : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Blast");
            //DisplayName.AddTranslation(GameCulture.Russian, "Взрыв");
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
            Projectile.friendly = true;
            Projectile.damage = 50;
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
            Lighting.AddLight(Projectile.Center, new Vector3(1f, 0.63f, 0.34f));
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