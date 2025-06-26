using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using Bismuth.Content.Buffs;
using Terraria.Audio;

namespace Bismuth.Content.Projectiles
{
    public class PhoenixP : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Phoenix");
            //DisplayName.AddTranslation(GameCulture.Russian, "Феникс");
        }
        public override void SetDefaults()
        {
            Projectile.width = 94;
            Projectile.height = 70;
            Projectile.aiStyle = 0;
            Projectile.hostile = false;
            Projectile.friendly = true;
            Projectile.damage = 0;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 150;
            Main.projFrames[this.Projectile.type] = 14;
            //  projectile.alpha = 255;
        }
        int loop = 0;
        public override void AI()
        {
            Projectile.position.X = ((int)Main.player[Projectile.owner].position.X - 38);
            Projectile.position.Y = (int)Main.player[Projectile.owner].position.Y - 70 - (Projectile.ai[0] / 3);
            Projectile.ai[0]++;
            if (Projectile.ai[0] == 30)
                SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/PhoenixScream"), Projectile.position);
            if (Projectile.frame < 13)
                Projectile.frameCounter++;
            if (Projectile.frameCounter % 6 == 0 && Projectile.frame < 13)
            {
                if (Projectile.frame == 10 && loop < 5)
                {
                    Projectile.frame = 9;
                    loop++;
                }
                else
                    Projectile.frame++;
            }
        }
        public override void OnKill(int timeLeft)
        {
            Main.player[Projectile.owner].AddBuff(ModContent.BuffType<PhoenixBlessing>(), 900);
            for (int i = 0; i < 60; i++)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Torch);
              
            }
        }
        public override bool PreDraw(ref Color lightColor)
        {
            Main.spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/Projectiles/PhoenixP").Value, Projectile.position - Main.screenPosition, new Rectangle?(new Rectangle(0, 70 * Projectile.frame, 94, 70)), Color.White);
            return false;
        }
    }
}