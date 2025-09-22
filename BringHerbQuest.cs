using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace Bismuth.Utilities.ModSupport
{
    public class PreSkeletronHerbQuest : BaseQuest
    {
        public int progress = 0; // 0 - not started, 1 - available, 2 - active
        public override string DisplayName => "Gather Herbs"; // Название в книге 
        public override string DisplayDescription => "Bring me 5 Dayblooms before defeating Skeletron."; // Описание в книге
        public override string DisplayStage => "Daybloom Collection"; // Этап в книге
        public override string UniqueKey => "PreSkeletronHerbQuest"; // Можешь не указывать, но лучше указывать уникальный ключ
        public override string NpcKey => DwarfBlacksmith; // Ключ NPC, который дает квест
        public override int Priority => 10; // Приоритет квеста (чем выше, тем выше в списке)
        public override bool ISManyEndings => false; // Если у квеста несколько стадией
        public override QuestPhase Phase => QuestPhase.PreSkeletron; // Для алхимика
        public override int CornerItem => ItemID.SailorShirt; // Иконка в углу чата
        public override string GetChat(NPC npc, Player player, int corneritem) // Текст в чате
        {
            corneritem = CornerItem;
            Main.npcChatCornerItem = corneritem;
            var q = player.GetModPlayer<QuestPlayer>();
            if (q.CompletedQuests.Contains(UniqueKey))
            {
                progress = 0; // Сброс прогресса после завершения
                return "Thanks for the Dayblooms!"; // Текст после завершения квеста
            }
            if (q.ActiveQuests.Contains(UniqueKey))
            {
                progress = 2; // Квест активен
                return "Have you gathered the 5 Dayblooms yet?"; // Текст, когда квест активен
            }
            progress = 1; // Квест доступен
            return "Please bring me 5 Dayblooms before you defeat Skeletron."; // Текст, когда квест доступен
        }
        public override string GetButtonText(Player player) // Текст на кнопке
        {
            var q = player.GetModPlayer<QuestPlayer>();
            if (q.CompletedQuests.Contains(UniqueKey)) return ""; // Если квест завершен, кнопка не показывается
            return "Accept";
        }
        public override bool IsCompleted(Player player)
        {
            var q = player.GetModPlayer<QuestPlayer>();
            return q.CompletedQuests.Contains(UniqueKey);
        }
        public override void OnChatButtonClicked(Player player) // Что происходит при нажатии на кнопку
        {
            Notification(player, false, true);
            var q = player.GetModPlayer<QuestPlayer>();

            if (q.CompletedQuests.Contains(UniqueKey)) return;

            for (int i = 0; i < player.inventory.Length; i++) // Проверка инвентаря игрока на наличие 5 Dayblooms
            {
                if (player.inventory[i].type == ItemID.Daybloom && player.inventory[i].stack >= 5)
                {
                    player.inventory[i].stack -= 5;
                    q.CompletedQuests.Add(UniqueKey);
                    Main.npcChatText = "Quest completed! Thanks for the Dayblooms!"; // Текст после завершения квеста
                    Notification(player, true, false); // Уведомление о завершении квеста
                    progress = 0;
                    return;
                }
            }
            if (!q.ActiveQuests.Contains(UniqueKey))
            {
                q.ActiveQuests.Add(UniqueKey);
                progress = 2;
            }

            Main.npcChatText = "You don't have 5 Dayblooms yet."; // Текст, если у игрока нет 5 Dayblooms
        }

        public override bool IsAvailable(Player player) // Проверка доступности квеста
        {
            var q = player.GetModPlayer<QuestPlayer>();
            bool isAvailable = !q.CompletedQuests.Contains(UniqueKey);
            if (isAvailable)
                progress = 1;
            else
                progress = 0;
            return isAvailable;
        }

        public override bool IsActive(Player player) // Проверка активности квеста
        {
            var q = player.GetModPlayer<QuestPlayer>();
            bool isActive = q.ActiveQuests.Contains(UniqueKey);
            if (isActive)
                progress = 2;
            return isActive;
        }

        public override void IsActiveQuestUIIcon(bool isAvailableQuest, bool isActiveQuest, SpriteBatch spriteBatch, NPC npc, Player player) // Иконка над головой NPC
        {
            isAvailableQuest = progress == 1;
            isActiveQuest = progress == 2;
            base.IsActiveQuestUIIcon(isAvailableQuest, isActiveQuest, spriteBatch, npc, player);
        }
    }
    public class QuestPlayer : ModPlayer // Класс для хранения данных о квестах игрока
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
        // И обезательно
        // public override void Load()
        //{
        // QuestRegistry.Register(new PreSkeletronHerbQuest());
        //}
    }
}