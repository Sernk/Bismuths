using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using Terraria.Localization;

namespace Bismuth.Content.Projectiles
{
    public class OrcWizardOrbP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Dark Orb");
            //DisplayName.AddTranslation(GameCulture.Russian, "Темная сфера");
        }
        public override void SetDefaults()
        {
            AIType = ProjectileID.Bullet;
            Projectile.tileCollide = false;
            Projectile.width = 20;
            Projectile.height = 16;
            Projectile.penetrate = -1;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.alpha = 0;
            Projectile.timeLeft = 200;
            Projectile.knockBack = 8f;
        }
        void CreateDust()
        {
            for (int i = 0; i < 24; i++)
            {
                int dust = Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 62);
                Main.dust[dust].velocity = Vector2.Zero;
                Main.dust[dust].noGravity = true;
            }
        }
        public override void AI()
        {         
            CreateDust();
            Lighting.AddLight(Projectile.position, new Vector3(0.21f, 0.06f, 0.29f));           
        }
    }
}