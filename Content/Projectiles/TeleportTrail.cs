using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Bismuth.Utilities;

namespace Bismuth.Content.Projectiles
{
    public class TeleportTrail : ModProjectile
    {
        public override void SetDefaults()
        {          
            Projectile.width = 12;
            Projectile.height = 12;
            Projectile.friendly = true;         
            Projectile.aiStyle = 0;
            Projectile.penetrate = 8;
            Projectile.timeLeft = 10;
            Projectile.alpha = 255;    
        }

        public override void AI()
        {
           
        }
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            Projectile.vampireHeal(675, target.position, target);
        }

    }
}