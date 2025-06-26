using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.GameInput;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Graphics;
using Terraria.DataStructures;
using System.IO;
using Terraria.Localization;
using System.Diagnostics;
using Bismuth.Utilities;
using Terraria.Audio;
using Bismuth.Content.Items.Other;
using Bismuth.Content.Items.Weapons.Assassin;
using Bismuth.Content.Items.Weapons.Magical;
using Bismuth.Content.Items.Weapons.Melee;
using Bismuth.Content.Items.Weapons.Ranged;
using Bismuth.Content.Items.Weapons.Throwing;
using Bismuth.Content.Items.Materials;
using Bismuth.Content.Items.Accessories;
using Bismuth.Content.Items.Armor;
using Bismuth.Content.Items.Tools;
using Bismuth.Content.NPCs;
using Bismuth.Content.Items.Placeable;

namespace Bismuth
{
    // if anybody will read this: take care of your psyche.
    // Big thanks to Rockos and his mod. Sources of it were very usefull.
    // Also thanks to Compozius and Zerokk. Their help in coding was essential.
    public class Quests : ModPlayer
    {
        #region quest variables
        public int EquipmentQuest = 0;
        public int LuceatQuest = 0;
        public int BookOfSecretsQuest = 0;     
        public int ElessarQuest = 0;
        public int GlamdringQuest = 0;    
        public int MinotaurHornQuest = 0;     
        public int ArmorPlateQuest = 0;      
        public int TombstoneQuest = 0;     
        public int FoodQuest = 0;    
        public int SoulScytheQuest = 0;       
        public int PotionQuest = 0;     
        public int NewPriestQuest = 0;     
        public int PhilosopherStoneQuest = 0;   
        public int PhilosopherStoneCharging = 0;     
        public int SunriseQuest = 0;    
        public int ReportQuest = 0;
     
        #endregion
        // Номера квестов:
        // 1 - стартовое обмундирование
        // 2 - книга секретов
        // 3 - эллесар
        // 4 - луцеат
        // 5 - гламдринг
        // 6 - рог минотавра
        // 7 - броня гномов
        // 8 - могила
        // 9 - новый священник
        // 10 - зелья
        // 11 - филосовский камень
        // 12 - еда для бедняка 
        // 13 - картина    
        // 14 - важное донесение
    
