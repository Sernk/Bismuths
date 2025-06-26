using Bismuth.Content.Buffs;
using Bismuth.Content.Projectiles;
using System;
using Terraria.Audio;
using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameInput;

namespace Bismuth.Utilities
{
    public class HotKeyPlayer : ModPlayer
    {
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            Player player = Main.player[Main.myPlayer];
            Mod mod = ModLoader.GetMod("Bismuth");
            BismuthPlayer Bismuthplayer = (BismuthPlayer)Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>();
            int buffIdx = player.FindBuffIndex(ModContent.BuffType<SkillCooldown>());
            int buffIdx2 = player.FindBuffIndex(ModContent.BuffType<TeleportCooldown>());
            if (Bismuth.VampireBatTurnHotKey.JustPressed)
            {
                if (Math.Abs(Main.time - Bismuth.pressedToggleBat) > 20)
                {
                    Bismuth.pressedToggleBat = Main.time;
                    if (Bismuthplayer.IsVampire && (Bismuthplayer.Hunger > 70 || player.GetModPlayer<BismuthPlayer>().IsEquippedDraculasCover))
                    {
                        if (player.FindBuffIndex(ModContent.BuffType<VampireBat>()) != -1)
                        {
                            player.ClearBuff(ModContent.BuffType<VampireBat>());
                        }
                        else
                        {
                            player.AddBuff(ModContent.BuffType<VampireBat>(), 10);
                        }
                        SoundEngine.PlaySound(SoundID.Item8, player.position);
                    }
                }
            }
            if (Bismuth.ToggleExpPanelHotKey.JustPressed)
            {
                if (Math.Abs(Main.time - Bismuth.pressedToggleExperiencePanelHotKeyTime) > 20)
                {
                    Bismuth.pressedToggleExperiencePanelHotKeyTime = Main.time;
                    Levels.HotKeyPressed2();
                }
            }
            if (Bismuth.FirstSkillActivate.JustPressed)
            {
                if (buffIdx < 0)
                {
                    if (Bismuthplayer.skill4lvl > 0 && Bismuthplayer.skill5lvl == 0)
                    {
                        player.AddBuff(ModContent.BuffType<SteelSkin>(), 1800);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 9000);
                    }
                    if (Bismuthplayer.skill5lvl > 0 && Bismuthplayer.skill6lvl == 0 && Bismuthplayer.skill7lvl == 0)
                    {
                        player.AddBuff(ModContent.BuffType<SteelSkin>(), 2100);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 8100);
                    }
                    if (Bismuthplayer.skill6lvl > 0 && Bismuthplayer.skill7lvl == 0)
                    {
                        player.AddBuff(ModContent.BuffType<SteelSkin>(), 2100);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 7200);
                    }
                    if (Bismuthplayer.skill7lvl > 0 && Bismuthplayer.skill6lvl == 0)
                    {
                        player.AddBuff(ModContent.BuffType<SteelSkin>(), 1500);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 7200);
                    }
                    if (Bismuthplayer.skill22lvl > 0 && Bismuthplayer.skill23lvl == 0)
                    {
                        player.AddBuff(ModContent.BuffType<Rage>(), 4800);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 36000);
                    }
                    if (Bismuthplayer.skill23lvl > 0 && Bismuthplayer.skill24lvl == 0)
                    {
                        player.AddBuff(ModContent.BuffType<Rage>(), 5400);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 36000);
                    }
                    if (Bismuthplayer.skill24lvl > 0)
                    {
                        player.AddBuff(ModContent.BuffType<Rage>(), 4200);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 36000);
                    }
                    if (Bismuthplayer.skill39lvl > 0 && Bismuthplayer.skill40lvl == 0)
                    {
                        player.AddBuff(ModContent.BuffType<Crowd>(), 2700);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 10800);
                    }
                    if (Bismuthplayer.skill40lvl > 0)
                    {
                        player.AddBuff(ModContent.BuffType<Crowd>(), 3300);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 9000);
                    }
                    if (Bismuthplayer.skill51lvl > 0)
                    {
                        player.AddBuff(ModContent.BuffType<Converter>(), 2700);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 13200);
                    }
                    if (Bismuthplayer.skill69lvl > 0 && Bismuthplayer.skill70lvl == 0)
                    {
                        player.AddBuff(BuffID.NightOwl, 14400);
                        player.AddBuff(BuffID.Hunter, 14400);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 28800);
                    }
                    if (Bismuthplayer.skill70lvl > 0 && Bismuthplayer.skill71lvl == 0)
                    {
                        player.AddBuff(BuffID.NightOwl, 21600);
                        player.AddBuff(BuffID.Hunter, 21600);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 28800);
                    }
                    if (Bismuthplayer.skill71lvl > 0)
                    {
                        player.AddBuff(BuffID.NightOwl, 21600);
                        player.AddBuff(BuffID.Hunter, 21600);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 28800);
                    }
                    if (Bismuthplayer.skill94lvl > 0 && Bismuthplayer.skill95lvl == 0)
                    {
                        player.AddBuff(ModContent.BuffType<StunningWeapons>(), 1500);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 12000);
                    }
                    if (Bismuthplayer.skill95lvl > 0 && Bismuthplayer.skill96lvl == 0)
                    {
                        player.AddBuff(ModContent.BuffType<StunningWeapons>(), 1500);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 10800);
                    }
                    if (Bismuthplayer.skill96lvl > 0)
                    {
                        player.AddBuff(ModContent.BuffType<StunningWeapons>(), 1500);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 9600);
                    }
                    if (Bismuthplayer.skill106lvl > 0 && Bismuthplayer.skill107lvl == 0)
                    {
                        player.AddBuff(ModContent.BuffType<EnergyShield>(), 3600);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 16200);
                    }
                    if (Bismuthplayer.skill107lvl > 0 && Bismuthplayer.skill108lvl == 0)
                    {
                        player.AddBuff(ModContent.BuffType<EnergyShield>(), 3600);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 14400);
                    }
                    if (Bismuthplayer.skill108lvl > 0)
                    {
                        player.AddBuff(ModContent.BuffType<EnergyShield>(), 3600);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 14400);
                    }
                    if (Bismuthplayer.skill124lvl > 0 && Bismuthplayer.skill125lvl == 0)
                    {
                        player.AddBuff(ModContent.BuffType<EthernalProjectiles>(), 3600);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 16200);
                    }
                    if (Bismuthplayer.skill125lvl > 0 && Bismuthplayer.skill126lvl == 0)
                    {
                        player.AddBuff(ModContent.BuffType<EthernalProjectiles>(), 5400);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 18000);
                    }
                    if (Bismuthplayer.skill126lvl > 0)
                    {
                        player.AddBuff(ModContent.BuffType<EthernalProjectiles>(), 7200);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 21600);
                    }
                    if (Bismuthplayer.skill127lvl > 0 && Bismuthplayer.skill128lvl == 0)
                    {
                        player.AddBuff(ModContent.BuffType<Motionless>(), 720);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 9000);
                    }
                    if (Bismuthplayer.skill128lvl > 0 && Bismuthplayer.skill129lvl == 0)
                    {
                        player.AddBuff(ModContent.BuffType<Motionless>(), 1200);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 9000);
                    }
                    if (Bismuthplayer.skill129lvl > 0)
                    {
                        player.AddBuff(ModContent.BuffType<Motionless>(), 1600);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 9000);
                    }
                }
            }
            if (Bismuth.TeleportActivate.JustPressed)
            {
                if (buffIdx < 0)
                {
                    if (Bismuthplayer.skill14lvl > 0 && Bismuthplayer.skill15lvl == 0)
                    {
                        player.AddBuff(ModContent.BuffType<Invulnerability>(), 420);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 7200);
                    }
                    if (Bismuthplayer.skill15lvl > 0)
                    {
                        player.AddBuff(ModContent.BuffType<Invulnerability>(), 720);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 6000);
                    }
                    if (Bismuthplayer.skill33lvl > 0 && Bismuthplayer.skill34lvl == 0)
                    {
                        player.AddBuff(ModContent.BuffType<MoreEnergy>(), 600);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 7800);
                    }
                    if (Bismuthplayer.skill34lvl > 0)
                    {
                        player.AddBuff(ModContent.BuffType<MoreEnergy>(), 840);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 6600);
                    }
                    if (Bismuthplayer.skill61lvl > 0 && Bismuthplayer.skill62lvl == 0)
                    {
                        player.AddBuff(ModContent.BuffType<NoLimit>(), 1080);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 14400);
                    }
                    if (Bismuthplayer.skill62lvl > 0)
                    {
                        player.AddBuff(ModContent.BuffType<NoLimit>(), 1500);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 13200);
                    }
                    if (Bismuthplayer.skill86lvl > 0 && Bismuthplayer.skill87lvl == 0)
                    {
                        player.AddBuff(ModContent.BuffType<Stealth>(), 900);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 10800);
                    }
                    if (Bismuthplayer.skill87lvl > 0 && Bismuthplayer.skill88lvl == 0)
                    {
                        player.AddBuff(ModContent.BuffType<Stealth>(), 1200);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 10800);
                    }
                    if (Bismuthplayer.skill88lvl > 0)
                    {
                        player.AddBuff(ModContent.BuffType<Stealth>(), 1500);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 10800);
                    }
                    if (Bismuthplayer.skill89lvl > 0)
                    {
                        player.AddBuff(ModContent.BuffType<DeathWish>(), 2880);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 10800);
                    }
                    if (Bismuthplayer.skill120lvl > 0)
                    {
                        player.AddBuff(ModContent.BuffType<AutoTargeting>(), 5400);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 21600);
                    }
                    if (Bismuthplayer.skill138lvl > 0 || Bismuthplayer.skill141lvl > 0)
                    {
                        Projectile.NewProjectile(Main.LocalPlayer.GetSource_FromThis(), Main.mouseX, Main.mouseY, 0f, 0f, ModContent.ProjectileType<MeteorBase>(), 0, 0f);
                        player.AddBuff(ModContent.BuffType<SkillCooldown>(), 3600);
                    }
                }
            }
            if (Bismuth.ToggleExpPanelHotKey.JustPressed)
            {
                if (Bismuthplayer.skill72lvl > 0 || Bismuthplayer.skill73lvl > 0 || Bismuthplayer.skill75lvl > 0)
                {
                    Bismuthplayer.TeleportPlayer();
                }
            }
        }
    }
}
