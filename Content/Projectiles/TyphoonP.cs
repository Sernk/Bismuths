using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class TyphoonP : ModProjectile
    {
        public override void SetDefaults()
        {

            Projectile.width = 20;
            Projectile.height = 20;
            Projectile.friendly = true;
            Projectile.aiStyle = 3;
            Projectile.DamageType = DamageClass.Throwing;
            Projectile.penetrate = 5;
        }

        public override void AI()
        {

        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            var s = Projectile.GetSource_FromThis();
            Projectile.NewProjectile(s, Projectile.position, new Vector2(-4.242640f * (float)Math.Sin(Math.PI / 15.8 + (Math.PI / 4)), -4.242640f * (float)Math.Cos(Math.PI / 15.8 + (Math.PI / 4))), ModContent.ProjectileType<TyphoonP2>(), 8, 4f, Projectile.owner);
            Projectile.NewProjectile(s, Projectile.position, new Vector2(-4.242640f * (float)Math.Sin(Math.PI / 15.8), -4.242640f * (float)Math.Cos(Math.PI / 15.8)), ModContent.ProjectileType<TyphoonP2>(), 8, 4f, Projectile.owner);
            Projectile.NewProjectile(s, Projectile.position, new Vector2(-4.242640f * (float)Math.Sin(Math.PI / 15.8 - (Math.PI / 4)), -4.242640f * (float)Math.Cos(Math.PI / 15.8 - (Math.PI / 4))), ModContent.ProjectileType<TyphoonP2>(), 8, 4f, Projectile.owner);
            Projectile.NewProjectile(s, Projectile.position, new Vector2(-4.242640f * (float)Math.Sin(Math.PI / 15.8 + (Math.PI / 2)), -4.242640f * (float)Math.Cos(Math.PI / 15.8 + (Math.PI / 2))), ModContent.ProjectileType<TyphoonP2>(), 8, 4f, Projectile.owner);
            Projectile.NewProjectile(s, Projectile.position, new Vector2(-4.242640f * (float)Math.Sin(Math.PI / 15.8 - (Math.PI / 2)), -4.242640f * (float)Math.Cos(Math.PI / 15.8 - (Math.PI / 2))), ModContent.ProjectileType<TyphoonP2>(), 8, 4f, Projectile.owner);
            Projectile.NewProjectile(s, Projectile.position, new Vector2(-4.242640f * (float)Math.Sin(Math.PI / 15.8 + (3 * Math.PI / 4)), -4.242640f * (float)Math.Cos(Math.PI / 15.8 + (3 * Math.PI / 4))), ModContent.ProjectileType<TyphoonP2>(), 8, 4f, Projectile.owner);
            Projectile.NewProjectile(s, Projectile.position, new Vector2(-4.242640f * (float)Math.Sin(Math.PI / 15.8 - (3 * Math.PI / 4)), -4.242640f * (float)Math.Cos(Math.PI / 15.8 - (3 * Math.PI / 4))), ModContent.ProjectileType<TyphoonP2>(), 8, 4f, Projectile.owner);
            Projectile.NewProjectile(s, Projectile.position, new Vector2(-4.242640f * (float)Math.Sin(Math.PI / 15.8 + Math.PI), -4.242640f * (float)Math.Cos(Math.PI / 15.8 + Math.PI)), ModContent.ProjectileType<TyphoonP2>(), 8, 4f, Projectile.owner);
            base.OnHitNPC(target, hit, damageDone);
        }
    }
}