        public IList<int> activequests = new List<int>();
        public IList<int> completedquests = new List<int>();
        public IList<string> descs = new List<string>();
        public IList<string> shorts = new List<string>();
        public IList<string> descscompl = new List<string>();
        public IList<string> shortscompl = new List<string>();
        public static Vector2 bookcoord = new Vector2(Main.screenWidth / 2 - 237, 200);       
        public Texture2D ActualPanel;
        int selectedquest = -1;
        int selectedquest2 = -1;
        string desc1 = Language.GetTextValue("Mods.Bismuth.Quest1Name");
        string desc2 = Language.GetTextValue("Mods.Bismuth.Quest2Name");
        string desc3 = Language.GetTextValue("Mods.Bismuth.Quest3Name");
        string desc4 = Language.GetTextValue("Mods.Bismuth.Quest4Name");
        string desc5 = Language.GetTextValue("Mods.Bismuth.Quest5Name");
        string desc6 = Language.GetTextValue("Mods.Bismuth.Quest6Name");
        string desc7 = Language.GetTextValue("Mods.Bismuth.Quest7Name");
        string desc8 = Language.GetTextValue("Mods.Bismuth.Quest8Name");
        string desc9 = Language.GetTextValue("Mods.Bismuth.Quest9Name");
        string desc10 = Language.GetTextValue("Mods.Bismuth.Quest10Name");
        string desc11 = Language.GetTextValue("Mods.Bismuth.Quest11Name");
        string desc12 = Language.GetTextValue("Mods.Bismuth.Quest12Name");
        string desc13 = Language.GetTextValue("Mods.Bismuth.Quest13Name");
        string desc14 = Language.GetTextValue("Mods.Bismuth.Quest14Name");
        string short1 = Language.GetTextValue("Mods.Bismuth.Quest1Short");
        string short2 = Language.GetTextValue("Mods.Bismuth.Quest2Short");
        string short3 = Language.GetTextValue("Mods.Bismuth.Quest3Short");
        string short4 = Language.GetTextValue("Mods.Bismuth.Quest4Short");
        string short5 = Language.GetTextValue("Mods.Bismuth.Quest5Short");
        string short6 = Language.GetTextValue("Mods.Bismuth.Quest6Short");
        string short7 = Language.GetTextValue("Mods.Bismuth.Quest7Short");
        string short8 = Language.GetTextValue("Mods.Bismuth.Quest8Short");
        string short9 = Language.GetTextValue("Mods.Bismuth.Quest9Short");
        string short10 = Language.GetTextValue("Mods.Bismuth.Quest10Short");
        string short11 = Language.GetTextValue("Mods.Bismuth.Quest11Short");
        string short12 = Language.GetTextValue("Mods.Bismuth.Quest12Short");
        string short13 = Language.GetTextValue("Mods.Bismuth.Quest13Short");
        string short14 = Language.GetTextValue("Mods.Bismuth.Quest14Short");
        public static Vector2 treecoord = new Vector2(bookcoord.X, bookcoord.Y);
        public override void Initialize()
        {
            EquipmentQuest = 0;
            BookOfSecretsQuest = 0;
            ElessarQuest = 0;
            LuceatQuest = 0;
            GlamdringQuest = 0;
            MinotaurHornQuest = 0;
            ArmorPlateQuest = 0;
            TombstoneQuest = 0;
            NewPriestQuest = 0;
            PotionQuest = 0;
            PhilosopherStoneQuest = 0;
            FoodQuest = 0;
            SunriseQuest = 0;
            ReportQuest = 0;
            activequests = new List<int>();
            completedquests = new List<int>();
            descs = new List<string>();
            shorts = new List<string>();
            descscompl = new List<string>();
            shortscompl = new List<string>();
            desc1 = Language.GetTextValue("Mods.Bismuth.Quest1Name");
            desc2 = Language.GetTextValue("Mods.Bismuth.Quest2Name");
            desc3 = Language.GetTextValue("Mods.Bismuth.Quest3Name");
            desc4 = Language.GetTextValue("Mods.Bismuth.Quest4Name");
            desc5 = Language.GetTextValue("Mods.Bismuth.Quest5Name");
            desc6 = Language.GetTextValue("Mods.Bismuth.Quest6Name");
            desc7 = Language.GetTextValue("Mods.Bismuth.Quest7Name");
            desc8 = Language.GetTextValue("Mods.Bismuth.Quest8Name");
            desc9 = Language.GetTextValue("Mods.Bismuth.Quest9Name");
            desc10 = Language.GetTextValue("Mods.Bismuth.Quest10Name");
            desc11 = Language.GetTextValue("Mods.Bismuth.Quest11Name");
            desc12 = Language.GetTextValue("Mods.Bismuth.Quest12Name");
            desc13 = Language.GetTextValue("Mods.Bismuth.Quest13Name");
            desc14 = Language.GetTextValue("Mods.Bismuth.Quest14Name");
            short1 = Language.GetTextValue("Mods.Bismuth.Quest1Short");
            short2 = Language.GetTextValue("Mods.Bismuth.Quest2Short");
            short3 = Language.GetTextValue("Mods.Bismuth.Quest3Short");
            short4 = Language.GetTextValue("Mods.Bismuth.Quest4Short");
            short5 = Language.GetTextValue("Mods.Bismuth.Quest5Short");
            short6 = Language.GetTextValue("Mods.Bismuth.Quest6Short");
            short7 = Language.GetTextValue("Mods.Bismuth.Quest7Short");
            short8 = Language.GetTextValue("Mods.Bismuth.Quest8Short");
            short9 = Language.GetTextValue("Mods.Bismuth.Quest9Short");
            short10 = Language.GetTextValue("Mods.Bismuth.Quest10Short");
            short11 = Language.GetTextValue("Mods.Bismuth.Quest11Short");
            short12 = Language.GetTextValue("Mods.Bismuth.Quest12Short");
            short13 = Language.GetTextValue("Mods.Bismuth.Quest13Short");
            short14 = Language.GetTextValue("Mods.Bismuth.Quest14Short");
        }
        public override void SaveData(TagCompound tag)
        {
            tag["Quest1"] = EquipmentQuest;
            tag["Quest2"] = BookOfSecretsQuest;
            tag["Quest3"] = ElessarQuest;
            tag["Quest4"] = ElessarQuest;
            tag["Quest5"] = LuceatQuest;
            tag["Quest6"] = GlamdringQuest;
            tag["Quest7"] = MinotaurHornQuest;
            tag["Quest8"] = ArmorPlateQuest;
            tag["Quest9"] = TombstoneQuest;
            tag["Quest10"] = PotionQuest;
            tag["Quest11"] = PhilosopherStoneQuest;
            tag["Quest12"] = FoodQuest;
            tag["Quest13"] = SunriseQuest;
            tag["Quest14"] = ReportQuest;
            tag["SoulScytheQuest"] = SoulScytheQuest;
            tag["PhilosopherStoneCharging"] = PhilosopherStoneCharging;
            tag["ActiveQuests"] = activequests;
            tag["CompletedQuests"] = completedquests;
            tag["QuestDescriptions"] = descs;
            tag["QuestTitles"] = shorts;
            tag["CompletedQuestDescriptions"] = descscompl;
            tag["CompletedQuestTitles"] = shortscompl;
        }
        //public override void SaveData(TagCompound tag)
        //{
        //    TagCompound save_data = new TagCompound();
        //    save_data.Add("Quest1", EquipmentQuest);
        //    save_data.Add("Quest2", BookOfSecretsQuest);
        //    save_data.Add("Quest3", ElessarQuest);
        //    save_data.Add("Quest4", LuceatQuest);
        //    save_data.Add("Quest5", GlamdringQuest);
        //    save_data.Add("Quest6", MinotaurHornQuest);
        //    save_data.Add("Quest7", ArmorPlateQuest);
        //    save_data.Add("Quest8", TombstoneQuest);
        //    save_data.Add("Quest9", NewPriestQuest);
        //    save_data.Add("Quest10", PotionQuest);
        //    save_data.Add("Quest11", PhilosopherStoneQuest);
        //    save_data.Add("Quest12", FoodQuest);
        //    save_data.Add("Quest13", SunriseQuest);
        //    save_data.Add("Quest14", ReportQuest);
        //    save_data.Add("SoulScytheQuest", SoulScytheQuest);
        //    save_data.Add("PhilosopherStoneCharging", PhilosopherStoneCharging);
        //    save_data.Add("ActiveQuests", activequests);
        //    save_data.Add("CompletedQuests", completedquests);
        //    save_data.Add("QuestDescriptions", descs);
        //    save_data.Add("QuestTitles", shorts);
        //    save_data.Add("CompletedQuestDescriptions", descscompl);
        //    save_data.Add("CompletedQuestTitles", shortscompl);
        //    return;
        //}
        public override void LoadData(TagCompound tag)
        {
            EquipmentQuest = tag.GetInt("Quest1");
            BookOfSecretsQuest = tag.GetInt("Quest2");
            ElessarQuest = tag.GetInt("Quest3");
            LuceatQuest = tag.GetInt("Quest4");
            GlamdringQuest = tag.GetInt("Quest5");
            MinotaurHornQuest = tag.GetInt("Quest6");
            ArmorPlateQuest = tag.GetInt("Quest7");
            TombstoneQuest = tag.GetInt("Quest8");
            NewPriestQuest = tag.GetInt("Quest9");
            PotionQuest = tag.GetInt("Quest10");
            PhilosopherStoneQuest = tag.GetInt("Quest11");
            FoodQuest = tag.GetInt("Quest12");
            SunriseQuest = tag.GetInt("Quest13");
            ReportQuest = tag.GetInt("Quest14");
            SoulScytheQuest = tag.GetInt("SoulScytheQuest");
            PhilosopherStoneCharging = tag.GetInt("PhilosopherStoneCharging");
            activequests = tag.GetList<int>("ActiveQuests");
            completedquests = tag.GetList<int>("CompletedQuests");
            descs = tag.GetList<string>("QuestDescriptions");
            shorts = tag.GetList<string>("QuestTitles");
            descscompl = tag.GetList<string>("CompletedQuestDescriptions");
            shortscompl = tag.GetList<string>("CompletedQuestTitles");
        }
        void UpdateQuests()
        {
            for(int i = 1; i < 255; i++)
            {
                if(Main.player[i].active)
                {
                    Player.GetModPlayer<Quests>().EquipmentQuest = Main.player[0].GetModPlayer<Quests>().EquipmentQuest;                    
                    Player.GetModPlayer<Quests>().LuceatQuest = Main.player[0].GetModPlayer<Quests>().LuceatQuest;
                    Player.GetModPlayer<Quests>().BookOfSecretsQuest = Main.player[0].GetModPlayer<Quests>().BookOfSecretsQuest;
                    Player.GetModPlayer<Quests>().ElessarQuest = Main.player[0].GetModPlayer<Quests>().ElessarQuest;
                    Player.GetModPlayer<Quests>().GlamdringQuest = Main.player[0].GetModPlayer<Quests>().GlamdringQuest;
                    Player.GetModPlayer<Quests>().MinotaurHornQuest = Main.player[0].GetModPlayer<Quests>().MinotaurHornQuest;
                    Player.GetModPlayer<Quests>().ArmorPlateQuest = Main.player[0].GetModPlayer<Quests>().ArmorPlateQuest;
                    Player.GetModPlayer<Quests>().TombstoneQuest = Main.player[0].GetModPlayer<Quests>().TombstoneQuest;
                    Player.GetModPlayer<Quests>().FoodQuest = Main.player[0].GetModPlayer<Quests>().FoodQuest;
                    Player.GetModPlayer<Quests>().SoulScytheQuest = Main.player[0].GetModPlayer<Quests>().SoulScytheQuest;
                    Player.GetModPlayer<Quests>().PotionQuest = Main.player[0].GetModPlayer<Quests>().PotionQuest;
                    Player.GetModPlayer<Quests>().NewPriestQuest = Main.player[0].GetModPlayer<Quests>().NewPriestQuest;
                    Player.GetModPlayer<Quests>().PhilosopherStoneQuest = Main.player[0].GetModPlayer<Quests>().PhilosopherStoneQuest;
                    Player.GetModPlayer<Quests>().SunriseQuest = Main.player[0].GetModPlayer<Quests>().SunriseQuest;
                    Player.GetModPlayer<Quests>().ReportQuest = Main.player[0].GetModPlayer<Quests>().ReportQuest;
                }
            }
        }
        public override void PreUpdateBuffs()
        {
            #region questlists
            if ((EquipmentQuest >= 10 && EquipmentQuest < 100) && !activequests.Contains(1))
            {
                activequests.Insert(0, 1);
                descs.Insert(0, desc1);
                shorts.Insert(0, short1);
            }
            if (EquipmentQuest == 100 && !completedquests.Contains(1))
            {
                activequests.Remove(1);
                completedquests.Insert(0, 1);
                descscompl.Insert(0, desc1);
                shortscompl.Insert(0, short1);
                shorts.Remove(short1);
                descs.Remove(desc1);
            }
            if (BookOfSecretsQuest >= 10 && BookOfSecretsQuest < 100 && !activequests.Contains(2))
            {
                descs.Insert(0, desc2);
                activequests.Insert(0, 2);
                shorts.Insert(0, short2);
            }
            if (BookOfSecretsQuest == 100 && !completedquests.Contains(2))
            {
                activequests.Remove(2);
                completedquests.Insert(0, 2);
                shorts.Remove(short2);
                descs.Remove(desc2);
                descscompl.Insert(0, desc2);
                shortscompl.Insert(0, short2);
            }
            if (ElessarQuest >= 10 && ElessarQuest < 100 && !activequests.Contains(3))
            {
                descs.Insert(0, desc3);
                activequests.Insert(0, 3);
                shorts.Insert(0, short3);
            }
            if ((ElessarQuest == 100 || ElessarQuest == 200) && !completedquests.Contains(3))
            {
                activequests.Remove(3);
                completedquests.Insert(0, 3);
                shorts.Remove(short3);
                descs.Remove(desc3);
                descscompl.Insert(0, desc3);
                shortscompl.Insert(0, short3);
            }
            if (LuceatQuest >= 10 && LuceatQuest < 100 && !activequests.Contains(4))
            {
                activequests.Insert(0, 4);
                descs.Insert(0, desc4);
                shorts.Insert(0, short4);
            }
            if (LuceatQuest == 100 && !completedquests.Contains(4))
            {
                activequests.Remove(4);
                completedquests.Insert(0, 4);
                shorts.Remove(short4);
                descs.Remove(desc4);
                descscompl.Insert(0, desc4);
                shortscompl.Insert(0, short4);
            }
            if (GlamdringQuest >= 10 && GlamdringQuest < 100 && !activequests.Contains(5))
            {
                activequests.Insert(0, 5);
                descs.Insert(0, desc5);
                shorts.Insert(0, short5);
            }
            if (GlamdringQuest == 100 && !completedquests.Contains(5))
            {
                activequests.Remove(5);
                completedquests.Insert(0, 5);
                shorts.Remove(short5);
                descs.Remove(desc5);
                descscompl.Insert(0, desc5);
                shortscompl.Insert(0, short5);
            }
            if (MinotaurHornQuest >= 10 && MinotaurHornQuest < 100 && !activequests.Contains(6))
            {
                descs.Insert(0, desc6);
                activequests.Insert(0, 6);
                shorts.Insert(0, short6);
            }
            if (MinotaurHornQuest == 100 && !completedquests.Contains(6))
            {
                activequests.Remove(6);
                completedquests.Insert(0, 6);
                shorts.Remove(short6);
                descscompl.Insert(0, desc6);
                descs.Remove(desc6);
                shortscompl.Insert(0, short6);
            }
            if (ArmorPlateQuest >= 10 && ArmorPlateQuest < 100 && !activequests.Contains(7))
            {
                descs.Insert(0, desc7);
                activequests.Insert(0, 7);
                shorts.Insert(0, short7);
            }
            if (ArmorPlateQuest == 100 && !completedquests.Contains(7))
            {
                activequests.Remove(7);
                completedquests.Insert(0, 7);
                shorts.Remove(short7);
                descscompl.Insert(0, desc7);
                descs.Remove(desc7);
                shortscompl.Insert(0, short7);
            }
            if (TombstoneQuest >= 10 && TombstoneQuest < 100 && !activequests.Contains(8))
            {
                descs.Insert(0, desc8);
                activequests.Insert(0, 8);
                shorts.Insert(0, short8);
            }           
            if ((TombstoneQuest == 100 || TombstoneQuest == 200 || TombstoneQuest == 300) && !completedquests.Contains(8))
            {
                activequests.Remove(8);
                completedquests.Insert(0, 8);
                shorts.Remove(short8);
                descs.Remove(desc8);
                descscompl.Insert(0, desc8);
                shortscompl.Insert(0, short8);
            }
            if (NewPriestQuest >= 10 && NewPriestQuest < 100 && !activequests.Contains(9))
            {
                descs.Insert(0, desc9);
                activequests.Insert(0, 9);
                shorts.Insert(0, short9);
            }
            if (NewPriestQuest == 100 && !completedquests.Contains(9))
            {
                activequests.Remove(9);
                completedquests.Insert(0, 9);
                shorts.Remove(short9);
                descs.Remove(desc9);
                descscompl.Insert(0, desc9);
                shortscompl.Insert(0, short9);
            }
            if (PotionQuest >= 10 && PotionQuest < 100 && !activequests.Contains(10))
            {
                descs.Insert(0, desc10);
                activequests.Insert(0, 10);
                shorts.Insert(0, short10);
            }
            if ((PotionQuest == 100 || PotionQuest == 200) && !completedquests.Contains(10))
            {
                activequests.Remove(10);
                completedquests.Insert(0, 10);
                shorts.Remove(short10);
                descs.Remove(desc10);
                descscompl.Insert(0, desc10);
                shortscompl.Insert(0, short10);
            }
            if (PhilosopherStoneQuest >= 10 && PhilosopherStoneQuest < 100 && !activequests.Contains(11))
            {
                descs.Insert(0, desc11);
                activequests.Insert(0, 11);
                shorts.Insert(0, short11);
            }
            if (PhilosopherStoneQuest == 100 && !completedquests.Contains(11))
            {
                activequests.Remove(11);
                completedquests.Insert(0, 11);
                shorts.Remove(short11);
                descscompl.Insert(0, desc11);
                shortscompl.Insert(0, short11);
                descs.Remove(desc11);
            }
            if (FoodQuest >= 10 && FoodQuest < 100 && !activequests.Contains(12))
            {
                descs.Insert(0, desc12);
                activequests.Insert(0, 12);
                shorts.Insert(0, short12);
            }
            if (FoodQuest == 100 && !completedquests.Contains(12))
            {
                activequests.Remove(12);
                completedquests.Insert(0, 12);
                shorts.Remove(short12);
                descscompl.Insert(0, desc12);
                descs.Remove(desc12);
                shortscompl.Insert(0, short12);
            }
            if (SunriseQuest >= 10 && SunriseQuest < 100 && !activequests.Contains(13))
            {
                descs.Insert(0, desc13);
                activequests.Insert(0, 13);
                shorts.Insert(0, short13);
            }
            if (SunriseQuest == 100 && !completedquests.Contains(13))
            {
                activequests.Remove(13);
                completedquests.Insert(0, 13);
                shorts.Remove(short13);
                descs.Remove(desc13);
                descscompl.Insert(0, desc13);
                shortscompl.Insert(0, short13);
            }
            if (ReportQuest >= 10 && ReportQuest < 100 && !activequests.Contains(14))
            {
                descs.Insert(0, desc14);
                activequests.Insert(0, 14);
                shorts.Insert(0, short14);
            }
            if (ReportQuest == 100 && !completedquests.Contains(14))
            {
                activequests.Remove(14);
                completedquests.Insert(0, 14);
                shorts.Remove(short14);
                descs.Remove(desc14);
                descscompl.Insert(0, desc14);
                shortscompl.Insert(0, short14);
            }
            #endregion
            #region UpdateStages
            if (EquipmentQuest == 20 && Player.GetModPlayer<BismuthPlayer>().PlayerClass != 0)
                EquipmentQuest = 30;
            if (EquipmentQuest == 90 && Player.talkNPC == -1)
            {
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
                EquipmentQuest = 100;
                if (!Player.GetModPlayer<BismuthPlayer>().NoRPGGameplay)
                {
                    if (Player.GetModPlayer<BismuthPlayer>().PlayerClass == 1)
                    {
                        Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<Gladius>());
                        Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<Scutum>());
                    }
                    if (Player.GetModPlayer<BismuthPlayer>().PlayerClass == 2)
                    {
                        Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<WoodenCrossbow>());
                    }
                    if (Player.GetModPlayer<BismuthPlayer>().PlayerClass == 3)
                    {
                        Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<WoodenStaff>());
                    }
                    if (Player.GetModPlayer<BismuthPlayer>().PlayerClass == 4)
                    {
                        Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<Lancea>());
                    }
                    if (Player.GetModPlayer<BismuthPlayer>().PlayerClass == 5)
                    {
                        Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<Parazonium>());
                    }
                }
            }
            if (LuceatQuest == 90 && Player.talkNPC == -1)
            {
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<Luceat>());
                LuceatQuest = 100;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (BookOfSecretsQuest == 90 && Player.talkNPC == -1)
            {
                BookOfSecretsQuest = 100;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (ElessarQuest == 90 && Player.talkNPC == -1)
            {
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<Panacea>(), 5);
                ElessarQuest = 100;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (ElessarQuest == 190 && Player.talkNPC == -1)
            {
                ElessarQuest = 200;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (GlamdringQuest == 90 && Player.talkNPC == -1)
            {
                GlamdringQuest = 100;
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<Glamdring>());
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (MinotaurHornQuest == 90 && Player.talkNPC == -1)
            {
                MinotaurHornQuest = 100;
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<HornOfGondor>());
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (ArmorPlateQuest == 90 && Player.talkNPC == -1)
            {
                ArmorPlateQuest = 100;
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<DwarvenCoin>(), 5);
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (TombstoneQuest == 90 && Player.talkNPC == -1)
            {
                TombstoneQuest = 100;
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<UnchargedSoulScythe>());
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");               
            }
            if (TombstoneQuest == 190 && Player.talkNPC == -1)
            {               
              //  TombstoneQuest = 200;
                if (Main.netMode == 2)
                {
                    NetMessage.SendData(7, -1, -1, null, 0, 0f, 0f, 0f, 0, 0, 0);
                }
                foreach (Player player in Main.player)
                {
                    if (player.active)
                        player.GetModPlayer<Quests>().TombstoneQuest = 200;
                }
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<ImperianBanner>());
            }
            if (TombstoneQuest == 290 && Player.talkNPC == -1)
            {
                TombstoneQuest = 300;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST FAILED!");
            }
            if (NewPriestQuest == 90 && Player.talkNPC == -1)
            {
                NewPriestQuest = 100;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (ReportQuest == 90 && Player.talkNPC == -1)
            {
                ReportQuest = 100;
                if (!Player.GetModPlayer<BismuthPlayer>().NoRPGGameplay)
                    Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<BookOfMazarbul>());
                else
                    Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ItemID.GoldCoin, 5);
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (PotionQuest == 90 && Player.talkNPC == -1)
            {
                PotionQuest = 100;
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<PotionOfInvulnerability>(), 5);
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (PotionQuest == 190 && Player.talkNPC == -1)
            {
                PotionQuest = 200;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST FAILED!");
            }
            if (PhilosopherStoneQuest == 90 && Player.talkNPC == -1)
            {
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<TabulaSmaragdina>());
                PhilosopherStoneQuest = 100;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (SunriseQuest == 90 && Player.talkNPC == -1)
            {
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<PotionOfHumanity>());
                SunriseQuest = 100;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            if (FoodQuest == 90 && Player.talkNPC == -1)
            {
                FoodQuest = 100;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
            }
            #endregion
        }     
        public void OldmanQuests()
        {
            if (Main.npcChatText == Language.GetTextValue("Mods.Bismuth.Oldman_4"))
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
            if (LuceatQuest < 10)
            {
                Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Oldman_2");
                Main.npcChatCornerItem = ModContent.ItemType<UnchargedLuceat>();
                LuceatQuest += 5;
            }
            if (LuceatQuest == 10)
            {
               Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;           
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<GreenKey>());
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                LuceatQuest = 20;
                return;
            }
            if (LuceatQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<UnchargedLuceat>() && Player.inventory[num66].stack > 0)
                    {
                        Player.inventory[num66].stack--;
                        LuceatQuest = 30;
                        Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Oldman_5");
                        temp = true;
                    }
                }
                if (!temp)
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Oldman_4");
            }
            if (LuceatQuest == 40 && Player.HasBuff(Mod.Find<ModBuff>("AuraOfEmpire").Type))
            {
                LuceatQuest = 90;
                Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Oldman_6");
                
            }
            if (LuceatQuest == 100 && TombstoneQuest == 200 && NewPriestQuest <= 10)
            {
                Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Oldman_8");
                NewPriestQuest += 5;
            }
            if (NewPriestQuest == 10)
            {
                //Player.talkNPC = -1;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                NewPriestQuest = 20;
                return;
            }

        }
        public void BabaYagaQuests()
        {
            if (Main.npcChatText == Language.GetTextValue("Mods.Bismuth.SwampWitch_4"))
                Main.LocalPlayer.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
            if (Main.npcChatText == Language.GetTextValue("Mods.Bismuth.SwampWitch_10"))
                Main.LocalPlayer.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
            if (BookOfSecretsQuest < 10)
            {
                Main.npcChatText = Language.GetTextValue("Mods.Bismuth.SwampWitch_2");
                Main.npcChatCornerItem = ModContent.ItemType<BookOfSecrets>();
                BookOfSecretsQuest += 5;
            }
            if (BookOfSecretsQuest == 10)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                BookOfSecretsQuest = 20;
                return;
            }
            if (BookOfSecretsQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<BookOfSecrets>() && Player.inventory[num66].stack > 0)
                    {
                        Player.inventory[num66].stack--;
                        BookOfSecretsQuest = 90;
                        Main.npcChatText = Language.GetTextValue("Mods.Bismuth.SwampWitch_5");
                        temp = true;
                    }
                }
                if(!temp)
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.SwampWitch_4");
            }
            if (BookOfSecretsQuest == 100 && ElessarQuest == 0 && Main.LocalPlayer.GetModPlayer<BismuthPlayer>().BosWait < 86400)
                Main.npcChatText = Language.GetTextValue("Mods.Bismuth.SwampWitch_6");          
            if (BookOfSecretsQuest == 100 && ElessarQuest < 10)
            {
                if (Player.GetModPlayer<BismuthPlayer>().BosWait == 86400)
                {
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.SwampWitch_8");
                    Main.npcChatCornerItem = ModContent.ItemType<Elessar>();
                    ElessarQuest += 5;
                }
              
            }
            if (BookOfSecretsQuest == 100 && ElessarQuest == 10)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<BookOfSecrets>());
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCEPTED!");
                ElessarQuest = 20;
                return;
            }
            if (ElessarQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<UnchargedElessar>() && Player.inventory[num66].stack > 0)
                    {
                       // player.inventory[num66].stack--;
                        ElessarQuest = 190;
                        Main.npcChatText = Language.GetTextValue("Mods.Bismuth.SwampWitch_13");
                        temp = true;
                    }
                }
                if (!temp)
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.SwampWitch_10");
            }           
        }
        public void BlacksmithQuests()
        {
            if (Main.npcChatText == Language.GetTextValue("Mods.Bismuth.Blacksmith_10") || Main.npcChatText == Language.GetTextValue("Mods.Bismuth.Blacksmith_15"))
                Main.LocalPlayer.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
            if (GlamdringQuest < 10)
            {
                Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Blacksmith_2", Main.npc[NPC.FindFirstNPC(NPCID.GoblinTinkerer)].GivenName);
                Main.npcChatCornerItem = ModContent.ItemType<GlamdringBlueprint>();
                GlamdringQuest += 5;
            }
            if (GlamdringQuest == 10)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                GlamdringQuest = 20;
                return;
            }
            if (GlamdringQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<GlamdringBlueprint>() && Player.inventory[num66].stack > 0)
                    {
                        Player.inventory[num66].stack--;
                        GlamdringQuest = 30;
                        Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Blacksmith_4");
                        temp = true;
                        return;
                    }
                }
                if (!temp)
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Blacksmith_3");
            }
            if (GlamdringQuest == 30)
            {
                if (Player.GetModPlayer<BismuthPlayer>().WaitGlamdring >= 600)
                {
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Blacksmith_6");                    
                    GlamdringQuest = 90;                   
                }
                else
                {
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Blacksmith_5");
                }
            }
            if (GlamdringQuest == 100 && Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().KilledEoC && MinotaurHornQuest < 10)
            {
                Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Blacksmith_8");
                Main.npcChatCornerItem = ModContent.ItemType<MinotaurHorn>();
                MinotaurHornQuest += 5;
            }
            if (GlamdringQuest == 100 && Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().KilledEoC && MinotaurHornQuest == 10)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                MinotaurHornQuest = 20;
                return;
            }
            if (MinotaurHornQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<MinotaurHorn>() && Player.inventory[num66].stack > 0)
                    {
                        Player.inventory[num66].stack--;
                        MinotaurHornQuest = 90;
                        Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Blacksmith_11");                      
                        temp = true;
                        return;
                    }
                }
                if (!temp)
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Blacksmith_10");
            }
            if (MinotaurHornQuest == 100 && Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().KilledWoF && ArmorPlateQuest < 10)
            {
                Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Blacksmith_13");
                Main.npcChatCornerItem = ModContent.ItemType<DwarvenBrokenArmor>();
                ArmorPlateQuest += 5;
            }
            if (MinotaurHornQuest == 100 && ArmorPlateQuest == 10 && Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().KilledWoF)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                ArmorPlateQuest = 20;
                return;
            }
            if (ArmorPlateQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<DwarvenBrokenArmor>() && Player.inventory[num66].stack >= 5)
                    {
                        Player.inventory[num66].stack -= 5;                        
                        ArmorPlateQuest = 90;
                        Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Blacksmith_16", Main.LocalPlayer.name);                      
                        temp = true;
                        return;
                    }
                }
                if (!temp)
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Blacksmith_15");
            }
        }
        public void PriestQuests()
        {
            if (Main.npcChatText == Language.GetTextValue("Mods.Bismuth.Priest_5"))
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
            if (TombstoneQuest < 10)
            {
                Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Priest_3");
                Main.npcChatCornerItem = ModContent.ItemType<WarriorsRemains>();
                TombstoneQuest += 5;
            }
            if (TombstoneQuest == 10)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<DirtyShovel>());
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                TombstoneQuest = 20;
                return;
            }
            if (TombstoneQuest == 20 || TombstoneQuest == 30)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<WarriorsRemains>() && Player.inventory[num66].stack > 0)
                    {
                        Player.inventory[num66].stack--;
                        TombstoneQuest = 90;
                        Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Priest_6", Main.npc[Player.talkNPC].GivenName);
                        temp = true;
                        return;
                    }
                }
                if (!temp)
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Priest_5");
               
            }
            else if (TombstoneQuest == 40)
            {
                TombstoneQuest = 290;
                Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Priest_7");
            }

        }
        public void ConsulQuests()
        {            
            if (EquipmentQuest < 10)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                EquipmentQuest = 20;
                return;
            }
            if (TombstoneQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<DirtyShovel>() && Player.inventory[num66].stack > 0)
                    {
                        Player.inventory[num66].stack--;
                        TombstoneQuest = 190;
                        Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Consul_3");
                        temp = true;
                        return;
                    }
                }
                if (!temp)
                {
                    TombstoneQuest = 25;
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Consul_4", Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Priest>())].GivenName);
                }
            }

            if (NewPriestQuest == 20)
            {
                NewPriestQuest = 90;
                Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Consul_2", Main.npc[NPC.FindFirstNPC(ModContent.NPCType<StrangeOldman>())].GivenName);               
            }

        }
        public void CommanderQuests()
        {
            if (Main.npcChatText == Language.GetTextValue("Mods.Bismuth.Commander_5"))
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
            if (EquipmentQuest == 30)
            {
                EquipmentQuest = 90;
                Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Commander_1");               
            }
            if (EquipmentQuest == 20)
            {
                EquipmentQuest = 90;
                Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Commander_1");
            }
            if (ReportQuest < 10 && EquipmentQuest == 100)
            {
                Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Commander_3"); 
                ReportQuest += 5;
            }
            if (ReportQuest == 10 && EquipmentQuest == 100)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                ReportQuest = 20;
                return;
            }
            if (ReportQuest == 20)
                Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Commander_5");
            if (ReportQuest == 30)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<ScoutsReport>() && Player.inventory[num66].stack > 0)
                    {
                        Player.inventory[num66].stack--;
                        ReportQuest = 80;                       
                        Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Commander_6");
                        temp = true;
                        return;
                    }
                }
                if (!temp)
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Commander_5"); 
            }
            if (ReportQuest == 80)
            {
                if (!Player.GetModPlayer<BismuthPlayer>().NoRPGGameplay)
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Commander_6_2");
                else
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Commander_6_3");
                ReportQuest = 90;
            }                    
        }
        public void AlchemistQuests()
        {
            if (Main.npcChatText == Language.GetTextValue("Mods.Bismuth.Alchemist_4") || Main.npcChatText == Language.GetTextValue("Mods.Bismuth.Alchemist_9") || Main.npcChatText == Language.GetTextValue("Mods.Bismuth.Alchemist_14"))
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
            if (SunriseQuest < 10)
            {
                Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Alchemist_2");
                Main.npcChatCornerItem = ModContent.ItemType<SunrisePicture>();
                SunriseQuest += 5;
            }
            if (SunriseQuest == 10)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                SunriseQuest = 20;
                return;
            }
            if (SunriseQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<SunrisePicture>() && Player.inventory[num66].stack > 0)
                    {
                        Player.inventory[num66].stack--;
                        SunriseQuest = 90;                        
                        Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Alchemist_5");
                        temp = true;
                        return;
                    }
                }
                if (!temp)
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Alchemist_4");
            }


            if (SunriseQuest == 100 && PotionQuest < 10)
            {
                Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Alchemist_7");
                Main.npcChatCornerItem = ModContent.ItemType<FernFlower>();
                PotionQuest += 5;
            }
            if (PotionQuest == 10)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                PotionQuest = 20;
                return;
            }
            if (PotionQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<FernFlower>() && Player.inventory[num66].stack >= 5)
                    {
                        Player.inventory[num66].stack -= 5;
                        PotionQuest = 30;
                        Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Alchemist_10");
                        temp = true;
                        return;
                    }
                }
                if (!temp)
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Alchemist_9");
            }
            if (PotionQuest == 40)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ItemID.Daybloom && Player.inventory[num66].stack >= 30)
                    {
                        Player.inventory[num66].stack -= 30;
                        PotionQuest = 90;
                        Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Alchemist_15");
                        temp = true;
                        return;
                    }
                }
                if (!temp)
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Alchemist_14");
            }
            if (PotionQuest == 100 && PhilosopherStoneQuest < 10)
            {
                Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Alchemist_17");
                Main.npcChatCornerItem = ModContent.ItemType<TabulaSmaragdina>();
                PhilosopherStoneQuest += 5;
            }
            if (PotionQuest == 100 && PhilosopherStoneQuest == 10)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                PhilosopherStoneQuest = 20;
                Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<UnchargedTruePhilosopherStone>());
                return;
            }
            if (PhilosopherStoneQuest == 20)
            {
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].type == ModContent.ItemType<TabulaSmaragdina>() && Player.inventory[num66].stack > 0)
                    {
                        Player.inventory[num66].stack--;
                        PhilosopherStoneQuest = 30;
                        Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Alchemist_19");
                        return;
                    }
                }               
            }
            if (PhilosopherStoneQuest == 30)
            {
                if (Player.GetModPlayer<BismuthPlayer>().WaitTabula >= 86400)
                {
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Alchemist_21");
                    PhilosopherStoneQuest = 90;                    
                }
                else
                {
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Alchemist_20");
                }
            }
        }
        public void BeggarQuests()
        {
            if (EquipmentQuest == 100 && FoodQuest < 10)
            {
                Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Beggar_2");
                Main.npcChatCornerItem = ItemID.CookedFish;
                FoodQuest += 5;
            }
            if (FoodQuest == 10)
            {
                Player.GetModPlayer<BismuthPlayer>().CustomChatClose = true;
                CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST ACCCEPTED!");
                FoodQuest = 20;
                return;
            }
            if (FoodQuest == 20)
            {
                bool temp = false;
                for (int num66 = 0; num66 < 58; num66++)
                {
                    if (Player.inventory[num66].buffType == 26)
                    {
                        Player.inventory[num66].stack--;
                        FoodQuest = 90;                     
                        Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Beggar_5");
                        temp = true;
                        return;
                    }
                }
                if (!temp)
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Beggar_4");
            }
        }
        public void BrokenArmorExchange()
        {
            for (int num66 = 0; num66 < 58; num66++)
            {
                if (Player.inventory[num66].type == ModContent.ItemType<DwarvenBrokenArmor>() && Player.inventory[num66].stack > 0)
                {
                    Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<DwarvenCoin>(), Player.inventory[num66].stack);
                    Player.inventory[num66].stack = 0;
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Blacksmith_17");
                    return;
                }
            }
        }
        public void SoulScytheCharging()
        {
            for (int num66 = 0; num66 < 58; num66++)
            {
                if (Player.inventory[num66].type == ModContent.ItemType<UnchargedSoulScythe>() && Player.inventory[num66].stack > 0)
                {
                    Player.inventory[num66].stack--;
                    SoulScytheQuest = 10;
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Priest_8");                    
                    return;
                }
            }           
            if (SoulScytheQuest == 10)
            {
                if (Player.GetModPlayer<BismuthPlayer>().WaitSoulScythe >= 1800)
                {
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Priest_9");
                    Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<SoulScythe>());
                    Player.GetModPlayer<BismuthPlayer>().SoulScytheCharge = 20;
                    SoulScytheQuest = 0;                  
                }               
            }
        }
        public void PholosopherStoneCharging()
        {
            bool temp = false;
            for (int num66 = 0; num66 < 58; num66++)
            {
                if (Player.inventory[num66].type == ModContent.ItemType<UnchargedTruePhilosopherStone>() && Player.inventory[num66].stack > 0)
                {
                    for (int num67 = 0; num67 < 58; num67++)
                    {
                        if (Player.inventory[num67].type == ModContent.ItemType<Aether>() && Player.inventory[num67].stack >= 10)
                        {
                            for (int num68 = 0; num68 < 58; num68++)
                            {
                                if (Player.inventory[num68].type == ItemID.SilverOre && Player.inventory[num68].stack >= 30)
                                {
                                    for (int num69 = 0; num69 < 58; num69++)
                                    {
                                        if (Player.inventory[num69].type == ModContent.ItemType<Quicksilver>() && Player.inventory[num69].stack >= 30)
                                        {
                                            for (int num70 = 0; num70 < 58; num70++)
                                            {
                                                if (Player.inventory[num70].type == ItemID.CopperOre && Player.inventory[num70].stack >= 30)
                                                {
                                                    for (int num71 = 0; num71 < 58; num71++)
                                                    {
                                                        if (Player.inventory[num71].type == ItemID.GoldOre && Player.inventory[num71].stack >= 30)
                                                        {
                                                            for (int num72 = 0; num72 < 58; num72++)
                                                            {
                                                                if (Player.inventory[num72].type == ItemID.IronOre && Player.inventory[num72].stack >= 30)
                                                                {
                                                                    for (int num73 = 0; num73 < 58; num73++)
                                                                    {
                                                                        if (Player.inventory[num73].type == ItemID.TinOre && Player.inventory[num73].stack >= 30)
                                                                        {
                                                                            for (int num74 = 0; num74 < 58; num74++)
                                                                            {
                                                                                if (Player.inventory[num74].type == ItemID.LeadOre && Player.inventory[num74].stack >= 30)
                                                                                {
                                                                                    Player.inventory[num66].stack--;
                                                                                    Player.inventory[num67].stack -= 10;
                                                                                    Player.inventory[num68].stack -= 30;
                                                                                    Player.inventory[num69].stack -= 30;
                                                                                    Player.inventory[num70].stack -= 30;
                                                                                    Player.inventory[num71].stack -= 30;
                                                                                    Player.inventory[num72].stack -= 30;
                                                                                    Player.inventory[num73].stack -= 30;
                                                                                    Player.inventory[num74].stack -= 30;
                                                                                    PhilosopherStoneCharging = 10;
                                                                                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Alchemist_23");
                                                                                    temp = true;
                                                                                    return;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
            }
            if (!temp)
                Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Alchemist_22");

            if (PhilosopherStoneCharging == 10)
            {
                if (Player.GetModPlayer<BismuthPlayer>().WaitStoneCharging >= 1800)
                {
                    Main.npcChatText = Language.GetTextValue("Mods.Bismuth.Alchemist_24");
                    Player.QuickSpawnItem(Main.LocalPlayer.GetSource_FromThis(), ModContent.ItemType<TruePhilosopherStone>());
                    PhilosopherStoneCharging = 0;
                    CombatText.NewText(new Rectangle((int)Player.position.X, (int)Player.position.Y - 35, 10, 10), Color.LemonChiffon, "QUEST COMPLETED!");
                }
            }
        }
        Texture2D emptypage = ModContent.Request<Texture2D>("Bismuth/UI/AdventurersBookPageEmpty").Value;
        Texture2D closebook = ModContent.Request<Texture2D>("Bismuth/UI/CloseBook").Value;
        Texture2D titletex = ModContent.Request<Texture2D>("Bismuth/UI/AdventurersBookTitle").Value;
        Texture2D arrowtex = ModContent.Request<Texture2D>("Bismuth/UI/ABArrow").Value;
        Texture2D activetex = ModContent.Request<Texture2D>("Bismuth/UI/ActivePart").Value;
        Texture2D completedtex = ModContent.Request<Texture2D>("Bismuth/UI/CompletedPart").Value;
        Texture2D emptypatterntex = ModContent.Request<Texture2D>("Bismuth/UI/EmptyPattern").Value;
        Texture2D activeQtex = ModContent.Request<Texture2D>("Bismuth/UI/ActiveQuestsSign").Value;
        Texture2D completedQtex = ModContent.Request<Texture2D>("Bismuth/UI/CompletedQuestsSign").Value;
        Texture2D statstex = ModContent.Request<Texture2D>("Bismuth/UI/PlayerStatsSign").Value;
        Texture2D linetex = ModContent.Request<Texture2D>("Bismuth/UI/QuestsLine").Value;
        Texture2D line2tex = ModContent.Request<Texture2D>("Bismuth/UI/QuestsLine2").Value;
        bool treeflag;
        int currentpage = 0;
        int completedpage = 1;
        public static int FrameWidth = 390;
        public static int FrameHeight = 474;
        public static Vector2 FrameStart = new Vector2(bookcoord.X + 510, bookcoord.Y + 60);
        public static void DrawPart(SpriteBatch sb, Texture2D button, Vector2 buttonpos, Vector2 RectStart, int width, int height, Color color) //Intersect работает хуева, поэтому такие костыли
        {
             if ((buttonpos.X + button.Width < RectStart.X && buttonpos.Y + button.Height < RectStart.Y) || (buttonpos.X + button.Width < RectStart.X && buttonpos.Y > RectStart.Y + width) || (buttonpos.X > RectStart.X + width && buttonpos.Y + button.Height < RectStart.Y) || buttonpos.X > RectStart.X && buttonpos.Y > RectStart.Y + height)
               return;

            if (buttonpos.X <= RectStart.X)
            {
                if (buttonpos.Y <= RectStart.Y)
                    sb.Draw(button, RectStart, new Rectangle?(new Rectangle((int)RectStart.X - (int)buttonpos.X, (int)RectStart.Y - (int)buttonpos.Y, (int)buttonpos.X + button.Width - (int)RectStart.X, (int)buttonpos.Y + button.Height - (int)RectStart.Y)), color);
                else if (buttonpos.Y > RectStart.Y && buttonpos.Y + button.Height < RectStart.Y + height)
                    sb.Draw(button, new Vector2(RectStart.X, buttonpos.Y), new Rectangle?(new Rectangle((int)RectStart.X - (int)buttonpos.X, 0, (int)buttonpos.X + button.Width - (int)RectStart.X, button.Height)), color);
                else if (buttonpos.Y + button.Height >= RectStart.Y + height)
                    sb.Draw(button, new Vector2(RectStart.X, buttonpos.Y), new Rectangle?(new Rectangle((int)RectStart.X - (int)buttonpos.X, 0, (int)buttonpos.X + button.Width - (int)RectStart.X, (int)RectStart.Y + height - (int)buttonpos.Y)), color);
            }
            else if (buttonpos.X > RectStart.X && buttonpos.X + button.Width < RectStart.X + width)
            {
                if (buttonpos.Y <= RectStart.Y)
                    sb.Draw(button, new Vector2(buttonpos.X, RectStart.Y), new Rectangle?(new Rectangle(0, (int)RectStart.Y - (int)buttonpos.Y, button.Width, (int)buttonpos.Y + button.Height - (int)RectStart.Y)), color);
                else if (buttonpos.Y > RectStart.Y && buttonpos.Y + button.Height < RectStart.Y + height)
                    sb.Draw(button, buttonpos, color);
                else if (buttonpos.Y + button.Height >= RectStart.Y + height)
                    sb.Draw(button, buttonpos, new Rectangle?(new Rectangle(0, 0, button.Width, (int)RectStart.Y + height - (int)buttonpos.Y)), color);
            }
            else if (buttonpos.X >= RectStart.X)
            {
                if (buttonpos.Y <= RectStart.Y)
                    sb.Draw(button, new Vector2(buttonpos.X, RectStart.Y), new Rectangle?(new Rectangle(0, (int)RectStart.Y - (int)buttonpos.Y, (int)RectStart.X + width - (int)buttonpos.X, (int)buttonpos.Y + button.Height - (int)RectStart.Y)), color);
                else if (buttonpos.Y > RectStart.Y && buttonpos.Y + button.Height < RectStart.Y + height)
                    sb.Draw(button, buttonpos, new Rectangle?(new Rectangle(0, 0, (int)RectStart.X + width - (int)buttonpos.X, button.Height)), color);
                else if (buttonpos.Y + button.Height >= RectStart.Y + height)
                    sb.Draw(button, buttonpos, new Rectangle?(new Rectangle(0, 0, (int)RectStart.X + width - (int)buttonpos.X, (int)RectStart.Y + height - (int)buttonpos.Y)), color);
            }
            
        }
        public void DrawBook(SpriteBatch sb)
        {
            DynamicSpriteFont curfont = Bismuth.Adonais;
            FrameStart = new Vector2(bookcoord.X + emptypage.Width / 2 + 40, bookcoord.Y + 60);
            treeflag = Main.mouseX > FrameStart.X && Main.mouseX < FrameStart.X + FrameWidth && Main.mouseY > FrameStart.Y && Main.mouseY < FrameStart.Y + FrameHeight && currentpage == 4; // Лежит ли мышь в рамке с древом          
            #region strings
            desc1 = Language.GetTextValue("Mods.Bismuth.Quest1Name");
            desc2 = Language.GetTextValue("Mods.Bismuth.Quest2Name");
            desc3 = Language.GetTextValue("Mods.Bismuth.Quest3Name");
            desc4 = Language.GetTextValue("Mods.Bismuth.Quest4Name");
            desc5 = Language.GetTextValue("Mods.Bismuth.Quest5Name");
            desc6 = Language.GetTextValue("Mods.Bismuth.Quest6Name");
            desc7 = Language.GetTextValue("Mods.Bismuth.Quest7Name");
            desc8 = Language.GetTextValue("Mods.Bismuth.Quest8Name");
            desc9 = Language.GetTextValue("Mods.Bismuth.Quest9Name");
            desc10 = Language.GetTextValue("Mods.Bismuth.Quest10Name");
            desc11 = Language.GetTextValue("Mods.Bismuth.Quest11Name");
            desc12 = Language.GetTextValue("Mods.Bismuth.Quest12Name");
            desc13 = Language.GetTextValue("Mods.Bismuth.Quest13Name");
            desc14 = Language.GetTextValue("Mods.Bismuth.Quest14Name");
            short1 = Language.GetTextValue("Mods.Bismuth.Quest1Short");
            short2 = Language.GetTextValue("Mods.Bismuth.Quest2Short");
            short3 = Language.GetTextValue("Mods.Bismuth.Quest3Short");
            short4 = Language.GetTextValue("Mods.Bismuth.Quest4Short");
            short5 = Language.GetTextValue("Mods.Bismuth.Quest5Short");
            short6 = Language.GetTextValue("Mods.Bismuth.Quest6Short");
            short7 = Language.GetTextValue("Mods.Bismuth.Quest7Short");
            short8 = Language.GetTextValue("Mods.Bismuth.Quest8Short");
            short9 = Language.GetTextValue("Mods.Bismuth.Quest9Short");
            short10 = Language.GetTextValue("Mods.Bismuth.Quest10Short");
            short11 = Language.GetTextValue("Mods.Bismuth.Quest11Short");
            short12 = Language.GetTextValue("Mods.Bismuth.Quest12Short");
            short13 = Language.GetTextValue("Mods.Bismuth.Quest13Short");
            short14 = Language.GetTextValue("Mods.Bismuth.Quest14Short");
            #endregion
            if (Main.player[Main.myPlayer].GetModPlayer<BismuthPlayer>().OpenedBook)
            {
               if (Main.mouseX > bookcoord.X && Main.mouseX < bookcoord.X + emptypage.Width && Main.mouseY > bookcoord.Y && Main.mouseY < bookcoord.Y + emptypage.Height && (Player.GetModPlayer<BismuthPlayer>().PlayerClass != 0 ? !treeflag : true) && Main.mouseLeft) //Лежит ли мышь в пределах книги, но вне рамки
                {
                    int oldposX = Main.mouseX - Main.lastMouseX;
                    int oldposY = Main.mouseY - Main.lastMouseY;
                    bookcoord.X += oldposX;
                    bookcoord.Y += oldposY;
                    treecoord.X += oldposX;
                    treecoord.Y += oldposY;
                }
                if (currentpage == 0)
                {
                    sb.Draw(titletex, bookcoord, Color.White);
                    sb.Draw(arrowtex, new Vector2(bookcoord.X + 450, bookcoord.Y + 272), Color.White);
                    if (Main.mouseX > bookcoord.X + 450 && Main.mouseX < bookcoord.X + 450 + arrowtex.Width && Main.mouseY > bookcoord.Y + 272 && Main.mouseY < bookcoord.Y + 272 + arrowtex.Height && Main.mouseLeft && Main.mouseLeftRelease)
                    {
                        bookcoord.X -= 465;
                        currentpage = 1;
                        SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/BookPageFlip"));
                    }
                }
                
                else
                {
                    sb.Draw(emptypage, bookcoord, Color.White);
                    sb.Draw(closebook, bookcoord + new Vector2(894, 20), Color.White);
                    if (Main.mouseX > bookcoord.X + 894 && Main.mouseX < bookcoord.X + 894 + closebook.Width && Main.mouseY > bookcoord.Y + 20 && Main.mouseY < bookcoord.Y + 20 + closebook.Height && Main.mouseLeft && Main.mouseLeftRelease)
                    {
                        Player.GetModPlayer<BismuthPlayer>().OpenedBook = false;
                        SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/BookClose"));
                    }
                    if (currentpage != 0 && currentpage != 1)
                    {
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.BackToTitle"), bookcoord.X + 700 - curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.BackToTitle")).X / 2, bookcoord.Y + 570, Color.White, Color.Black, Vector2.Zero);
                        if (Main.mouseX > bookcoord.X + 695 - curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.BackToTitle")).X / 2 && Main.mouseX < bookcoord.X + 705 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.BackToTitle")).X / 2 && Main.mouseY > bookcoord.Y + 565 && Main.mouseY < bookcoord.Y + 595 && Main.mouseLeft && Main.mouseLeftRelease)
                        {
                            currentpage = 1;
                            SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/BookPageFlip"));
                        }
                        if(currentpage == 2 || currentpage == 3)
                        sb.Draw(line2tex, new Vector2(bookcoord.X + 502, bookcoord.Y + 160), Color.White);
                    }
                    if (currentpage == 1)
                    {
                        
                        string text1 = BismuthPlayer.StringBreak(curfont, Language.GetTextValue("Mods.Bismuth.TitleText"), 380f);
                        Utils.DrawBorderStringFourWay(sb, curfont, text1, bookcoord.X + 26, bookcoord.Y + 26, Color.White, Color.Black, Vector2.Zero);                       
                        string text2 = BismuthPlayer.StringBreak(curfont, Language.GetTextValue("Mods.Bismuth.LinksText"), 380f);
                    /*    Vector2 offset2 = curfont.MeasureString(text2);
                        Utils.DrawBorderStringFourWay(sb, curfont, text2, bookcoord.X + 700 - offset2.X / 2, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero);
                        string text3;
                        Vector2 offset3;
                        if (Language.ActiveCulture == GameCulture.Russian)
                        {
                            text3 = BismuthPlayer.StringBreak(curfont, Language.GetTextValue("Mods.Bismuth.WikiText", "bismuth-mod.fandom.com"), 380f);
                            offset3 = curfont.MeasureString(text3);
                            Utils.DrawBorderStringFourWay(sb, curfont, text3, bookcoord.X + 510, bookcoord.Y + 104 + offset2.Y + 10, Color.White, Color.Black, Vector2.Zero);
                            if (Main.mouseLeft && Main.mouseLeftRelease && Main.mouseX > bookcoord.X + 510 && Main.mouseX < bookcoord.X + 510 + curfont.MeasureString("bismuth-mod.fandom.com").X && Main.mouseY > bookcoord.Y + 104 + offset2.Y + 10 && Main.mouseY < bookcoord.Y + 104 + offset2.Y + 10 + curfont.MeasureString("bismuth-mod.fandom.com").Y)
                            {

                                Main.PlaySound(10);
                                Process.Start("https://bismuth-mod.fandom.com/ru/wiki/Bismuth_Mod_%D0%B2%D0%B8%D0%BA%D0%B8");
                            }
                        }
                        else
                        {
                            text3 = BismuthPlayer.StringBreak(curfont, Language.GetTextValue("Mods.Bismuth.WikiText", "terrariamods.gamepedia.com/Bismuth_Mod"), 380f);
                            offset3 = curfont.MeasureString(text3);
                            Utils.DrawBorderStringFourWay(sb, curfont, text3, bookcoord.X + 510, bookcoord.Y + 104 + offset2.Y + 10, Color.White, Color.Black, Vector2.Zero);
                            if (Main.mouseLeft && Main.mouseLeftRelease && Main.mouseX > bookcoord.X + 510 && Main.mouseX < bookcoord.X + 510 + curfont.MeasureString("terrariamods.gamepedia.com/Bismuth_Mod").X && Main.mouseY > bookcoord.Y + 104 + offset2.Y + 10 && Main.mouseY < bookcoord.Y + 104 + offset2.Y + 10 + curfont.MeasureString("terrariamods.gamepedia.com/Bismuth_Mod").Y)
                            {

                                Main.PlaySound(10);
                                Process.Start("https://terrariamods.gamepedia.com/Bismuth_Mod#");
                            }
                        }
                        string text4 = "";
                        Vector2 offset4 = Vector2.Zero;
                        if (Language.ActiveCulture == GameCulture.Russian)
                        {
                            text4 = BismuthPlayer.StringBreak(curfont, Language.GetTextValue("Mods.Bismuth.VkText", "vk.com/bismuthmod"), 380f);
                            offset4 = curfont.MeasureString(text4);
                            offset4.Y += 10;
                            Utils.DrawBorderStringFourWay(sb, curfont, text4, bookcoord.X + 510, bookcoord.Y + 104 + offset2.Y + 10 + offset3.Y + 10, Color.White, Color.Black, Vector2.Zero);
                            if (Main.mouseLeft && Main.mouseLeftRelease && Main.mouseX > bookcoord.X + 510 && Main.mouseX < bookcoord.X + 510 + curfont.MeasureString("vk.com/bismuthmod").X && Main.mouseY > bookcoord.Y + 104 + offset2.Y + 10 + offset3.Y + 10 && Main.mouseY < bookcoord.Y + 104 + offset2.Y + 10 + offset3.Y + 10 + curfont.MeasureString("vk.com/bismuthmod").Y)
                            {
                                Main.PlaySound(10);
                                Process.Start("https://vk.com/bismuthmod");
                            }
                        }
                        string text5 = BismuthPlayer.StringBreak(curfont, Language.GetTextValue("Mods.Bismuth.DiscordText", "discord.gg/tuwdbnh"), 380f);
                        Vector2 offset5 = curfont.MeasureString(text5);
                        Utils.DrawBorderStringFourWay(sb, curfont, text5, bookcoord.X + 510, bookcoord.Y + 104 + offset2.Y + 10 + offset3.Y + 10 + offset4.Y, Color.White, Color.Black, Vector2.Zero);
                            if (Main.mouseLeft && Main.mouseLeftRelease && Main.mouseX > bookcoord.X + 510 && Main.mouseX < bookcoord.X + 510 + curfont.MeasureString("discord.gg/tuwdbnh").X && Main.mouseY > bookcoord.Y + 104 + offset2.Y + 10 + offset3.Y + 10 + offset4.Y && Main.mouseY < bookcoord.Y + 104 + offset2.Y + 10 + offset3.Y + 10 + offset4.Y + curfont.MeasureString("discord.gg/tuwdbnh").Y)
                            {
                                Main.PlaySound(10);
                                Process.Start("https://discord.gg/tuwdbnh");
                            }

                        string text6 = BismuthPlayer.StringBreak(curfont, Language.GetTextValue("Mods.Bismuth.ForumsText", "forums.terraria.org/bismuth-mod"), 380f);
                        Vector2 offset6 = curfont.MeasureString(text6);
                        Utils.DrawBorderStringFourWay(sb, curfont, text6, bookcoord.X + 510, bookcoord.Y + 104 + offset2.Y + 10 + offset3.Y + 10 + offset4.Y + offset5.Y + 10, Color.White, Color.Black, Vector2.Zero);
                        if (Main.mouseLeft && Main.mouseLeftRelease && Main.mouseX > bookcoord.X + 510 && Main.mouseX < bookcoord.X + 510 + curfont.MeasureString("forums.terraria.org/bismuth-mod").X && Main.mouseY > bookcoord.Y + 104 + offset2.Y + 10 + offset3.Y + 10 + offset4.Y + offset5.Y + 10 && Main.mouseY < bookcoord.Y + 104 + offset2.Y + 10 + offset3.Y + 10 + offset4.Y + offset5.Y + 10 + curfont.MeasureString("forums.terraria.org/bismuth-mod").Y)
                        {
                            Main.PlaySound(10);
                            Process.Start("https://forums.terraria.org/index.php?threads/bismuth-mod-release.85081/#post-1859257");
                        }*/
                        sb.Draw(emptypatterntex, new Vector2(bookcoord.X + 510, bookcoord.Y + 14), Color.White);
                        sb.Draw(statstex, new Vector2(bookcoord.X + 526, bookcoord.Y + 20), Color.White);
                        sb.Draw(emptypatterntex, new Vector2(bookcoord.X + 610, bookcoord.Y + 14), Color.White);
                        sb.Draw(activeQtex, new Vector2(bookcoord.X + 631, bookcoord.Y + 18), Color.White);
                        sb.Draw(emptypatterntex, new Vector2(bookcoord.X + 710, bookcoord.Y + 14), Color.White);
                        sb.Draw(completedQtex, new Vector2(bookcoord.X + 722, bookcoord.Y + 18), Color.White);
                        if (Main.mouseX > bookcoord.X + 610 && Main.mouseX < bookcoord.X + 610 + emptypatterntex.Width && Main.mouseY > bookcoord.Y + 14 && Main.mouseY < bookcoord.Y + 14 + emptypatterntex.Height && Main.mouseLeft && Main.mouseLeftRelease)
                        {                            
                            currentpage = 2;
                            SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/BookPageFlip"));
                        }
                        if (Main.mouseX > bookcoord.X + 710 && Main.mouseX < bookcoord.X + 710 + emptypatterntex.Width && Main.mouseY > bookcoord.Y + 14 && Main.mouseY < bookcoord.Y + 14 + emptypatterntex.Height && Main.mouseLeft && Main.mouseLeftRelease)
                        {
                            currentpage = 3;
                            SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/BookPageFlip"));
                        }
                        if (Main.mouseX > bookcoord.X + 510 && Main.mouseX < bookcoord.X + 510 + emptypatterntex.Width && Main.mouseY > bookcoord.Y + 14 && Main.mouseY < bookcoord.Y + 14 + emptypatterntex.Height && Main.mouseLeft && Main.mouseLeftRelease)
                        {
                            currentpage = 4;
                            SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/BookPageFlip"));
                            return;
                        }
                    }
                    float size = Language.ActiveCulture.CultureInfo.Name == "ru-RU" ? 0.8f : 1.0f;

                    if (currentpage == 2)
                    {
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.ActiveQuests"), bookcoord.X + 240 - curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.ActiveQuests")).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                        #region questsdescription
                        if(selectedquest != 0 && selectedquest != -1)
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Stages"), bookcoord.X + 700 - curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Stages")).X / 2, bookcoord.Y + 60, Color.White, Color.Black, Vector2.Zero);
                        switch (selectedquest)
                        {
                            
                            case 1:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc1, bookcoord.X + 700 - curfont.MeasureString(desc1).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    if (EquipmentQuest == 20)
                                    {
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest1Stage1")).X * 0.9f, bookcoord.Y + 87), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest1Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    if (EquipmentQuest >= 30 && EquipmentQuest < 100)
                                    {
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest1Stage1")).X * 0.9f, bookcoord.Y + 88), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest1Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest1Stage2")).X * 0.9f, bookcoord.Y + 107), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest1Stage2"), bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }                                    
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary1", Main.npc[NPC.FindFirstNPC(Mod.Find<ModNPC>("ImperianConsul").Type)].GivenName), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 2:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc2, bookcoord.X + 700 - curfont.MeasureString(desc2).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest2Stage1")).X * 0.9f, bookcoord.Y + 87), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest2Stage1"), bookcoord.X + 518, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary2"), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 3:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc3, bookcoord.X + 700 - curfont.MeasureString(desc3).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc3, bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest3Stage1_1")).X * 0.9f, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest3Stage1_1")).X * 0.9f, bookcoord.Y + 87), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest3Stage1_1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.QuestOr"), bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest3Stage1_2")).X * 0.9f, bookcoord.Y + 127), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest3Stage1_2"), bookcoord.X + 516, bookcoord.Y + 130, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary3"), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 4:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc4, bookcoord.X + 700 - curfont.MeasureString(desc4).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    if (LuceatQuest == 20)
                                    {
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest4Stage1")).X * 0.9f, bookcoord.Y + 87), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest4Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary4"), 380f, size);
                                        Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    }
                                    if (LuceatQuest == 30 || LuceatQuest == 40 || LuceatQuest == 90)
                                    {
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest4Stage1")).X * 0.9f, bookcoord.Y + 88), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest4Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest4Stage2")).X * 0.9f, bookcoord.Y + 107), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest4Stage2"), bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary4_2"), 380f, size);
                                        Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    }
                                    break;
                                }
                            case 5:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc5, bookcoord.X + 700 - curfont.MeasureString(desc5).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    if (GlamdringQuest == 20)
                                    {
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest5Stage1")).X * 0.9f, bookcoord.Y + 87), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest5Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    if (GlamdringQuest == 30 || GlamdringQuest == 90)
                                    {
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest5Stage1")).X * 0.9f, bookcoord.Y + 88), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest5Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest5Stage2")).X * 0.9f, bookcoord.Y + 107), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest5Stage2"), bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary5", Main.npc[NPC.FindFirstNPC(Mod.Find<ModNPC>("DwarfBlacksmith").Type)].GivenName, Main.npc[NPC.FindFirstNPC(NPCID.GoblinTinkerer)].GivenName), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 6:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc6, bookcoord.X + 700 - curfont.MeasureString(desc6).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest6Stage1")).X * 0.9f, bookcoord.Y + 87), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest6Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary6", Main.npc[NPC.FindFirstNPC(Mod.Find<ModNPC>("DwarfBlacksmith").Type)].GivenName), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 7:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc7, bookcoord.X + 700 - curfont.MeasureString(desc7).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest7Stage1")).X * 0.9f, bookcoord.Y + 87), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest7Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary7", Main.npc[NPC.FindFirstNPC(Mod.Find<ModNPC>("DwarfBlacksmith").Type)].GivenName), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                } //!/
                            case 8:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc8, bookcoord.X + 700 - curfont.MeasureString(desc8).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest8Stage1_1")).X * 0.9f, bookcoord.Y + 87), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest8Stage1_1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.QuestOr"), bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest8Stage1_2")).X * 0.9f, bookcoord.Y + 127), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest8Stage1_2"), bookcoord.X + 516, bookcoord.Y + 130, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary8", Main.LocalPlayer.GetModPlayer<BismuthPlayer>().necrosname), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 9:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc9, bookcoord.X + 700 - curfont.MeasureString(desc9).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest9Stage1")).X * 0.9f, bookcoord.Y + 87), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest9Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary9", Main.LocalPlayer.GetModPlayer<BismuthPlayer>().oldmanname, Main.npc[NPC.FindFirstNPC(Mod.Find<ModNPC>("ImperianConsul").Type)].GivenName), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 10:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc10, bookcoord.X + 700 - curfont.MeasureString(desc10).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    if (PotionQuest == 20 || PotionQuest == 30)
                                    {
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest10Stage1")).X * 0.9f, bookcoord.Y + 87), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest10Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    if (PotionQuest == 40 || PotionQuest == 90)
                                    {
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest10Stage1")).X * 0.9f, bookcoord.Y + 88), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest10Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest10Stage2_1")).X * 0.9f, bookcoord.Y + 108), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest10Stage2_1"), bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest10Stage3")).X * 0.9f, bookcoord.Y + 127), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest10Stage3"), bookcoord.X + 516, bookcoord.Y + 130, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary10", Main.npc[NPC.FindFirstNPC(Mod.Find<ModNPC>("Alchemist").Type)].GivenName), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 11:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc11, bookcoord.X + 700 - curfont.MeasureString(desc11).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    if (PhilosopherStoneQuest == 20)
                                    {
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest11Stage1")).X * 0.9f, bookcoord.Y + 87), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest11Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    if (PhilosopherStoneQuest == 30 || PhilosopherStoneQuest == 90)
                                    {
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest11Stage1")).X * 0.9f, bookcoord.Y + 88), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest11Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest11Stage2")).X * 0.9f, bookcoord.Y + 107), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest11Stage2"), bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary11", Main.npc[NPC.FindFirstNPC(Mod.Find<ModNPC>("Alchemist").Type)].GivenName), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 12:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc12, bookcoord.X + 700 - curfont.MeasureString(desc12).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest12Stage1")).X * 0.9f, bookcoord.Y + 87), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest12Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary12", Main.npc[NPC.FindFirstNPC(Mod.Find<ModNPC>("Beggar").Type)].GivenName), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 13:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc13, bookcoord.X + 700 - curfont.MeasureString(desc13).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest13Stage1")).X * 0.9f, bookcoord.Y + 87), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest13Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary13", Main.npc[NPC.FindFirstNPC(Mod.Find<ModNPC>("Alchemist").Type)].GivenName), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 14:
                                {


                                    Utils.DrawBorderStringFourWay(sb, curfont, desc14, bookcoord.X + 700 - curfont.MeasureString(desc14).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    if (ReportQuest == 20)
                                    {
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest14Stage1")).X * 0.9f, bookcoord.Y + 87), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest14Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    if (ReportQuest == 30 || ReportQuest == 90)
                                    {
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest14Stage1")).X * 0.9f, bookcoord.Y + 87), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest14Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        sb.Draw(activetex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest14Stage2")).X * 0.9f, bookcoord.Y + 107), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest14Stage2"), bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary14", Main.npc[NPC.FindFirstNPC(Mod.Find<ModNPC>("ImperianCommander").Type)].GivenName), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            default:
                                break;

                        }
                        #endregion
                        #region active quest selection
                        if (!activequests.Contains(selectedquest))
                            selectedquest = 0;
                        if (activequests.Count > 0)
                        {

                            Utils.DrawBorderStringFourWay(sb, curfont, descs[0], bookcoord.X + 40, bookcoord.Y + 60, Color.White, Color.Black, Vector2.Zero);
                            Utils.DrawBorderStringFourWay(sb, curfont, shorts[0], bookcoord.X + 44, bookcoord.Y + 84, Color.White, Color.Black, Vector2.Zero, 0.85f);
                            if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 10 && Main.mouseY < bookcoord.Y + 104 && Main.mouseLeft && Main.mouseLeftRelease)
                            {
                                SoundEngine.PlaySound(SoundID.MenuOpen);
                                selectedquest = activequests[0];
                            }
                            sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 108), Color.White);
                        }
                        if (activequests.Count > 1)
                        {
                            Utils.DrawBorderStringFourWay(sb, curfont, descs[1], bookcoord.X + 40, bookcoord.Y + 126, Color.White, Color.Black, Vector2.Zero);
                            Utils.DrawBorderStringFourWay(sb, curfont, shorts[1], bookcoord.X + 44, bookcoord.Y + 150, Color.White, Color.Black, Vector2.Zero, 0.85f);
                            if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 122 && Main.mouseY < bookcoord.Y + 170 && Main.mouseLeft && Main.mouseLeftRelease)
                            {
                                SoundEngine.PlaySound(SoundID.MenuOpen);
                                selectedquest = activequests[1];
                            }
                            sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 172), Color.White);
                        }
                        if (activequests.Count > 2)
                        {
                            Utils.DrawBorderStringFourWay(sb, curfont, descs[2], bookcoord.X + 40, bookcoord.Y + 190, Color.White, Color.Black, Vector2.Zero);
                            Utils.DrawBorderStringFourWay(sb, curfont, shorts[2], bookcoord.X + 44, bookcoord.Y + 214, Color.White, Color.Black, Vector2.Zero, 0.85f);
                            if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 186 && Main.mouseY < bookcoord.Y + 234 && Main.mouseLeft && Main.mouseLeftRelease)
                            {
                                selectedquest = activequests[2];
                            }
                            sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 236), Color.White);
                        }
                        if (activequests.Count > 3)
                        {
                            Utils.DrawBorderStringFourWay(sb, curfont, descs[3], bookcoord.X + 40, bookcoord.Y + 254, Color.White, Color.Black, Vector2.Zero);
                            Utils.DrawBorderStringFourWay(sb, curfont, shorts[3], bookcoord.X + 44, bookcoord.Y + 278, Color.White, Color.Black, Vector2.Zero, 0.85f);
                            if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 250 && Main.mouseY < bookcoord.Y + 298 && Main.mouseLeft && Main.mouseLeftRelease)
                            {
                                selectedquest = activequests[3];
                            }
                            sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 300), Color.White);
                        }
                        if (activequests.Count > 4)
                        {
                            Utils.DrawBorderStringFourWay(sb, curfont, descs[4], bookcoord.X + 40, bookcoord.Y + 318, Color.White, Color.Black, Vector2.Zero);
                            Utils.DrawBorderStringFourWay(sb, curfont, shorts[4], bookcoord.X + 44, bookcoord.Y + 342, Color.White, Color.Black, Vector2.Zero, 0.85f);
                            if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 314 && Main.mouseY < bookcoord.Y + 362 && Main.mouseLeft && Main.mouseLeftRelease)
                            {
                                selectedquest = activequests[4];
                            }
                            sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 364), Color.White);
                        }
                        if (activequests.Count > 5)
                        {
                            Utils.DrawBorderStringFourWay(sb, curfont, descs[5], bookcoord.X + 40, bookcoord.Y + 382, Color.White, Color.Black, Vector2.Zero);
                            Utils.DrawBorderStringFourWay(sb, curfont, shorts[5], bookcoord.X + 44, bookcoord.Y + 406, Color.White, Color.Black, Vector2.Zero, 0.85f);
                            if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 378 && Main.mouseY < bookcoord.Y + 426 && Main.mouseLeft && Main.mouseLeftRelease)
                            {
                                selectedquest = activequests[5];
                            }
                            sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 428), Color.White);
                        }
                    }
                    #endregion
                    if (currentpage == 3)
                    {
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.CompletedQuests"), bookcoord.X + 240 - curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.CompletedQuests")).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                        if (selectedquest2 != 0 && selectedquest2 != -1)
                            Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Stages"), bookcoord.X + 700 - curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Stages")).X / 2, bookcoord.Y + 60, Color.White, Color.Black, Vector2.Zero);
                        if (completedquests.Count > 6 && completedpage != 3)
                        {
                            sb.Draw(arrowtex, new Vector2(bookcoord.X + emptypage.Width / 2 - 45, bookcoord.Y + emptypage.Height - 90), Color.White);
                            if (Main.mouseX > bookcoord.X + emptypage.Width / 2 - 45 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 45 + arrowtex.Width && Main.mouseY > bookcoord.Y + emptypage.Height - 90 && Main.mouseY < bookcoord.Y + emptypage.Height - 90 + arrowtex.Height && Main.mouseLeft && Main.mouseLeftRelease)
                            {
                                completedpage++;
                                SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/BookPageFlip"));
                            }
                        }
                        if (completedquests.Count > 6 && completedpage != 1)
                        {
                            sb.Draw(arrowtex, new Vector2(bookcoord.X + 30, bookcoord.Y + emptypage.Height - 90), new Rectangle(0, 0, arrowtex.Width, arrowtex.Height), Color.White, 0f, Vector2.Zero, 1f, SpriteEffects.FlipHorizontally, 0f);
                            if (Main.mouseX > bookcoord.X + 30 && Main.mouseX < bookcoord.X + 30 + arrowtex.Width && Main.mouseY > bookcoord.Y + emptypage.Height - 90 && Main.mouseY < bookcoord.Y + emptypage.Height - 90 + arrowtex.Height && Main.mouseLeft && Main.mouseLeftRelease)
                            {
                                completedpage--;
                                SoundEngine.PlaySound(new SoundStyle("Bismuth/Sounds/Custom/BookPageFlip"));
                            }
                        }
                        #region completedquestsdescription
                        switch (selectedquest2)
                        {
                            case 1:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc1, bookcoord.X + 700 - curfont.MeasureString(desc1).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest1Stage1")).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest1Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest1Stage2")).X * 0.9f, bookcoord.Y + 108), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest1Stage2"), bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    if (Player.GetModPlayer<BismuthPlayer>().NoRPGGameplay)
                                    {
                                        string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary1_2", Main.npc[NPC.FindFirstNPC(ModContent.NPCType<ImperianConsul>())].GivenName), 380f, size);
                                        Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    }
                                    else
                                    {
                                        string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary1", Main.npc[NPC.FindFirstNPC(ModContent.NPCType<ImperianConsul>())].GivenName), 380f, size);
                                        Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc2, bookcoord.X + 700 - curfont.MeasureString(desc2).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest2Stage1")).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest2Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary2_2"), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 3:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc3, bookcoord.X + 700 - curfont.MeasureString(desc3).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    if (ElessarQuest == 100)
                                    {
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest3Stage1_1")).X * 0.9f, bookcoord.Y + 88), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest3Stage1_1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    if (ElessarQuest == 200)
                                    {
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest3Stage1_2")).X * 0.9f, bookcoord.Y + 88), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest3Stage1_2"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary3"), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 4:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc4, bookcoord.X + 700 - curfont.MeasureString(desc4).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest4Stage1")).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest4Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest4Stage2")).X * 0.9f, bookcoord.Y + 108), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest4Stage2"), bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary4_2"), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 5:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc5, bookcoord.X + 700 - curfont.MeasureString(desc5).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest5Stage1")).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest5Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest5Stage2")).X * 0.9f, bookcoord.Y + 108), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest5Stage2"), bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary5", Main.npc[NPC.FindFirstNPC(ModContent.NPCType<DwarfBlacksmith>())].GivenName, Main.npc[NPC.FindFirstNPC(NPCID.GoblinTinkerer)].GivenName), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 6:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc6, bookcoord.X + 700 - curfont.MeasureString(desc6).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest6Stage1")).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest6Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary6", Main.npc[NPC.FindFirstNPC(ModContent.NPCType<DwarfBlacksmith>())].GivenName), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 7:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc7, bookcoord.X + 700 - curfont.MeasureString(desc7).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest7Stage1")).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest7Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary7", Main.npc[NPC.FindFirstNPC(ModContent.NPCType<DwarfBlacksmith>())].GivenName), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                } 
                            case 8:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc8, bookcoord.X + 700 - curfont.MeasureString(desc8).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    if (TombstoneQuest == 100)
                                    {
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest8Stage1_1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest8Stage1_1")).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    }
                                    if (TombstoneQuest == 300)
                                    {
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest8Stage1_3"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest8Stage1_3")).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    }
                                    if (TombstoneQuest == 200)
                                    {
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest8Stage1_2"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest8Stage1_2")).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    }
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary8", Main.LocalPlayer.GetModPlayer<BismuthPlayer>().necrosname), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 9:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc9, bookcoord.X + 700 - curfont.MeasureString(desc9).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest9Stage1")).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest9Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary9", Main.LocalPlayer.GetModPlayer<BismuthPlayer>().oldmanname, Main.npc[NPC.FindFirstNPC(ModContent.NPCType<ImperianConsul>())].GivenName), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 10:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc10, bookcoord.X + 700 - curfont.MeasureString(desc10).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest10Stage1")).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest10Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    if (PotionQuest == 100)
                                    {

                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest10Stage2_1")).X * 0.9f, bookcoord.Y + 108), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest10Stage2_1"), bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest10Stage3")).X * 0.9f, bookcoord.Y + 128), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest10Stage3"), bookcoord.X + 516, bookcoord.Y + 130, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    if (PotionQuest == 200)
                                    {
                                        sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest10Stage2_2")).X * 0.9f, bookcoord.Y + 107), Color.White);
                                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest10Stage2_2"), bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    }
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary10", Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Alchemist>())].GivenName), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 11:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc11, bookcoord.X + 700 - curfont.MeasureString(desc11).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest11Stage1")).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest11Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest11Stage2")).X * 0.9f, bookcoord.Y + 108), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest11Stage2"), bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary11", Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Alchemist>())].GivenName), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 12:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc12, bookcoord.X + 700 - curfont.MeasureString(desc12).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest12Stage1")).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest12Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary12", Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Beggar>())].GivenName), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 13:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc13, bookcoord.X + 700 - curfont.MeasureString(desc13).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest13Stage1")).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest13Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary13", Main.npc[NPC.FindFirstNPC(ModContent.NPCType<Alchemist>())].GivenName), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            case 14:
                                {
                                    Utils.DrawBorderStringFourWay(sb, curfont, desc14, bookcoord.X + 700 - curfont.MeasureString(desc14).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest14Stage1")).X * 0.9f, bookcoord.Y + 88), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest14Stage1"), bookcoord.X + 516, bookcoord.Y + 90, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    sb.Draw(completedtex, new Vector2(bookcoord.X + 520 + curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.Quest14Stage2")).X * 0.9f, bookcoord.Y + 108), Color.White);
                                    Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.Quest14Stage2"), bookcoord.X + 516, bookcoord.Y + 110, Color.White, Color.Black, Vector2.Zero, 0.9f);
                                    string diary = BismuthPlayer.StringBreak(FontAssets.MouseText.Value, Language.GetTextValue("Mods.Bismuth.QuestDiary14", Main.npc[NPC.FindFirstNPC(ModContent.NPCType<ImperianCommander>())].GivenName), 380f, size);
                                    Utils.DrawBorderStringFourWay(sb, FontAssets.MouseText.Value, diary, bookcoord.X + 510, bookcoord.Y + 210, Color.White, Color.Black, Vector2.Zero, size);
                                    break;
                                }
                            default:
                                break;

                        }
                        #endregion
                        #region completed quest selection
                        if (completedpage == 1)
                        {
                            if (completedquests.Count > 0)
                            {

                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[0], bookcoord.X + 40, bookcoord.Y + 60, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[0], bookcoord.X + 44, bookcoord.Y + 84, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 10 && Main.mouseY < bookcoord.Y + 104 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    SoundEngine.PlaySound(SoundID.MenuOpen);
                                    selectedquest2 = completedquests[0];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 108), Color.White);
                            }
                            if (completedquests.Count > 1)
                            {
                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[1], bookcoord.X + 40, bookcoord.Y + 126, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[1], bookcoord.X + 44, bookcoord.Y + 150, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 122 && Main.mouseY < bookcoord.Y + 170 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    SoundEngine.PlaySound(SoundID.MenuOpen);
                                    selectedquest2 = completedquests[1];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 172), Color.White);
                            }
                            if (completedquests.Count > 2)
                            {
                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[2], bookcoord.X + 40, bookcoord.Y + 190, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[2], bookcoord.X + 44, bookcoord.Y + 214, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 186 && Main.mouseY < bookcoord.Y + 234 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    selectedquest2 = completedquests[2];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 236), Color.White);
                            }
                            if (completedquests.Count > 3)
                            {
                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[3], bookcoord.X + 40, bookcoord.Y + 254, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[3], bookcoord.X + 44, bookcoord.Y + 278, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 250 && Main.mouseY < bookcoord.Y + 298 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    selectedquest2 = completedquests[3];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 300), Color.White);
                            }
                            if (completedquests.Count > 4)
                            {
                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[4], bookcoord.X + 40, bookcoord.Y + 318, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[4], bookcoord.X + 44, bookcoord.Y + 342, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 314 && Main.mouseY < bookcoord.Y + 362 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    selectedquest2 = completedquests[4];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 364), Color.White);
                            }
                            if (completedquests.Count > 5)
                            {
                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[5], bookcoord.X + 40, bookcoord.Y + 382, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[5], bookcoord.X + 44, bookcoord.Y + 406, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 378 && Main.mouseY < bookcoord.Y + 426 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    selectedquest2 = completedquests[5];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 428), Color.White);
                            }
                        }
                        if (completedpage == 2)
                        {
                            if (completedquests.Count > 6)
                            {

                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[6], bookcoord.X + 40, bookcoord.Y + 60, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[6], bookcoord.X + 44, bookcoord.Y + 84, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 10 && Main.mouseY < bookcoord.Y + 104 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    SoundEngine.PlaySound(SoundID.MenuOpen);
                                    selectedquest2 = completedquests[6];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 108), Color.White);
                            }
                            if (completedquests.Count > 7)
                            {
                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[7], bookcoord.X + 40, bookcoord.Y + 126, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[7], bookcoord.X + 44, bookcoord.Y + 150, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 122 && Main.mouseY < bookcoord.Y + 170 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    SoundEngine.PlaySound(SoundID.MenuOpen);
                                    selectedquest2 = completedquests[7];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 172), Color.White);
                            }
                            if (completedquests.Count > 8)
                            {
                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[8], bookcoord.X + 40, bookcoord.Y + 190, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[8], bookcoord.X + 44, bookcoord.Y + 214, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 186 && Main.mouseY < bookcoord.Y + 234 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    selectedquest2 = completedquests[8];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 236), Color.White);
                            }
                            if (completedquests.Count > 9)
                            {
                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[9], bookcoord.X + 40, bookcoord.Y + 254, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[9], bookcoord.X + 44, bookcoord.Y + 278, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 250 && Main.mouseY < bookcoord.Y + 298 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    selectedquest2 = completedquests[9];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 300), Color.White);
                            }
                            if (completedquests.Count > 10)
                            {
                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[10], bookcoord.X + 40, bookcoord.Y + 318, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[10], bookcoord.X + 44, bookcoord.Y + 342, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 314 && Main.mouseY < bookcoord.Y + 362 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    selectedquest2 = completedquests[10];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 364), Color.White);
                            }
                            if (completedquests.Count > 11)
                            {
                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[11], bookcoord.X + 40, bookcoord.Y + 382, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[11], bookcoord.X + 44, bookcoord.Y + 406, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 378 && Main.mouseY < bookcoord.Y + 426 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    selectedquest2 = completedquests[11];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 428), Color.White);
                            }
                        }
                        if (completedpage == 3)
                        {
                            if (completedquests.Count > 12)
                            {
                                Utils.DrawBorderStringFourWay(sb, curfont, descscompl[12], bookcoord.X + 40, bookcoord.Y + 382, Color.White, Color.Black, Vector2.Zero);
                                Utils.DrawBorderStringFourWay(sb, curfont, shortscompl[12], bookcoord.X + 44, bookcoord.Y + 406, Color.White, Color.Black, Vector2.Zero, 0.85f);
                                if (Main.mouseX > bookcoord.X + 15 && Main.mouseX < bookcoord.X + emptypage.Width / 2 - 15 && Main.mouseY > bookcoord.Y + 378 && Main.mouseY < bookcoord.Y + 426 && Main.mouseLeft && Main.mouseLeftRelease)
                                {
                                    selectedquest2 = completedquests[12];
                                }
                                sb.Draw(linetex, new Vector2(bookcoord.X + 58, bookcoord.Y + 108), Color.White);
                            }
                        }
                        #endregion
                    }
                    if (currentpage == 4)
                    {
                        
                        #region Stats
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.PlayerStat"), bookcoord.X + 240 - curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.PlayerStat")).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.HPStat", Player.statLifeMax2), bookcoord.X + 70, bookcoord.Y + 60, Color.White, Color.Black, Vector2.Zero, 0.82f);                                                
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.RegenStat", Player.lifeRegen / 2, Player.lifeRegen % 2 == 0 ? ".5" : ""), bookcoord.X + 70, bookcoord.Y + 80, Color.White, Color.Black, Vector2.Zero, 0.82f);                      
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.MPStat", Player.statManaMax2), bookcoord.X + 70, bookcoord.Y + 100, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.ManaCostStat", Player.manaCost * 100), bookcoord.X + 70, bookcoord.Y + 120, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.DefenceStat", Player.statDefense), bookcoord.X + 70, bookcoord.Y + 140, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.EnduranceStat", Player.endurance * 100), bookcoord.X + 70, bookcoord.Y + 160, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.BlockStat", Player.GetModPlayer<BismuthPlayer>().BlockChance + Player.GetModPlayer<BismuthPlayer>().BlockChanceForSkills), bookcoord.X + 70, bookcoord.Y + 180, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.DodgeStat", Player.GetModPlayer<BismuthPlayer>().DodgeChance + Player.GetModPlayer<BismuthPlayer>().DodgeChanceForSkills), bookcoord.X + 70, bookcoord.Y + 200, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.ParryStat", Player.GetModPlayer<BismuthPlayer>().ParryChance + Player.GetModPlayer<BismuthPlayer>().ParryChanceForSkills), bookcoord.X + 70, bookcoord.Y + 220, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.MSStat", Player.moveSpeed * 100), bookcoord.X + 70, bookcoord.Y + 240, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.MeleeDmgStat", Player.GetDamage(DamageClass.Melee) * 100), bookcoord.X + 70, bookcoord.Y + 260, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.MeleeCritStat", Player.GetCritChance(DamageClass.Melee)), bookcoord.X + 70, bookcoord.Y + 280, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.MeleeSpeedStat", (int)(((float)1 / Player.GetAttackSpeed(DamageClass.Melee)) * 100)), bookcoord.X + 70, bookcoord.Y + 300, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.MagicDmgStat", Player.GetDamage(DamageClass.Magic) * 100), bookcoord.X + 70, bookcoord.Y + 320, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.MagicCritStat", Player.GetCritChance(DamageClass.Magic)), bookcoord.X + 70, bookcoord.Y + 340, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.MinionDmgStat", Player.GetDamage(DamageClass.Summon) * 100), bookcoord.X + 70, bookcoord.Y + 360, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.MaxMinionStat", Player.maxMinions), bookcoord.X + 70, bookcoord.Y + 380, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.RangedDmgStat", Player.GetDamage(DamageClass.Ranged) * 100), bookcoord.X + 70, bookcoord.Y + 400, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.RangedCritStat", Player.GetCritChance(DamageClass.Ranged)), bookcoord.X + 70, bookcoord.Y + 420, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.ThrownDmgStat", Player.GetDamage(DamageClass.Throwing) * 100), bookcoord.X + 70, bookcoord.Y + 440, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.ThrownCritStat", Player.GetCritChance(DamageClass.Throwing)), bookcoord.X + 70, bookcoord.Y + 460, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.ThrownVelStat", Player.ThrownVelocity * 100), bookcoord.X + 70, bookcoord.Y + 480, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.AssassinDmgStat", Player.GetModPlayer<ModP>().assassinDamage * 100), bookcoord.X + 70, bookcoord.Y + 500, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.AssassinCritStat", Player.GetModPlayer<ModP>().assassinCrit), bookcoord.X + 70, bookcoord.Y + 520, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.CritDmgStat", (Player.GetModPlayer<BismuthPlayer>().critDmgMult + Player.GetModPlayer<BismuthPlayer>().critDmgMultForSkills) * 100), bookcoord.X + 70, bookcoord.Y + 540, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.CharmStat", Player.GetModPlayer<BismuthPlayer>().Charm), bookcoord.X + 70, bookcoord.Y + 560, Color.White, Color.Black, Vector2.Zero, 0.82f);
                        #endregion
                        Utils.DrawBorderStringFourWay(sb, curfont, Language.GetTextValue("Mods.Bismuth.SkillsTree"), bookcoord.X + 700 - curfont.MeasureString(Language.GetTextValue("Mods.Bismuth.SkillsTree")).X / 2, bookcoord.Y + 30, Color.White, Color.Black, Vector2.Zero);
                        if (Player.GetModPlayer<BismuthPlayer>().PlayerClass != 0)
                        {
                            if (treecoord.X > FrameStart.X)
                                treecoord.X = FrameStart.X;
                            if (treecoord.X + ActualPanel.Width < FrameStart.X + FrameWidth)
                                treecoord.X = FrameStart.X + FrameWidth - ActualPanel.Width;//
                            if (treecoord.Y > FrameStart.Y)
                                treecoord.Y = FrameStart.Y;
                            if (treecoord.Y + ActualPanel.Height < FrameStart.Y + FrameHeight)
                                treecoord.Y = FrameStart.Y + FrameHeight - ActualPanel.Height;
                            if (treeflag && Main.mouseLeft) // Лежит ли мышь в пределах рамки
                            {
                                int oldposX = Main.mouseX - Main.lastMouseX;
                                int oldposY = Main.mouseY - Main.lastMouseY;
                                if (treecoord.X <= FrameStart.X && treecoord.X + ActualPanel.Width >= FrameStart.X + FrameWidth && treecoord.Y <= FrameStart.Y && treecoord.Y + ActualPanel.Height >= FrameStart.Y + FrameHeight)
                                {
                                    treecoord.X += oldposX;
                                    treecoord.Y += oldposY;
                                }
                                if (treecoord.X > FrameStart.X)
                                    treecoord.X = FrameStart.X;
                                if (treecoord.X + ActualPanel.Width < FrameStart.X + FrameWidth)
                                    treecoord.X = FrameStart.X + FrameWidth - ActualPanel.Width;//
                                if (treecoord.Y > FrameStart.Y)
                                    treecoord.Y = FrameStart.Y;
                                if (treecoord.Y + ActualPanel.Height < FrameStart.Y + FrameHeight)
                                    treecoord.Y = FrameStart.Y + FrameHeight - ActualPanel.Height;

                            }
                            sb.Draw(ActualPanel, FrameStart, new Rectangle?(new Rectangle((int)(FrameStart.X - treecoord.X), (int)(FrameStart.Y - treecoord.Y), FrameWidth, FrameHeight)), Color.White);
                            if (Player.GetModPlayer<BismuthPlayer>().PlayerClass == 1)
                                Player.GetModPlayer<BismuthPlayer>().DrawWarriorTree(sb);
                            if (Player.GetModPlayer<BismuthPlayer>().PlayerClass == 2)
                                Player.GetModPlayer<BismuthPlayer>().DrawRangerTree(sb);
                            if (Player.GetModPlayer<BismuthPlayer>().PlayerClass == 3)
                                Player.GetModPlayer<BismuthPlayer>().DrawWizardTree(sb);
                            if (Player.GetModPlayer<BismuthPlayer>().PlayerClass == 4)
                                Player.GetModPlayer<BismuthPlayer>().DrawThrowerTree(sb);
                            if (Player.GetModPlayer<BismuthPlayer>().PlayerClass == 5)
                                Player.GetModPlayer<BismuthPlayer>().DrawAssassinTree(sb);
                        }
                        else
                        {
                            Utils.DrawBorderStringFourWay(sb, Bismuth.Adonais, "Use engraving to choose your class", bookcoord.X + 514, bookcoord.Y + 300, Color.White, Color.Black, Vector2.Zero, 1.1f);
                        }
                    }
                }
            }
            else
            {
                currentpage = 0;
                bookcoord = new Vector2(Main.screenWidth / 2 - 237, 200);
            }          
        }
    }
}
