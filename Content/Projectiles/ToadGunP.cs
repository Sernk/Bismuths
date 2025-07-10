using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.ModLoader;

namespace Bismuth.Content.Projectiles
{
    public class ToadGunP : ModProjectile
    {
        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.scale = 1f;
            Projectile.friendly = true;
            Projectile.penetrate = -1;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.extraUpdates = 1;
            Projectile.aiStyle = -1;
        }

        float angle = 0f;

        public override void AI()
        {
            if (Projectile.ai[1] == 0f && angle == 0f)
            {
                angle = (float)Math.Atan2(Projectile.velocity.Y, Projectile.velocity.X) + 1.57f;                              
            }
                Projectile.rotation = angle;
            if (Projectile.ai[0] == 0f)
            {
                Projectile.ai[1] += 1f;
                if (Projectile.ai[1] >= 20f)
                {
                    Projectile.ai[0] = 1f;
                    Projectile.ai[1] = 0f;
                    Projectile.netUpdate = true;
                }
            }
            else
            {
                Projectile.tileCollide = false;
                float num = 25f;
                float num2 = 5f;
                Vector2 vector = new Vector2(Projectile.position.X + (float)Projectile.width * 0.5f, Projectile.position.Y + (float)Projectile.height * 0.5f);
                float num3 = Main.player[Projectile.owner].position.X + (float)(Main.player[Projectile.owner].width / 2) - vector.X;
                float num4 = Main.player[Projectile.owner].position.Y + (float)(Main.player[Projectile.owner].height / 2) - vector.Y;
                float num5 = (float)Math.Sqrt((double)(num3 * num3 + num4 * num4));
                if (num5 > 3000f)
                {
                    Projectile.Kill();
                }
                num5 = num / num5;
                num3 *= num5;
                num4 *= num5;
                if (Projectile.velocity.X < num3)
                {
                    Projectile.velocity.X = Projectile.velocity.X + num2;
                    if (Projectile.velocity.X < 0f && num3 > 0f)
                    {
                        Projectile.velocity.X = Projectile.velocity.X + num2;
                    }
                }
                else if (Projectile.velocity.X > num3)
                {
                    Projectile.velocity.X = Projectile.velocity.X - num2;
                    if (Projectile.velocity.X > 0f && num3 < 0f)
                    {
                        Projectile.velocity.X = Projectile.velocity.X - num2;
                    }
                }
                if (Projectile.velocity.Y < num4)
                {
                    Projectile.velocity.Y = Projectile.velocity.Y + num2;
                    if (Projectile.velocity.Y < 0f && num4 > 0f)
                    {
                        Projectile.velocity.Y = Projectile.velocity.Y + num2;
                    }
                }
                else if (Projectile.velocity.Y > num4)
                {
                    Projectile.velocity.Y = Projectile.velocity.Y - num2;
                    if (Projectile.velocity.Y > 0f && num4 < 0f)
                    {
                        Projectile.velocity.Y = Projectile.velocity.Y - num2;
                    }
                }
                if (Main.myPlayer == Projectile.owner)
                {
                    Rectangle rectangle = new Rectangle((int)Projectile.position.X, (int)Projectile.position.Y, Projectile.width, Projectile.height);
                    Rectangle value = new Rectangle((int)Main.player[Projectile.owner].position.X, (int)Main.player[Projectile.owner].position.Y, Main.player[Projectile.owner].width, Main.player[Projectile.owner].height);
                    if (rectangle.Intersects(value))
                    {
                        Projectile.Kill();
                    }
                }
            }
            if (Projectile.ai[0] == 0f)
            {
                Vector2 velocity = Projectile.velocity;
                velocity.Normalize();
            }
            (Projectile.Center - Main.player[Projectile.owner].Center).Normalize();
        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            Projectile.ai[1] = 20f;
            return false;
        }
        public override void PostDraw(Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>("Bismuth/Content/Projectiles/ToadGunP_Chain").Value;
            Vector2 vector = Projectile.Center;
            Vector2 mountedCenter = Main.player[Projectile.owner].MountedCenter;
            Rectangle? sourceRectangle = null;
            Vector2 origin = new Vector2((float)texture.Width * 0.5f, (float)texture.Height * 0.5f);
            float num = (float)texture.Height;
            Vector2 vector2 = mountedCenter - vector;
            float rotation = (float)Math.Atan2((double)vector2.Y, (double)vector2.X) - 1.57f;
            bool flag = true;
            if (float.IsNaN(vector.X) && float.IsNaN(vector.Y))
            {
                flag = false;
            }
            if (float.IsNaN(vector2.X) && float.IsNaN(vector2.Y))
            {
                flag = false;
            }
            while (flag)
            {
                if ((double)vector2.Length() < (double)num + 1.0)
                {
                    flag = false;
                }
                else
                {
                    Vector2 value = vector2;
                    value.Normalize();
                    vector += value * num;
                    vector2 = mountedCenter - vector;
                    Color color = Lighting.GetColor((int)vector.X / 16, (int)((double)vector.Y / 16.0));
                    color = Projectile.GetAlpha(color);
                    Main.spriteBatch.Draw(texture, vector - Main.screenPosition, sourceRectangle, color, rotation, origin, 1f, SpriteEffects.None, 0f);
                }
            }
        }
    }
}