using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;
using Bismuth.Content.Buffs;
using Bismuth.Content.Items.Accessories;
using Bismuth.Content.Items.Armor;

namespace Bismuth.Utilities.Global
{
    public class SkillsGlobalItems : GlobalItem
    {
        public static int[] VanillaMeleePrefixes = new int[16] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 81 };
        public static int[] VanillaRangedPrefixes = new int[12] { 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 58, 82 };
        public static int[] VanillaMagicPrefixes = new int[12] { 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 52, 83 };
        public static int[] VanillaUniversalPrefixes = new int[14] { 36, 37, 38, 39, 40, 41, 53, 54, 55, 56, 57, 59, 60, 61 };
        public static int[] VanillaCommonPrefixes = new int[10] { 42, 43, 44, 45, 46, 47, 48, 49, 50, 51 };
        public static int[] VanillaAccessoriesPrefixes = new int[19] { 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80 };
        public override int ChoosePrefix(Item item, UnifiedRandom rand)
        {
            if (item.ModItem is AssassinItem)
                return rand.Next(1, 1000);
            return base.ChoosePrefix(item, rand);
        }
        public override float UseTimeMultiplier(Item item, Player player)
        {
            float bonus = 0;
            if (item.useTime <= 1 || item.useAnimation <= 2)
            {
                return 1f;
            }
            float num = 1f;
            float num2 = 1f;
            if (item.ModItem != null)
            {
                num2 = (num = item.ModItem.UseTimeMultiplier(player));
            }
            if (player.GetModPlayer<BismuthPlayer>().IsEquippedBerserksRing)
            {
                bonus += 0.3f;
            }
            if (player.armor[0].type == ModContent.ItemType<ScalyHelmet>())
            {
                bonus += 0.05f;
            }
            if (player.GetModPlayer<BismuthPlayer>().skill101lvl > 0 && player.inventory[player.selectedItem].CountsAsClass(DamageClass.Ranged))
            {
                bonus += 0.05f;
            }
            if (player.GetModPlayer<BismuthPlayer>().skill101lvl > 1 && player.inventory[player.selectedItem].CountsAsClass(DamageClass.Ranged))
            {
                bonus += 0.1f;
            }
            if (player.GetModPlayer<BismuthPlayer>().skill101lvl > 2 && player.inventory[player.selectedItem].CountsAsClass(DamageClass.Ranged))
            {
                bonus += 0.15f;
            }
            num *= (1f + bonus);
            if (num <= 0f)
            {
                return 1f;
            }
            if ((float)item.useAnimation / num < 3f || (float)item.useTime / num < 2f)
            {
                if (item.useAnimation - 1 <= item.useTime)
                {
                    num = (float)item.useAnimation / 3f;
                }
                else
                {
                    num = (float)item.useTime / 2f;
                }
            }
            return num / num2;

        }
        public override bool Shoot(Item item, Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 speed, int type, int damage, float knockback)
        {
            #region skill111
            if (player.GetModPlayer<BismuthPlayer>().skill111lvl > 0)
            {
                if (type == ProjectileID.BeeArrow || type == ProjectileID.BoneArrow || type == ProjectileID.ChlorophyteArrow || type == ProjectileID.CursedArrow || type == ProjectileID.FireArrow || type == ProjectileID.FlamingArrow || type == ProjectileID.FrostArrow || type == ProjectileID.FrostburnArrow || type == ProjectileID.HellfireArrow || type == ProjectileID.HolyArrow || type == ProjectileID.IchorArrow || type == ProjectileID.JestersArrow || type == ProjectileID.MoonlordArrow || type == ProjectileID.PhantasmArrow || type == ProjectileID.ShadowFlameArrow || type == ProjectileID.UnholyArrow || type == ProjectileID.VenomArrow || type == ProjectileID.WoodenArrowFriendly)
                {
                    if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill114lvl == 0)
                    {
                        Projectile.NewProjectile(source, position, new Vector2(speed.X + 1, speed.Y - 1), type, damage, knockback, Main.myPlayer);
                    }
                    if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill114lvl == 1)
                    {
                        Projectile.NewProjectile(source, position, new Vector2((speed.X + 1) * 1.15f, (speed.Y - 1) * 1.15f), type, damage, knockback, Main.myPlayer);
                    }
                    if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill114lvl == 2)
                    {
                        Projectile.NewProjectile(source, position, new Vector2((speed.X + 1) * 1.35f, (speed.Y - 1) * 1.35f), type, damage, knockback, Main.myPlayer);

                    }
                    if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill114lvl == 3)
                    {
                        Projectile.NewProjectile(source, position, new Vector2((speed.X + 1) * 1.6f, (speed.Y - 1) * 1.6f), type, damage, knockback, Main.myPlayer);
                    }
                }
            }
            #endregion
            #region skill114
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill114lvl == 1)
            {
                if (type == ProjectileID.BeeArrow || type == ProjectileID.BoneArrow || type == ProjectileID.ChlorophyteArrow || type == ProjectileID.CursedArrow || type == ProjectileID.FireArrow || type == ProjectileID.FlamingArrow || type == ProjectileID.FrostArrow || type == ProjectileID.FrostburnArrow || type == ProjectileID.HellfireArrow || type == ProjectileID.HolyArrow || type == ProjectileID.IchorArrow || type == ProjectileID.JestersArrow || type == ProjectileID.MoonlordArrow || type == ProjectileID.PhantasmArrow || type == ProjectileID.ShadowFlameArrow || type == ProjectileID.UnholyArrow || type == ProjectileID.VenomArrow || type == ProjectileID.WoodenArrowFriendly)
                {
                    speed.X *= 1.15f;
                    speed.Y *= 1.15f;
                }
            }
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill114lvl == 2)
            {
                if (type == ProjectileID.BeeArrow || type == ProjectileID.BoneArrow || type == ProjectileID.ChlorophyteArrow || type == ProjectileID.CursedArrow || type == ProjectileID.FireArrow || type == ProjectileID.FlamingArrow || type == ProjectileID.FrostArrow || type == ProjectileID.FrostburnArrow || type == ProjectileID.HellfireArrow || type == ProjectileID.HolyArrow || type == ProjectileID.IchorArrow || type == ProjectileID.JestersArrow || type == ProjectileID.MoonlordArrow || type == ProjectileID.PhantasmArrow || type == ProjectileID.ShadowFlameArrow || type == ProjectileID.UnholyArrow || type == ProjectileID.VenomArrow || type == ProjectileID.WoodenArrowFriendly)
                {
                    speed.X *= 1.35f;
                    speed.Y *= 1.35f;
                }
            }
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill114lvl == 3)
            {
                if (type == ProjectileID.BeeArrow || type == ProjectileID.BoneArrow || type == ProjectileID.ChlorophyteArrow || type == ProjectileID.CursedArrow || type == ProjectileID.FireArrow || type == ProjectileID.FlamingArrow || type == ProjectileID.FrostArrow || type == ProjectileID.FrostburnArrow || type == ProjectileID.HellfireArrow || type == ProjectileID.HolyArrow || type == ProjectileID.IchorArrow || type == ProjectileID.JestersArrow || type == ProjectileID.MoonlordArrow || type == ProjectileID.PhantasmArrow || type == ProjectileID.ShadowFlameArrow || type == ProjectileID.UnholyArrow || type == ProjectileID.VenomArrow || type == ProjectileID.WoodenArrowFriendly)
                {
                    speed.X *= 1.6f;
                    speed.Y *= 1.6f;
                }
            }
            #endregion
            #region QuiverMoreArrow
            if (player.GetModPlayer<BismuthPlayer>().IsEquippedQuiver)
            {
                if (type == ProjectileID.BeeArrow || type == ProjectileID.BoneArrow || type == ProjectileID.ChlorophyteArrow || type == ProjectileID.CursedArrow || type == ProjectileID.FireArrow || type == ProjectileID.FlamingArrow || type == ProjectileID.FrostArrow || type == ProjectileID.FrostburnArrow || type == ProjectileID.HellfireArrow || type == ProjectileID.HolyArrow || type == ProjectileID.IchorArrow || type == ProjectileID.JestersArrow || type == ProjectileID.MoonlordArrow || type == ProjectileID.PhantasmArrow || type == ProjectileID.ShadowFlameArrow || type == ProjectileID.UnholyArrow || type == ProjectileID.VenomArrow || type == ProjectileID.WoodenArrowFriendly)
                {
                    if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill114lvl == 0)
                    {
                        Projectile.NewProjectile(source, position, new Vector2(speed.X + 1, speed.Y + 1), type, damage, knockback, Main.myPlayer);
                    }
                    if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill114lvl == 1)
                    {
                        Projectile.NewProjectile(source, position, new Vector2((speed.X + 1) * 1.15f, (speed.Y + 1) * 1.15f), type, damage, knockback, Main.myPlayer);
                    }
                    if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill114lvl == 2)
                    {
                        Projectile.NewProjectile(source, position, new Vector2((speed.X + 1) * 1.35f, (speed.Y + 1) * 1.35f), type, damage, knockback, Main.myPlayer);
                    }
                    if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill114lvl == 3)
                    {
                        Projectile.NewProjectile(source, position, new Vector2((speed.X + 1) * 1.6f, (speed.Y + 1) * 1.6f), type, damage, knockback, Main.myPlayer);
                    }
                }
            }
            #endregion
            #region TribalQuiverMoreArrow
            if (player.GetModPlayer<BismuthPlayer>().IsEquippedTribalQuiver && Main.rand.Next(0, 20) < 3)
            {
                if (type == ProjectileID.BeeArrow || type == ProjectileID.BoneArrow || type == ProjectileID.ChlorophyteArrow || type == ProjectileID.CursedArrow || type == ProjectileID.FireArrow || type == ProjectileID.FlamingArrow || type == ProjectileID.FrostArrow || type == ProjectileID.FrostburnArrow || type == ProjectileID.HellfireArrow || type == ProjectileID.HolyArrow || type == ProjectileID.IchorArrow || type == ProjectileID.JestersArrow || type == ProjectileID.MoonlordArrow || type == ProjectileID.PhantasmArrow || type == ProjectileID.ShadowFlameArrow || type == ProjectileID.UnholyArrow || type == ProjectileID.VenomArrow || type == ProjectileID.WoodenArrowFriendly)
                {
                    if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill114lvl == 0)
                    {
                        Projectile.NewProjectile(source, position, new Vector2(speed.X - 1, speed.Y - 1), type, damage, knockback, Main.myPlayer);
                    }
                    if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill114lvl == 1)
                    {
                        Projectile.NewProjectile(source, position, new Vector2((speed.X - 1) * 1.15f, (speed.Y - 1) * 1.15f), type, damage, knockback, Main.myPlayer);
                    }
                    if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill114lvl == 2)
                    {
                        Projectile.NewProjectile(source, position, new Vector2((speed.X - 1) * 1.35f, (speed.Y - 1) * 1.35f), type, damage, knockback, Main.myPlayer);
                    }
                    if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill114lvl == 3)
                    {
                        Projectile.NewProjectile(source, position, new Vector2((speed.X - 1) * 1.6f, (speed.Y - 1) * 1.6f), type, damage, knockback, Main.myPlayer);
                    }
                }
            }
            #endregion           
            return true;
        }
        public override bool? UseItem(Item item, Player player)
        {
            bool isequippedamulet = false;
            for (int k = 3; k < 8 + player.extraAccessorySlots; k++)
            {
                if (player.armor[k].type == ModContent.ItemType<TransmutationAmulet>())
                {
                    isequippedamulet = true;
                    break;
                }
            }
            if (item.type == ItemID.LesserHealingPotion || item.type == ItemID.HealingPotion || item.type == ItemID.GreaterHealingPotion || item.type == ItemID.SuperHealingPotion)
            {
                if (player.GetModPlayer<BismuthPlayer>().KilledBossesCount >= 4 && player.GetModPlayer<BismuthPlayer>().IsEquippedAthenasShield)
                {
                    item.healLife = (int)(item.healLife * 1.3f);
                }
                if (player.GetModPlayer<BismuthPlayer>().IsEquippedBelt)
                    item.healLife = (int)(item.healLife * 1.2f);
            }
            if (item.type == ItemID.LesserManaPotion || item.type == ItemID.ManaPotion || item.type == ItemID.GreaterManaPotion || item.type == ItemID.SuperManaPotion)
            {
                if (player.GetModPlayer<BismuthPlayer>().IsEquippedBelt)
                    item.healMana = (int)(item.healMana * 1.2f);
            }
            if (player.GetModPlayer<BismuthPlayer>().skill134lvl > 0)
            {
                if (item.type == ItemID.LesserHealingPotion || item.type == ItemID.HealingPotion || item.type == ItemID.GreaterHealingPotion || item.type == ItemID.SuperHealingPotion)
                {
                    item.healLife = (int)(item.healLife * 1.25f);
                }
                if (item.type == ItemID.LesserManaPotion || item.type == ItemID.ManaPotion || item.type == ItemID.GreaterManaPotion || item.type == ItemID.SuperManaPotion)
                {
                    item.healMana = (int)(item.healMana * 1.25f);
                }
            }
            if (item.type == ItemID.ManaRegenerationPotion || item.type == ItemID.MagicPowerPotion || item.type == ItemID.InvisibilityPotion || item.type == ItemID.ThornsPotion || item.type == ItemID.GillsPotion || item.type == ItemID.GravitationPotion || item.type == ItemID.ObsidianSkinPotion || item.type == ItemID.NightOwlPotion || item.type == ItemID.SwiftnessPotion || item.type == ItemID.ArcheryPotion || item.type == ItemID.FeatherfallPotion || item.type == ItemID.IronskinPotion || item.type == ItemID.WaterWalkingPotion || item.type == ItemID.ShinePotion || item.type == ItemID.HunterPotion || item.type == ItemID.MiningPotion || item.type == ItemID.RegenerationPotion || item.type == ItemID.BattlePotion || item.type == ItemID.WarmthPotion || item.type == ItemID.HeartreachPotion || item.type == ItemID.LifeforcePotion || item.type == ItemID.EndurancePotion || item.type == ItemID.FishingPotion || item.type == ItemID.CratePotion || item.type == ItemID.SonarPotion || item.type == ItemID.SummoningPotion || item.type == ItemID.SpelunkerPotion || item.type == ItemID.AmmoReservationPotion || item.type == 2329 || item.type == ItemID.CalmingPotion || item.type == ItemID.BuilderPotion || item.type == ItemID.RagePotion || item.type == ItemID.WrathPotion || item.type == ItemID.TitanPotion || item.type == ItemID.InfernoPotion || item.type == ItemID.FlipperPotion)
            {
                if (player.GetModPlayer<BismuthPlayer>().IsEquippedBelt)
                {
                    item.buffTime = (int)(item.buffTime * 1.15f);
                }
                if (isequippedamulet)
                {
                    item.buffTime = (int)(item.buffTime * 1.1f);
                    item.healMana = player.statManaMax2 / 10;
                }
                if (player.GetModPlayer<BismuthPlayer>().skill35lvl > 0)
                    player.AddBuff(ModContent.BuffType<InvigoratingDrink>(), 900);
            }
            if (item.type == ItemID.BottledWater)
                Main.LocalPlayer.GetModPlayer<BismuthPlayer>().Wetness += 10;
            return base.UseItem(item, player);
        }
        public override bool CanUseItem(Item item, Player player)
        {
            if (item.type == ItemID.RodofDiscord || item.type == ItemID.BlueTorch || item.type == ItemID.BoneTorch || item.type == ItemID.CursedTorch || item.type == ItemID.DemonTorch || item.type == ItemID.GreenTorch || item.type == ItemID.IceTorch || item.type == ItemID.IchorTorch || item.type == ItemID.OrangeTorch || item.type == ItemID.PurpleTorch || item.type == ItemID.RainbowTorch || item.type == ItemID.PinkTorch || item.type == ItemID.RedTorch || item.type == ItemID.TikiTorch || item.type == ItemID.Torch || item.type == ItemID.UltrabrightTorch || item.type == ItemID.WhiteTorch || item.type == ItemID.YellowTorch || item.type == ItemID.FlareGun)
            {
                if (player.FindBuffIndex(ModContent.BuffType<FearOfMaze>()) != -1)
                    return false;
            }
            if (item.healMana > 0 && player.GetModPlayer<BismuthPlayer>().IsEquippedGoldenRune)
                return false;
            return base.CanUseItem(item, player);
        }
    }
}