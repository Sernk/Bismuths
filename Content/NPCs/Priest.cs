using Bismuth.Content.Items.Materials;
using Bismuth.Content.Items.Other;
using Bismuth.Content.Items.Weapons.Magical;
using Bismuth.Content.Items.Weapons.Melee;
using Bismuth.Utilities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.NPCs
{
    [AutoloadHead]
    public class Priest : ModNPC
    {
        public override void SetStaticDefaults()
        {
            NPCID.Sets.NoTownNPCHappiness[NPC.type] = true;
        }
        public override void Load()
        {
            string Priest_1 = this.GetLocalization("Chat.Priest_1").Value; // Ru: Мне нужен человек, который не будет задавать лишних вопросов. Приходи, когда покров тьмы сокроет нас - и ты не пожалеешь
                                                                           // En: I need a person that won’t ask any questions. Come here when night falls upon this city – and you’ll not regret it
            string Priest_2 = this.GetLocalization("Chat.Priest_2").Value; // Ru: "Желаешь ли ты заполучить в свои руки оружие невиданной силы? Умеешь ли ты хранить тайны? Если да - готовься слушать, ибо у меня есть задание для тебя. Я щедро награжу тебя, ведь ничто в нашем подлунном мире не должно делаться даром...
                                                                           // En: Do you wish to lay your hands on a weapon of unseen power? Do you know how to keep secrets? If so – prepare to listen, for I have a task for you. You’ll, of course, be given a generous reward – nothing in this world should be done for free…
            string Priest_4 = this.GetLocalization("Chat.Priest_4").Value; // Ru: Ты уже добыл мощи воина? En: Have you obtained the warrior’s remains yet?
            string Priest_5 = this.GetLocalization("Chat.Priest_5").Value; // Ru: Мне нужны останки для проведения ритуала. Приходи, когда добудешь их. En: I need the remains for a ritual. Come back once you have them.

            string PriestNQ_1 = this.GetLocalization("Chat.PriestNQ_1").Value; // Ru: Если хочешь узнать больше о руинах, приходи ночью. En: If you want to know more about the ruins – visit me at night.
            string PriestNQ_2 = this.GetLocalization("Chat.PriestNQ_2").Value; // Ru: Какой солнечный день сегодня... Надеюсь, ночь тоже будет ясной.
                                                                               // En: What a sunny day it is… I hope the night is going to be just as clear.
            string PriestNQ_3 = this.GetLocalization("Chat.PriestNQ_3").Value; // Ru: Магия смерти возвышает достойных и низвергает слабых... Готов ли ты заплатить такую цену?
                                                                               // En: Death magic rewards the worthy and tortures the weak… Are you ready to pay such a price?
            string PriestNQ_4 = this.GetLocalization("Chat.PriestNQ_4").Value; // Ru: Фолианты {0} интересны... En: The tomes from {0} are interesting..

            string PriestAnsv_1 = this.GetLocalization("Chat.PriestAnsv_1").Value; // Ru: Я слушаю En: I'm listening
            string PriestAnsv_2 = this.GetLocalization("Chat.PriestAnsv_2").Value; // Ru: Пожелай мне удачи En: Wish me luck
            string PriestAnsv_3 = this.GetLocalization("Chat.PriestAnsv_3").Value; // Ru: Я достал мощи En: I got remains
            string PriestAnsv_4 = this.GetLocalization("Chat.PriestAnsv_4").Value; // Ru: Я пока не нашел могилу En: I haven't found tombstone yet
            string PriestAnsv_5 = this.GetLocalization("Chat.PriestAnsv_5").Value; // Ru: Я сломал могильную плиту En: I've broken tombstone
            string PriestAnsv_6 = this.GetLocalization("Chat.PriestAnsv_6").Value; // Ru: Я хочу зарядить косу En: I'd like to charge scythe
            string PriestAnsv_7 = this.GetLocalization("Chat.PriestAnsv_7").Value; // Ru: Ты зарядил её? En: Did you charge it?
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
            NPC.lifeMax = 1;
            NPC.dontTakeDamageFromHostiles = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0f;
        }
        public override List<string> SetNPCNameList() => new List<string>()
        {
            this.GetLocalizedValue("Name.Rizo"), // Language.GetTextValue("Mods.Bismuth.PriestName_1");
            this.GetLocalizedValue("Name.Albert"), // Language.GetTextValue("Mods.Bismuth.PriestName_2");
            this.GetLocalizedValue("Name.Bernando"), // Language.GetTextValue("Mods.Bismuth.PriestName_3");
            this.GetLocalizedValue("Name.Seefeld") // Language.GetTextValue("Mods.Bismuth.PriestName_4");
        };
        public override string GetChat()
        {
            string Priest_1 = this.GetLocalization("Chat.Priest_1").Value;
            string Priest_2 = this.GetLocalization("Chat.Priest_2").Value;
            string Priest_4 = this.GetLocalization("Chat.Priest_4").Value;

            string PriestNQ_1 = this.GetLocalization("Chat.PriestNQ_1").Value;
            string PriestNQ_2 = this.GetLocalization("Chat.PriestNQ_2").Value;
            string PriestNQ_3 = this.GetLocalization("Chat.PriestNQ_3").Value;
            string PriestNQ_4 = this.GetLocalization("Chat.PriestNQ_4").Value;

            if (Main.dayTime && Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 0)
                return Priest_1;
            else if (!Main.dayTime && Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 0)
                return Priest_2;
            else if (!Main.dayTime && Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 20 || Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 30 || Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 40)
                return Priest_4;
            else
            {
                if (!Main.dayTime)
                {
                    if (NPC.FindFirstNPC(NPCID.Wizard) >= 0)
                    {
                        switch (WorldGen.genRand.Next(0, 2))
                        {
                            case 0:
                                return PriestNQ_3;
                            default:
                                return string.Format(this.GetLocalization("Chat.PriestNQ_4").Value, Main.npc[NPC.FindFirstNPC(NPCID.Wizard)].GivenName);
                        }
                    }
                    else
                        return PriestNQ_3;
                }
                else
                {
                    if (NPC.FindFirstNPC(NPCID.Wizard) >= 0 && WorldGen.genRand.Next(0, 3) == 0)
                        return string.Format(this.GetLocalization("Chat.PriestNQ_4").Value, Main.npc[NPC.FindFirstNPC(NPCID.Wizard)].GivenName);
                    else;
                    {
                        switch (WorldGen.genRand.Next(0, 2))
                        {
                            case 0:
                                return PriestNQ_1;
                            default:
                                return PriestNQ_2;
                        }
                    }
                }
            }
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D available = ModContent.Request<Texture2D>("Bismuth/UI/AvailableQuest").Value;
            Texture2D active = ModContent.Request<Texture2D>("Bismuth/UI/ActiveQuest").Value;
            if (!Main.dayTime && Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest <= 10)
                spriteBatch.Draw(available, NPC.position - Main.screenPosition + new Vector2(10, -36), Color.White);
            if (!Main.dayTime && Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest > 10 && Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest < 100)
                spriteBatch.Draw(active, NPC.position - Main.screenPosition + new Vector2(6, -40), Color.White);           
        }
        public override bool CheckConditions(int left, int right, int top, int bottom)
        {
            return false;
        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            string Priest_5 = this.GetLocalization("Chat.Priest_5").Value;
            string PriestAnsv_1 = this.GetLocalization("Chat.PriestAnsv_1").Value;
            string PriestAnsv_2 = this.GetLocalization("Chat.PriestAnsv_2").Value;
            string PriestAnsv_3 = this.GetLocalization("Chat.PriestAnsv_3").Value;
            string PriestAnsv_4 = this.GetLocalization("Chat.PriestAnsv_4").Value;
            string PriestAnsv_5 = this.GetLocalization("Chat.PriestAnsv_5").Value;
            string PriestAnsv_6 = this.GetLocalization("Chat.PriestAnsv_6").Value;
            string PriestAnsv_7 = this.GetLocalization("Chat.PriestAnsv_7").Value;

            Quests quests = (Quests)Main.player[Main.myPlayer].GetModPlayer<Quests>();
            if (!Main.dayTime)
            {
                button = Lang.inter[28].Value;
                if (Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 0)
                    button2 = PriestAnsv_1;
                if (Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 5)
                    button2 = PriestAnsv_2;
                if (Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 30 || Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 20)
                {
                    bool temp = false;
                    for (int num66 = 0; num66 < 58; num66++)
                    {
                        if (Main.player[Main.myPlayer].inventory[num66].type == ModContent.ItemType<WarriorsRemains>() && Main.player[Main.myPlayer].inventory[num66].stack > 0)
                        {
                            temp = true;
                            button2 = PriestAnsv_3;
                        }
                    }
                    if (!temp && Main.npcChatText != Priest_5)
                        button2 = PriestAnsv_4;
                }
                if (Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 40)
                    button2 = PriestAnsv_5;
                if (Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 100)
                {
                    if (Main.LocalPlayer.GetModPlayer<Quests>().SoulScytheQuest == 0)
                    {
                        bool temp = false;
                        for (int num66 = 0; num66 < 58; num66++)
                        {
                            if (Main.LocalPlayer.inventory[num66].type == ModContent.ItemType<UnchargedSoulScythe>() && Main.LocalPlayer.inventory[num66].stack > 0)
                            {
                                temp = true;

                            }
                        }
                        if (temp)
                            button2 = PriestAnsv_6;
                    }
                    else if(Main.LocalPlayer.GetModPlayer<Quests>().SoulScytheQuest == 10 && Main.LocalPlayer.GetModPlayer<BismuthPlayer>().WaitSoulScythe == 1800)
                    {

                        button2 = PriestAnsv_7;
                    }
                }
            }
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            Quests quests = (Quests)Main.player[Main.myPlayer].GetModPlayer<Quests>();
            if (!Main.dayTime)
            {
                if (firstButton)
                    shopName = "PriestShop";
                else if (Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest != 300)
                {
                    if (Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest != 100)
                        quests.PriestQuests();
                    else
                        quests.SoulScytheCharging();

                }
            }
        }
        public override void AddShops()
        {
            var Tombstone = new Condition("DownedPlantBoss", () => Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 100);
            var KilledEoCS = new Condition("DownedPlantBoss", () => Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledEoC);

            NPCShop shop = new(Type, "PriestShop");

            shop.Add(ModContent.ItemType<InkBottle>());
            shop.Add(ModContent.ItemType<BookOfTheDead>(), Tombstone);
            shop.Add(ModContent.ItemType<TheBladeOfWoe>(), KilledEoCS);

            shop.Register();
        }
        public void UpdatePosition()
        {
            if (Main.player[Main.myPlayer].position.X >= NPC.position.X)
                NPC.spriteDirection = 1;
            else                                                                                                                                                                                                                                                                                                                                                                                                                                                                              
                NPC.spriteDirection = -1;
        }
        int pretimer = 0;
        public override void AI()
        {
            NPC.netUpdate = true;
            NPC.dontTakeDamage = true;
            NPC.breath = 100;
            if (NPC.oldVelocity.X != 0f)
                NPC.velocity.X = 0f;

            if (Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 200)
            {
                if (Main.netMode == 0)
                {
                    NPC.Transform(ModContent.NPCType<PriestTeleportation>());
                }
                else
                {
                    NPC.life = -1;
                    NPC.active = false;
                    NetMessage.SendData(MessageID.DamageNPC, -1, -1, null, NPC.whoAmI, -1f, 0f, 0f, 0, 0, 0); NPC.active = false;
                    return;
                }
            }
            if (Main.LocalPlayer.talkNPC != -1)
            {
                if (Main.npc[Main.LocalPlayer.talkNPC].whoAmI == NPC.whoAmI)
                {
                    UpdatePosition();
                }
                if (Main.npc[Main.LocalPlayer.talkNPC].type != NPC.type)
                {
                    if (Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest < 10)
                        Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest = 0;
                }
            }
            else
            {
                if (Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest < 10)
                    Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest = 0;
            }
        }
    }
}