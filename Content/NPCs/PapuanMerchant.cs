﻿using Bismuth.Content.Items.Armor;
using Bismuth.Content.Items.Materials;
using Bismuth.Content.Items.Tools;
using Bismuth.Content.Items.Weapons.Melee;
using Bismuth.Content.Items.Weapons.Throwing;
using Bismuth.Content.Projectiles;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.NPCs
{
    [AutoloadHead]
    public class PapuanMerchant : ModNPC
    {
        public override void Load()
        {
            _ = this.GetLocalization("Say").Value; // "At "
            _ = this.GetLocalization("Say1").Value; // during Halloween you can buy fashionable Dryad's panties, but I can sell it to you always(not yet). Took the hint?
            _ = this.GetLocalization("Say2").Value; // I think,
            _ = this.GetLocalization("Say3").Value; // will be happy, when he will see this hammerhead fish.
            _ = this.GetLocalization("Say4").Value; // Ones I killed 5 sharks with only one spoon.
            _ = this.GetLocalization("Say5").Value; // I would have made you a discount, but the fish was tasteless, so no
            _ = this.GetLocalization("Say6").Value; // I choose pointy peakes.
        }
        public override string Texture
        {
            get
            {
                return "Bismuth/Content/NPCs/PapuanMerchant";
            }
        }
        public override void SetStaticDefaults()
        {
            Main.npcFrameCount[NPC.type] = 25;
            NPCID.Sets.ExtraFramesCount[NPC.type] = 5;
            NPCID.Sets.AttackFrameCount[NPC.type] = 4;
            NPCID.Sets.DangerDetectRange[NPC.type] = 500;
            NPCID.Sets.AttackType[NPC.type] = 0;
            NPCID.Sets.AttackTime[NPC.type] = 30;
            NPCID.Sets.AttackAverageChance[NPC.type] = 30;
            NPCID.Sets.NoTownNPCHappiness[NPC.type] = true;
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 28;
            NPC.height = 48;
            NPC.aiStyle = 7;
            NPC.damage = 55;
            NPC.defense = 15;
            NPC.lifeMax = 250;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0.5f;
            AnimationType = NPCID.Demolitionist;
        }
        public override bool CanTownNPCSpawn(int numTownNPCs)
        {
            for (int i = 0; i < 255; i++)
            {
                Player player = Main.player[i];
                if (player.active)
                {
                    for (int j = 0; j < player.inventory.Length; j++)
                    {
                        if (player.inventory[j].type == ModContent.ItemType<RuneEssence>())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        public override List<string> SetNPCNameList()
        {
            switch (WorldGen.genRand.Next(4))
            {
                case 0:
                    return new List<string>
                    {
                        this.GetLocalizedValue("Name.Gagini"),
                    };
                case 1:
                    return new List<string>
                    {
                        this.GetLocalizedValue("Name.Budd"),
                    };
                case 2:
                    return new List<string>
                    {
                        this.GetLocalizedValue("Name.Butannaziba"),
                    };
                case 3:
                    return new List<string>
                    {
                        this.GetLocalizedValue("Name.Mazozi"),
                    };
                case 4:
                    return new List<string>
                    {
                        this.GetLocalizedValue("Name.Nkemdilim"),
                    };
                case 5:
                    return new List<string>
                    {
                        this.GetLocalizedValue("Name.Olanreuodzhu"),
                    };
                case 6:
                    return new List<string>
                    {
                        this.GetLocalizedValue("Name.Syed"),
                    };
                case 7:
                    return new List<string>
                    {
                        this.GetLocalizedValue("Name.Tafari"),
                    };
                case 8:
                    return new List<string>
                    {
                        this.GetLocalizedValue("Name.Chidzhenda"),
                    };
                default:
                    return new List<string>                         
                    {
                        this.GetLocalizedValue("Name.Jango"),
                    };
            }
        }
        public override string GetChat()
        {
            string Say0 = this.GetLocalization("Say").Value;
            string Say1 = this.GetLocalization("Say1").Value;
            string Say2 = this.GetLocalization("Say2").Value;
            string Say3 = this.GetLocalization("Say3").Value;
            string Say4 = this.GetLocalization("Say4").Value;
            string Say5 = this.GetLocalization("Say5").Value;
            string Say6 = this.GetLocalization("Say6").Value;

            int Angler = NPC.FindFirstNPC(NPCID.Angler);
            int Armsdealer = NPC.FindFirstNPC(NPCID.ArmsDealer);

            string armsdealerName = Armsdealer != -1 ? Main.npc[Armsdealer].GivenName : "";
            string anglerName = Angler != -1 ? Main.npc[Angler].GivenName : "";

            string SayFull = $"{Say0} {armsdealerName} {Say1}";
            string SayFull1 = $"{Say2} {anglerName} {Say3}";

            if (Armsdealer >= 0 && Main.rand.Next(5) == 0)
            {
                return SayFull;
            }
            if (Angler >= 0 && Main.rand.Next(5) == 0)
            {
                return SayFull1;
            }
            switch (Main.rand.Next(3))
            {
                case 0: return Say4;
                case 1: return Say5;
                default: return Say6;
            }
        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Lang.inter[28].Value;
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            if (firstButton)
            {
                shopName = "PapuanMerchantShop";
            }
        }
        public override void AddShops()
        {
            var HardMode = new Condition("KilledEoC", () => Main.hardMode);

            NPCShop shop = new(Type, "PapuanMerchantShop");

            shop.Add(ModContent.ItemType<RuneRim>());
            shop.Add(ModContent.ItemType<SharkKnife>());
            shop.Add(ModContent.ItemType<SharkJavelin>());
            shop.Add(ModContent.ItemType<SharkHalberd>());
            shop.Add(ModContent.ItemType<JaguarsMask>());
            shop.Add(ModContent.ItemType<JaguarsBreastplate>());
            shop.Add(ModContent.ItemType<JaguarsLeggings>());
            shop.Add(ModContent.ItemType<JaguarsPickaxe>());

            shop.Add(ModContent.ItemType<HerbalFeather>(), HardMode);

            shop.Register();
        }
        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 60;
            knockback = 6f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 10;
            randExtraCooldown = 10;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = ModContent.ProjectileType<SharkKnifeP>();
            attackDelay = 4;
        }
        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }
        public override void HitEffect(NPC.HitInfo hit)
        {
            if (NPC.life <= 0)
            {
                for (int k = 0; k < 20; k++)
                {
                    Dust.NewDust(NPC.position, NPC.width, NPC.height, 5, 2.5f * hit.HitDirection, -2.5f, 0, default(Color), 0.7f);
                }
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PapuanMerchantHead").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PapuanMerchantBody").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PapuanMerchantArm").Type, 1f);
                Gore.NewGore(NPC.GetSource_Death(), NPC.position, NPC.velocity, Mod.Find<ModGore>("PapuanMerchantLeg").Type, 1f);
            }
        }
    }
}