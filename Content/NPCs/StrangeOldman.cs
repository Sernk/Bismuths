using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Bismuth.Content.Buffs;
using Bismuth.Content.Items.Other;

namespace Bismuth.Content.NPCs
{
    //[AutoloadHead]
    public class StrangeOldman : ModNPC
    {
        public override void Load()
        {
            string OldmanName_1 = this.GetLocalization("Chat.OldmanName_1").Value; // Ru: Эгей En: Egey
            string OldmanName_2 = this.GetLocalization("Chat.OldmanName_2").Value; // Ru: Альфус En: Alphus
            string OldmanName_3 = this.GetLocalization("Chat.OldmanName_3").Value; // Ru: Авгур En: Avgur
            string OldmanName_4 = this.GetLocalization("Chat.OldmanName_4").Value; // Ru: Салливан En: Sulyvahn
            string OldmanName_5 = this.GetLocalization("Chat.OldmanName_5").Value; // Ru: Пепин En: Pepin

            string Oldman_1 = this.GetLocalization("Chat.Oldman_1").Value; // Ru: Человек! Слава богам Олимпа! Мне нужна помощь! Вот уже несколько месяцев я нахожусь в этой пещере без шанса на спасение, ты - моя последняя надежда!
                                                                           // En: A human! Thanks, Gods of Olympus! I need your help! I’ve been stuck in this cave without a chance for rescue for several months now – you’re my last hope!
            string Oldman_3 = this.GetLocalization("Chat.Oldman_3").Value; // Ru: Тебе удалось найти камень? En: Have you found the stone?
            string Oldman_4 = this.GetLocalization("Chat.Oldman_4").Value; // Ru: Не медли, моя жизнь зависит от тебя! En: Don’t take too long, my life is in your hands!
            string Oldman_7 = this.GetLocalization("Chat.Oldman_7").Value; // Ru: {0}, могу я попросить тебя кое о чем? En: {0}, may I ask something of you?

            string OldmanNQ_1 = this.GetLocalization("Chat.OldmanNQ_1").Value; // Ru: Я так рад, что выбрался из лабиринта - там было очень темно.
                                                                               // En: I'm glad to have finally gotten out of that labyrinth - it was mighty dark in there.
            string OldmanNQ_2 = this.GetLocalization("Chat.OldmanNQ_2").Value; // Ru: Теперь, когда Минотавр повержен, в подземелье станет гораздо спокойнее.
                                                                               // En: Now that the Minotaur has been slain, the underground is going to calm down by a lot.
            string OldmanNQ_3 = this.GetLocalization("Chat.OldmanNQ_3").Value; // Ru: В давние времена был герой вроде тебя, который тоже одолел Минотавра. Тесей, кажется так его звали.
                                                                               // En: In the ancient times there was a hero who too defeated the Minotaur. Theseus was his name, I believe.
            string OldmanNQ_4 = this.GetLocalization("Chat.OldmanNQ_4").Value; // Ru: Нет ничего приятнее, чем снова оказаться среди жителей Империи.
                                                                               // En: There's nothing better that once again being among the people of the Empire.
            string OldmanNQ_5 = this.GetLocalization("Chat.OldmanNQ_5").Value; // Ru: {0} - странный тип. Я ему не доверяю. En: {0} is an odd guy. I don't trust him.

            string OldmanAnsv_1 = this.GetLocalization("Chat.OldmanAnsv_1").Value; // Ru: Как ты сюда попал? En: How did you get here?
            string OldmanAnsv_2 = this.GetLocalization("Chat.OldmanAnsv_2").Value; // Ru: Оставайся тут, я спасу тебя En: Just stay here and you'll be saved
            string OldmanAnsv_3 = this.GetLocalization("Chat.OldmanAnsv_3").Value; // Ru: Я нашел его! En: I found it!
            string OldmanAnsv_4 = this.GetLocalization("Chat.OldmanAnsv_4").Value; // Ru: Я ищу этот камень En: I'm searching for the stone
            string OldmanAnsv_5 = this.GetLocalization("Chat.OldmanAnsv_5").Value; // Ru: По поводу награды... En: About the reward...
            string OldmanAnsv_6 = this.GetLocalization("Chat.OldmanAnsv_6").Value; // Ru: Конечно! En: Sure!
            string OldmanAnsv_7 = this.GetLocalization("Chat.OldmanAnsv_7").Value; // Ru: Я поговорю с {0} En: I'll talk to {0}
        }
        public override void SetStaticDefaults()
        {
            // DisplayName.SetDefault("Strange Old Man");
            //DisplayName.AddTranslation(GameCulture.Russian, "Странный старик");
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
        public override List<string> SetNPCNameList() => new List<string>()
        {
                this.GetLocalizedValue("Name.Rizo"), // Language.GetTextValue("Mods.Bismuth.OldmanName_1");
                this.GetLocalizedValue("Name.RizoZ"), // Language.GetTextValue("Mods.Bismuth.OldmanName_2");
                this.GetLocalizedValue("Name.RizoZZ"), // Language.GetTextValue("Mods.Bismuth.OldmanName_3");
                this.GetLocalizedValue("Name.RizoZZZ"), // Language.GetTextValue("Mods.Bismuth.OldmanName_4");
                this.GetLocalizedValue("Name.RizoZZZZ") // Language.GetTextValue("Mods.Bismuth.OldmanName_5");
        };
        public override void PostDraw(SpriteBatch spriteBatch, Vector2 screenPos, Color drawColor)
        {
            Texture2D available = ModContent.Request<Texture2D>("Bismuth/UI/AvailableQuest").Value;
            Texture2D active = ModContent.Request<Texture2D>("Bismuth/UI/ActiveQuest").Value;
            if (Main.LocalPlayer.GetModPlayer<Quests>().LuceatQuest <= 10 || (Main.LocalPlayer.GetModPlayer<Quests>().LuceatQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().NewPriestQuest <= 10 && Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 200))
                spriteBatch.Draw(available, NPC.position - Main.screenPosition + new Vector2(12, -36), Color.White);
            if (Main.LocalPlayer.GetModPlayer<Quests>().LuceatQuest > 10 && Main.LocalPlayer.GetModPlayer<Quests>().LuceatQuest < 100)
                spriteBatch.Draw(active, NPC.position - Main.screenPosition + new Vector2(8, -40), Color.White);

        }
        public override string GetChat()
        {
            string Oldman_1 = this.GetLocalization("Chat.Oldman_1").Value;
            string Oldman_3 = this.GetLocalization("Chat.Oldman_3").Value;
            string Oldman_7 = this.GetLocalization("Chat.Oldman_7").Value;
            string OldmanNQ_1 = this.GetLocalization("Chat.OldmanNQ_1").Value;
            string OldmanNQ_2 = this.GetLocalization("Chat.OldmanNQ_2").Value;
            string OldmanNQ_3 = this.GetLocalization("Chat.OldmanNQ_3").Value;
            string OldmanNQ_4 = this.GetLocalization("Chat.OldmanNQ_4").Value;
            string OldmanNQ_5 = this.GetLocalization("Chat.OldmanNQ_5").Value;

            if (Main.LocalPlayer.GetModPlayer<Quests>().LuceatQuest == 0)
                return Oldman_1;
            else if(Main.LocalPlayer.GetModPlayer<Quests>().LuceatQuest > 10 && Main.LocalPlayer.GetModPlayer<Quests>().LuceatQuest < 100 && Main.LocalPlayer.FindBuffIndex(ModContent.BuffType<AuraOfEmpire>()) == -1)
                return Oldman_3;
            else if (Main.LocalPlayer.GetModPlayer<Quests>().LuceatQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 200 && Main.LocalPlayer.GetModPlayer<Quests>().NewPriestQuest == 0)
                return string.Format(this.GetLocalization("Chat.Oldman_7").Value, Main.LocalPlayer.name);
            else if(Main.LocalPlayer.GetModPlayer<Quests>().LuceatQuest == 100 || (Main.LocalPlayer.GetModPlayer<Quests>().LuceatQuest < 100 && Main.LocalPlayer.FindBuffIndex(ModContent.BuffType<AuraOfEmpire>()) != -1))
            {
                switch (WorldGen.genRand.Next(0, 5))
                {
                    case 0:
                        {
                            return OldmanNQ_1;
                        }
                    case 1:
                        {
                            return OldmanNQ_2;
                        }
                    case 2:
                        {
                            return OldmanNQ_3;
                        }
                    case 3:
                        {
                            return OldmanNQ_4;
                        }
                    default:
                        {
                            return string.Format(this.GetLocalization("Chat.OldmanNQ_5").Value, Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Priest>())].GivenName);
                        }
                }
            }
            return "s";
        }
        public override bool CheckConditions(int left, int right, int top, int bottom)
        {
            return false;
        }
        public override void SetChatButtons(ref string button, ref string button2)
        {
            string Oldman_4 = this.GetLocalization("Chat.Oldman_4").Value;
            string OldmanAnsv_1 = this.GetLocalization("Chat.OldmanAnsv_1").Value;
            string OldmanAnsv_2 = this.GetLocalization("Chat.OldmanAnsv_2").Value;
            string OldmanAnsv_3 = this.GetLocalization("Chat.OldmanAnsv_3").Value;
            string OldmanAnsv_4 = this.GetLocalization("Chat.OldmanAnsv_4").Value;
            string OldmanAnsv_5 = this.GetLocalization("Chat.OldmanAnsv_5").Value;
            string OldmanAnsv_6 = this.GetLocalization("Chat.OldmanAnsv_6").Value;
            string OldmanAnsv_7 = this.GetLocalization("Chat.OldmanAnsv_7").Value;

            if (Main.LocalPlayer.GetModPlayer<Quests>().LuceatQuest == 0)
            {
                button = OldmanAnsv_1;
            }
            if (Main.LocalPlayer.GetModPlayer<Quests>().LuceatQuest == 5)
            {
                button = OldmanAnsv_2;
            }
            if (Main.LocalPlayer.GetModPlayer<Quests>().LuceatQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Main.player[Main.myPlayer].inventory[num66].type == ModContent.ItemType<UnchargedLuceat>() && Main.player[Main.myPlayer].inventory[num66].stack > 0)
                    {
                        button = OldmanAnsv_3;
                        temp = true;
                    }
                }              
                if(!temp && Main.npcChatText != Oldman_4)
                    button = OldmanAnsv_4;
            }
            if(Main.LocalPlayer.GetModPlayer<Quests>().LuceatQuest == 40 && Main.LocalPlayer.HasBuff(ModContent.BuffType<AuraOfEmpire>()))
                 button = OldmanAnsv_5;

            if (Main.LocalPlayer.GetModPlayer<Quests>().LuceatQuest == 100 && Main.LocalPlayer.GetModPlayer<Quests>().NewPriestQuest == 0 && Main.LocalPlayer.GetModPlayer<Quests>().TombstoneQuest == 200)
            {
                button = OldmanAnsv_6;
            }
            if (Main.LocalPlayer.GetModPlayer<Quests>().NewPriestQuest == 5)
            {
                button = string.Format(this.GetLocalization("Chat.OldmanAnsv_7").Value, Main.npc[NPC.FindFirstNPC(ModContent.NPCType<ImperianConsul>())].GivenName);
            }
        }
        public override void OnChatButtonClicked(bool firstButton, ref string shopName)
        {
            Quests quests = (Quests)Main.player[Main.myPlayer].GetModPlayer<Quests>();
            if (firstButton)
                quests.OldmanQuests();                
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
            string OldmanName_1 = this.GetLocalization("Chat.OldmanName_1").Value;
            string OldmanName_2 = this.GetLocalization("Chat.OldmanName_2").Value;
            string OldmanName_3 = this.GetLocalization("Chat.OldmanName_3").Value;
            string OldmanName_4 = this.GetLocalization("Chat.OldmanName_4").Value;
            string OldmanName_5 = this.GetLocalization("Chat.OldmanName_5").Value;

            if (!NPC.HasGivenName)
            {
                switch (WorldGen.genRand.Next(0, 5))
                {
                    case 0:
                        NPC.GivenName = OldmanName_1;
                        break;
                    case 1:
                        NPC.GivenName = OldmanName_2;
                        break;
                    case 2:
                        NPC.GivenName = OldmanName_3;
                        break;
                    case 3:
                        NPC.GivenName = OldmanName_4;
                        break;
                    default:
                        NPC.GivenName = OldmanName_5;
                        break;
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
            if (Main.LocalPlayer.talkNPC != -1)
            {
                if (Main.npc[Main.LocalPlayer.talkNPC].whoAmI == NPC.whoAmI)
                {
                    UpdatePosition();
                }
                if (Main.npc[Main.LocalPlayer.talkNPC].type != NPC.type)
                {
                    if (Main.LocalPlayer.GetModPlayer<Quests>().LuceatQuest < 10)
                        Main.LocalPlayer.GetModPlayer<Quests>().LuceatQuest = 0;
                    if (Main.LocalPlayer.GetModPlayer<Quests>().NewPriestQuest < 10)
                        Main.LocalPlayer.GetModPlayer<Quests>().NewPriestQuest = 0;
                }
            }
            else
            {
                if (Main.LocalPlayer.GetModPlayer<Quests>().LuceatQuest < 10)
                    Main.LocalPlayer.GetModPlayer<Quests>().LuceatQuest = 0;
                if (Main.LocalPlayer.GetModPlayer<Quests>().NewPriestQuest < 10)
                    Main.LocalPlayer.GetModPlayer<Quests>().NewPriestQuest = 0;
            }
            if (NPC.AnyNPCs(ModContent.NPCType<OldmanPriest>()))
                NPC.active = false;
        }
    }
}
