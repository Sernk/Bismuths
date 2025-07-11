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
    public class PapuanMerchant : ModNPC // НЕ ЗАБЫТЬ ДОБАВИТЬ ЛОКАЛИЗАЦИЮ И ПЕРЕВОДЫ
    {

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

        //public override List<string> SetNPCNameList()/* tModPorter Suggestion: Return a list of names */
        //{
        //    switch (WorldGen.genRand.Next(4))
        //    {
        //        case 0:
        //            return "Gagini";
        //        case 1:
        //            return "Budd";
        //        case 2:
        //            return "Butannaziba";
        //        case 3:
        //            return "Mazozi";
        //        case 4:
        //            return "Nkemdilim";
        //        case 5:
        //            return "Olanreuodzhu";
        //        case 6:
        //            return "Syed";
        //        case 7:
        //            return "Tafari";
        //        case 8:
        //            return "Chidzhenda";
        //        default:
        //            return "Jango";
        //    }
        //}
        public override List<string> SetNPCNameList() => new List<string>()
        {
            this.GetLocalizedValue("Name.Gagini"), 
            this.GetLocalizedValue("Name.Budd"), 
            this.GetLocalizedValue("Name.Butannaziba"), 
            this.GetLocalizedValue("Name.Mazozi"), 
            this.GetLocalizedValue("Name.Nkemdilim"), 
            this.GetLocalizedValue("Name.Olanreuodzhu"),
            this.GetLocalizedValue("Name.Syed"), 
            this.GetLocalizedValue("Name.Tafari"), 
            this.GetLocalizedValue("Name.Chidzhenda"), 
            this.GetLocalizedValue("Name.Jango"), 
        };
        public override string GetChat()
        {
            int Angler = NPC.FindFirstNPC(NPCID.Angler);
            int Armsdealer = NPC.FindFirstNPC(NPCID.ArmsDealer);
            if (Armsdealer >= 0 && Main.rand.Next(5) == 0)
                return "At " + Main.npc[Armsdealer].GivenName + " during Halloween you can buy fashionable Dryad's panties, but I can sell it to you always(not yet). Took the hint?";
            if (Angler >= 0 && Main.rand.Next(5) == 0)
            {
                return "I think, " + Main.npc[Angler].GivenName + " will be happy, when he will see this hammerhead fish.";
            }
            switch (Main.rand.Next(3))
            {
                case 0:
                    return "Ones I killed 5 sharks with only one spoon.";
                case 1:
                    return "I would have made you a discount, but the fish was tasteless, so no";
                default:
                    return "I choose pointy peakes.";
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
            //shop.Add(ModContent.ItemType<JaguarsMask>());
            //shop.Add(ModContent.ItemType<JaguarsBreastplate>());
            //shop.Add(ModContent.ItemType<JaguarsLeggings>());
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