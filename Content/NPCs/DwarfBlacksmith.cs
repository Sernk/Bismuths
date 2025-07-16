using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Bismuth.Utilities;
using Terraria.Audio;
using Bismuth.Content.Items.Weapons.Throwing;
using Bismuth.Content.Items.Weapons.Magical;
using Bismuth.Content.Items.Other;
using Bismuth.Content.Items.Weapons.Ranged;
using Bismuth.Content.Items.Weapons.Melee;
using Bismuth.Content.Items.Materials;
using Bismuth.Content.Items.Armor;
using Bismuth.Content.Items.Accessories;
using Bismuth.Content.Items.Weapons.Assassin;

namespace Bismuth.Content.NPCs
{
    [AutoloadHead]
    public class DwarfBlacksmith : ModNPC
    {
        public int tick = 0;
        public int currentframe = 0;
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Blacksmith");
            //DisplayName.AddTranslation(GameCulture.Russian, "Кузнец");
            Main.npcFrameCount[NPC.type] = 20;
            NPCID.Sets.NoTownNPCHappiness[NPC.type] = true;
        }
        public override void Load()
        {
            string Blacksmith_1 = this.GetLocalization("Chat.Blacksmith_1").Value; // Ru: {0}, готов поспорить, что тебя тоже выводят из себя эти мерзкие гоблины. Но у меня есть решение. En: {0}, I bet those filthy goblins piss you off as well, don’t they? Well I have a solution for that
            string Blacksmith_3 = this.GetLocalization("Chat.Blacksmith_3").Value; // Ru: В окрестностях города чересчур много гоблинских морд, не отделенных пока от туловища, но это дело поправимое, если ты принесешь мне чертеж. En: There are far too many goblin snouts in the vicinity of this town, but that’s a solvable problem, if you bring me the blueprint, of course.
            string Blacksmith_5 = this.GetLocalization("Chat.Blacksmith_5").Value; // Ru: Меч ещё не готов, приходи позже. En: The blade is not ready yet, come back later.
            string Blacksmith_7 = this.GetLocalization("Chat.Blacksmith_7").Value; // Ru: Клянусь своим молотом, ты пришел как раз вовремя! У меня есть предложение для тебя. En: I swear on my hammer, you’re right on time! I have an offer for you.
            string Blacksmith_9 = this.GetLocalization("Chat.Blacksmith_9").Value; // Ru: Настало время минотавру лишиться одного из своих драгоценных рогов. Ты уже одержал верх над этим чудовищем? En: It is time for the minotaur to lose one of its horns. Have you slain the beast yet?
            string Blacksmith_10 = this.GetLocalization("Chat.Blacksmith_10").Value; // Ru: В таком случае не теряй времени, я буду ждать тебя. En: In that case don’t waste any more time, I’ll be waiting for you.
            string Blacksmith_12 = this.GetLocalization("Chat.Blacksmith_12").Value; // Ru: Знаешь, когда-то давно меня нельзя было назвать последним из выживших гномов. Наша цивилизация процветала, мы были королями подземелий, но одно сильное землетрясение перечеркнуло всю нашу историю. Душа многих умерших так и не нашли упокоения и они до сих пор бродят по шахтам в обличии костяных болванов. En: You know, a long time ago I couldn’t be called the last survivor of the gnomes. Our civilization prospered, underground we were the kings, but a single powerful earthquake put an end to our entire history. Many of the deceased haven’t found peace yet, and are still roaming the mines as skeletons
            string Blacksmith_14 = this.GetLocalization("Chat.Blacksmith_14").Value; // Ru: Мне не терпится начать ковать снаряжение из этого сплава. Ты уже достал 5 нагрудников? En: I can’t wait to start forging equipment from this alloy. Have you obtained 5 breastplates yet?
            string Blacksmith_15 = this.GetLocalization("Chat.Blacksmith_15").Value; // Ru: В таком случае не теряй времени даром, ты знаешь, что делать. En: In that case, don’t waste any more time – you know what to do.

            string BlacksmithNQ_1 = this.GetLocalization("Chat.BlacksmithNQ_1").Value; // Ru: Какие у нашей цивилизации были зелья - можно было детей поить! En: What great potions our civilization had – children could drink those!
            string BlacksmithNQ_2 = this.GetLocalization("Chat.BlacksmithNQ_2").Value; // Ru: Иногда мне кажется, что {0} мой дальний родственник. En: Sometimes I wonder if {0} is my distant relative.
            string BlacksmithNQ_3 = this.GetLocalization("Chat.BlacksmithNQ_3").Value; // Ru: Ты не находил маленького красивого колечка? Нет? Ладно. En: You haven’t seen a pretty ring around, have you? No? Okay then.
            string BlacksmithNQ_4 = this.GetLocalization("Chat.BlacksmithNQ_4").Value; // Ru: Когда-то давно, ещё до землетрясения, мы добывали руду удивительного качества. Возможно, ты ещё сможешь её отыскать глубоко под землёй. En: A long time ago, before the earthquake, we were mining an ore of surprising quality. Perhaps, you could still find some deep underground.

            string BlacksmithAnsv_1 = this.GetLocalization("Chat.BlacksmithAnsv_1").Value; // Ru: Какое решение? En: What solution?
            string BlacksmithAnsv_2 = this.GetLocalization("Chat.BlacksmithAnsv_2").Value; // Ru: Я принесу этот чертеж En: I'll bring you a blueprint
            string BlacksmithAnsv_3 = this.GetLocalization("Chat.BlacksmithAnsv_3").Value; // Ru: Вот чертеж, как просил En: Here is a blueprint, as you asked
            string BlacksmithAnsv_4 = this.GetLocalization("Chat.BlacksmithAnsv_4").Value; // Ru: Я пока не разговаривал с {0} En: I haven't talked to {0} yet
            string BlacksmithAnsv_5 = this.GetLocalization("Chat.BlacksmithAnsv_5").Value; // Ru: Меч готов? En: How is sword making going?
            string BlacksmithAnsv_6 = this.GetLocalization("Chat.BlacksmithAnsv_6").Value; // Ru: Я весь внимание En: I'm all ears
            string BlacksmithAnsv_7 = this.GetLocalization("Chat.BlacksmithAnsv_7").Value; // Ru: Убить ещё одну тварь? En: One more beast to defeat?
            string BlacksmithAnsv_8 = this.GetLocalization("Chat.BlacksmithAnsv_8").Value; // Ru: Я убил его, мой друг! En: I killed it, my friend!
            string BlacksmithAnsv_9 = this.GetLocalization("Chat.BlacksmithAnsv_9").Value; // Ru: Минотавр пока ещё жив En: Minotaur is still alive
            string BlacksmithAnsv_10 = this.GetLocalization("Chat.BlacksmithAnsv_10").Value; // Ru: Ближе к делу En: Get to the point
            string BlacksmithAnsv_11 = this.GetLocalization("Chat.BlacksmithAnsv_11").Value; // Ru: По рукам En: Deal
            string BlacksmithAnsv_12 = this.GetLocalization("Chat.BlacksmithAnsv_12").Value; // Ru: Я работаю над этим En: I'm working on it
            string BlacksmithAnsv_13 = this.GetLocalization("Chat.BlacksmithAnsv_13").Value; // Ru: Вот твои нагрудники En: Here are breastplates
            string BlacksmithAnsv_14 = this.GetLocalization("Chat.BlacksmithAnsv_14").Value; // Ru: Обменять нагрудники En: Exchange breastplates
        }
        public override string GetChat()
        {
            string Blacksmith_1 = this.GetLocalization("Chat.Blacksmith_1").Value;
            string Blacksmith_3 = this.GetLocalization("Chat.Blacksmith_3").Value;
            string Blacksmith_7 = this.GetLocalization("Chat.Blacksmith_7").Value;
            string Blacksmith_9 = this.GetLocalization("Chat.Blacksmith_9").Value;
            string Blacksmith_12 = this.GetLocalization("Chat.Blacksmith_12").Value;
            string Blacksmith_14 = this.GetLocalization("Chat.Blacksmith_14").Value;

            string BlacksmithNQ_1 = this.GetLocalization("Chat.BlacksmithNQ_1").Value;
            string BlacksmithNQ_2 = this.GetLocalization("Chat.BlacksmithNQ_2").Value;
            string BlacksmithNQ_3 = this.GetLocalization("Chat.BlacksmithNQ_3").Value;
            string BlacksmithNQ_4 = this.GetLocalization("Chat.BlacksmithNQ_4").Value;

            if (NPC.AnyNPCs(NPCID.GoblinTinkerer) && Main.LocalPlayer.GetModPlayer<Quests>().GlamdringQuest == 0 && Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest == 100)
                return string.Format(this.GetLocalization("Chat.Blacksmith_1").Value, Main.LocalPlayer.name);
            else if (Main.LocalPlayer.GetModPlayer<Quests>().GlamdringQuest == 20)
                return Blacksmith_3;
            else if (Main.LocalPlayer.GetModPlayer<Quests>().MinotaurHornQuest == 0 && Main.LocalPlayer.GetModPlayer<Quests>().GlamdringQuest == 100 && Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledEoC)
                return Blacksmith_7;
            else if (Main.LocalPlayer.GetModPlayer<Quests>().MinotaurHornQuest == 20)
                return Blacksmith_9;
            else if (Main.LocalPlayer.GetModPlayer<Quests>().ArmorPlateQuest == 20)
                return Blacksmith_14;
            else if (Main.LocalPlayer.GetModPlayer<Quests>().ArmorPlateQuest == 0 && Main.LocalPlayer.GetModPlayer<Quests>().GlamdringQuest == 100 && Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledWoF)
                return Blacksmith_12;
            else
            {
                if (NPC.FindFirstNPC(NPCID.Demolitionist) >= 0 && WorldGen.genRand.Next(0, 4) == 0)
                    return string.Format(this.GetLocalization("Chat.BlacksmithNQ_2").Value, Main.npc[NPC.FindFirstNPC(NPCID.Demolitionist)].GivenName);
                else switch (WorldGen.genRand.Next(0, 3))
                    {
                        case 0:
                            return BlacksmithNQ_1;
                        case 1:
                            return BlacksmithNQ_3;
                        default:
                            return BlacksmithNQ_4;                      
                    }
            }
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 32;
            NPC.height = 42;
            NPC.aiStyle = -1;
            NPC.damage = 10;
            NPC.defense = 20;
            NPC.lifeMax = 1000;
            NPC.dontTakeDamageFromHostiles = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0f;
        }
        public override List<string> SetNPCNameList() => new List<string>()
        {
                this.GetLocalizedValue("Name.Rizo"), // Language.GetTextValue("Mods.Bismuth.BlacksmithName_1");
                this.GetLocalizedValue("Name.Albert"), // Language.GetTextValue("Mods.Bismuth.BlacksmithName_2");
                this.GetLocalizedValue("Name.Bernando"), // Language.GetTextValue("Mods.Bismuth.BlacksmithName_3");
                this.GetLocalizedValue("Name.Seefeld"), // Language.GetTextValue("Mods.Bismuth.BlacksmithName_4");
                this.GetLocalizedValue("Name.Robert"), // Language.GetTextValue("Mods.Bismuth.BlacksmithName_5");
                this.GetLocalizedValue("Name.Gerald") // Language.GetTextValue("Mods.Bismuth.BlacksmithName_6");
        };
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D available = ModContent.Request<Texture2D>("Bismuth/UI/AvailableQuest").Value;
            Texture2D active = ModContent.Request<Texture2D>("Bismuth/UI/ActiveQuest").Value;
            if ((Main.LocalPlayer.GetModPlayer<Quests>().GlamdringQuest <= 10 && Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest == 100 && NPC.AnyNPCs(NPCID.GoblinTinkerer)) || (Main.LocalPlayer.GetModPlayer<Quests>().GlamdringQuest == 100 && Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledEoC && Main.LocalPlayer.GetModPlayer<Quests>().MinotaurHornQuest <= 10) || (Main.LocalPlayer.GetModPlayer<Quests>().MinotaurHornQuest == 100 && Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledWoF && Main.LocalPlayer.GetModPlayer<Quests>().ArmorPlateQuest <= 10))
                spriteBatch.Draw(available, NPC.position - Main.screenPosition + new Vector2(20, -36), Color.White);
            if ((Main.LocalPlayer.GetModPlayer<Quests>().GlamdringQuest > 10 && Main.LocalPlayer.GetModPlayer<Quests>().GlamdringQuest < 100) || (Main.LocalPlayer.GetModPlayer<Quests>().MinotaurHornQuest > 10 && Main.LocalPlayer.GetModPlayer<Quests>().MinotaurHornQuest < 100) || (Main.LocalPlayer.GetModPlayer<Quests>().ArmorPlateQuest > 10 && Main.LocalPlayer.GetModPlayer<Quests>().ArmorPlateQuest < 100))
                spriteBatch.Draw(active, NPC.position - Main.screenPosition + new Vector2(16, -44), Color.White);
            spriteBatch.Draw(ModContent.Request<Texture2D>("Bismuth/Content/NPCs/DwarfBlacksmith_Glow").Value, NPC.position - Main.screenPosition + new Vector2(-18f, -4f), new Rectangle?(NPC.frame), Color.White, NPC.rotation, Vector2.Zero, 1f, SpriteEffects.None, 0.0f);
        }
        public override void AddShops()
        {
            var KilledEoCS = new Condition("KilledEoCS", () => Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledEoC);
            var KilledSkeletron = new Condition("KilledSkeletron", () => Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledSkeletron);
            var KilledWoF = new Condition("KilledWoF", () => Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledWoF);
            var KilledAnyMechBoss = new Condition("KilledAnyMechBoss", () => Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledAnyMechBoss);

            NPCShop shop = new(Type, "DwarfShop");

            shop.Add(ModContent.ItemType<ImperianHelmet>());
            shop.Add(ModContent.ItemType<Lorica>());
            shop.Add(ModContent.ItemType<Ocrea>());
            shop.Add(ModContent.ItemType<Gladius>());
            shop.Add(ModContent.ItemType<Scutum>());
            shop.Add(ModContent.ItemType<WoodenCrossbow>());
            shop.Add(ModContent.ItemType<WoodenStaff>());
            shop.Add(ModContent.ItemType<Lancea>());
            shop.Add(ModContent.ItemType<Parazonium>());
            shop.Add(ModContent.ItemType<ImprovedMiningPotion>());

            shop.Add(new Item(ModContent.ItemType<BismuthumCasket>())
            {
                shopCustomPrice = 1,
                shopSpecialCurrency = Bismuth.DwarvenCoinID
            });
            shop.Add(new Item(ModContent.ItemType<PotionOfOblivion>())
            {
                shopCustomPrice = 1,
                shopSpecialCurrency = Bismuth.DwarvenCoinID
            });
            shop.Add(new Item(ModContent.ItemType<RingRim>())
            {
                shopCustomPrice = 2,
                shopSpecialCurrency = Bismuth.DwarvenCoinID
            });

            shop.Add(new Item(ModContent.ItemType<GalvornScroll>())
            {
                shopCustomPrice = 1,
                shopSpecialCurrency = Bismuth.DwarvenCoinID
            },  KilledEoCS);
            shop.Add(new Item(ModContent.ItemType<Angrist>())
            {
                shopCustomPrice = 5,
                shopSpecialCurrency = Bismuth.DwarvenCoinID
            },  KilledEoCS);
            shop.Add(new Item(ModContent.ItemType<Aeglos>())
            {
                shopCustomPrice = 5,
                shopSpecialCurrency = Bismuth.DwarvenCoinID
            },  KilledSkeletron);
            shop.Add(new Item(ModContent.ItemType<Ringril>())
            {
                shopCustomPrice = 15,
                shopSpecialCurrency = Bismuth.DwarvenCoinID
            },  KilledWoF);
            shop.Add(new Item(ModContent.ItemType<MasterToolBox>())
            {
                shopCustomPrice = 5,
                shopSpecialCurrency = Bismuth.DwarvenCoinID
            },  KilledWoF);
            shop.Add(new Item(ModContent.ItemType<StarOfTheDunedain>())
            {
                shopCustomPrice = 20,
                shopSpecialCurrency = Bismuth.DwarvenCoinID
            },  KilledAnyMechBoss);

            shop.Register();
        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            string Blacksmith_5 = this.GetLocalization("Chat.Blacksmith_5").Value;
            string Blacksmith_10 = this.GetLocalization("Chat.Blacksmith_10").Value;
            string Blacksmith_15 = this.GetLocalization("Chat.Blacksmith_15").Value;
            string BlacksmithAnsv_1 = this.GetLocalization("Chat.BlacksmithAnsv_1").Value;
            string BlacksmithAnsv_2 = this.GetLocalization("Chat.BlacksmithAnsv_2").Value;
            string BlacksmithAnsv_3 = this.GetLocalization("Chat.BlacksmithAnsv_3").Value;
            string BlacksmithAnsv_4 = this.GetLocalization("Chat.BlacksmithAnsv_4").Value;
            string BlacksmithAnsv_5 = this.GetLocalization("Chat.BlacksmithAnsv_5").Value;
            string BlacksmithAnsv_6 = this.GetLocalization("Chat.BlacksmithAnsv_6").Value;
            string BlacksmithAnsv_7 = this.GetLocalization("Chat.BlacksmithAnsv_7").Value;
            string BlacksmithAnsv_8 = this.GetLocalization("Chat.BlacksmithAnsv_8").Value;
            string BlacksmithAnsv_9 = this.GetLocalization("Chat.BlacksmithAnsv_9").Value;
            string BlacksmithAnsv_10 = this.GetLocalization("Chat.BlacksmithAnsv_10").Value;
            string BlacksmithAnsv_11 = this.GetLocalization("Chat.BlacksmithAnsv_11").Value;
            string BlacksmithAnsv_12 = this.GetLocalization("Chat.BlacksmithAnsv_12").Value;
            string BlacksmithAnsv_13 = this.GetLocalization("Chat.BlacksmithAnsv_13").Value;
            string BlacksmithAnsv_14 = this.GetLocalization("Chat.BlacksmithAnsv_14").Value;

            button = Lang.inter[28].Value;
            if (NPC.AnyNPCs(NPCID.GoblinTinkerer) && Main.LocalPlayer.GetModPlayer<Quests>().GlamdringQuest == 0 && Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest == 100)
                button2 = BlacksmithAnsv_1;
            if (Main.LocalPlayer.GetModPlayer<Quests>().GlamdringQuest == 5)
                button2 = BlacksmithAnsv_2;
            if (Main.LocalPlayer.GetModPlayer<Quests>().GlamdringQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Main.player[Main.myPlayer].inventory[num66].type == ModContent.ItemType<GlamdringBlueprint>() && Main.player[Main.myPlayer].inventory[num66].stack > 0)
                    {
                        temp = true;
                    }
                }
                if (temp)
                    button2 = BlacksmithAnsv_3;
            }
            if (Main.LocalPlayer.GetModPlayer<Quests>().GlamdringQuest == 30 && Main.npcChatText != Blacksmith_5)
            {
                button2 = BlacksmithAnsv_5;
            }
            if (Main.LocalPlayer.GetModPlayer<Quests>().MinotaurHornQuest == 0 && Main.LocalPlayer.GetModPlayer<Quests>().GlamdringQuest == 100 && Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledEoC)
                button2 = BlacksmithAnsv_6;
            if (Main.LocalPlayer.GetModPlayer<Quests>().MinotaurHornQuest == 5)
                button2 = BlacksmithAnsv_7;
            if (Main.LocalPlayer.GetModPlayer<Quests>().MinotaurHornQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Main.player[Main.myPlayer].inventory[num66].type == ModContent.ItemType<MinotaurHorn>() && Main.player[Main.myPlayer].inventory[num66].stack > 0)
                    {
                        temp = true;
                    }
                }
                if (temp)
                    button2 = BlacksmithAnsv_8;
                else if (!temp && Main.npcChatText != Blacksmith_10)
                    button2 = BlacksmithAnsv_9;
            }
            if (Main.LocalPlayer.GetModPlayer<Quests>().ArmorPlateQuest == 0 && Main.LocalPlayer.GetModPlayer<Quests>().MinotaurHornQuest == 100 && Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledWoF)
                button2 = BlacksmithAnsv_10;
            if (Main.LocalPlayer.GetModPlayer<Quests>().ArmorPlateQuest == 5)
                button2 = BlacksmithAnsv_11;
            if (Main.LocalPlayer.GetModPlayer<Quests>().ArmorPlateQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Main.player[Main.myPlayer].inventory[num66].type == ModContent.ItemType<DwarvenBrokenArmor>() && Main.player[Main.myPlayer].inventory[num66].stack >= 5)
                    {
                        temp = true;
                    }
                }
                if (temp)
                    button2 = BlacksmithAnsv_13;
                else if (!temp && Main.npcChatText != Blacksmith_15)
                    button2 = BlacksmithAnsv_12;
            }
            if (Main.LocalPlayer.GetModPlayer<Quests>().ArmorPlateQuest == 100)
            {
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Main.player[Main.myPlayer].inventory[num66].type == ModContent.ItemType<DwarvenBrokenArmor>() && Main.player[Main.myPlayer].inventory[num66].stack > 0)
                    {
                        button2 = BlacksmithAnsv_14;
                    }
                }
            }
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            Quests quests = (Quests)Main.player[Main.myPlayer].GetModPlayer<Quests>();
            if (firstButton)
                shopName = "DwarfShop";
            else
            {
                if (Main.LocalPlayer.GetModPlayer<Quests>().ArmorPlateQuest != 100)
                    quests.BlacksmithQuests();
                else
                    quests.BrokenArmorExchange();
            }
        }
        public override void AI()
        {
            if (Main.netMode != NetmodeID.Server)
            {
                if ((currentframe == 0 && tick == 0) || (currentframe == 10 && tick == 0))
                {
                    SoundStyle anvilStrike = new SoundStyle("Bismuth/Sounds/Custom/AnvilStrike")
                    {
                        Volume = ModContent.GetInstance<BismuthConfig>().BlacksmithForgingVolume,
                        Pitch = 0f,
                        PitchVariance = 0.1f,
                        MaxInstances = 3,
                        SoundLimitBehavior = SoundLimitBehavior.ReplaceOldest
                    };
                    SoundEngine.PlaySound(anvilStrike, NPC.position);
                }
            }
            if (NPC.homeTileX == -1 || NPC.homeTileY == -1)
            {
                NPC.homeTileX = NPC.Center.ToTileCoordinates().X;
                NPC.homeTileY = NPC.Center.ToTileCoordinates().Y;
            }
            NPC.dontTakeDamage = true;
            NPC.breath = 100;
            NPC.life = NPC.lifeMax;
            if (NPC.oldVelocity.X != 0f)
                NPC.velocity.X = 0f;
            if ((currentframe >= 0 && currentframe <= 1) || (currentframe >= 10 && currentframe <= 11))
            {
                
                Lighting.AddLight(NPC.position, new Vector3(242, 138, 48) * 0.0055f);
            }
            else
                Lighting.AddLight(NPC.position, new Vector3(242, 138, 48) * 0.0045f);
            if (Main.LocalPlayer.talkNPC != -1)
            {
                if (Main.npc[Main.LocalPlayer.talkNPC].type != NPC.type)
                {
                    if (Main.LocalPlayer.GetModPlayer<Quests>().GlamdringQuest < 10)
                        Main.LocalPlayer.GetModPlayer<Quests>().GlamdringQuest = 0;
                    if (Main.LocalPlayer.GetModPlayer<Quests>().MinotaurHornQuest < 10)
                        Main.LocalPlayer.GetModPlayer<Quests>().MinotaurHornQuest = 0;
                    if (Main.LocalPlayer.GetModPlayer<Quests>().ArmorPlateQuest < 10)
                        Main.LocalPlayer.GetModPlayer<Quests>().ArmorPlateQuest = 0;
                }
            }
            else
            {
                if (Main.LocalPlayer.GetModPlayer<Quests>().GlamdringQuest < 10)
                    Main.LocalPlayer.GetModPlayer<Quests>().GlamdringQuest = 0;
                if (Main.LocalPlayer.GetModPlayer<Quests>().MinotaurHornQuest < 10)
                    Main.LocalPlayer.GetModPlayer<Quests>().MinotaurHornQuest = 0;
                if (Main.LocalPlayer.GetModPlayer<Quests>().ArmorPlateQuest < 10)
                    Main.LocalPlayer.GetModPlayer<Quests>().ArmorPlateQuest = 0;
            }
        }
        public override void FindFrame(int frameHeight)
        {
            NPC.frame.Y = currentframe * frameHeight;
            if (Main.LocalPlayer.talkNPC != -1)
            {
                if (Main.npc[Main.LocalPlayer.talkNPC].whoAmI == NPC.whoAmI)
                {
                    if (currentframe > 9)
                        currentframe = 0;
                    tick++;
                    if (tick == 6)
                    {
                        tick = 0;
                        currentframe++;
                    }
                    if (currentframe > 9)
                        currentframe = 0;
                }
                else
                {
                    if (currentframe < 10)
                        currentframe = 10;
                    tick++;
                    if (tick == 6)
                    {
                        tick = 0;
                        currentframe++;
                    }
                    if (currentframe > 19)
                        currentframe = 10;
                }
            }
            else
            {
                if (currentframe < 10)
                    currentframe = 10; 
                tick++;
                if (tick == 6)
                {
                    tick = 0;
                    currentframe++;
                }
                if (currentframe > 19)
                    currentframe = 10;
            }
         
        }
        public override bool CheckConditions(int left, int right, int top, int bottom)
        {
            return false;
        }
    }
}
