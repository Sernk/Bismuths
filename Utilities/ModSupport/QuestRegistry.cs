using System.Collections.Generic;
using System.Linq;
using Terraria;

namespace Bismuth.Utilities.ModSupport
{
    public static class QuestRegistry
    {
        private static readonly List<IQuest> quests = [];
        public static void Register(IQuest quest) => quests.Add(quest);
        public static IEnumerable<IQuest> GetAvailableQuests(Player player, string npcKey)
        {
            return quests .Where(q => q.NpcKey == npcKey && q.IsAvailable(player)) .OrderByDescending(q => q.Priority); 
        }
        public static IQuest? GetTopQuest(Player player, string npcKey)
        {
            return GetAvailableQuests(player, npcKey).FirstOrDefault();
        }
        public static IQuest? GetQuestByKey(string key)
        {
            return quests.FirstOrDefault(q => q.UniqueKey == key);
        }
    }
}
