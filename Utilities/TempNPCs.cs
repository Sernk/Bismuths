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
        }
        public override void NetSend(BinaryWriter writer)
        {
            writer.WriteFlags(AlchemistTemp, AlchemistTempStart, BabaYagaTemp, BabaYagaTempStart, WaitStoneQuestsTemp, WaitStoneQuestsTempStart, RecipePhilosopherStone, BueBegger);
        }
        public override void NetReceive(BinaryReader reader)
        {
            reader.ReadFlags(out AlchemistTemp, out AlchemistTempStart, out BabaYagaTemp, out BabaYagaTempStart, out WaitStoneQuestsTemp, out WaitStoneQuestsTempStart, out RecipePhilosopherStone, out BueBegger);
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
        }
        #endregion
    }
}