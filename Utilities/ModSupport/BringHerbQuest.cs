using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Bismuth.Utilities.ModSupport
{
    public class BringHerbQuest : BaseQuest
    {
        public override string DisplayName => "sss";
        public override string DisplayDescription => "Bring me a Daybloom.";
        public override string UniqueKey => "BringHerbQuest";
        public override string NpcKey => "BabaYaga";
        public override int Priority => 10;

        public override string GetChat(NPC npc, Player player)
        {
            var q = player.GetModPlayer<QuestPlayer>();
            if (q.CompletedQuests.Contains(UniqueKey)) return "Спасибо ещё раз за траву!";      
            if (q.ActiveQuests.Contains(UniqueKey)) return "Ты уже выполняешь моё задание — принеси Daybloom!";  
            return "Принеси мне Daybloom!";
        }
        public override string GetButtonText(Player player)
        {
            var q = player.GetModPlayer<QuestPlayer>();
            if (q.CompletedQuests.Contains(UniqueKey)) return "";
            return "Принести";
        }
        public override void OnChatButtonClicked(Player player)
        {
            var q = player.GetModPlayer<QuestPlayer>();

            if (q.CompletedQuests.Contains(UniqueKey)) return;
               

            // проверка Daybloom
            for (int i = 0; i < player.inventory.Length; i++)
            {
                if (player.inventory[i].type == ItemID.Daybloom && player.inventory[i].stack > 0)
                {
                    player.inventory[i].stack--;
                    q.CompletedQuests.Add(UniqueKey);
                    Main.npcChatText = "Спасибо, квест завершён!";
                    Notification(player, true, false);
                    return;
                }
            }

            // если предмета нет — активируем квест
            if (!q.ActiveQuests.Contains(UniqueKey))
                q.ActiveQuests.Add(UniqueKey);

            Main.npcChatText = "У тебя пока нет Daybloom.";
        }
        public override bool IsAvailable(Player player)
        {
            var q = player.GetModPlayer<QuestPlayer>();
            return !q.CompletedQuests.Contains(UniqueKey);
        }

        public override bool IsActive(Player player)
        {
            var q = player.GetModPlayer<QuestPlayer>();
            return q.ActiveQuests.Contains(UniqueKey);
        }
    }
    public class QuestPlayer : ModPlayer
    {
        public HashSet<string> CompletedQuests = new();
        public HashSet<string> ActiveQuests = new();

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