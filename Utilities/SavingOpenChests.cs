using System.IO;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Bismuth.Utilities
{
    public class SavingOpenChests : ModSystem
    {
        public static bool HChest = false;
        public static bool OChest = false;
        public static bool RChest = false;
        public static bool GChest = false;
        public static bool BChest = false;
        public static bool MChest = false;

        public override void ClearWorld()
        {
            HChest = false;
            OChest = false;
            RChest = false;
            GChest = false;
            BChest = false;
            MChest = false;
        }
        public override void SaveWorldData(TagCompound tag)
        {
            if (HChest) tag["HChest"] = true;
            if (OChest) tag["OChest"] = true;
            if (RChest) tag["RChest"] = true;
            if (GChest) tag["GChest"] = true;
            if (BChest) tag["BChest"] = true;
            if (MChest) tag["MChest"] = true;
        }
        public override void NetSend(BinaryWriter writer)
        {
            writer.WriteFlags(HChest, OChest, RChest, GChest, BChest, MChest);
        }
        public override void NetReceive(BinaryReader reader)
        {
            reader.ReadFlags(out HChest, out OChest, out RChest, out GChest, out BChest, out MChest);
        }
        public override void LoadWorldData(TagCompound tag)
        {
            HChest = tag.ContainsKey("HChest");
            OChest = tag.ContainsKey("OChest");
            RChest = tag.ContainsKey("RChest");
            GChest = tag.ContainsKey("GChest");
            BChest = tag.ContainsKey("BChest");
            MChest = tag.ContainsKey("MChest");
        }
    }
}