using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bismuth.Content.NPCs;
using Bismuth.Utilities;

namespace Bismuth.Content.Projectiles
{
    public class UndeadRevivingP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = false;
            Projectile.penetrate = 50;
            Projectile.timeLeft = 600;
            Projectile.damage = 0;
            Projectile.tileCollide = false;
            Projectile.alpha = 255;
        }
      
        Vector2 MoveTo = Vector2.Zero;
        public override void AI()
        {
            if (Projectile.ai[0] != 0 && Projectile.ai[1] != 0)
            {
                MoveTo = new Vector2(Projectile.ai[0], Projectile.ai[1]);
                Projectile.ai[0] = 0f;
                Projectile.ai[1] = 0f;
            }
            Projectile.alpha = 255;
         
            Projectile.ai[0]++;
            if (Projectile.ai[0] > 10f)
            {

                Projectile.Navigate(MoveTo, 7f, 15f);
            }
            if (Vector2.Distance(Projectile.position, MoveTo) < 3f)
                Projectile.Kill();
            for (int i = 0; i < 8; i++)

            {
                int dust2 = Dust.NewDust(Projectile.position, 12, 12, 65, 0.0f, 0.0f, 0, new Color(), 1.0f);
                Main.dust[dust2].scale = 1.0f;
                Main.dust[dust2].noGravity = true;
                Main.dust[dust2].velocity = Vector2.Zero;
            }
           /* for (int i = 0; i < 5; i++)

            {
                int dust2 = Dust.NewDust(MoveTo, 0, 0, 132, 0.0f, 0.0f, 0, new Color(), 1.0f);
                Main.dust[dust2].scale = 1.0f;
                Main.dust[dust2].noGravity = true;
                Main.dust[dust2].velocity = Vector2.Zero;
            }*/
            /*   if (projectile.ai[1] >= 60 && projectile.ai[1] < 70)
               {
                  projectile.velocity += -perp / 10;
                  projectile.velocity += UtilsAI.VelocityToPoint(start, projectile.position, 4f);
               }*/
        }
        public override void OnKill(int timeLeft)
        {
            for (int counter = 0; counter < 15; counter++)
            {
                Vector2 velocity = Projectile.velocity * ((float)Main.rand.Next(20, 140) / 100f);

                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 62);
            }
            NPC.NewNPC(Projectile.GetSource_FromThis(), (int)MoveTo.X, (int)MoveTo.Y, ModContent.NPCType<NecromancersSkeleton>());
        }
    }
}