using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Projectiles
{
    public class MisericordeP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.aiStyle = 1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 50;
            Projectile.extraUpdates = 1;
            Projectile.timeLeft = 65;
            Projectile.damage = 0;
            AIType = ProjectileID.Bullet;
            Projectile.tileCollide = false;
            Projectile.alpha = 255;
        }
        Vector2 velToTarget;
        Vector2 velTangent;
        Vector2 oldvelToTarget;
        Vector2 targetPos;
        public override void AI()
        {
            Projectile.alpha = 255;
            Player player = Main.player[Projectile.owner];
            if (Projectile.ai[1] == 0.0f)
            {
                if(Projectile.ai[0] == 0.0f)
                    targetPos = Projectile.position + new Vector2(0, 100f);
                if (Projectile.ai[0] == 1.0f)
                    targetPos = Projectile.position + new Vector2(-70.71067811f, 70.71067811f);
                if (Projectile.ai[0] == 2.0f)
                    targetPos = Projectile.position + new Vector2(-100, 0f);
                if (Projectile.ai[0] == 3.0f)
                    targetPos = Projectile.position + new Vector2(-70.71067811f, -70.71067811f);
                if (Projectile.ai[0] == 4.0f)
                    targetPos = Projectile.position + new Vector2(0, -100f);
                if (Projectile.ai[0] == 5.0f)
                    targetPos = Projectile.position + new Vector2(70.71067811f, -70.71067811f);
                if (Projectile.ai[0] == 6.0f)
                    targetPos = Projectile.position + new Vector2(100, 0f);
                if (Projectile.ai[0] == 7.0f)
                    targetPos = Projectile.position + new Vector2(70.71067811f, 70.71067811f);             
                velToTarget = (targetPos - Projectile.position) / 15;
                velTangent = UtilsAI.Perpendicular(velToTarget);
                oldvelToTarget = velToTarget;
                Projectile.ai[1] = 1f;
            }
            velToTarget = (targetPos - Projectile.position) / 15;
            oldvelToTarget = (targetPos - Projectile.position) / 15;
            velToTarget *= 1.0003f;
            velTangent = UtilsAI.Perpendicular(oldvelToTarget);
            Projectile.velocity = velTangent;
            Projectile.velocity += velToTarget;
            for (int i = 0; i < 5; i++)

            {
                int dust2 = Dust.NewDust(Projectile.Center, 0, 0, 60, 0.0f, 0.0f, 0, new Color(), 1.0f);
                Main.dust[dust2].scale = 1.1f;
                Main.dust[dust2].noGravity = true;
                Main.dust[dust2].velocity = Vector2.Zero;
            }
            /*   if (projectile.ai[1] >= 60 && projectile.ai[1] < 70)
               {
                  projectile.velocity += -perp / 10;
                  projectile.velocity += UtilsAI.VelocityToPoint(start, projectile.position, 4f);
               }*/
        }
    }
}