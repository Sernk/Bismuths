using Terraria;

namespace Bismuth.Utilities.ModSupport
{
    public interface IQuest
    {
        string UniqueKey { get; }
        string NpcKey { get; } 
        int Priority { get; }
        string DisplayName { get; }
        string DisplayDescription { get; }
        string GetChat(NPC npc, Player player);
        string GetButtonText(Player player);
        void OnChatButtonClicked(Player player);
        bool IsAvailable(Player player);
        bool IsActive(Player player);
        void Notification(Player player, bool ISCompletedSuccessfully, bool ISQUESTACCEPTED);
    }
}
