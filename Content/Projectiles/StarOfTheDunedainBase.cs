using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class StarOfTheDunedainBase : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 8;
            Projectile.height = 8;
            Projectile.friendly = true;
            Projectile.aiStyle = 1;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 120;
            Projectile.extraUpdates = 1;
            AIType = ProjectileID.Bullet;
            Projectile.tileCollide = false;
        }
        Vector2 save;
        public override void AI()
        {
            Player player = Main.player[Projectile.owner];
            if ((double)Projectile.ai[0] == 0.0)
            {
                int baseDamage = 34;
                float modifiedDamage = player.GetDamage(DamageClass.Melee).ApplyTo(baseDamage);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0.0f, 0.0f, ModContent.ProjectileType<StarOfTheDunedainP>(), (int)modifiedDamage, 4.4f, Projectile.owner, Projectile.whoAmI, 0.0f);
                Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, 0.0f, 0.0f, ModContent.ProjectileType<StarOfTheDunedainP>(), (int)modifiedDamage, 4.4f, Projectile.owner, Projectile.whoAmI, 1.0f);
                Projectile.ai[0] = 1.0f;
                Projectile.netUpdate = true;
            }
            Projectile.ai[1]++;
            if (Projectile.ai[1] < 50)
            {
                save = Projectile.velocity;
            }
            if (Projectile.ai[1] >= 50 && Projectile.ai[1] < 60)
            {
                Projectile.velocity -= save / 10;
            }
            if (Projectile.ai[1] >= 60 && Projectile.ai[1] < 70)
            {
                Projectile.velocity += -save / 10;
            }
            // projectile.rotation++;
        }
    }
}
