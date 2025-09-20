using Bismuth.Utilities;
using Bismuth.Utilities.ModSupport;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.NPCs
{
    [AutoloadHead]
    public class ImperianConsul : ModNPC
    {
        public override void Load()
        {
            string Consul_1 = this.GetLocalization("Chat.Consul_1").Value; // Ru: О, у нас пополнение! Добро пожаловать, боец, ты находишься в единственном оплоте спокойствия на многие километры вокруг - в Имперском городе! Я уверен, ты послужишь на благо Империи, а пока осмотрись вокруг. Гравировка класса поможет тебе выбрать свой путь, после наведайся к главнокомандующему за экипировкой
                                                                           // En: Oh, we have a rookie! Welcome, fighter. You’re standing in the only safe haven for miles away – the Imperial city! I’m sure you’ll serve the Empire well, for now, take a look around. The class engraving will help you choose your path, visit the Commander to get your equipment once you’re done.

            string ConsulNQ_1 = this.GetLocalization("Chat.ConsulNQ_1").Value; // Ru: Пришёл, увидел, сдал квест! En: You came, you saw, you completed the quest!
            string ConsulNQ_2 = this.GetLocalization("Chat.ConsulNQ_2").Value; // Ru: Все дороги ведут в наш город. En: Every road leads to our city.
            string ConsulNQ_3 = this.GetLocalization("Chat.ConsulNQ_3").Value; // Ru: Если ты ищешь задание - поспрашивай жителей нашего города En: If you need a quest – take one from our citizens

            string ConsulAnsv_1 = this.GetLocalization("Chat.ConsulAnsv_1").Value; // Ru: Так точно! En: Yes, sir!
            string ConsulAnsv_2 = this.GetLocalization("Chat.ConsulAnsv_2").Value; // Ru: Я хочу поговорить о {0} En: I want to talk about {0}
            string ConsulAnsv_3 = this.GetLocalization("Chat.ConsulAnsv_3").Value; // Ru: Городу нужен новый священник... En: Town needs new priest...
            string ConsulAnsv_4 = this.GetLocalization("Chat.ConsulAnsv_4").Value; // Ru: Нет, спасибо (без РПГ) En: No, thanks (non-RPG gameplay)
        }
        public override void SetStaticDefaults()
        {
            NPCID.Sets.NoTownNPCHappiness[NPC.type] = true;
        }
        public override void SetDefaults()
        {
            NPC.townNPC = true;
            NPC.friendly = true;
            NPC.width = 32;
            NPC.height = 42;
            NPC.aiStyle = -1;
            NPC.defense = 20;
            NPC.lifeMax = 1000;
            NPC.dontTakeDamageFromHostiles = true;
            NPC.HitSound = SoundID.NPCHit1;
            NPC.DeathSound = SoundID.NPCDeath1;
            NPC.knockBackResist = 0f;
        }
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            var quests = QuestRegistry.GetAvailableQuests(Main.LocalPlayer, BaseQuest.ImperialConsul);
            bool showAvailable = Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest <= 10;
            bool showActive = Main.LocalPlayer.GetModPlayer<Quests>().NewPriestQuest == 20 || Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 20;

            foreach (var quest in quests)
            {
                quest.IsActiveQuestUIIcon(showAvailable, showActive, spriteBatch, NPC, Main.LocalPlayer);
            }
            if (!quests.Any())
            {
                Texture2D available = ModContent.Request<Texture2D>("Bismuth/UI/AvailableQuest").Value;
                Texture2D active = ModContent.Request<Texture2D>("Bismuth/UI/ActiveQuest").Value;

                if (showAvailable)
                {
                    spriteBatch.Draw(available, NPC.position - Main.screenPosition + new Vector2(8, -34), Color.White);
                }
                if (showActive)
                {
                    spriteBatch.Draw(active, NPC.position - Main.screenPosition + new Vector2(4, -38), Color.White);
                }
            }
        }
        public override List<string> SetNPCNameList() => new List<string>()
        {
            this.GetLocalizedValue("Name.Rizo"), // Language.GetTextValue("Mods.Bismuth.ConsulName_1");
            this.GetLocalizedValue("Name.Albert"), // Language.GetTextValue("Mods.Bismuth.ConsulName_2");
            this.GetLocalizedValue("Name.Bernando"), // Language.GetTextValue("Mods.Bismuth.ConsulName_3");
            this.GetLocalizedValue("Name.Seefeld"), // Language.GetTextValue("Mods.Bismuth.ConsulName_4");
            this.GetLocalizedValue("Name.Sqt") // Language.GetTextValue("Mods.Bismuth.ConsulName_5");
        };
        public override string GetChat()
        {
            string Consul_1 = this.GetLocalization("Chat.Consul_1").Value;
            string ConsulNQ_1 = this.GetLocalization("Chat.ConsulNQ_1").Value;
            string ConsulNQ_2 = this.GetLocalization("Chat.ConsulNQ_1").Value;
            string ConsulNQ_3 = this.GetLocalization("Chat.ConsulNQ_1").Value;

            Player player = Main.player[Main.myPlayer];
            var quest = QuestRegistry.GetAvailableQuests(player, BaseQuest.ImperialConsul).FirstOrDefault();

            if (TempNPCs.ImperianConsulNewQuest && quest != null)
            {
                return quest.GetChat(NPC, player, quest.CornerItem);
            }

            if (Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest == 0)
                return Consul_1;
            else return WorldGen.genRand.Next(0, 4) switch
            {
                0 => ConsulNQ_1,
                1 => ConsulNQ_2,
                2 => ConsulNQ_2,
                _ => ConsulNQ_3,
            };
        }
        public override bool CheckConditions(int left, int right, int top, int bottom)
        {
            return false;
        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            string ConsulAnsv_1 = this.GetLocalization("Chat.ConsulAnsv_1").Value;
            string ConsulAnsv_2 = this.GetLocalization("Chat.ConsulAnsv_2").Value;
            string ConsulAnsv_3 = this.GetLocalization("Chat.ConsulAnsv_3").Value;
            string ConsulAnsv_4 = this.GetLocalization("Chat.ConsulAnsv_4").Value;

            Quests quests = (Quests)Main.player[Main.myPlayer].GetModPlayer<Quests>();
            if (Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest == 0)
            {
                button = ConsulAnsv_4;
                if(Main.LocalPlayer.GetModPlayer<BismuthPlayer>().PlayerClass == 0)
                    button2 = ConsulAnsv_1;
            }
            if (Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 20)//TO DO
                button = string.Format(this.GetLocalization("Chat.ConsulAnsv_2").Value, Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Priest>())].GivenName);
            if (Main.LocalPlayer.GetModPlayer<Quests>().NewPriestQuest == 20)
            {
                TempNPCs.ImperianConsulNewQuest = true;
                button = ConsulAnsv_3;
            }
            Player player = Main.player[Main.myPlayer];
            var quest = QuestRegistry.GetAvailableQuests(player, BaseQuest.ImperialConsul).FirstOrDefault();

            if (TempNPCs.ImperianConsulNewQuest && quest != null)
            {
                button = quest.GetButtonText(player);
            }
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            Quests quests = (Quests)Main.player[Main.myPlayer].GetModPlayer<Quests>();
            if (firstButton)
                quests.ConsulQuests();
            else if(quests.EquipmentQuest == 0 && Main.LocalPlayer.GetModPlayer<BismuthPlayer>().PlayerClass == 0)
            {
                Main.LocalPlayer.GetModPlayer<BismuthPlayer>().NoRPGGameplay = true;
                Main.LocalPlayer.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                quests.EquipmentQuest = 90;
            }
            if (TempNPCs.ImperianCommanderNewQuest)
            {
                Player player = Main.LocalPlayer;
                var quest = QuestRegistry.GetAvailableQuests(player, BaseQuest.ImperianCommander).FirstOrDefault();
                quest?.OnChatButtonClicked(player);
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
            NPC.dontTakeDamage = true;
            NPC.breath = 100;
            NPC.life = NPC.lifeMax;
            if (NPC.homeTileX == -1 || NPC.homeTileY == -1)
            {
                NPC.homeTileX = NPC.Center.ToTileCoordinates().X;
                NPC.homeTileY = NPC.Center.ToTileCoordinates().Y;
            }
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
                    if (Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest < 10)
                        Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest = 0;
                    if (Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 25)
                        Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest = 20;
                }
            }
            else
            {
                if (Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest < 10)
                    Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest = 0;
                if (Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 25)
                    Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest = 20;
            }
        }
    }
}