using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace Bismuth.Content.Projectiles
{
    public class RevivingEagleP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Ghost Eagle");
            //DisplayName.AddTranslation(GameCulture.Russian, "Призрачный орел");
        }
        public override void SetDefaults()
        {
            Projectile.width = 18;
            Projectile.height = 32;
            Projectile.aiStyle = 0;
            Projectile.hostile = false;
            Projectile.friendly = true;
            Projectile.damage = 0;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 120;
            Main.projFrames[this.Projectile.type] = 6;
            //  projectile.alpha = 255;
        }
        public override void AI()
        {
            Projectile.position.X = ((int)Main.player[Projectile.owner].position.X - 38);
            if(Projectile.frame < 5)
                Projectile.frameCounter++;
            if (Projectile.frameCounter % 8 == 0 && Projectile.frame < 5)
                Projectile.frame++;
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Main.spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/Projectiles/RevivingEagleP").Value, Projectile.position - Main.screenPosition, new Rectangle?(new Rectangle(0, 60 * Projectile.frame, 94, 60)), Color.White);
            return false;
        }
    }
}