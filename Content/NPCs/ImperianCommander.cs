using Bismuth.Content.Items.Other;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Bismuth.Content.NPCs
{
    [AutoloadHead]
    public class ImperianCommander : ModNPC
    {
        public override void SetStaticDefaults()
        {
            NPCID.Sets.NoTownNPCHappiness[NPC.type] = true;
        }
        public override void Load()
        {
            string CommanderAnsv_1 = this.GetLocalization("Chat.CommanderAnsv_1").Value; // Ru: Вы можете выдать мне экипировку?
                                                                                         // En: Can you give me equipment?
            string CommanderAnsv_2 = this.GetLocalization("Chat.CommanderAnsv_2").Value; // Ru: Ради Империи я готов на всё!
                                                                                         // En: I'll do my best for Empire!
            string CommanderAnsv_3 = this.GetLocalization("Chat.CommanderAnsv_3").Value; // Ru: Считайте, что отчет уже у вас!
                                                                                         // En: I'll bring you this report
            string CommanderAnsv_4 = this.GetLocalization("Chat.CommanderAnsv_4").Value; // Ru: Я смог достать отчет
                                                                                         // En: Here is your report
            string CommanderAnsv_5 = this.GetLocalization("Chat.CommanderAnsv_5").Value; // Ru: Я пока не нашел разведчика
                                                                                         // En: I haven't found the scout yet
            string CommanderAnsv_6 = this.GetLocalization("Chat.CommanderAnsv_6").Value; // Ru: Что нам это даёт?
                                                                                         // En: Where does that get us?
            string Commander_2 = this.GetLocalization("Chat.Commander_2").Value; // Ru: У меня есть крайне важное задание для вас, боец.
                                                                                 // En: I have a very important task for you, fighter.
            string Commander_4 = this.GetLocalization("Chat.Commander_4").Value; // Ru: Есть какие-либо зацепки относительно того, что произошло возле замка?
                                                                                 // En: Do you have any clues as to what happened near the castle?
            string Commander_5 = this.GetLocalization("Chat.Commander_5").Value; // Ru: Возвращайтесь, как только добудете информацию
                                                                                 // En: Come back once you have the information.
            string CommanderNQ_1 = this.GetLocalization("Chat.CommanderNQ_1").Value; // Ru: Сомкнуть щиты!
                                                                                     // En: Lock your shields!
            string CommanderNQ_2 = this.GetLocalization("Chat.CommanderNQ_2").Value; // Ru: Легионеры, вы позор римской армии!
                                                                                     // En: Legionaries, you are a disgrace to the Roman Empire!
            string CommanderNQ_3 = this.GetLocalization("Chat.CommanderNQ_3").Value; // Ru: Римским солдатам запрещено умирать без разрешения!
                                                                                     // En: Roman soldiers are forbidden from dying without permission!
            string CommanderNQ_4 = this.GetLocalization("Chat.CommanderNQ_4").Value; // Ru: Обратись к {0}, он сделает тебе достойное снаряжение.
                                                                                     // En: Ask {0}, he’ll make you decent equipment.
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
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D available = ModContent.Request<Texture2D>("Bismuth/UI/AvailableQuest").Value;
            Texture2D active = ModContent.Request<Texture2D>("Bismuth/UI/ActiveQuest").Value;
            if (Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest == 30 || (Main.LocalPlayer.GetModPlayer<Quests>().ReportQuest > 10 && Main.LocalPlayer.GetModPlayer<Quests>().ReportQuest < 100))
                spriteBatch.Draw(active, NPC.position - Main.screenPosition + new Vector2(6, -44), Color.White);
            if (Main.LocalPlayer.GetModPlayer<Quests>().ReportQuest <= 10 && Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest == 100)
                spriteBatch.Draw(available, NPC.position - Main.screenPosition + new Vector2(6, -44), Color.White);
        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            string CommanderAnsv_1 = this.GetLocalization("Chat.CommanderAnsv_1").Value;
            string CommanderAnsv_2 = this.GetLocalization("Chat.CommanderAnsv_2").Value;
            string CommanderAnsv_3 = this.GetLocalization("Chat.CommanderAnsv_3").Value;
            string CommanderAnsv_4 = this.GetLocalization("Chat.CommanderAnsv_4").Value;
            string CommanderAnsv_5 = this.GetLocalization("Chat.CommanderAnsv_5").Value;
            string CommanderAnsv_6 = this.GetLocalization("Chat.CommanderAnsv_6").Value;

            string Commander_5 = this.GetLocalization("Chat.Commander_5").Value;

            Quests quests = (Quests)Main.player[Main.myPlayer].GetModPlayer<Quests>();
            if (Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest == 30)
                button = CommanderAnsv_1;
            if (Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().ReportQuest == 0)
                button = CommanderAnsv_2;
            if (Main.LocalPlayer.GetModPlayer<Quests>().ReportQuest == 5)
            {
                button = CommanderAnsv_3;
            }
            if (Main.LocalPlayer.GetModPlayer<Quests>().ReportQuest == 20 || Main.LocalPlayer.GetModPlayer<Quests>().ReportQuest == 30)
            {
                bool temp = false;
                if (Main.LocalPlayer.GetModPlayer<Quests>().ReportQuest == 30)
                {               
                    for (int num66 = 0; num66 < 58; num66++)
                    {
                        if (Main.LocalPlayer.inventory[num66].type == ModContent.ItemType<ScoutsReport>() && Main.LocalPlayer.inventory[num66].stack > 0)
                        {
                            temp = true;
                            button = CommanderAnsv_4;
                        }
                    }
                }
                if(!temp && Main.npcChatText != Commander_5)
                    button = CommanderAnsv_5;
            }
            if (Main.LocalPlayer.GetModPlayer<Quests>().ReportQuest == 80)
            {
                button = CommanderAnsv_6;
            }
        }
        public override List<string> SetNPCNameList() => new List<string>()
        {
                this.GetLocalizedValue("Name.Rizo"), // Language.GetTextValue("Mods.Bismuth.CommanderName_1");
                this.GetLocalizedValue("Name.Albert"), // Language.GetTextValue("Mods.Bismuth.CommanderName_2");
                this.GetLocalizedValue("Name.Bernando"), // Language.GetTextValue("Mods.Bismuth.CommanderName_3");
                this.GetLocalizedValue("Name.Seefeld") // Language.GetTextValue("Mods.Bismuth.CommanderName_4");
        };

        public override bool CheckConditions(int left, int right, int top, int bottom)
        {
            return false;
        }
        public override string GetChat()
        {
            string Commander_2 = this.GetLocalization("Chat.Commander_2").Value;
            string Commander_4 = this.GetLocalization("Chat.Commander_4").Value;

            string CommanderNQ_1 = this.GetLocalization("Chat.CommanderNQ_1").Value;
            string CommanderNQ_2 = this.GetLocalization("Chat.CommanderNQ_2").Value;
            string CommanderNQ_3 = this.GetLocalization("Chat.CommanderNQ_3").Value;
            string CommanderNQ_4 = this.GetLocalization("Chat.CommanderNQ_4").Value;

            if (Main.LocalPlayer.GetModPlayer<Quests>().EquipmentQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().ReportQuest == 0)
                return Commander_2;
            if(Main.LocalPlayer.GetModPlayer<Quests>().ReportQuest == 20 || Main.LocalPlayer.GetModPlayer<Quests>().ReportQuest == 30)
                return Commander_4;
            else
            {
                if (NPC.FindFirstNPC(ModContent.NPCType<DwarfBlacksmith>()) >= 0 && WorldGen.genRand.Next(0, 4) == 0)
                    return string.Format(this.GetLocalization("Chat.CommanderNQ_4").Value, Main.npc[NPC.FindFirstNPC(ModContent.NPCType<DwarfBlacksmith>())].GivenName);
                else switch (WorldGen.genRand.Next(0, 3))
                    {
                        case 0:
                            return CommanderNQ_1;
                        case 1:
                            return CommanderNQ_2;                       
                        default:
                            return CommanderNQ_3;
                    }
            }
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            Quests quests = (Quests)Main.player[Main.myPlayer].GetModPlayer<Quests>();
            if (firstButton)
                quests.CommanderQuests();
        }
        public void UpdatePosition()
        {
            if (Main.player[Main.myPlayer].position.X >= NPC.position.X)
                NPC.spriteDirection = 1;
            else
                NPC.spriteDirection = -1;
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
                    if (Main.LocalPlayer.GetModPlayer<Quests>().ReportQuest < 10)
                        Main.LocalPlayer.GetModPlayer<Quests>().ReportQuest = 0;
                }
            }
            else
            {
                if (Main.LocalPlayer.GetModPlayer<Quests>().ReportQuest < 10)
                    Main.LocalPlayer.GetModPlayer<Quests>().ReportQuest = 0;
            }
        }
    }
}
