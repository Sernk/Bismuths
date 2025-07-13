using Bismuth.Content.Buffs;
using Bismuth.Content.Items.Accessories;
using Bismuth.Content.Items.Materials;
using Bismuth.Content.Items.Weapons.Magical;
using Bismuth.Content.Items.Weapons.Melee;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace Bismuth.Utilities.Global
{
    public class GlobalNPCs : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public bool stundef = false;
        public override void ResetEffects(NPC npc)
        {
            stundef = false;
        }
        public override void EditSpawnRate(Player player, ref int spawnRate, ref int maxSpawns)
        {
            if (player.HasBuff(ModContent.BuffType<AuraOfEmpire>()))
            {
                spawnRate = 0;
                maxSpawns = 0;
            }
            if (player.HasBuff(ModContent.BuffType<FearOfMaze>()))
            {
                spawnRate = 0;
                maxSpawns = 0;
            }
        }
        bool flag = false;
        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (stundef)
            {
                if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill94lvl > 0 && Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill95lvl == 0)
                {
                    if (!flag)
                    {
                        flag = true;
                        npc.defense *= 3;
                    }
                }
                else if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill95lvl > 0 && Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill96lvl == 0)
                {
                    if (!flag)
                    {
                        flag = true;
                        npc.defense = (int)(npc.defense * 1.5);
                    }
                }
            }
            else if (flag)
            {
                if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill94lvl > 0 && Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill95lvl == 0)
                {
                   
                        npc.defense /= 3;                   
                }
                else if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill95lvl > 0 && Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().skill96lvl == 0)
                {

                    npc.defense = (int)(npc.defense / 1.5);
                }
                flag = false;
            }
        }
        public override void ModifyActiveShop(NPC npc, string shopName, Item[] items)
        {
            /// <summary>
            /// <примешено в cref="Shop"/>
            /// </summary>
        }
        public override void ModifyHitNPC(NPC npc, NPC target, ref NPC.HitModifiers modifiers)
        {
            // код возможно не провальные 
            // Main.npc[j].StrikeNPC() я не знал как его исправить
            float damage = modifiers.SourceDamage.Additive;
            var damages = 20f * Main.LocalPlayer.GetDamage(DamageClass.Generic);
            var knockBack = 1f;
            var direction = npc.direction;

            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().EmpathyNPCs.Count > 0)
            {
                if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().EmpathyNPCs.Contains(target))
                {
                    damage /= (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().EmpathyNPCs.Count + 1);
                    Main.player[Main.myPlayer].Hurt(PlayerDeathReason.ByCustomReason(Main.player[Main.myPlayer].name + Language.GetTextValue("Mods.Bismuth.DeathReason4")), (int)damage / (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().EmpathyNPCs.Count + 1), 1);
                    for (int j = 0; j < Main.npc.Length; j++)
                    {
                        NPC netednpc = Main.npc[j];
                        if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().EmpathyNPCs.Contains(netednpc) && netednpc != target)
                        {
                            npc.StrikeNPC(new NPC.HitInfo()
                            {
                                Damage = (int)damages.ApplyTo(1) / (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().EmpathyNPCs.Count + 1),
                                Knockback = knockBack,
                                HitDirection = direction,
                                Crit = Main.rand.Next(2) == 0
                            });
                        }
                    }
                }
            }
        }
        public override void ModifyHitByProjectile(NPC npc, Projectile projectile, ref NPC.HitModifiers modifiers)
        {
            float damage = modifiers.SourceDamage.Additive;

            var damages = 20f * Main.LocalPlayer.GetDamage(DamageClass.Generic);
            var knockBack = 1f;
            var direction = npc.direction;
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().EmpathyNPCs.Count > 0)
            {
                if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().EmpathyNPCs.Contains(npc))
                {
                    damage /= (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().EmpathyNPCs.Count + 1);
                    Main.player[Main.myPlayer].Hurt(PlayerDeathReason.ByCustomReason(Main.player[Main.myPlayer].name + " was the victim of a broken connection"), (int)damage / (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().EmpathyNPCs.Count + 1), 1);
                    for (int j = 0; j < Main.npc.Length; j++)
                    {
                        NPC netednpc = Main.npc[j];
                        if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().EmpathyNPCs.Contains(netednpc) && netednpc != npc)
                        {
                            npc.StrikeNPC(new NPC.HitInfo()
                            {
                                Damage = (int)damages.ApplyTo(1) / (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().EmpathyNPCs.Count + 1),
                                Knockback = knockBack,
                                HitDirection = direction,
                                Crit = Main.rand.Next(2) == 0
                            });
                        }
                    }
                }
                //   return false;
            }
        }
        public override void OnKill(NPC npc)
        {
            Player player = Main.player[Main.myPlayer];
            var source = npc.GetSource_FromThis();
            if (UtilsAI.CheckEmptyPlaceWithTiles(npc.position + new Vector2(npc.width / 2 - 8, npc.height - 8)) && !npc.noGravity && player.GetModPlayer<BismuthPlayer>().BOTDPlaces.Count < 6)
            {
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (player.inventory[num66].type == ModContent.ItemType<BookOfTheDead>() && player.inventory[num66].stack > 0)
                    {
                        player.GetModPlayer<BismuthPlayer>().BOTDPlaces.Add(npc.position + new Vector2(npc.width / 2, npc.height));
                        break;
                    }
                }
            }
            if (player.inventory[player.selectedItem].type == ModContent.ItemType<SoulScythe>())
            {
                if (npc.type == NPCID.GiantWormBody || npc.type == NPCID.GiantWormTail || npc.type == NPCID.GiantWormHead)

                {
                    Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<EarthEssence>());
                    player.GetModPlayer<BismuthPlayer>().SoulScytheCharge--;
                }
                if (npc.type == NPCID.DiggerBody || npc.type == NPCID.DiggerHead || npc.type == NPCID.DiggerTail)

                {
                    Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<EarthEssence>());
                    player.GetModPlayer<BismuthPlayer>().SoulScytheCharge--;
                }
                if (npc.type == NPCID.TombCrawlerBody || npc.type == NPCID.TombCrawlerHead || npc.type == NPCID.TombCrawlerTail)

                {
                    Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<EarthEssence>());
                    player.GetModPlayer<BismuthPlayer>().SoulScytheCharge--;
                }
                if (npc.type == NPCID.ManEater)

                {
                    Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<EarthEssence>());
                    player.GetModPlayer<BismuthPlayer>().SoulScytheCharge--;
                }
                if (npc.type == NPCID.Harpy)
                {
                    Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<AirEssence>());
                    player.GetModPlayer<BismuthPlayer>().SoulScytheCharge--;
                }
                if (npc.type == NPCID.WyvernBody || npc.type == NPCID.WyvernBody2 || npc.type == NPCID.WyvernBody3 || npc.type == NPCID.WyvernHead || npc.type == NPCID.WyvernLegs || npc.type == NPCID.WyvernTail)
                {
                    Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<AirEssence>());
                    player.GetModPlayer<BismuthPlayer>().SoulScytheCharge--;
                }
                if (npc.type == NPCID.AngryNimbus)

                {
                    Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<AirEssence>());
                    player.GetModPlayer<BismuthPlayer>().SoulScytheCharge--;
                }
                if (npc.type == NPCID.FireImp)

                {
                    Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<FireEssence>());
                    player.GetModPlayer<BismuthPlayer>().SoulScytheCharge--;
                }
                if (npc.type == NPCID.LavaSlime)

                {
                    Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<FireEssence>());
                    player.GetModPlayer<BismuthPlayer>().SoulScytheCharge--;
                }
                if (npc.type == NPCID.Demon)

                {
                    Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<FireEssence>());
                    player.GetModPlayer<BismuthPlayer>().SoulScytheCharge--;
                }
                if (npc.type == NPCID.VoodooDemon)

                {
                    Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<FireEssence>());
                    player.GetModPlayer<BismuthPlayer>().SoulScytheCharge--;
                }
                if (npc.type == NPCID.Shark)

                {
                    Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<WaterEssence>());
                    player.GetModPlayer<BismuthPlayer>().SoulScytheCharge--;
                }
                if (npc.type == NPCID.GreenJellyfish)

                {
                    Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<WaterEssence>());
                    player.GetModPlayer<BismuthPlayer>().SoulScytheCharge--;
                }
                if (npc.type == NPCID.BlueJellyfish)

                {
                    Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<WaterEssence>());
                    player.GetModPlayer<BismuthPlayer>().SoulScytheCharge--;
                }
                if (npc.type == NPCID.PinkJellyfish)

                {
                    Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<WaterEssence>());
                    player.GetModPlayer<BismuthPlayer>().SoulScytheCharge--;
                }
                if (npc.type == NPCID.Piranha)

                {
                    Item.NewItem(source, (int)npc.position.X, (int)npc.position.Y, npc.width, npc.height, ModContent.ItemType<WaterEssence>());
                    player.GetModPlayer<BismuthPlayer>().SoulScytheCharge--;
                }
            }
            if (player.GetModPlayer<BismuthPlayer>().skill84lvl > 0 && !Main.dayTime)
                npc.value *= 1.4f;
            if (player.GetModPlayer<BismuthPlayer>().skill98lvl > 0)
                npc.value *= 1.05f;
            if (player.GetModPlayer<BismuthPlayer>().skill98lvl > 1)
                npc.value *= 1.05f;
            if (player.GetModPlayer<BismuthPlayer>().skill98lvl > 2)
                npc.value *= 1.1f;
            for (int k = 3; k < 8 + player.extraAccessorySlots; k++)
            {
                if (player.armor[k].type == ModContent.ItemType<MidasGlove>())
                {
                    npc.value *= 1.3f;
                }
            }
        }   
    }
}