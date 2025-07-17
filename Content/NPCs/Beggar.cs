using Bismuth.Content.Items.Materials;
using Bismuth.Content.Items.Other;
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
    public class Beggar : ModNPC
    {
        public override void SetStaticDefaults()
        {
            NPCID.Sets.NoTownNPCHappiness[NPC.type] = true;
        }
        public override void Load()
        {
            string Beggar_1 = this.GetLocalization("Chat.Beggar_1").Value; // Ru: Э-ге-ге, да ты же тот самый новенький! У меня есть к тебе дело, юнец! En: E-he-he, you’re that newbie, aren’t you! I have a job for you, young’un!
            string Beggar_3 = this.GetLocalization("Chat.Beggar_3").Value; // Ru: Я знаю, что такой смелый и отважный воин, как ты, не откажет в помощи старому больному человеку. Принеси мне чего-нибудь пожевать, и тогда, возможно, я награжу тебя... Шучу, конечно En: I know a valiant warrior such as yourself wouldn’t refuse to aid a helpless old man. Bring me a snack, and then, perhaps I’ll reward you… A joke, obviously.
            string Beggar_4 = this.GetLocalization("Chat.Beggar_4").Value; // Ru: Еда у тебя? En: You have the food yet?

            string BeggarNQ_1 = this.GetLocalization("Chat.BeggarNQ_1").Value; // Ru: {0} - лучший человек в городе. En: {0} – is the best dude in town.
            string BeggarNQ_2 = this.GetLocalization("Chat.BeggarNQ_2").Value; // Ru: Не найдется монетки? En: Could you spare a coin?
            string BeggarNQ_3 = this.GetLocalization("Chat.BeggarNQ_3").Value; // Ru: {0} - не тот, кем кажется. Внимательней следи за ним. En: {0} – is more than he lets on. Keep a close eye on him.
            string BeggarNQ_4 = this.GetLocalization("Chat.BeggarNQ_4").Value; // Ru: Какой хороший сегодня день... Не найдётся чего-нибудь выпить? En: What a good day it is today… Do you have anything to drink?
            string BeggarNQ_5 = this.GetLocalization("Chat.BeggarNQ_5").Value; // Ru: Извини, но у тебя не хватает денег, чтобы сделать ставку. Возвращайся, когда у тебя появится хотя-бы одна золотая монета. En: Sorry, but you don't have enough money to make a bet. Come back when you will earn at least one gold coin.
            string BeggarNQ_6 = this.GetLocalization("Chat.BeggarNQ_6").Value; // Ru: Сейчас у тебя {0} побед в сумме и {1} побед подряд En: Now you have {0} victories at all and {1} in a row.

            string BeggarAnsv_1 = this.GetLocalization("Chat.BeggarAnsv_1").Value; // Ru: Что тебе нужно? En: What do you need from me?
            string BeggarAnsv_2 = this.GetLocalization("Chat.BeggarAnsv_2").Value; // Ru: Что ж, я принесу тебе еду En: I'll bring you food
            string BeggarAnsv_3 = this.GetLocalization("Chat.BeggarAnsv_3").Value; // Ru: Я достал еду для тебя En: Here is food for you
            string BeggarAnsv_4 = this.GetLocalization("Chat.BeggarAnsv_4").Value; // Ru: Я был занят другими делами En: I was busy with other things
            string BeggarAnsv_5 = this.GetLocalization("Chat.BeggarAnsv_5").Value; // Ru: Сыграть в кости En: Play dice
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
            this.GetLocalizedValue("Name.Rizo"), // Language.GetTextValue("Mods.Bismuth.BeggarName_1");
            this.GetLocalizedValue("Name.Albert"), // Language.GetTextValue("Mods.Bismuth.BeggarName_2");
            this.GetLocalizedValue("Name.Bernando"), // Language.GetTextValue("Mods.Bismuth.BeggarName_3");
            this.GetLocalizedValue("Name.Seefeld"), // Language.GetTextValue("Mods.Bismuth.BeggarName_4");
            this.GetLocalizedValue("Name.Robert") // Language.GetTextValue("Mods.Bismuth.BeggarName_5");
        };
        public override string GetChat()
        {
            string Beggar_1 = this.GetLocalization("Chat.Beggar_1").Value;
            string Beggar_3 = this.GetLocalization("Chat.Beggar_3").Value;
            string Beggar_4 = this.GetLocalization("Chat.Beggar_4").Value;
            string BeggarNQ_1 = this.GetLocalization("Chat.BeggarNQ_1").Value;
            string BeggarNQ_2 = this.GetLocalization("Chat.BeggarNQ_2").Value;
            string BeggarNQ_3 = this.GetLocalization("Chat.BeggarNQ_3").Value;
            string BeggarNQ_4 = this.GetLocalization("Chat.BeggarNQ_4").Value;
            string BeggarNQ_6 = this.GetLocalization("Chat.BeggarNQ_6").Value;

            if (Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().FoodQuest == 0)
            {
                return Beggar_1;
            }
            else if (Main.LocalPlayer.GetModPlayer<Quests>().FoodQuest == 20)
            {
                return Beggar_3;
            }
            else
            {
                if (NPC.FindFirstNPC(550) >= 0 && WorldGen.genRand.Next(0, 4) == 0)
                {
                    return string.Format(this.GetLocalization("Chat.BeggarNQ_1").Value, Main.npc[NPC.FindFirstNPC(550)].GivenName);
                }
                else if (NPC.FindFirstNPC(ModContent.NPCType<Priest>()) >= 0 && WorldGen.genRand.Next(0, 4) == 0)
                {
                    return string.Format(this.GetLocalization("Chat.BeggarNQ_3").Value, Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Priest>())].GivenName);
                }
                else switch (WorldGen.genRand.Next(0, 2))
                    {
                        case 0:
                            return BeggarNQ_2;
                        case 1:
                            return BeggarNQ_4;
                        default:
                            return string.Format(this.GetLocalization("Chat.BeggarNQ_6").Value, Main.LocalPlayer.GetModPlayer<DiceGame>().VictoryTotal, Main.LocalPlayer.GetModPlayer<DiceGame>().VictoryInARow);
                    }
            }
        }
        public override bool CheckConditions(int left, int right, int top, int bottom)
        {
            return false;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D available = ModContent.Request<Texture2D>("Bismuth/UI/AvailableQuest").Value;
            Texture2D active = ModContent.Request<Texture2D>("Bismuth/UI/ActiveQuest").Value;
            if (Main.LocalPlayer.GetModPlayer<Quests>().FoodQuest <= 10 && Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest == 100)
            {
                spriteBatch.Draw(available, NPC.position - Main.screenPosition + new Vector2(10, -36), Color.White);
            }
            if (Main.LocalPlayer.GetModPlayer<Quests>().FoodQuest > 10 && Main.LocalPlayer.GetModPlayer<Quests>().FoodQuest < 100)
            {
                spriteBatch.Draw(active, NPC.position - Main.screenPosition + new Vector2(6, -40), Color.White);
            }
        }
        public override void AddShops()
        {
            NPCShop shop = new(Type, "BeggarShop");

            shop.Add(ModContent.ItemType<Picklock>());
            shop.Add(ModContent.ItemType<MirrorRim>());

            shop.Register();
        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            string Beggar_4 = this.GetLocalization("Chat.Beggar_4").Value;
            string BeggarAnsv_1 = this.GetLocalization("Chat.BeggarAnsv_1").Value;
            string BeggarAnsv_2 = this.GetLocalization("Chat.BeggarAnsv_2").Value;
            string BeggarAnsv_3 = this.GetLocalization("Chat.BeggarAnsv_3").Value;
            string BeggarAnsv_4 = this.GetLocalization("Chat.BeggarAnsv_4").Value;
            string BeggarAnsv_5 = this.GetLocalization("Chat.BeggarAnsv_5").Value;

            Quests quests = (Quests)Main.player[Main.myPlayer].GetModPlayer<Quests>();
           
            if (Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest == 100)
            {
                if (Main.LocalPlayer.GetModPlayer<Quests>().FoodQuest == 0)
                {
                    button2 = BeggarAnsv_1;
                }
                if (Main.LocalPlayer.GetModPlayer<Quests>().FoodQuest == 5)
                {
                    button2 = BeggarAnsv_2;
                }
                if (Main.LocalPlayer.GetModPlayer<Quests>().FoodQuest == 20)
                {
                    bool temp = false;
                    for (int num66 = 0; num66 < 58; num66++)
                    {
                        if (Main.LocalPlayer.inventory[num66].stack > 0 && Main.LocalPlayer.inventory[num66].type == ItemID.CookedMarshmallow || Main.LocalPlayer.inventory[num66].type == ItemID.PadThai || Main.LocalPlayer.inventory[num66].type == ItemID.Pho || Main.LocalPlayer.inventory[num66].type == ItemID.Sashimi || Main.LocalPlayer.inventory[num66].type == ItemID.CookedFish || Main.LocalPlayer.inventory[num66].type == ItemID.CookedShrimp || Main.LocalPlayer.inventory[num66].type == ItemID.BowlofSoup || Main.LocalPlayer.inventory[num66].type == ItemID.Bacon || Main.LocalPlayer.inventory[num66].type == ItemID.GingerbreadCookie || Main.LocalPlayer.inventory[num66].type == ItemID.SugarCookie || Main.LocalPlayer.inventory[num66].type == ItemID.GrubSoup || Main.LocalPlayer.inventory[num66].type == ItemID.ChristmasPudding || Main.LocalPlayer.inventory[num66].type == ItemID.PumpkinPie)
                        {
                            temp = true;
                            button2 = BeggarAnsv_3;
                        }
                    }
                    if (!temp && Main.npcChatText != Beggar_4)
                    {
                        button2 = BeggarAnsv_4;
                    }
                }
                if (Main.LocalPlayer.GetModPlayer<Quests>().FoodQuest == 100)
                {
                    button = Lang.inter[28].Value;
                    button2 = BeggarAnsv_5;
                }
            }
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            string BeggarNQ_5 = this.GetLocalization("Chat.BeggarNQ_5").Value;

            Quests quests = (Quests)Main.player[Main.myPlayer].GetModPlayer<Quests>();
            DiceGame Dicegame = (DiceGame)Main.player[Main.myPlayer].GetModPlayer<DiceGame>();
            if (firstButton && Main.LocalPlayer.GetModPlayer<Quests>().FoodQuest == 100)
            {
                shopName = "BeggarShop";
            }
            else
            {
                if (Main.LocalPlayer.GetModPlayer<Quests>().FoodQuest != 100)
                {
                    quests.BeggarQuests();
                }
                else
                {
                    Player player = Main.player[Main.myPlayer];
                    bool temp = false;
                    for (int num66 = 0; num66 < 58; num66++)
                    {
                        if (player.inventory[num66].type == ItemID.GoldCoin)
                        {
                            temp = true;
                            Dicegame.IsTableOpened = true;
                        }
                    }
                    if (!temp)
                    {
                        Main.npcChatText = BeggarNQ_5;
                    }
                }
            }               
        }
        public void UpdatePosition()
        {
            if (Main.player[Main.myPlayer].position.X >= NPC.position.X)
                NPC.spriteDirection = -1;
            else
                NPC.spriteDirection = 1;
        }
        public override void AI()
        {
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
            if (Main.LocalPlayer.talkNPC != -1)
            {
                if (Main.npc[Main.LocalPlayer.talkNPC].whoAmI == NPC.whoAmI)
                {
                    UpdatePosition();
                }
                if (Main.npc[Main.LocalPlayer.talkNPC].type != NPC.type)
                {
                    if (Main.LocalPlayer.GetModPlayer<Quests>().FoodQuest < 10)
                        Main.LocalPlayer.GetModPlayer<Quests>().FoodQuest = 0;
                }
            }
            else
            {
                if (Main.LocalPlayer.GetModPlayer<Quests>().FoodQuest < 10)
                    Main.LocalPlayer.GetModPlayer<Quests>().FoodQuest = 0;
            }
        }
    }
}