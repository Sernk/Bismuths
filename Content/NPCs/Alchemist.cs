using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Bismuth.Content.Items.Other;
using Bismuth.Content.Items.Materials;
using Microsoft.Xna.Framework.Graphics;
using Bismuth.Utilities;
using Bismuth.Content.Items.Accessories;
using Bismuth.Content.Items.Placeable;

namespace Bismuth.Content.NPCs
{
    [AutoloadHead]
    public class Alchemist : ModNPC
    {
        public override void Load()
        {
            string AlchemistNQ_1 = this.GetLocalization("Chat.AlchemistNQ_1").Value; // ru Хорошие новости, народ, слизь снова потекла! en Good news, everyone, the slime’s oozing again!
            string AlchemistNQ_2 = this.GetLocalization("Chat.AlchemistNQ_2").Value; // ru Не покупай зелий у {0}, вся его магия - детские фокусы. en Don’t buy potions from {0}, his magic’s cheap tricks.
            string AlchemistNQ_3 = this.GetLocalization("Chat.AlchemistNQ_3").Value; // ru Знал бы ты, как я изобрёл странное зелье... en If only you knew how I invented a weird potion.
            string AlchemistNQ_4 = this.GetLocalization("Chat.AlchemistNQ_4").Value; // ru Как говорил один мой мудрый коллега: \"Что случилось однажды, может никогда больше не случиться. Но то, что случилось два раза, непременно случится и в третий\" en As my wise colleague once said: ”What happened once could never repeat. However, what happened twice is certain to happen again
            string Alchemist_1 = this.GetLocalization("Chat.Alchemist_1").Value; // ru Дорогой друг, не найдется ли у тебя минутки выслушать меня? en Dear friend, do you have a minute to hear me out?
            string Alchemist_3 = this.GetLocalization("Chat.Alchemist_3").Value; // ru У тебя получилось достать картину? en Have you succeded in finding the picture?
            string Alchemist_4 = this.GetLocalization("Chat.Alchemist_4").Value; // ru В таком случае я буду ждать. Это святилище находится где-то в небесах. en In that case, I’ll wait. The shrine is somewhere up in the sky, by the way.
            string Alchemist_8 = this.GetLocalization("Chat.Alchemist_8").Value; // ru Ты уже раздобыл цветы папоротника? en Have you obtained the fern flowers yet?
            string Alchemist_9 = this.GetLocalization("Chat.Alchemist_9").Value; // ru Продолжай поиски, мне нужно ровно 5 штук. en Keep up the search, I need just 5 of them.
            string Alchemist_11 = this.GetLocalization("Chat.Alchemist_11").Value; // ru Хорошо, в таком случае я добавлю смерть-травы...Готово, позволь мне проверить результат...Ох, что-то мне нехорошо... en Okay, in that case I’ll add some deathweed… Okay, it’s done, let’s check the result… Oh, something’s wrong, friend, I don’t feel so good…
            string Alchemist_12 = this.GetLocalization("Chat.Alchemist_12").Value; // ru Тогда тебе придется принести 30 цветков, чтобы я смог завершить варку. Удачи! en Okay, then you bring me 30 of them so I can finish the brewing. Good luck!
            string Alchemist_13 = this.GetLocalization("Chat.Alchemist_13").Value; // ru Днецветы сами себя не соберут, мой друг. Ты уже добыл их? en Dayblooms won’t gather themselves, friend. Have you got them yet?
            string Alchemist_14 = this.GetLocalization("Chat.Alchemist_14").Value; // ru Стало быть, ты знаешь, чем заняться в свободное время. Жду тебя с цветками. en You sure know what to do in your free time, huh. I’m waiting for the flowers.
            string Alchemist_16 = this.GetLocalization("Chat.Alchemist_16").Value; // ru Знаешь, ты сильно помог мне с тех пор, как появился в этих краях. Я думаю, ты заслужил узнать о величайшем артефакте алхимии. Вот уже 400 лет в моей семье хранится истинный филосовский камень. Среди прочих его свойств есть одно занимательное - он способен спасти тебя, когда ты уже одной ногой в могиле, однако после этого он разряжается. en You know, you've been a great help since I arrived to these lands. I think you deserve the knowledge of the greatest artifact of alchemy. For 400 years my family's kept the true philosopher's stone. Among its properties,there is a very fascinating one – it can save you when you’re at death's door, however, it has to be charged afterwards.
            string Alchemist_20 = this.GetLocalization("Chat.Alchemist_20").Value; // ru Нет, к сожалению, мне пока не удалось раскрыть тайну эфира. Приходи позже. en No, sadly, I'm not done solving the mystery of aether yet. Come back later.
            string Alchemist_23 = this.GetLocalization("Chat.Alchemist_23").Value; // ru Отлично, я сейчас же начну заряжать камень. Приходи позже. en Cool, I’ll start charging the stone right now. Come back later.
            string AlchemistButton_1 = this.GetLocalization("Chat.AlchemistButton_1").Value; // ru Говори, что тебе нужно en Tell me what do you need
            string AlchemistButton_2 = this.GetLocalization("Chat.AlchemistButton_2").Value; // ru Понял en Got it
            string AlchemistButton_3 = this.GetLocalization("Chat.AlchemistButton_3").Value; // ru Именно так en Skies lost a picture
            string AlchemistButton_4 = this.GetLocalization("Chat.AlchemistButton_4").Value; // ru Картину непросто найти en It's not that easy to find the picture
            string AlchemistButton_5 = this.GetLocalization("Chat.AlchemistButton_5").Value; // ru Нужно что-то ещё? en What's the next task?
            string AlchemistButton_6 = this.GetLocalization("Chat.AlchemistButton_6").Value; // ru Без проблем en No problem
            string AlchemistButton_7 = this.GetLocalization("Chat.AlchemistButton_7").Value; // ru Вот цветки папоротника en Here are fern flowers
            string AlchemistButton_8 = this.GetLocalization("Chat.AlchemistButton_8").Value; // ru Нужно больше времени en I need more time to do this
            string AlchemistButton_9 = this.GetLocalization("Chat.AlchemistButton_9").Value; // ru Днецветы en Dayblooms
            string AlchemistButton_10 = this.GetLocalization("Chat.AlchemistButton_10").Value; // ru Смерть-траву en Deathweed
            string AlchemistButton_11 = this.GetLocalization("Chat.AlchemistButton_11").Value; // ru Днецветы, как по заказу en Dayblooms, as you ordered
            string AlchemistButton_12 = this.GetLocalization("Chat.AlchemistButton_12").Value; // ru Дай ещё немного времени en Give me a bit more time
            string AlchemistButton_13 = this.GetLocalization("Chat.AlchemistButton_13").Value; // ru Но зачем вам я? en But why do you need me?
            string AlchemistButton_14 = this.GetLocalization("Chat.AlchemistButton_14").Value; // ru Я отыщу любой артефакт! en There are no artifacts I won't find
            string AlchemistButton_15 = this.GetLocalization("Chat.AlchemistButton_15").Value; // ru Вот твоя скрижаль en Here is tabula
            string AlchemistButton_16 = this.GetLocalization("Chat.AlchemistButton_16").Value; // ru Как идет перевод? en How's translation going?
            string AlchemistButton_17 = this.GetLocalization("Chat.AlchemistButton_17").Value; // ru Я хочу зарядить камень en I'd like to charge the stone
            string AlchemistButton_18 = this.GetLocalization("Chat.AlchemistButton_18").Value; // ru Камень готов? en Is the stone ready?
        }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Alchemist");
            //DisplayName.AddTranslation(GameCulture.Russian, "Алхимик");
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
                this.GetLocalizedValue("Name.Rizo"), // Language.GetTextValue("Mods.Bismuth.AlchemistName_1");
                this.GetLocalizedValue("Name.Albert"), // Language.GetTextValue("Mods.Bismuth.AlchemistName_2");
                this.GetLocalizedValue("Name.Bernando"), // Language.GetTextValue("Mods.Bismuth.AlchemistName_3");
                this.GetLocalizedValue("Name.Seefeld"), // Language.GetTextValue("Mods.Bismuth.AlchemistName_4");
                this.GetLocalizedValue("Name.Robert") // Language.GetTextValue("Mods.Bismuth.AlchemistName_5");
        };
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D available = ModContent.Request<Texture2D>("Bismuth/UI/AvailableQuest").Value;
            Texture2D active = ModContent.Request<Texture2D>("Bismuth/UI/ActiveQuest").Value;
            if ((Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().SunriseQuest <= 10 && BismuthWorld.downedSkeletron) || (Main.LocalPlayer.GetModPlayer<Quests>().SunriseQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest <= 10) || (Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().PhilosopherStoneQuest <= 10))
                spriteBatch.Draw(available, NPC.position - Main.screenPosition + new Vector2(12, -36), Color.White);
            if ((Main.LocalPlayer.GetModPlayer<Quests>().SunriseQuest > 10 && Main.LocalPlayer.GetModPlayer<Quests>().SunriseQuest < 100) || (Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest > 10 && Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest < 100) || (Main.LocalPlayer.GetModPlayer<Quests>().PhilosopherStoneQuest > 10 && Main.LocalPlayer.GetModPlayer<Quests>().PhilosopherStoneQuest < 100))
                spriteBatch.Draw(active, NPC.position - Main.screenPosition + new Vector2(8, -40), Color.White);

        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            #region strings
            string Alchemist_4 = this.GetLocalization("Chat.Alchemist_4").Value;
            string Alchemist_9 = this.GetLocalization("Chat.Alchemist_9").Value;
            string Alchemist_12 = this.GetLocalization("Chat.Alchemist_12").Value;
            string Alchemist_14 = this.GetLocalization("Chat.Alchemist_14").Value;
            string Alchemist_20 = this.GetLocalization("Chat.Alchemist_20").Value;
            string Alchemist_23 = this.GetLocalization("Chat.Alchemist_23").Value;
            string AlchemistButton_1 = this.GetLocalization("Chat.AlchemistButton_1").Value;
            string AlchemistButton_2 = this.GetLocalization("Chat.AlchemistButton_2").Value;
            string AlchemistButton_3 = this.GetLocalization("Chat.AlchemistButton_3").Value;
            string AlchemistButton_4 = this.GetLocalization("Chat.AlchemistButton_4").Value;
            string AlchemistButton_5 = this.GetLocalization("Chat.AlchemistButton_5").Value;
            string AlchemistButton_6 = this.GetLocalization("Chat.AlchemistButton_6").Value;
            string AlchemistButton_7 = this.GetLocalization("Chat.AlchemistButton_7").Value;
            string AlchemistButton_8 = this.GetLocalization("Chat.AlchemistButton_8").Value;
            string AlchemistButton_9 = this.GetLocalization("Chat.AlchemistButton_9").Value;
            string AlchemistButton_10 = this.GetLocalization("Chat.AlchemistButton_10").Value; 
            string AlchemistButton_11 = this.GetLocalization("Chat.AlchemistButton_11").Value; 
            string AlchemistButton_12 = this.GetLocalization("Chat.AlchemistButton_12").Value; 
            string AlchemistButton_13 = this.GetLocalization("Chat.AlchemistButton_13").Value; 
            string AlchemistButton_14 = this.GetLocalization("Chat.AlchemistButton_14").Value; 
            string AlchemistButton_15 = this.GetLocalization("Chat.AlchemistButton_15").Value; 
            string AlchemistButton_16 = this.GetLocalization("Chat.AlchemistButton_16").Value; 
            string AlchemistButton_17 = this.GetLocalization("Chat.AlchemistButton_17").Value; 
            string AlchemistButton_18 = this.GetLocalization("Chat.AlchemistButton_18").Value;
            #endregion
            Quests quests = (Quests)Main.player[Main.myPlayer].GetModPlayer<Quests>();
            if (Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest != 200)
            {
                if (Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest == 30)
                    button = AlchemistButton_9;
                else
                    button = Lang.inter[28].Value;
                if (Main.LocalPlayer.GetModPlayer<Quests>().SunriseQuest == 0 && Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest == 100 && BismuthWorld.downedSkeletron)
                    button2 = AlchemistButton_1;
                if (Main.LocalPlayer.GetModPlayer<Quests>().SunriseQuest == 5)
                    button2 = AlchemistButton_2;
                if (Main.LocalPlayer.GetModPlayer<Quests>().SunriseQuest == 20)
                {
                    bool temp = false;
                    for (int num66 = 0; num66 < 58; num66++)
                    {
                        if (Main.LocalPlayer.inventory[num66].type == ModContent.ItemType<SunrisePicture>() && Main.LocalPlayer.inventory[num66].stack > 0)
                        {
                            button2 = AlchemistButton_3;
                            temp = true;
                        }
                    }
                    if (!temp && Main.npcChatText != Alchemist_4)
                        button2 = AlchemistButton_4;
                }
                if (Main.LocalPlayer.GetModPlayer<Quests>().SunriseQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest == 0)
                    button2 = AlchemistButton_5;
                if (Main.LocalPlayer.GetModPlayer<Quests>().SunriseQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest == 5)
                    button2 = AlchemistButton_6;
                if (Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest == 20)
                {
                    bool temp = false;
                    for (int num66 = 0; num66 < 58; num66++)
                    {
                        if (Main.LocalPlayer.inventory[num66].type == ModContent.ItemType<FernFlower>() && Main.LocalPlayer.inventory[num66].stack >= 5)
                        {
                            temp = true;
                            button2 = AlchemistButton_7;
                        }
                    }
                    if (!temp && Main.npcChatText != Alchemist_9)
                        button2 = AlchemistButton_8;
                }
                if (Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest == 30)
                {
                    button = AlchemistButton_9;
                    button2 = AlchemistButton_10;
                }
                if (Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest == 40)
                {
                    bool temp = false;
                    for (int num66 = 0; num66 < 58; num66++)
                    {
                        if (Main.LocalPlayer.inventory[num66].type == ItemID.Daybloom && Main.LocalPlayer.inventory[num66].stack >= 30)
                        {
                            button2 = AlchemistButton_11;
                            temp = true;
                        }
                    }
                    if (!temp && Main.npcChatText != Alchemist_12 && Main.npcChatText != Alchemist_14)
                        button2 = AlchemistButton_12;
                }
                if (Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().PhilosopherStoneQuest == 0)
                    button2 = AlchemistButton_13;
                if (Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().PhilosopherStoneQuest == 5)
                    AlchemistButton_14 = this.GetLocalization("Chat.AlchemistButton_14").Value;
                if (Main.LocalPlayer.GetModPlayer<Quests>().PhilosopherStoneQuest == 5)
                {
                    button2 = AlchemistButton_14;
                }
                if (Main.LocalPlayer.GetModPlayer<Quests>().PhilosopherStoneQuest == 20)
                {
                    for (int num66 = 0; num66 < 58; num66++)
                    {
                        if (Main.LocalPlayer.inventory[num66].type == ModContent.ItemType<TabulaSmaragdina>() && Main.LocalPlayer.inventory[num66].stack > 0)
                        {
                            button2 = AlchemistButton_15;
                        }
                    }
                }
                if (Main.LocalPlayer.GetModPlayer<Quests>().PhilosopherStoneQuest == 30 && Main.npcChatText != Alchemist_20)
                {
                    button2 = AlchemistButton_16;
                }
                if (Main.LocalPlayer.GetModPlayer<Quests>().PhilosopherStoneQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().PhilosopherStoneCharging == 0 && Main.npcChatText != Alchemist_23)
                {
                    button2 = AlchemistButton_17;
                }
                if (Main.LocalPlayer.GetModPlayer<Quests>().PhilosopherStoneCharging == 10 && Main.LocalPlayer.GetModPlayer<BismuthPlayer>().WaitStoneCharging >= 1800)
                {
                    button2 = AlchemistButton_18;
                }
            }
        }
        public override void AddShops()
        {
            var KilledEoC = new Condition("KilledEoC", () => Main.LocalPlayer.GetModPlayer<BismuthPlayer>().KilledEoC);
            var PhilosopherStoneQuest = new Condition("PhilosopherStoneQuest", () => Main.LocalPlayer.GetModPlayer<Quests>().PhilosopherStoneQuest == 100);

            NPCShop shop = new(Type, "AlchemistShop");

            shop.Add(ModContent.ItemType<EmptyAmulet>());
            shop.Add(ModContent.ItemType<PotionOfHumanity>());

            shop.Add(ModContent.ItemType<Alembic>(), KilledEoC);
            shop.Add(ModContent.ItemType<AlchemistsBelt>(), PhilosopherStoneQuest);

            shop.Register();
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            string Alchemist_11 = this.GetLocalization("Chat.Alchemist_11").Value;
            string Alchemist_12 = this.GetLocalization("Chat.Alchemist_12").Value;
            Quests quests = (Quests)Main.player[Main.myPlayer].GetModPlayer<Quests>();
            if (firstButton)
            {
                if (Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest == 30)
                {
                    Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest = 40;
                    Main.npcChatText = Alchemist_12;
                }
                else
                    shopName = "AlchemistShop";
            }
            else
            {
                if (Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest == 30)
                {
                    Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest = 190;
                    Main.npcChatText = Alchemist_11;
                }
                else if (Main.LocalPlayer.GetModPlayer<Quests>().PhilosopherStoneQuest == 100)
                    quests.PholosopherStoneCharging();
                else
                    quests.AlchemistQuests();
            }                
        }
        public override string GetChat()
        {
            string Alchemist_1 = this.GetLocalization("Chat.Alchemist_1").Value;
            string Alchemist_3 = this.GetLocalization("Chat.Alchemist_3").Value;
            string Alchemist_8 = this.GetLocalization("Chat.Alchemist_8").Value;
            string Alchemist_13 = this.GetLocalization("Chat.Alchemist_13").Value;
            string Alchemist_16 = this.GetLocalization("Chat.Alchemist_16").Value;
            string AlchemistNQ_1 = this.GetLocalization("Chat.AlchemistNQ_1").Value; 
            string AlchemistNQ_2 = this.GetLocalization("Chat.AlchemistNQ_2").Value; 
            string AlchemistNQ_3 = this.GetLocalization("Chat.AlchemistNQ_3").Value; 
            string AlchemistNQ_4 = this.GetLocalization("Chat.AlchemistNQ_4").Value;

            if (Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().SunriseQuest == 0 && BismuthWorld.downedSkeletron)
                return Alchemist_1;
            else if (Main.LocalPlayer.GetModPlayer<Quests>().SunriseQuest == 20)
                return Alchemist_3;
            else if (Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest == 20)
                return Alchemist_8;
            else if (Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest == 40)
                return Alchemist_13;
            else if (Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().PhilosopherStoneQuest == 0)
                return Alchemist_16;
            else
            {
                if (NPC.FindFirstNPC(NPCID.WitchDoctor) >= 0 && WorldGen.genRand.Next(0, 4) == 0)
                {
                    return string.Format(this.GetLocalization("Chat.AlchemistNQ_2").Value, Main.npc[NPC.FindFirstNPC(NPCID.WitchDoctor)].GivenName);
                }
                else switch (WorldGen.genRand.Next(0, 3))
                    {
                        case 0:
                            return AlchemistNQ_1;
                        case 1:
                            return AlchemistNQ_3;
                        default:
                            return AlchemistNQ_4;
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
        public override bool CheckConditions(int left, int right, int top, int bottom)
        {
            return false;
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
                    if (Main.LocalPlayer.GetModPlayer<Quests>().SunriseQuest < 10)
                        Main.LocalPlayer.GetModPlayer<Quests>().SunriseQuest = 0;
                    if (Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest < 10)
                        Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest = 0;
                    if (Main.LocalPlayer.GetModPlayer<Quests>().PhilosopherStoneQuest < 10)
                        Main.LocalPlayer.GetModPlayer<Quests>().PhilosopherStoneQuest = 0;
                }
            }
            else
            {
                if (Main.LocalPlayer.GetModPlayer<Quests>().SunriseQuest < 10)
                    Main.LocalPlayer.GetModPlayer<Quests>().SunriseQuest = 0;
                if (Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest < 10)
                    Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest = 0;
                if (Main.LocalPlayer.GetModPlayer<Quests>().PhilosopherStoneQuest < 10)
                    Main.LocalPlayer.GetModPlayer<Quests>().PhilosopherStoneQuest = 0;
            }
            if (Main.LocalPlayer.GetModPlayer<Quests>().PotionQuest == 200)
            {
                NPC.NewNPC(NPC.GetSource_FromThis(), (int)NPC.position.X, (int)NPC.position.Y + 36, ModContent.NPCType<AlchemistDeath>(), 0, NPC.spriteDirection);
                NPC.active = false;
            }
        }
    }
}
