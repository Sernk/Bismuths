using System.Collections.Generic;
using System.Linq;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Bismuth.Utilities.ModSupport
{
    public class QuestPlayer : ModPlayer
    {
        public HashSet<string> CompletedQuests = [];
        public HashSet<string> ActiveQuests = [];

        public override void SaveData(TagCompound tag)
        {
            tag["CompletedQuests"] = CompletedQuests.ToList();
            tag["ActiveQuests"] = ActiveQuests.ToList();
        }
        public override void LoadData(TagCompound tag)
        {
            CompletedQuests = [.. tag.GetList<string>("CompletedQuests")];
            ActiveQuests = [.. tag.GetList<string>("ActiveQuests")];
        }
    }
}