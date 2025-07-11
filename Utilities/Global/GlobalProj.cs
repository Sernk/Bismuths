using Bismuth.Content.Buffs;
using Bismuth.Content.NPCs;
using Bismuth.Content.Projectiles;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Utilities.Global
{
    public class GlobalProj : GlobalProjectile
    {
        public static int rikoshet = 3;
        public override bool OnTileCollide(Projectile projectile, Vector2 oldVelocity)
        {
            if (projectile.type == 580 && NPC.AnyNPCs(ModContent.NPCType<EvilBabaYaga>()))
            {
                projectile.damage = 15;
                Projectile.NewProjectile(projectile.GetSource_FromThis(), projectile.position, new Vector2(0, 0), ModContent.ProjectileType<LightningBlast>(), 20, 0.5f);
                SoundEngine.PlaySound(SoundID.Item122, projectile.position);
            }
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill112lvl > 0)
            {
                if (projectile.type == ProjectileID.Bullet || projectile.type == ProjectileID.ChlorophyteBullet || projectile.type == ProjectileID.BulletHighVelocity || projectile.type == ProjectileID.CrystalBullet || projectile.type == ProjectileID.CursedBullet || projectile.type == ProjectileID.GoldenBullet || projectile.type == ProjectileID.IchorBullet || projectile.type == ProjectileID.MoonlordBullet || projectile.type == ProjectileID.NanoBullet || projectile.type == ProjectileID.PartyBullet || projectile.type == ProjectileID.SniperBullet || projectile.type == ProjectileID.VenomBullet)
                {
                    rikoshet--;
                    if (rikoshet <= 0)
                    {
                        projectile.Kill();
                        rikoshet = 3;
                    }
                    if (rikoshet > 0)
                    {
                        if (projectile.velocity.X != oldVelocity.X)
                        {
                            projectile.velocity.X = -oldVelocity.X;
                        }
                        if (projectile.velocity.Y != oldVelocity.Y)
                        {
                            projectile.velocity.Y = -oldVelocity.Y;
                        }
                        SoundEngine.PlaySound(SoundID.Item10, projectile.position);
                    }
                    return false;
                }     
            }
            return base.OnTileCollide(projectile, oldVelocity);
        }                                 
        public override void OnKill(Projectile projectile, int timeLeft)
        {
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill112lvl > 0)
            {
                if (projectile.type == ProjectileID.Bullet || projectile.type == ProjectileID.ChlorophyteBullet || projectile.type == ProjectileID.BulletHighVelocity || projectile.type == ProjectileID.CrystalBullet || projectile.type == ProjectileID.CursedBullet || projectile.type == ProjectileID.GoldenBullet || projectile.type == ProjectileID.IchorBullet || projectile.type == ProjectileID.MoonlordBullet || projectile.type == ProjectileID.NanoBullet || projectile.type == ProjectileID.PartyBullet || projectile.type == ProjectileID.SniperBullet || projectile.type == ProjectileID.VenomBullet)
                {
                    rikoshet = 3;
                }
            }
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill115lvl > 0)
            {
                
                if (projectile.type == ProjectileID.Bullet || projectile.type == ProjectileID.ChlorophyteBullet || projectile.type == ProjectileID.BulletHighVelocity || projectile.type == ProjectileID.CrystalBullet || projectile.type == ProjectileID.CursedBullet || projectile.type == ProjectileID.GoldenBullet || projectile.type == ProjectileID.IchorBullet || projectile.type == ProjectileID.MoonlordBullet || projectile.type == ProjectileID.NanoBullet || projectile.type == ProjectileID.PartyBullet || projectile.type == ProjectileID.SniperBullet || projectile.type == ProjectileID.VenomBullet)
                {
                    SoundEngine.PlaySound(SoundID.Item14, projectile.position);
                    for (int num466 = 0; num466 < 7; num466++)
                    {
                        Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 31, 0f, 0f, 100, default(Color), 1.5f);
                    }
                    for (int num467 = 0; num467 < 3; num467++)
                    {
                        int num468 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 2.5f);
                        Main.dust[num468].noGravity = true;
                        Main.dust[num468].velocity *= 3f;
                        num468 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 6, 0f, 0f, 100, default(Color), 1.5f);
                        Main.dust[num468].velocity *= 2f;
                    }
                    int num469 = Gore.NewGore(projectile.GetSource_FromThis(), new Vector2(projectile.position.X - 10f, projectile.position.Y - 10f), default(Vector2), Main.rand.Next(61, 64), 1f);
                    Main.gore[num469].velocity *= 0.3f;
                    Gore expr_F126_cp_0 = Main.gore[num469];
                    expr_F126_cp_0.velocity.X = expr_F126_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.05f;
                    Gore expr_F156_cp_0 = Main.gore[num469];
                    expr_F156_cp_0.velocity.Y = expr_F156_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.05f;
                    if (projectile.owner == Main.myPlayer)
                    {
                        projectile.localAI[1] = -1f;
                        projectile.maxPenetrate = 0;
                        projectile.position.X = projectile.position.X + (float)(projectile.width / 2);
                        projectile.position.Y = projectile.position.Y + (float)(projectile.height / 2);
                        projectile.width = 80;
                        projectile.height = 80;
                        projectile.position.X = projectile.position.X - (float)(projectile.width / 2);
                        projectile.position.Y = projectile.position.Y - (float)(projectile.height / 2);
                        projectile.Damage();
                    }
                }
            }
        }
        public override void AI(Projectile projectile)
        {            
            if (Main.player[Main.myPlayer].FindBuffIndex(ModContent.BuffType<AutoTargeting>()) != -1 && projectile.CountsAsClass(DamageClass.Ranged))
            {
                float num138 = (float)Math.Sqrt((double)(projectile.velocity.X * projectile.velocity.X + projectile.velocity.Y * projectile.velocity.Y));
                float num139 = projectile.localAI[0];
                if (num139 == 0f)
                {
                    projectile.localAI[0] = num138;
                    num139 = num138;
                }
                if (projectile.alpha > 0)
                {
                    projectile.alpha -= 25;
                }
                if (projectile.alpha < 0)
                {
                    projectile.alpha = 0;
                }
                float num140 = projectile.position.X;
                float num141 = projectile.position.Y;
                float num142 = 300f;
                bool flag4 = false;
                int num143 = 0;
                if (projectile.ai[1] == 0f)
                {
                    for (int num144 = 0; num144 < 200; num144++)
                    {
                        if (Main.npc[num144].CanBeChasedBy(this, false) && (projectile.ai[1] == 0f || projectile.ai[1] == (float)(num144 + 1)))
                        {
                            float num145 = Main.npc[num144].position.X + (float)(Main.npc[num144].width / 2);
                            float num146 = Main.npc[num144].position.Y + (float)(Main.npc[num144].height / 2);
                            float num147 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num145) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num146);
                            if (num147 < num142 && Collision.CanHit(new Vector2(projectile.position.X + (float)(projectile.width / 2), projectile.position.Y + (float)(projectile.height / 2)), 1, 1, Main.npc[num144].position, Main.npc[num144].width, Main.npc[num144].height))
                            {
                                num142 = num147;
                                num140 = num145;
                                num141 = num146;
                                flag4 = true;
                                num143 = num144;
                            }
                        }
                    }
                    if (flag4)
                    {
                        projectile.ai[1] = (float)(num143 + 1);
                    }
                    flag4 = false;
                }
                if (projectile.ai[1] > 0f)
                {
                    int num148 = (int)(projectile.ai[1] - 1f);
                    if (Main.npc[num148].active && Main.npc[num148].CanBeChasedBy(this, true) && !Main.npc[num148].dontTakeDamage)
                    {
                        float num149 = Main.npc[num148].position.X + (float)(Main.npc[num148].width / 2);
                        float num150 = Main.npc[num148].position.Y + (float)(Main.npc[num148].height / 2);
                        float num151 = Math.Abs(projectile.position.X + (float)(projectile.width / 2) - num149) + Math.Abs(projectile.position.Y + (float)(projectile.height / 2) - num150);
                        if (num151 < 1000f)
                        {
                            flag4 = true;
                            num140 = Main.npc[num148].position.X + (float)(Main.npc[num148].width / 2);
                            num141 = Main.npc[num148].position.Y + (float)(Main.npc[num148].height / 2);
                        }
                    }
                    else
                    {
                        projectile.ai[1] = 0f;
                    }
                }
                if (!projectile.friendly)
                {
                    flag4 = false;
                }
                if (flag4)
                {
                    float num152 = num139;
                    Vector2 vector13 = new Vector2(projectile.position.X + (float)projectile.width * 0.5f, projectile.position.Y + (float)projectile.height * 0.5f);
                    float num153 = num140 - vector13.X;
                    float num154 = num141 - vector13.Y;
                    float num155 = (float)Math.Sqrt((double)(num153 * num153 + num154 * num154));
                    num155 = num152 / num155;
                    num153 *= num155;
                    num154 *= num155;
                    int num156 = 8;
                    projectile.velocity.X = (projectile.velocity.X * (float)(num156 - 1) + num153) / (float)num156;
                    projectile.velocity.Y = (projectile.velocity.Y * (float)(num156 - 1) + num154) / (float)num156;
                }
            }
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill143lvl > 0 && projectile.CountsAsClass(DamageClass.Throwing))
            {
                projectile.penetrate = 5;
            }
        }                   
    }
}