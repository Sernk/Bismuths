using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Bismuth.Utilities;
using Bismuth.Content.Items.Armor;
using Bismuth.Content.Items.Other;
using Bismuth.Content.Items.Placeable;

namespace Bismuth.Content.NPCs
{
    //[AutoloadHead]
    public class BabaYaga : ModNPC
    {
        public override void Load()
        {
            string SwampWitchName_1 = this.GetLocalization("Chat.SwampWitchName_1").Value; //Ru: Хагата En: Hagata
            string SwampWitchName_2 = this.GetLocalization("Chat.SwampWitchName_2").Value; //Ru: Пряха En: Priaha
            string SwampWitchName_3 = this.GetLocalization("Chat.SwampWitchName_3").Value; //Ru: Шептуха En: Whispera
            string SwampWitchName_4 = this.GetLocalization("Chat.SwampWitchName_4").Value; //Ru: Тельза En: Telsa
            string SwampWitchName_5 = this.GetLocalization("Chat.SwampWitchName_5").Value; //Ru: Флемет En: Flemet

            string SwampWitchAnsv_1 = this.GetLocalization("Chat.SwampWitchAnsv_1").Value; //Ru: Что вам нужно от меня? En: What do you need from me?
            string SwampWitchAnsv_2 = this.GetLocalization("Chat.SwampWitchAnsv_2").Value; //Ru: Думаю, я справлюсь En: I think I can do it
            string SwampWitchAnsv_3 = this.GetLocalization("Chat.SwampWitchAnsv_3").Value; //Ru: Фолиант у меня En: I found the book
            string SwampWitchAnsv_3_2 = this.GetLocalization("Chat.SwampWitchAnsv_3_2").Value; // Ru: Я продолжу поиски En: I'll continue my searches
            string SwampWitchAnsv_4 = this.GetLocalization("Chat.SwampWitchAnsv_4").Value; //Ru: Как продвигаются исследования? En: How's research going?
            string SwampWitchAnsv_5 = this.GetLocalization("Chat.SwampWitchAnsv_5").Value; //Ru: Где спрятан этот камень? En: Where can I find the stone?
            string SwampWitchAnsv_6 = this.GetLocalization("Chat.SwampWitchAnsv_6").Value; //Ru: Я достану камень! En: I'll get the stone!
            string SwampWitchAnsv_7 = this.GetLocalization("Chat.SwampWitchAnsv_7").Value; //Ru: Да, вот он En: Yes, take it
            string SwampWitchAnsv_8 = this.GetLocalization("Chat.SwampWitchAnsv_8").Value; //Ru: Это сложнее, чем кажется En: It is harder than it looks
            string SwampWitchAnsv_9 = this.GetLocalization("Chat.SwampWitchAnsv_9").Value; //Ru: Я оставлю его себе En: Yes, but you don't deserve it
            string SwampWitchAnsv_10 = this.GetLocalization("Chat.SwampWitchAnsv_10").Value; //Ru: Я заберу твою жизнь! En: Be ready to lose your life!

            string SwampWitch_1 = this.GetLocalization("Chat.SwampWitch_1").Value; // Ru: Юный герой... Я знала, что ты придешь... Остановись же и выслушай меня, и я клянусь - ты будешь вознагражден En: Young hero… I knew you’d come… Hear me out, I swear - you will not regret it
            string SwampWitch_3 = this.GetLocalization("Chat.SwampWitch_3").Value; // Ru: Ты уже принес книгу? En: Have you brought the book?
            string SwampWitch_4 = this.GetLocalization("Chat.SwampWitch_4").Value; // Ru: Мне нужна книга, чтобы продолжить мои исследования. En: I need the book to continue my research.
            string SwampWitch_6 = this.GetLocalization("Chat.SwampWitch_6").Value; // Ru: Мои исследования ещё не завершены - приходи позже. En: My research is not yet over – come back later.
            string SwampWitch_7 = this.GetLocalization("Chat.SwampWitch_7").Value; // Ru: А, это ты! Как раз вовремя - я только закончила чтение манускрипта. Теперь ничто не помешает тебе заполучить камень. En: Ah, if it isn’t the young hero! You’re right on time – I just finished reading the tome. Now nothing is going to stop you from getting the stone.
            string SwampWitch_9 = this.GetLocalization("Chat.SwampWitch_9").Value; // Ru: Как продвигаются поиски камня? En: Did you find the stone?
            string SwampWitch_10 = this.GetLocalization("Chat.SwampWitch_10").Value; // Ru: Принеси мне камень - и ты будешь вознагражден En: Bring me the stone – and you’ll be rewarded.
            string SwampWitch_12 = this.GetLocalization("Chat.SwampWitch_12").Value; //Ru: Отличная работа, юный герой! Я держу своё слово - эти зелья помогут тебе уберечься от множества ядов и болезней. Если тебе понадобятся ещё - ты всегда можешь купить их у меня. En: Excellent work, young hero! I stay true to my word – these potions will keep you safe from many poisons and diseases. If you need more – you can always buy them here.

            string SwampWitchNQ_1 = this.GetLocalization("Chat.SwampWitchNQ_1").Value; // Ru: Щепотка поганки, каблук башмака... En: Pinch of deathcup, heel of shoe
            string SwampWitchNQ_2 = this.GetLocalization("Chat.SwampWitchNQ_2").Value; // Ru: Да поможет тебе магия, герой.. En: Let the magic guide you, hero.
            string SwampWitchNQ_3 = this.GetLocalization("Chat.SwampWitchNQ_3").Value; // Ru: Кто такой {0}? Его магия сильна. En: Who is {0}? His magic is strong.
            string SwampWitchNQ_4 = this.GetLocalization("Chat.SwampWitchNQ_4").Value; // Ru: Ты не видел нигде серебряных туфелек? En: Have you seen silver shoes around anywhere?
        }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Swamp Witch");
            //DisplayName.AddTranslation(GameCulture.Russian, "Болотная ведьма");
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 26;
            NPC.height = 48;
            NPC.aiStyle = -1;
            NPC.damage = 10;
            NPC.defense = 20;
            NPC.lifeMax = 1000;
            NPC.dontTakeDamageFromHostiles = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0f;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D available = ModContent.Request<Texture2D>("Bismuth/UI/AvailableQuest").Value;
            Texture2D active = ModContent.Request<Texture2D>("Bismuth/UI/ActiveQuest").Value;
            if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest <= 10 || (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest == 100 && Main.LocalPlayer.GetModPlayer<BismuthPlayer>().BosWait == 86400 && Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest <= 10))
                spriteBatch.Draw(available, NPC.position - Main.screenPosition + new Vector2(8, -34), Color.White);
            if ((Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest > 10 && Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest < 100) || (Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest > 10 && Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest < 100))
                spriteBatch.Draw(active, NPC.position - Main.screenPosition + new Vector2(4, -38), Color.White);

        }     
        public override string GetChat()
        {
            string SwampWitch_1 = this.GetLocalization("Chat.SwampWitch_1").Value; 
            string SwampWitch_3 = this.GetLocalization("Chat.SwampWitch_3").Value; 
            string SwampWitch_7 = this.GetLocalization("Chat.SwampWitch_7").Value; 
            string SwampWitch_9 = this.GetLocalization("Chat.SwampWitch_9").Value; 
            string SwampWitchNQ_1 = this.GetLocalization("Chat.SwampWitchNQ_1").Value; 
            string SwampWitchNQ_2 = this.GetLocalization("Chat.SwampWitchNQ_2").Value; 
            string SwampWitchNQ_3 = this.GetLocalization("Chat.SwampWitchNQ_3").Value; 
            string SwampWitchNQ_4 = this.GetLocalization("Chat.SwampWitchNQ_4").Value; 

            if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest == 0)
                return SwampWitch_1;
            else if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest == 20)
                return SwampWitch_3;
            else if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest == 0 && Main.LocalPlayer.GetModPlayer<BismuthPlayer>().BosWait == 86400)
                return SwampWitch_7;
            else if (Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest == 20)
                return SwampWitch_9;
            else
            {
                if (NPC.FindFirstNPC(ModContent.NPCType<Priest>()) >= 0 && WorldGen.genRand.Next(0, 4) == 0)
                    return string.Format(this.GetLocalization("Chat.SwampWitchNQ_3").Value, Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Priest>())].GivenName);
                else switch (WorldGen.genRand.Next(0, 3))
                {
                   case 0:
                   return SwampWitchNQ_1;
                   case 1:
                   return SwampWitchNQ_2;
                   default:
                   return SwampWitchNQ_4;
                }
            }
        }
        public override void AddShops()
        {
            var Elessar = new Condition("DownedPlantBoss", () => Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest == 100);

            NPCShop shop = new(Type, "BabaYagaShop");

            shop.Add(ModContent.ItemType<Ushanka>());
            shop.Add(ModContent.ItemType<Valenki>());
            shop.Add(ModContent.ItemType<WallCarpet>());
            shop.Add(ModContent.ItemType<Pancakes>());

            shop.Add(ModContent.ItemType<Panacea>(), Elessar);

            shop.Register();
        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            string SwampWitchAnsv_1 = this.GetLocalization("Chat.SwampWitchAnsv_1").Value;
            string SwampWitchAnsv_2 = this.GetLocalization("Chat.SwampWitchAnsv_2").Value;
            string SwampWitchAnsv_3 = this.GetLocalization("Chat.SwampWitchAnsv_3").Value;
            string SwampWitchAnsv_3_2 = this.GetLocalization("Chat.SwampWitchAnsv_3_2").Value;
            string SwampWitchAnsv_4 = this.GetLocalization("Chat.SwampWitchAnsv_4").Value;
            string SwampWitchAnsv_5 = this.GetLocalization("Chat.SwampWitchAnsv_5").Value;
            string SwampWitchAnsv_6 = this.GetLocalization("Chat.SwampWitchAnsv_6").Value;
            string SwampWitchAnsv_7 = this.GetLocalization("Chat.SwampWitchAnsv_7").Value;
            string SwampWitchAnsv_8 = this.GetLocalization("Chat.SwampWitchAnsv_8").Value;
            string SwampWitchAnsv_9 = this.GetLocalization("Chat.SwampWitchAnsv_9").Value;
            string SwampWitchAnsv_10 = this.GetLocalization("Chat.SwampWitchAnsv_10").Value;
            string SwampWitch_4 = this.GetLocalization("Chat.SwampWitch_4").Value;
            string SwampWitch_6 = this.GetLocalization("Chat.SwampWitch_6").Value;
            string SwampWitch_10 = this.GetLocalization("Chat.SwampWitch_10").Value;
            if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest == 0)
            {
                button2 = SwampWitchAnsv_1;
            }
            if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest == 5)
            {
                button2 = SwampWitchAnsv_2;
            }
            if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest == 20 && Main.npcChatText != SwampWitch_4)
            {
                Player player = Main.player[Main.myPlayer];
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (player.inventory[num66].type == Mod.Find<ModItem>("BookOfSecrets").Type && player.inventory[num66].stack > 0)
                    {
                        button2 = SwampWitchAnsv_3;
                        temp = true;
                    }
                }
                if (!temp)
                {
                    button2 = SwampWitchAnsv_3_2;
                }
            }
            if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest == 0)
            {
                if (Main.LocalPlayer.GetModPlayer<BismuthPlayer>().BosWait < 86400 && Main.npcChatText != SwampWitch_6)
                    button2 = SwampWitchAnsv_4;
              else if (Main.LocalPlayer.GetModPlayer<BismuthPlayer>().BosWait == 86400 && Main.npcChatText != SwampWitch_6)
                    button2 = SwampWitchAnsv_5;
            }
            if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest == 5)
            {
                button2 = SwampWitchAnsv_6;
            }
            if (Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest == 200)
            {
                button = SwampWitchAnsv_10;
            }
            if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Main.player[Main.myPlayer].inventory[num66].type == ModContent.ItemType<UnchargedElessar>() && Main.player[Main.myPlayer].inventory[num66].stack > 0 && Main.npcChatText != SwampWitch_10)
                    {
                          button = SwampWitchAnsv_7;
                          button2 = SwampWitchAnsv_9;
                          temp = true;
                    }
                }
                if (!temp)
                {
                    button = Lang.inter[28].Value;
                    if (Main.npcChatText != SwampWitch_10)
                        button2 = SwampWitchAnsv_8;
                }
            }
            else if (Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest != 200)
                button = Lang.inter[28].Value;

        }
        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            string SwampWitch_12 = this.GetLocalization("Chat.SwampWitch_12").Value;
            Quests quests = (Quests)Main.player[Main.myPlayer].GetModPlayer<Quests>();
            if (firstButton)
            {
                if (Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest == 20)
                {
                    bool temp = false;
                    for (int num66 = 0; num66 < 58; num66++)
                    {
                        if (Main.player[Main.myPlayer].inventory[num66].type == ModContent.ItemType<UnchargedElessar>() && Main.player[Main.myPlayer].inventory[num66].stack > 0)
                        {
                              temp = true;
                              Main.LocalPlayer.inventory[num66].stack--;
                              Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest = 90;
                              Main.npcChatText = SwampWitch_12;
                        }
                    }
                    if (!temp)
                    {
                        shopName = "BabaYagaShop";
                    }
                }
                else if (Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest == 200 && Main.LocalPlayer.GetModPlayer<BismuthPlayer>().witchsecondatt)
                {
                    NPC.NewNPC(NPC.GetSource_FromThis(), BismuthWorld.WitchSpawnX, BismuthWorld.WitchSpawnY, ModContent.NPCType<EvilBabaYaga>());
                    NPC.active = false;
                }
                else
                  shopName = "BabaYagaShop";
            }
            else
              quests.BabaYagaQuests();
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
            string SwampWitchName_1 = this.GetLocalization("Chat.SwampWitchName_1").Value;
            string SwampWitchName_2 = this.GetLocalization("Chat.SwampWitchName_2").Value;
            string SwampWitchName_3 = this.GetLocalization("Chat.SwampWitchName_3").Value;
            string SwampWitchName_4 = this.GetLocalization("Chat.SwampWitchName_4").Value;
            string SwampWitchName_5 = this.GetLocalization("Chat.SwampWitchName_5").Value;

            if (!NPC.HasGivenName) // TownNPCName() решил выебнуться
            {
                switch (WorldGen.genRand.Next(0, 5))
                {
                    case 0:
                        NPC.GivenName = SwampWitchName_1;
                        break;
                    case 1:
                        NPC.GivenName = SwampWitchName_2;
                        break;
                    case 2:
                        NPC.GivenName = SwampWitchName_3;
                        break;
                    case 3:
                        NPC.GivenName = SwampWitchName_4;
                        break;
                    default:
                        NPC.GivenName = SwampWitchName_5;
                        break;
                }
            }
            if (NPC.homeTileX == -1 || NPC.homeTileY == -1)
            {
                NPC.homeTileX = NPC.Center.ToTileCoordinates().X;
                NPC.homeTileY = NPC.Center.ToTileCoordinates().Y;
            }
            NPC.breath = 100;
            NPC.life = NPC.lifeMax;
            NPC.dontTakeDamage = true;
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
                    if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest < 10)
                        Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest = 0;
                    if (Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest < 10)
                        Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest = 0;
                }
            }
            else
            {
                if (Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest < 10)
                    Main.LocalPlayer.GetModPlayer<Quests>().BookOfSecretsQuest = 0;
                if (Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest < 10)
                    Main.LocalPlayer.GetModPlayer<Quests>().ElessarQuest = 0;
            }
        }
    }
}