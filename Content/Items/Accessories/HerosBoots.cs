using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.Graphics.Shaders;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Bismuth.Utilities;
using Bismuth.Content.Projectiles;

namespace Bismuth.Content.Items.Accessories
{
    [AutoloadEquip(EquipType.Shoes)]
    public class HerosBoots : ModItem
    {
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("The Boots of a Hero");
            // Tooltip.SetDefault("Doesn't give any bonuses");
            //DisplayName.AddTranslation(GameCulture.Russian, "Ботинки героя");
            //Tooltip.AddTranslation(GameCulture.Russian, "Не даёт никаких бонусов"); 
        }
        public override void SetDefaults()
        {
            Item.value = 3000000;
            Item.defense = 1;
            Item.rare = 10;
            Item.accessory = true;
        }
        public override void ModifyTooltips(List<TooltipLine> tooltips) 
        {
            tooltips.Add(new TooltipLine(this.Mod, "ItemName", Language.GetTextValue("Mods.Bismuth.DivineEquipment"))
            {
                OverrideColor = new Color?(new Color(0, 239, 239))
            });
            int count = 0;
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().KilledEoC)
                count++;
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().KilledSkeletron)
                count++;
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().KilledWoF)
                count++;
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().KilledAnyMechBoss)
                count++;
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().KilledPlantera)
                count++;
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().KilledGolem)
                count++;
            if (count == 1)
                tooltips[3].Text = Language.GetTextValue("Mods.Bismuth.HerosBoots"); 
            if (count == 2)
                tooltips[3].Text = Language.GetTextValue("Mods.Bismuth.HerosBoots1");
            if (count == 3)
                tooltips[3].Text = Language.GetTextValue("Mods.Bismuth.HerosBoots2");
            if (count == 4)
                tooltips[3].Text = Language.GetTextValue("Mods.Bismuth.HerosBoots3");
            if (count == 5)
                tooltips[3].Text = Language.GetTextValue("Mods.Bismuth.HerosBoots4");
            if (count == 6)
                tooltips[3].Text = Language.GetTextValue("Mods.Bismuth.HerosBoots5");
            if (count == 7)
                tooltips[3].Text = Language.GetTextValue("Mods.Bismuth.HerosBoots6");
        }
        int bootstimer1 = 0;
        int timer = 0;
        const float jumpdist = 450f;
        float plandist = 0f;
        Vector2 ActualPos;
        Vector2 OldPos;
        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            #region double and triblejump
            var jumpAgainCloud = player.GetJumpState<CloudInABottleJump>();
            var jumpAgainSandstorm = player.GetJumpState<SandstormInABottleJump>();
            var jumpAgainBlizzard = player.GetJumpState<BlizzardInABottleJump>();
            var jumpAgainFart = player.GetJumpState<FartInAJarJump>();
            var jumpAgainSail = player.GetJumpState<TsunamiInABottleJump>();
            var jumpAgainUnicorn = player.GetJumpState<UnicornMountJump>();
            var source = player.GetSource_FromThis();

            if (player.controlJump)
            {
                if (player.grapCount > 0)
                {
                    player.grappling[0] = -1;
                    player.grapCount = 0;
                    for (int j = 0; j < 1000; j++)
                    {
                        if (Main.projectile[j].active && Main.projectile[j].owner == player.whoAmI && Main.projectile[j].aiStyle == 7)
                        {
                            Main.projectile[j].Kill();
                        }
                    }
                }
                bool flag = false;
                if (player.mount.Active && player.mount.Type == 3 && player.wetSlime > 0)
                {
                    flag = true;
                }
                if (player.jump > 0)
                {

                }
                else if ((((player.sliding || player.velocity.Y == 0f) | flag) || jumpAgainCloud.Active || jumpAgainSandstorm.Active || jumpAgainBlizzard.Active || jumpAgainFart.Active || jumpAgainSail.Active || jumpAgainUnicorn.Active || BismuthPlayer.jumpAgainHeroSecond || BismuthPlayer.jumpAgainHeroThird || (player.wet && player.accFlipper && (!player.mount.Active || !player.mount.Cart))) && (player.releaseJump || (player.autoJump && (player.velocity.Y == 0f || player.sliding))))
                {
                   
                    if (player.sliding || player.velocity.Y == 0f)
                    {
                        player.justJumped = true;
                    }
                    bool flag2 = false;
                    if (player.wet && player.accFlipper)
                    {
                        if (player.swimTime == 0)
                        {
                            player.swimTime = 30;
                        }
                        flag2 = true;
                    }
                    bool flag3 = false;
                    bool flag4 = false;
                    bool flag5 = false;
                    bool flag6 = false;
                    bool flag7 = false;
                    bool flag8 = false;
                    bool flag9 = false;
                    if (!flag)
                    {
                        if (jumpAgainUnicorn.Active)
                        {
                            flag7 = true;
                            jumpAgainUnicorn.Enable();
                        }
                        else if (BismuthPlayer.jumpAgainHeroSecond)
                        {
                            BismuthPlayer.jumpAgainHeroSecond = false;
                            flag8 = true;
                        }
                        else if (BismuthPlayer.jumpAgainHeroThird)
                        {
                            BismuthPlayer.jumpAgainHeroThird = false;
                            flag9 = true;
                        }
                       
                        else if (jumpAgainSandstorm.Active)
                        {
                            flag3 = true;
                            jumpAgainSandstorm.Enable();
                        }
                        else if (jumpAgainBlizzard.Active)
                        {
                            flag4 = true;
                            jumpAgainBlizzard.Enable();
                        }
                        else if (jumpAgainFart.Active)
                        {
                            jumpAgainFart.Enable();
                            flag5 = true;
                        }
                        else if (jumpAgainSail.Active)
                        {
                            jumpAgainSail.Enable();
                            flag6 = true;
                        }                     
                        else
                        {
                            jumpAgainCloud.Enable();
                        }
                    }
                    player.canRocket = false;
                    player.rocketRelease = false;
                    if ((player.velocity.Y == 0f || player.sliding || (player.autoJump && player.justJumped)) && player.GetJumpState(ExtraJump.CloudInABottle).Enabled)
                    {
                        jumpAgainCloud.Enable();
                    }
                    if ((player.velocity.Y == 0f || player.sliding || (player.autoJump && player.justJumped)) && player.GetJumpState(ExtraJump.SandstormInABottle).Enabled)
                    {
                        jumpAgainSandstorm.Enable();
                    }
                    if ((player.velocity.Y == 0f || player.sliding || (player.autoJump && player.justJumped)) && player.GetJumpState(ExtraJump.BlizzardInABottle).Enabled)
                    {
                        jumpAgainBlizzard.Enable();
                    }
                    if ((player.velocity.Y == 0f || player.sliding || (player.autoJump && player.justJumped)) && player.GetJumpState(ExtraJump.FartInAJar).Enabled)
                    {
                        jumpAgainFart.Enable();
                    }
                    if ((player.velocity.Y == 0f || player.sliding || (player.autoJump && player.justJumped)) && player.GetJumpState(ExtraJump.TsunamiInABottle).Enabled)
                    {
                        jumpAgainSail.Enable();
                    }
                    if ((player.velocity.Y == 0f || player.sliding || (player.autoJump && player.justJumped)) && player.GetJumpState(ExtraJump.UnicornMount).Enabled)
                    {
                        jumpAgainUnicorn.Enable();
                    }
                    if ((player.velocity.Y == 0f || player.sliding || (player.autoJump && player.justJumped)) && BismuthPlayer.doubleJumpHeroSecond)
                    {
                        BismuthPlayer.jumpAgainHeroSecond = true;
                    }
                    if ((player.velocity.Y == 0f || player.sliding || (player.autoJump && player.justJumped)) && BismuthPlayer.doubleJumpHeroThird)
                    {
                        BismuthPlayer.jumpAgainHeroThird = true;
                    }
                    if (((player.velocity.Y == 0f | flag2) || player.sliding) | flag)
                    {
                        
                        player.velocity.Y = (0f - Player.jumpSpeed) * player.gravDir;
                        player.jump = Player.jumpHeight;
                        if (player.sliding)
                        {
                            player.velocity.X = 3f * (0f - (float)player.slideDir);
                        }
                    }
                    else if (flag8)
                    {
                        SoundEngine.PlaySound(SoundID.DoubleJump, player.position);
                        player.velocity.Y = (0f - Player.jumpSpeed) * player.gravDir;
                        player.jump = (int)((double)Player.jumpHeight * 0.75);
                        Projectile.NewProjectile(source, player.position + new Vector2(0f, 4f), new Vector2(-5f, 3f), ModContent.ProjectileType<HeroBootsJumpEffect>(), 0, 0.0f, Main.myPlayer, 0.0f, 0.0f);
                        Projectile.NewProjectile(source, player.position + new Vector2(0f, 4f), new Vector2(5f, 3f), ModContent.ProjectileType<HeroBootsJumpEffect>(), 0, 0.0f, Main.myPlayer, 0.0f, 0.0f);
                        Projectile.NewProjectile(source, player.position + new Vector2(0f, 4f), new Vector2(-3f, 5f), ModContent.ProjectileType<HeroBootsJumpEffect>(), 0, 0.0f, Main.myPlayer, 0.0f, 0.0f);
                        Projectile.NewProjectile(source, player.position + new Vector2(0f, 4f), new Vector2(3f, 5f), ModContent.ProjectileType<HeroBootsJumpEffect>(), 0, 0.0f, Main.myPlayer, 0.0f, 0.0f);
                        Projectile.NewProjectile(source, player.position + new Vector2(0f, 4f), new Vector2(0f, 6f), ModContent.ProjectileType<HeroBootsJumpEffect>(), 0, 0.0f, Main.myPlayer, 0.0f, 0.0f);
                    }
                    else if (flag9)
                    {
                        SoundEngine.PlaySound(SoundID.DoubleJump, player.position);
                        player.velocity.Y = (0f - Player.jumpSpeed) * player.gravDir;
                        player.jump = (int)((double)Player.jumpHeight * 0.75);
                        Projectile.NewProjectile(source, player.position + new Vector2(0f, 4f), new Vector2(-5f, 3f), ModContent.ProjectileType<HeroBootsJumpEffect>(), 0, 0.0f, Main.myPlayer, 0.0f, 0.0f);
                        Projectile.NewProjectile(source, player.position + new Vector2(0f, 4f), new Vector2(5f, 3f), ModContent.ProjectileType<HeroBootsJumpEffect>(), 0, 0.0f, Main.myPlayer, 0.0f, 0.0f);
                        Projectile.NewProjectile(source, player.position + new Vector2(0f, 4f), new Vector2(-3f, 5f), ModContent.ProjectileType<HeroBootsJumpEffect>(), 0, 0.0f, Main.myPlayer, 0.0f, 0.0f);
                        Projectile.NewProjectile(source, player.position + new Vector2(0f, 4f), new Vector2(3f, 5f), ModContent.ProjectileType<HeroBootsJumpEffect>(), 0, 0.0f, Main.myPlayer, 0.0f, 0.0f);
                        Projectile.NewProjectile(source, player.position + new Vector2(0f, 4f), new Vector2(0f, 6f), ModContent.ProjectileType<HeroBootsJumpEffect>(), 0, 0.0f, Main.myPlayer, 0.0f, 0.0f);
                    }
                    else if (flag3)
                    {
                        jumpAgainSandstorm.Enable();
                        int height = player.height;
                        float num2 = player.gravDir;
                        SoundEngine.PlaySound(SoundID.DoubleJump, player.position);
                        player.velocity.Y = (0f - Player.jumpSpeed) * player.gravDir;
                        player.jump = Player.jumpHeight * 3;
                    }
                    else if (flag4)
                    {
                        jumpAgainBlizzard.Enable();
                        int height2 = player.height;
                        float num3 = player.gravDir;
                        SoundEngine.PlaySound(SoundID.DoubleJump, player.position);
                        player.velocity.Y = (0f - Player.jumpSpeed) * player.gravDir;
                        player.jump = (int)((double)Player.jumpHeight * 1.5);
                    }
                    else if (flag6)
                    {
                        jumpAgainSail.Enable();
                        int num4 = player.height;
                        if (player.gravDir == -1f)
                        {
                            num4 = 0;
                        }
                        SoundEngine.PlaySound(SoundID.DoubleJump, player.position);
                        player.velocity.Y = (0f - Player.jumpSpeed) * player.gravDir;
                        player.jump = (int)((double)Player.jumpHeight * 1.25);
                        for (int j = 0; j < 30; j++)
                        {
                            int num5 = Dust.NewDust(new Vector2(player.position.X, player.position.Y + (float)num4), player.width, 12, 253, player.velocity.X * 0.3f, player.velocity.Y * 0.3f, 100, default(Color), 1.5f);
                            if (j % 2 == 0)
                            {
                                Dust dust = Main.dust[num5];
                                dust.velocity.X = dust.velocity.X + (float)Main.rand.Next(30, 71) * 0.1f;
                            }
                            else
                            {
                                Dust dust2 = Main.dust[num5];
                                dust2.velocity.X = dust2.velocity.X - (float)Main.rand.Next(30, 71) * 0.1f;
                            }
                            Dust dust3 = Main.dust[num5];
                            dust3.velocity.Y = dust3.velocity.Y + (float)Main.rand.Next(-10, 31) * 0.1f;
                            Main.dust[num5].noGravity = true;
                            Main.dust[num5].scale += (float)Main.rand.Next(-10, 41) * 0.01f;
                            Dust obj = Main.dust[num5];
                            obj.velocity *= Main.dust[num5].scale * 0.7f;
                            Vector2 value = new Vector2((float)Main.rand.Next(-100, 101), (float)Main.rand.Next(-100, 101));
                            value.Normalize();
                            value *= (float)Main.rand.Next(81) * 0.1f;
                        }
                    }
                    else if (flag5)
                    {
                        jumpAgainFart.Enable();
                        int num6 = player.height;
                        if (player.gravDir == -1f)
                        {
                            num6 = 0;
                        }
                        SoundEngine.PlaySound(SoundID.Item16, player.position);
                        player.velocity.Y = (0f - Player.jumpSpeed) * player.gravDir;
                        player.jump = Player.jumpHeight * 2;
                        for (int k = 0; k < 10; k++)
                        {
                            int num7 = Dust.NewDust(new Vector2(player.position.X - 34f, player.position.Y + (float)num6 - 16f), 102, 32, 188, (0f - player.velocity.X) * 0.5f, player.velocity.Y * 0.5f, 100, default(Color), 1.5f);
                            Main.dust[num7].velocity.X = Main.dust[num7].velocity.X * 0.5f - player.velocity.X * 0.1f;
                            Main.dust[num7].velocity.Y = Main.dust[num7].velocity.Y * 0.5f - player.velocity.Y * 0.3f;
                        }
                        int num8 = Gore.NewGore(source, new Vector2(player.position.X + (float)(player.width / 2) - 16f, player.position.Y + (float)num6 - 16f), new Vector2(0f - player.velocity.X, 0f - player.velocity.Y), Main.rand.Next(435, 438), 1f);
                        Main.gore[num8].velocity.X = Main.gore[num8].velocity.X * 0.1f - player.velocity.X * 0.1f;
                        Main.gore[num8].velocity.Y = Main.gore[num8].velocity.Y * 0.1f - player.velocity.Y * 0.05f;
                        num8 = Gore.NewGore(source, new Vector2(player.position.X - 36f, player.position.Y + (float)num6 - 16f), new Vector2(0f - player.velocity.X, 0f - player.velocity.Y), Main.rand.Next(435, 438), 1f);
                        Main.gore[num8].velocity.X = Main.gore[num8].velocity.X * 0.1f - player.velocity.X * 0.1f;
                        Main.gore[num8].velocity.Y = Main.gore[num8].velocity.Y * 0.1f - player.velocity.Y * 0.05f;
                        num8 = Gore.NewGore(source, new Vector2(player.position.X + (float)player.width + 4f, player.position.Y + (float)num6 - 16f), new Vector2(0f - player.velocity.X, 0f - player.velocity.Y), Main.rand.Next(435, 438), 1f);
                        Main.gore[num8].velocity.X = Main.gore[num8].velocity.X * 0.1f - player.velocity.X * 0.1f;
                        Main.gore[num8].velocity.Y = Main.gore[num8].velocity.Y * 0.1f - player.velocity.Y * 0.05f;
                    }
                    else if (flag7)
                    {
                        jumpAgainUnicorn.Enable();
                        int height3 = player.height;
                        float num9 = player.gravDir;
                        SoundEngine.PlaySound(SoundID.DoubleJump, player.position);
                        player.velocity.Y = (0f - Player.jumpSpeed) * player.gravDir;
                        player.jump = Player.jumpHeight * 2;
                        Vector2 center = player.Center;
                        Vector2 value2 = new Vector2(50f, 20f);
                        float num10 = 6.28318548f * Main.rand.NextFloat();
                        for (int l = 0; l < 5; l++)
                        {
                            for (float num11 = 0f; num11 < 14f; num11 += 1f)
                            {
                                Dust dust4 = Main.dust[Dust.NewDust(center, 0, 0, Utils.SelectRandom(Main.rand, 176, 177, 179), 0f, 0f, 0, default(Color), 1f)];
                                Vector2 value3 = Vector2.UnitY.RotatedBy((double)(num11 * 6.28318548f / 14f + num10), default(Vector2));
                                value3 *= 0.2f * (float)l;
                                dust4.position = center + value3 * value2;
                                dust4.velocity = value3 + new Vector2(0f, player.gravDir * 4f);
                                dust4.noGravity = true;
                                dust4.scale = 1f + Main.rand.NextFloat() * 0.8f;
                                dust4.fadeIn = Main.rand.NextFloat() * 2f;
                                dust4.shader = GameShaders.Armor.GetSecondaryShader(player.cMount, player);
                            }
                        }
                    }                    
                    else
                    {
                        jumpAgainCloud.Enable();
                        int num12 = player.height;
                        if (player.gravDir == -1f)
                        {
                            num12 = 0;
                        }
                        SoundEngine.PlaySound(SoundID.DoubleJump, player.position);
                        player.velocity.Y = (0f - Player.jumpSpeed) * player.gravDir;
                        player.jump = (int)((double)Player.jumpHeight * 0.75);
                        for (int m = 0; m < 10; m++)
                        {
                            int num13 = Dust.NewDust(new Vector2(player.position.X - 34f, player.position.Y + (float)num12 - 16f), 102, 32, 16, (0f - player.velocity.X) * 0.5f, player.velocity.Y * 0.5f, 100, default(Color), 1.5f);
                            Main.dust[num13].velocity.X = Main.dust[num13].velocity.X * 0.5f - player.velocity.X * 0.1f;
                            Main.dust[num13].velocity.Y = Main.dust[num13].velocity.Y * 0.5f - player.velocity.Y * 0.3f;
                        }
                        int num14 = Gore.NewGore(source, new Vector2(player.position.X + (float)(player.width / 2) - 16f, player.position.Y + (float)num12 - 16f), new Vector2(0f - player.velocity.X, 0f - player.velocity.Y), Main.rand.Next(11, 14), 1f);
                        Main.gore[num14].velocity.X = Main.gore[num14].velocity.X * 0.1f - player.velocity.X * 0.1f;
                        Main.gore[num14].velocity.Y = Main.gore[num14].velocity.Y * 0.1f - player.velocity.Y * 0.05f;
                        num14 = Gore.NewGore(source, new Vector2(player.position.X - 36f, player.position.Y + (float)num12 - 16f), new Vector2(0f - player.velocity.X, 0f - player.velocity.Y), Main.rand.Next(11, 14), 1f);
                        Main.gore[num14].velocity.X = Main.gore[num14].velocity.X * 0.1f - player.velocity.X * 0.1f;
                        Main.gore[num14].velocity.Y = Main.gore[num14].velocity.Y * 0.1f - player.velocity.Y * 0.05f;
                        num14 = Gore.NewGore(source, new Vector2(player.position.X + (float)player.width + 4f, player.position.Y + (float)num12 - 16f), new Vector2(0f - player.velocity.X, 0f - player.velocity.Y), Main.rand.Next(11, 14), 1f);
                        Main.gore[num14].velocity.X = Main.gore[num14].velocity.X * 0.1f - player.velocity.X * 0.1f;
                        Main.gore[num14].velocity.Y = Main.gore[num14].velocity.Y * 0.1f - player.velocity.Y * 0.05f;
                    }
                }
                player.releaseJump = false;
            }
            else
            {
                player.jump = 0;
                player.releaseJump = true;
                player.rocketRelease = true;
            }
            #endregion

            int count = 0;
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().KilledEoC)
                count++;
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().KilledWormorBrain)
                count++;
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().KilledSkeletron)
                count++;
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().KilledWoF)
                count++;
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().KilledAnyMechBoss)
                count++;
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().KilledPlantera)
                count++;
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().KilledGolem)
                count++;
            Player.jumpSpeed += 0.15f;
            
           
            if (count >= 4)
            {
                if (player.velocity != Vector2.Zero)
                {
                    player.lifeRegen += 10;
                }
            }
            if (count >= 5)
            {
                if (player.controlDown && player.velocity == Vector2.Zero)
                {
                    bootstimer1++;
                }

                if (bootstimer1 == 30)
                    SoundEngine.PlaySound(SoundID.Item13, player.position);
                if (bootstimer1 > 30 && bootstimer1 < 60)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        int index1 = Dust.NewDust(new Vector2(player.position.X, player.position.Y + player.height - 4), player.width, 3, 244, 0.0f, 0.0f, 0, new Color(), 1f);
                        Main.dust[index1].noGravity = true;
                        Main.dust[index1].velocity = Vector2.Zero;
                        Main.dust[index1].scale = 0.9f;
                    }
                }
                if (bootstimer1 == 60)
                {
                    OldPos = player.position;
                    plandist = Vector2.Distance(Main.MouseWorld, player.position);
                    ActualPos.X = (jumpdist * (Main.MouseWorld.X - player.position.X)) / plandist + player.position.X;
                    ActualPos.Y = (jumpdist * (Main.MouseWorld.Y - player.position.Y)) / plandist + player.position.Y;
                    bootstimer1++;
                }
                if (bootstimer1 > 60 && bootstimer1 < 120)
                {
                    bootstimer1++;
                    if (bootstimer1 < 67)
                    {
                        player.velocity = Collision.TileCollision(player.position, (ActualPos - OldPos) / 25, player.width, player.height, true, true, (int)player.gravDir);
                    }
                    for (int i = 0; i < 8; i++)
                    {
                        int index1 = Dust.NewDust(new Vector2(player.Center.X - 6, player.Center.Y + 6), 12, 12, 244, 0.0f, 0.0f, 0, new Color(), 1f);
                        Main.dust[index1].noGravity = true;
                        Main.dust[index1].velocity = Vector2.Zero;
                        Main.dust[index1].scale = 0.9f;
                    }
                }
                if (bootstimer1 < 60 && (!player.controlDown || player.velocity != Vector2.Zero))
                    bootstimer1 = 0;
                if (bootstimer1 >= 120)
                    bootstimer1 = 0;
            }
            if (count == 1)
            {
                player.accRunSpeed = 6f;
            }
            if (count == 2)
            {
                player.accRunSpeed = 6f;
                player.moveSpeed += 0.1f;
                player.waterWalk = true;
                Player.jumpSpeed += 0.06f;

            }
            if (count == 3)
            {
                player.accRunSpeed = 6f;
                player.moveSpeed += 0.15f;
                player.waterWalk = true;
                player.fireWalk = true;
                Player.jumpSpeed += 0.08f;
               
            }
            if (count == 4)
            {
                player.accRunSpeed = 6f;
                player.moveSpeed += 0.20f;
                player.waterWalk = true;
                player.waterWalk2 = true;
                player.fireWalk = true;
                Player.jumpSpeed += 0.1f;
                BismuthPlayer.doubleJumpHeroSecond = true;
            }
            if (count == 5)
            {
                player.accRunSpeed = 6f;
                player.moveSpeed += 0.3f;
                player.waterWalk = true;
                player.waterWalk2 = true;
                player.fireWalk = true;
                Player.jumpSpeed += 0.14f;
                BismuthPlayer.doubleJumpHeroSecond = true;                
            }
            if (count == 6)
            {
                player.accRunSpeed = 6f;
                player.moveSpeed += 0.45f;
                player.waterWalk = true;
                player.waterWalk2 = true;
                player.fireWalk = true;
                Player.jumpSpeed += 0.2f;
                BismuthPlayer.doubleJumpHeroSecond = true;
                BismuthPlayer.doubleJumpHeroThird = true;
            }
            if (count == 7)
            {
                player.accRunSpeed = 6f;
                player.moveSpeed += 0.6f;
                player.waterWalk = true;
                player.waterWalk2 = true;
                player.fireWalk = true;
                Player.jumpSpeed += 0.25f;
                BismuthPlayer.doubleJumpHeroSecond = true;
                BismuthPlayer.doubleJumpHeroThird = true;
                player.noFallDmg = true;
            }
        }
    }
}