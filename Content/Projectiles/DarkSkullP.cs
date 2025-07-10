using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Localization;
using Bismuth.Utilities;

namespace Bismuth.Content.Projectiles
{
    public class DarkSkullP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Dark Skull");
            //DisplayName.AddTranslation(GameCulture.Russian, "Темный череп");
        }
        public override void SetDefaults()
        {
            AIType = ProjectileID.Bullet;
            Projectile.tileCollide = false;
            Projectile.width = 20;
            Projectile.height = 16;
            Main.projFrames[Projectile.type] = 4;
            Projectile.penetrate = -1;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.alpha = 0;
            Projectile.timeLeft = 200;
            Projectile.knockBack = 8f;
        }
        void CreateDust()
        {
            for (int i = 0; i < 8; i++)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 62);
                Main.dust[dust].velocity = Vector2.Zero;
                Main.dust[dust].noGravity = true;
            }
        }
        int tick = 0;
        Vector2 perp;
        public override void AI()
        {
            if (Projectile.ai[0] == 0f)
            {
                perp = UtilsAI.Perpendicular(Projectile.velocity);
            }
            Projectile.ai[0]++;
            if (Projectile.ai[0] % 20 < 5 || Projectile.ai[0] % 20 >= 15)
                Projectile.velocity += perp / 30;
            else
                Projectile.velocity -= perp / 30;
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 1.57f;
            // if(projectile.ai[0] == 0f)
            //     projectile.Navigate()
            CreateDust();
            Lighting.AddLight(Projectile.position, new Vector3(0.21f, 0.06f, 0.29f));
            Projectile.frameCounter++;
            if (Projectile.frameCounter > 8)
            {
                Projectile.frame++;
                Projectile.frameCounter = 0;
            }
            if (Projectile.frame > 3)
            {
                Projectile.frame = 0;
            }
        }
    }
}