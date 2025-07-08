using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Bismuth.Utilities;

namespace Bismuth.Content.Projectiles
{
    public class MirrorSkullP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
        }
        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 32;
            Projectile.aiStyle = 0;
            Main.projFrames[this.Projectile.type] = 13;
            Projectile.hostile = false;
            Projectile.friendly = true;
            Projectile.damage = 0;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 600;
        }
        public override void AI()
        {
            //projectile.velocity.Y = -1f;
            Projectile.position.X = ((int)Main.player[Projectile.owner].position.X - 6);
            Projectile.frameCounter++;
            if (Projectile.frameCounter % 6 == 0)
                Projectile.frame++;
            if (Projectile.frame >= 13)
            {               
                if (Main.player[Projectile.owner].active && !Main.player[Projectile.owner].dead && Main.player[Projectile.owner].GetModPlayer<BismuthPlayer>().DeathPos != Vector2.Zero)
                {
                    Main.player[Projectile.owner].position = Main.player[Projectile.owner].GetModPlayer<BismuthPlayer>().DeathPos;
                    Main.player[Projectile.owner].GetModPlayer<BismuthPlayer>().DeathPos = Vector2.Zero;
                }
                Projectile.Kill();
            }
        }
    }
}