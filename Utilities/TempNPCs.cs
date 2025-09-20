using System.IO;
using Terraria;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Bismuth.Utilities
{
    public class TempNPCs : ModSystem
    {
        private const int Temp = 18000; // 5 минут = 300 сек * 60 тиков
        private const int Temp2 = 3600; // 1 минут = 60 сек  * 60 тиков
        private double LastTemp = 0;

        public static bool AlchemistTemp = false;
        public static bool AlchemistTempStart = false;
        public static bool WaitStoneQuestsTemp = false;
        public static bool WaitStoneQuestsTempStart = false;
        public static bool RecipePhilosopherStone = false;
        public static bool BabaYagaTemp = false;
        public static bool BabaYagaTempStart = false;
        public static bool BueBegger = false;
        public static bool AlchemistPreSkeletonNewQuest = true;
        public static bool AlchemistNewQuest = false;
        public static bool BeggarNewQuest = false;
        public static bool BabaYagaNewQuest = false;
        public static bool DwarfBlacksmithNewQuest = false;
        public static bool ImperianCommanderNewQuest = false;
        public static bool ImperianConsulNewQuest = false;

        public override void PostUpdateWorld()
        {
            if (AlchemistTempStart)
            {
                if (Main.GameUpdateCount - LastTemp >= Temp2)
                {
                    LastTemp = Main.GameUpdateCount;
                    AlchemistTemp = true;
                    AlchemistTempStart = false;
                }
            }
            if (WaitStoneQuestsTempStart)
            {
                if (Main.GameUpdateCount - LastTemp >= Temp)
                {
                    LastTemp = Main.GameUpdateCount;
                    WaitStoneQuestsTemp = true;
                    WaitStoneQuestsTempStart = false;
                }
            }
            if (BabaYagaTempStart)
            {
                if (Main.GameUpdateCount - LastTemp >= Temp)
                {
                    LastTemp = Main.GameUpdateCount;
                    BabaYagaTemp = true;
                    BabaYagaTempStart = false;
                }
            }
        }
        #region Save tag
        public override void ClearWorld()
        {
            AlchemistTemp = false;
            AlchemistTempStart = false;
            BabaYagaTemp = false;
            BabaYagaTempStart = false;
            WaitStoneQuestsTemp = false;
            WaitStoneQuestsTempStart = false;
            RecipePhilosopherStone = false;
            BueBegger = false;
            BabaYagaNewQuest = false;
            AlchemistNewQuest = false;
            AlchemistPreSkeletonNewQuest = true;
            BeggarNewQuest = false;
            DwarfBlacksmithNewQuest = false;
            ImperianCommanderNewQuest = false;
            ImperianConsulNewQuest = false;
        }
        public override void SaveWorldData(TagCompound tag)
        {
            if (AlchemistTemp) tag["AlchemistTemp"] = true;
            if (AlchemistTempStart) tag["AlchemistTempStart"] = true;
            if (BabaYagaTemp) tag["BabaYagaTemp"] = true;
            if (BabaYagaTempStart) tag["BabaYagaTempStart"] = true;
            if (WaitStoneQuestsTemp) tag["WaitStoneQuestsTemp"] = true;
            if (WaitStoneQuestsTempStart) tag["WaitStoneQuestsTempStart"] = true;
            if (RecipePhilosopherStone) tag["RecipePhilosopherStone"] = true;
            if (BueBegger) tag["BueBegger"] = true;
            if (BabaYagaNewQuest) tag["BabaYagaNewQuest"] = true;
            if (AlchemistNewQuest) tag["AlchemistNewQuest"] = true;
            if (AlchemistPreSkeletonNewQuest) tag["AlchemistPreSkeletonNewQuest"] = true;
            if (BeggarNewQuest) tag["BeggarNewQuest"] = true;
            if (DwarfBlacksmithNewQuest) tag["DwarfBlacksmithNewQuest"] = true;
            if (ImperianCommanderNewQuest) tag["ImperianCommanderNewQuest"] = true;
            if(ImperianConsulNewQuest) tag["ImperianConsulNewQuest"] = true;
        }
        public override void NetSend(BinaryWriter writer)
        {
            writer.WriteFlags(AlchemistTemp, AlchemistTempStart, BabaYagaTemp, BabaYagaTempStart, WaitStoneQuestsTemp, WaitStoneQuestsTempStart, RecipePhilosopherStone, BueBegger);
            writer.Write(BabaYagaNewQuest);
        }
        public override void NetReceive(BinaryReader reader)
        {
            reader.ReadFlags(out AlchemistTemp, out AlchemistTempStart, out BabaYagaTemp, out BabaYagaTempStart, out WaitStoneQuestsTemp, out WaitStoneQuestsTempStart, out RecipePhilosopherStone, out BueBegger);
            BabaYagaNewQuest = reader.ReadBoolean();
        }
        public override void LoadWorldData(TagCompound tag)
        {
            AlchemistTemp = tag.ContainsKey("AlchemistTemp");
            AlchemistTempStart = tag.ContainsKey("AlchemistTempStart");
            BabaYagaTemp = tag.ContainsKey("BabaYagaTemp");
            BabaYagaTempStart = tag.ContainsKey("BabaYagaTempStart");
            WaitStoneQuestsTemp = tag.ContainsKey("WaitStoneQuestsTemp");
            WaitStoneQuestsTempStart = tag.ContainsKey("WaitStoneQuestsTempStart");
            RecipePhilosopherStone = tag.ContainsKey("RecipePhilosopherStone");
            BueBegger = tag.ContainsKey("BueBegger");
            BabaYagaNewQuest = tag.ContainsKey("BabaYagaNewQuest");
            AlchemistNewQuest = tag.ContainsKey("AlchemistNewQuest");
            AlchemistPreSkeletonNewQuest = tag.ContainsKey("AlchemistPreSkeletonNewQuest");
            BeggarNewQuest = tag.ContainsKey("BeggarNewQuest");
            DwarfBlacksmithNewQuest = tag.ContainsKey("DwarfBlacksmithNewQuest");
            ImperianCommanderNewQuest = tag.ContainsKey("ImperianCommanderNewQuest");
            ImperianConsulNewQuest = tag.ContainsKey("ImperianConsulNewQuest");
        }
        #endregion
    }
}