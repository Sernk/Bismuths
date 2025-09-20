using Microsoft.Xna.Framework.Graphics;
using Terraria;

namespace Bismuth.Utilities.ModSupport
{
    public enum QuestPhase
    {
        PreSkeletron, 
        PostOriginalAlchemist,
        PostOriginalBabaYaga,
        PostOriginalDwarfBlacksmith
    }
    public interface IQuest
    {
        string UniqueKey { get; }
        string NpcKey { get; } 
        int Priority { get; }
        string DisplayName { get; }
        string DisplayDescription { get; }
        string DisplayStage { get; }
        bool ISManyEndings { get; }
        int CornerItem { get; }
        QuestPhase Phase { get; }
        string GetChat(NPC npc, Player player, int Itemcorneritem);
        string GetButtonText(Player player);
        void OnChatButtonClicked(Player player);
        bool IsAvailable(Player player);
        void IsActiveQuestUIIcon(bool isAvailableQuest, bool isActiveQuest, SpriteBatch spriteBatch, NPC npc, Player player);
        bool IsActive(Player player);
        void Notification(Player player, bool ISCompletedSuccessfully, bool ISQUESTACCEPTED);
    }
}
